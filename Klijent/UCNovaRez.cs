using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Klijent
{
    public partial class UCNovaRez : UserControl
    {
        private List<DateTime> slobodniTermini = new List<DateTime>();
        private Rezervacija novaRezervacija;

        public UCNovaRez()
        {
            InitializeComponent();
            StilizujKontrole();

        }

        private void StilizujKontrole()
        {
            pnlHeader.BackColor = Color.White;
            pnlHeader.Padding = new Padding(20, 0, 20, 0);

            lblNaslov.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(30, 42, 58);
            lblNaslov.TextAlign = ContentAlignment.MiddleLeft;

            Font labelFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Color labelColor = Color.FromArgb(80, 100, 120);
            foreach (Control c in pnlForma.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Font = labelFont;
                    lbl.ForeColor = labelColor;
                }
            }

            cmbIzbor.Font = new Font("Segoe UI", 10);
            cmbIzbor.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpDatum.Font = new Font("Segoe UI", 10);

            cmbTermin.Font = new Font("Segoe UI", 10);
            cmbTermin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTermin.Format += (s, e) =>
            {
                if (e.Value is DateTime dt)
                    e.Value = dt.ToString("HH:mm");
            };

            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSacuvaj.Height = 44;
            btnSacuvaj.Width = 160;
            btnSacuvaj.Cursor = Cursors.Hand;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbIzbor.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati stavku iz liste.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTermin.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati termin.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTipVozila.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati tip vozila.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUsluga.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati uslugu.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRegistracija.Text))
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
                    korisnik = (Korisnik)cmbIzbor.SelectedItem;
                }
                else
                {
                    radnik = (Radnik)cmbIzbor.SelectedItem;
                    korisnik = MainCoordinator.Instanca.PrijavljeniKorisnik;
                }

                if (novaRezervacija == null)
                {
                    MessageBox.Show("Rezervacija nije inicijalizovana.", "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                novaRezervacija.Termin = (DateTime)cmbTermin.SelectedItem;
                novaRezervacija.Radnik = radnik;
                novaRezervacija.Korisnik = korisnik;

                Usluga izabranaUsluga = (Usluga)cmbUsluga.SelectedItem;
                TipVozila izabranTip = (TipVozila)cmbTipVozila.SelectedItem;

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
                        Registracija = txtRegistracija.Text.Trim(),
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
                dtpDatum.Value = DateTime.Today;
                UcitajSlobodneTermine(DateTime.Today);
                txtRegistracija.Clear();
                if (cmbIzbor.Items.Count > 0) cmbIzbor.SelectedIndex = 0;
                if (cmbTipVozila.Items.Count > 0) cmbTipVozila.SelectedIndex = 0;

                try
                {
                    Odgovor odgKreiraj = Komunikacija.Instance.PosaljiZahtev(
                        Operacija.KreirajRezervaciju);
                    if (odgKreiraj.Uspesno)
                        novaRezervacija = Komunikacija.Instance
                            .Serializer.ReadType<Rezervacija>(odgKreiraj.Objekat);
                }
                catch { novaRezervacija = null;  }
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

                // Generiši sve termine od 08:00 do 19:00
                List<DateTime> sviTermini = new List<DateTime>();
                for (int sat = 8; sat <= 19; sat++) { 
                    DateTime t = datum.Date.AddHours(sat);

                    //Uslov da su termini u budućnosti, jer ne možemo rezervisati termin koji je već prošao
                    if (t > DateTime.Now)
                        sviTermini.Add(t);

                }
                // Slobodni = svi - zauzeti
                slobodniTermini = sviTermini
                    .Where(t => !zauzeti.Any(z => z.Hour == t.Hour))
                    .ToList();

                cmbTermin.DataSource = null;
                cmbTermin.DataSource = slobodniTermini;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            try
            {
                Odgovor odgKreiraj = Komunikacija.Instance.PosaljiZahtev(Operacija.KreirajRezervaciju);
                if (odgKreiraj.Uspesno)
                {
                    novaRezervacija = Komunikacija.Instance.Serializer.ReadType<Rezervacija>(odgKreiraj.Objekat);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sistem ne može da kreira rezervaciju: {ex.Message}",
                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
            {
                lblIzbor.Text = "Korisnik:";
                UcitajKorisnike();
            }
            else
            {
                lblIzbor.Text = "Radnik:";
                UcitajRadnike();
            }

            UcitajTipoveVozila();

            dtpDatum.MinDate = DateTime.Today;
            dtpDatum.Value = DateTime.Today;
            UcitajSlobodneTermine(DateTime.Today);
        }

        private void UcitajTipoveVozila()
        {

            Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveTipoveVozila);
            if (!odgovor.Uspesno) return;
            List<TipVozila> lista = Komunikacija.Instance.Serializer.ReadType<List<TipVozila>>(odgovor.Objekat);
            cmbTipVozila.DataSource = lista;
            cmbTipVozila.DisplayMember = "Naziv";
            cmbTipVozila.ValueMember = "IdTipVozila";

           

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

                cmbIzbor.DataSource = lista;
                cmbIzbor.DisplayMember = "ImePrezime";
                cmbIzbor.ValueMember = "IdKorisnik";
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

                cmbIzbor.DataSource = lista;
                cmbIzbor.DisplayMember = "ImePrezime";
                cmbIzbor.ValueMember = "IdRadnik";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            UcitajSlobodneTermine(dtpDatum.Value);
        }

        private void cmbTipVozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipVozila.SelectedItem == null) return;
                TipVozila izabrani = (TipVozila)cmbTipVozila.SelectedItem;

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveUsluge);
                if (!odgovor.Uspesno) return;

                List<Usluga> sve = Komunikacija.Instance.Serializer.ReadType<List<Usluga>>(odgovor.Objekat);
                List<Usluga> filtrirane = sve.Where(u => u.TipVozila?.IdTipVozila == izabrani.IdTipVozila).ToList();

                cmbUsluga.DataSource = filtrirane;
                cmbUsluga.DisplayMember = "Naziv";
                cmbUsluga.ValueMember = "IdUsluga";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsluga.SelectedItem is Usluga u)
                lblCena.Text = $"{u.Cena:N2} RSD";
        }
    }
}
