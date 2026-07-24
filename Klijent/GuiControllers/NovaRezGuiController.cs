using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class NovaRezGuiController
    {
        private static NovaRezGuiController instance;
        public static NovaRezGuiController Instance
        {
            get
            {
                if (instance == null) instance = new NovaRezGuiController();
                return instance;
            }
        }
        private NovaRezGuiController() { }

        private bool sacuvano = false;
        private UCNovaRez ucNovaRez;
        private List<DateTime> slobodniTermini = new List<DateTime>();
        private Rezervacija novaRezervacija;
        private BindingList<StavkaRezervacije> stavke = new BindingList<StavkaRezervacije>();

        public Control CreateUC()
        {
            ucNovaRez = new UCNovaRez();

            SrediFormu();
            StilTabele.Primeni(ucNovaRez.dgvStavke);

            ucNovaRez.btnRezervisi.Click += BtnRezervisi_Click;
            ucNovaRez.btnDodajStavku.Click += BtnDodajStavku_Click;
            ucNovaRez.dtpDatum.ValueChanged += DtpDatum_ValueChanged;
            ucNovaRez.cmbUsluga.SelectedIndexChanged += CmbUsluga_SelectedIndexChanged;
            
             ucNovaRez.btnObrisiStavku.Click += BtnObrisiStavku_Click;

            ucNovaRez.dgvStavke.AutoGenerateColumns = false;
            ucNovaRez.dgvStavke.DataSource = stavke;

            return ucNovaRez;
        }

        private void SrediFormu()
        {
            try
            {
                Odgovor odgKreiraj = Komunikacija.Instance.PosaljiZahtev(Operacija.KreirajRezervaciju);
                if (!odgKreiraj.Uspesno)
                {
                    MessageBox.Show("Sistem ne može da kreira rezervaciju.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                novaRezervacija = Komunikacija.Instance.Serializer.ReadType<Rezervacija>(odgKreiraj.Objekat);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sistem ne može da kreira rezervaciju: {ex.Message}",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sacuvano = false;

            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
            {
                ucNovaRez.lblIzbor.Text = "Korisnik:";
                UcitajKorisnike();
            }
            else
            {
                ucNovaRez.lblIzbor.Text = "Radnik:";
                UcitajRadnike();
            }

            UcitajUsluge();

            ucNovaRez.dtpDatum.MinDate = DateTime.Today;
            ucNovaRez.dtpDatum.Value = DateTime.Today;
            UcitajSlobodneTermine(DateTime.Today);

            OsveziUkupno();
        }

        private void UcitajUsluge()
        {
            Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveUsluge);
            if (!odgovor.Uspesno)
            {
                MessageBox.Show("Sistem ne može da učita listu usluga.", "Greška", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Usluga> sve = Komunikacija.Instance.Serializer.ReadType<List<Usluga>>(odgovor.Objekat);
            ucNovaRez.cmbUsluga.DataSource = sve;
            ucNovaRez.cmbUsluga.DisplayMember = "Naziv";
            ucNovaRez.cmbUsluga.ValueMember = "IdUsluga";
        }

        private void CmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucNovaRez.cmbUsluga.SelectedItem is Usluga u)
                ucNovaRez.lblCena.Text = $"{u.Cena:N2} RSD";
        }

        private void BtnDodajStavku_Click(object sender, EventArgs e)
        {
            if (ucNovaRez.cmbUsluga.SelectedItem is not Usluga usluga)
            {
                MessageBox.Show("Izaberite uslugu.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stavke.Any(s => s.Usluga?.IdUsluga == usluga.IdUsluga))
            {
                MessageBox.Show($"{usluga.Naziv} usluga je već dodata!", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string registracija = ucNovaRez.txtRegistracija.Text.Trim();
            if (string.IsNullOrWhiteSpace(registracija))
            {
                MessageBox.Show("Unesite registraciju vozila.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            stavke.Add(new StavkaRezervacije
            {
                Usluga = usluga,
                Cena = usluga.Cena
            });

            OsveziUkupno();
        }

        private void BtnObrisiStavku_Click(object sender, EventArgs e)
        {
            if (ucNovaRez.dgvStavke.CurrentRow?.DataBoundItem is StavkaRezervacije s)
            {
                stavke.Remove(s);
                OsveziUkupno();
            }
        }

        private void OsveziUkupno()
        {
            double ukupno = stavke.Sum(s => s.Cena);
            ucNovaRez.lblUkupno.Text = $"Ukupno: {ukupno:N2} RSD";
        }

        private void BtnRezervisi_Click(object sender, EventArgs e)
        {
            if (ucNovaRez.cmbIzbor.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati stavku iz liste.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ucNovaRez.cmbTermin.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati termin.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string registracija = ucNovaRez.txtRegistracija.Text.Trim();
            if (string.IsNullOrWhiteSpace(registracija))
            {
                MessageBox.Show("Unesite registraciju vozila.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stavke.Count == 0)
            {
                MessageBox.Show("Dodajte bar jednu stavku (uslugu).", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Radnik radnik;
                Korisnik korisnik;

                if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
                {
                    radnik = MainCoordinator.Instanca.PrijavljeniRadnik;
                    korisnik = (Korisnik)ucNovaRez.cmbIzbor.SelectedItem;
                }
                else
                {
                    radnik = (Radnik)ucNovaRez.cmbIzbor.SelectedItem;
                    korisnik = MainCoordinator.Instanca.PrijavljeniKorisnik;
                }

                if (novaRezervacija == null)
                {
                    MessageBox.Show("Rezervacija nije inicijalizovana.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                novaRezervacija.Termin = (DateTime)ucNovaRez.cmbTermin.SelectedItem;
                novaRezervacija.Radnik = radnik;
                novaRezervacija.Korisnik = korisnik;
                novaRezervacija.Registracija = registracija;
                novaRezervacija.Stavke = stavke.ToList();

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.UbaciRezervaciju, novaRezervacija);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Rezervacija je uspešno kreirana!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                sacuvano = true;   
                

                if (MainCoordinator.Instanca.PrijavljeniKorisnik != null)
                    MainCoordinator.Instanca.ShowMojeRezervacije(null, EventArgs.Empty);  
                else
                    MainCoordinator.Instanca.ShowSveRezervacije(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool MozeNapustiti()
        {

            if (novaRezervacija == null || sacuvano)
                return true;   

            var odgovor = MessageBox.Show(
                "Imate nedovršenu rezervaciju. Da li ste sigurni da želite da prekinete unos?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (odgovor != DialogResult.Yes)
                return false;  

            try { Komunikacija.Instance.PosaljiZahtev(Operacija.ObrisiRezervaciju, novaRezervacija); }
            catch {  }

            novaRezervacija = null;
            return true;
        }

        public void ObrisiNesacuvanu()
        {
            if (novaRezervacija != null && !sacuvano)
            {
                try { Komunikacija.Instance.PosaljiZahtev(Operacija.ObrisiRezervaciju, novaRezervacija); }
                catch { }
                novaRezervacija = null;
            }
        }
        private void UcitajSlobodneTermine(DateTime datum)
        {
            try
            {
                int? idPerionica = OdrediIdPerionica();
                if (idPerionica == null)
                {
                    ucNovaRez.cmbTermin.DataSource = null;
                    return;
                }

                RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
                {
                    Datum = datum,
                    IdPerionica = idPerionica
                };

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiZauzeteTermine, kriterijum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<DateTime> zauzeti = Komunikacija.Instance.Serializer.ReadType<List<DateTime>>(odgovor.Objekat);
                
                List<DateTime> sviTermini = new List<DateTime>();
                for (int sat = 8; sat < 19; sat++)
                {
                    DateTime t = datum.Date.AddHours(sat);
                    if(t > DateTime.Now) sviTermini.Add(t);
                }

                slobodniTermini = sviTermini.Where(t => !zauzeti.Any(z => z.Hour == t.Hour)).ToList();
                
                ucNovaRez.cmbTermin.DataSource = null;
                ucNovaRez.cmbTermin.DataSource = slobodniTermini;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? OdrediIdPerionica()
        {

            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
                return MainCoordinator.Instanca.PrijavljenaRadnikPerionica.IdPerionica;
            
           
            if (ucNovaRez.cmbIzbor.SelectedItem is Radnik radnik && radnik.Perionica != null)
                return radnik.Perionica.IdPerionica;

            return null;
        }

        private void UcitajKorisnike()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveKorisnike);
                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Korisnik> lista = Komunikacija.Instance.Serializer.ReadType<List<Korisnik>>(odgovor.Objekat);
                ucNovaRez.cmbIzbor.DataSource = lista;
                ucNovaRez.cmbIzbor.DisplayMember = "ImePrezime";
                ucNovaRez.cmbIzbor.ValueMember = "IdKorisnik";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajRadnike()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveRadnike);
                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Radnik> lista = Komunikacija.Instance.Serializer.ReadType<List<Radnik>>(odgovor.Objekat);
                ucNovaRez.cmbIzbor.DataSource = lista;
                ucNovaRez.cmbIzbor.DisplayMember = "ImePrezimePerionica";
                ucNovaRez.cmbIzbor.ValueMember = "IdRadnik";
                ucNovaRez.cmbIzbor.SelectedIndexChanged += (s, e) => UcitajSlobodneTermine(ucNovaRez.dtpDatum.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtpDatum_ValueChanged(object sender, EventArgs e)
        {
            UcitajSlobodneTermine(ucNovaRez.dtpDatum.Value);
        }
    }
}