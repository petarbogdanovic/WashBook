using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class NovaRezGuiController
    {
        // Singleton
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

        private UCNovaRez ucNovaRez;
        private List<DateTime> slobodniTermini = new List<DateTime>();
        private Rezervacija novaRezervacija;

        public Control CreateUC()
        {
            ucNovaRez = new UCNovaRez();
           
            SrediFormu();

            // Vezivanje event handlera
            ucNovaRez.btnSacuvaj.Click += BtnSacuvaj_Click;
            ucNovaRez.dtpDatum.ValueChanged += DtpDatum_ValueChanged;
            ucNovaRez.cmbTipVozila.SelectedIndexChanged += CmbTipVozila_SelectedIndexChanged;
            ucNovaRez.cmbUsluga.SelectedIndexChanged += CmbUsluga_SelectedIndexChanged;

            return ucNovaRez;
        }

     
        private void SrediFormu()
        {
            
            try
            {
                Odgovor odgKreiraj = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.KreirajRezervaciju);

                if (odgKreiraj.Uspesno)
                {
                    novaRezervacija = Komunikacija.Instance
                        .Serializer.ReadType<Rezervacija>(odgKreiraj.Objekat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sistem ne može da kreira rezervaciju: {ex.Message}",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            UcitajTipoveVozila();

            ucNovaRez.dtpDatum.MinDate = DateTime.Today;
            ucNovaRez.dtpDatum.Value = DateTime.Today;
            UcitajSlobodneTermine(DateTime.Today);
        }

        private void BtnSacuvaj_Click(object sender, EventArgs e)
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
            if (ucNovaRez.cmbTipVozila.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati tip vozila.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ucNovaRez.cmbUsluga.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati uslugu.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ucNovaRez.txtRegistracija.Text))
            {
                MessageBox.Show("Morate uneti registraciju vozila.", "Upozorenje",
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

                Usluga izabranaUsluga = (Usluga)ucNovaRez.cmbUsluga.SelectedItem;
                TipVozila izabranTip = (TipVozila)ucNovaRez.cmbTipVozila.SelectedItem;

                StavkaRezervacije stavka = new StavkaRezervacije
                {
                    RbStavka = 1,
                    Usluga = izabranaUsluga,
                    SStavke = new List<SStavkaRezervacije>
                    {
                        new SStavkaRezervacije
                        {
                            RbSStavka = 1,
                            TipVozila = izabranTip,
                            Registracija = ucNovaRez.txtRegistracija.Text.Trim(),
                            Cena = izabranaUsluga.Cena
                        }
                    }
                };
                novaRezervacija.Stavke.Add(stavka);

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

                // Resetuj formu
                ucNovaRez.dtpDatum.Value = DateTime.Today;
                UcitajSlobodneTermine(DateTime.Today);
                ucNovaRez.txtRegistracija.Clear();
                if (ucNovaRez.cmbIzbor.Items.Count > 0) ucNovaRez.cmbIzbor.SelectedIndex = 0;
                if (ucNovaRez.cmbTipVozila.Items.Count > 0) ucNovaRez.cmbTipVozila.SelectedIndex = 0;

                // Pripremi novu praznu rezervaciju
                try
                {
                    Odgovor odgKreiraj = Komunikacija.Instance.PosaljiZahtev(
                        Operacija.KreirajRezervaciju);
                    if (odgKreiraj.Uspesno)
                        novaRezervacija = Komunikacija.Instance
                            .Serializer.ReadType<Rezervacija>(odgKreiraj.Objekat);
                    else
                        novaRezervacija = null;
                }
                catch
                {
                    novaRezervacija = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajSlobodneTermine(DateTime datum)
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiZauzeteTermine, datum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<DateTime> zauzeti = Komunikacija.Instance
                    .Serializer.ReadType<List<DateTime>>(odgovor.Objekat);

                List<DateTime> sviTermini = new List<DateTime>();
                for (int sat = 8; sat <= 19; sat++)
                {
                    DateTime t = datum.Date.AddHours(sat);
                    if (t > DateTime.Now)
                        sviTermini.Add(t);
                }

                slobodniTermini = sviTermini
                    .Where(t => !zauzeti.Any(z => z.Hour == t.Hour))
                    .ToList();

                ucNovaRez.cmbTermin.DataSource = null;
                ucNovaRez.cmbTermin.DataSource = slobodniTermini;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajTipoveVozila()
        {
            Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveTipoveVozila);
            if (!odgovor.Uspesno) return;
            List<TipVozila> lista = Komunikacija.Instance.Serializer
                .ReadType<List<TipVozila>>(odgovor.Objekat);
            ucNovaRez.cmbTipVozila.DataSource = lista;
            ucNovaRez.cmbTipVozila.DisplayMember = "Naziv";
            ucNovaRez.cmbTipVozila.ValueMember = "IdTipVozila";
        }

        private void UcitajKorisnike()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiSveKorisnike);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Korisnik> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Korisnik>>(odgovor.Objekat);

                ucNovaRez.cmbIzbor.DataSource = lista;
                ucNovaRez.cmbIzbor.DisplayMember = "ImePrezime";
                ucNovaRez.cmbIzbor.ValueMember = "IdKorisnik";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajRadnike()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiSveRadnike);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Radnik> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Radnik>>(odgovor.Objekat);

                ucNovaRez.cmbIzbor.DataSource = lista;
                ucNovaRez.cmbIzbor.DisplayMember = "ImePrezime";
                ucNovaRez.cmbIzbor.ValueMember = "IdRadnik";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtpDatum_ValueChanged(object sender, EventArgs e)
        {
            UcitajSlobodneTermine(ucNovaRez.dtpDatum.Value);
        }

        private void CmbTipVozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ucNovaRez.cmbTipVozila.SelectedItem == null) return;
                TipVozila izabrani = (TipVozila)ucNovaRez.cmbTipVozila.SelectedItem;

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveUsluge);
                if (!odgovor.Uspesno) return;

                List<Usluga> sve = Komunikacija.Instance.Serializer
                    .ReadType<List<Usluga>>(odgovor.Objekat);
                List<Usluga> filtrirane = sve
                    .Where(u => u.TipVozila?.IdTipVozila == izabrani.IdTipVozila).ToList();

                ucNovaRez.cmbUsluga.DataSource = filtrirane;
                ucNovaRez.cmbUsluga.DisplayMember = "Naziv";
                ucNovaRez.cmbUsluga.ValueMember = "IdUsluga";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucNovaRez.cmbUsluga.SelectedItem is Usluga u)
                ucNovaRez.lblCena.Text = $"{u.Cena:N2} RSD";
        }
    }
}