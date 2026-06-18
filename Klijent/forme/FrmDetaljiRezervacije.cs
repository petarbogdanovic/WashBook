using Klijent.GuiControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.forme
{
    public partial class FrmDetaljiRezervacije : Form
    {
        private Rezervacija rezervacija;

        public FrmDetaljiRezervacije(Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;
        }


        private void FrmDetaljiRezervacije_Load(object sender, EventArgs e)
        {
            dgvStavkeDetalji.AutoGenerateColumns = false;

            bool jeRadnik = MainCoordinator.Instanca.PrijavljeniRadnik != null;
            btnPromeniStatus.Visible = jeRadnik;
            btnPromeniTermin.Visible = !jeRadnik;
            btnStorniraj.Visible = !jeRadnik;

            Osvezi();
        }

        private void Osvezi()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.PretraziRezervaciju, rezervacija);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                rezervacija = Komunikacija.Instance
                    .Serializer.ReadType<Rezervacija>(odgovor.Objekat);

                PrikaziPodatke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrikaziPodatke()
        {
            lblDatum.Text = $"Datum: {rezervacija.DatumRezervacije:dd.MM.yyyy.}";
            lblTermin.Text = $"Termin: {rezervacija.Termin:dd.MM.yyyy. HH:mm}";
            lblStatus.Text = $"Status: {rezervacija.StatusRezervacije}";
            lblRegistracija.Text = $"Registracija: {rezervacija.Registracija}";
            lblKorisnik.Text = $"Korisnik: {rezervacija.ImeKorisnika}";
            lblRadnik.Text = $"Radnik: {rezervacija.ImeRadnika}";

            dgvStavkeDetalji.DataSource = null;
            dgvStavkeDetalji.DataSource = rezervacija.Stavke;

            double ukupno = rezervacija.Stavke?.Sum(s => s.Cena) ?? 0;
            lblUkupno.Text = $"Ukupno: {ukupno:N2} RSD";
        }

        private void btnPromeniStatus_Click(object sender, EventArgs e)
        {
            new FrmPromeniStatus(rezervacija).ShowDialog();
            Osvezi();
        }

        private void btnPromeniTermin_Click(object sender, EventArgs e)
        {
            new FrmPromeniTermin(rezervacija).ShowDialog();
            Osvezi();
        }

        private void btnStorniraj_Click(object sender, EventArgs e)
        {
            if (rezervacija.StatusRezervacije != StatusRezervacije.KREIRANA)
            {
                MessageBox.Show("Moguće je stornirati samo rezervacije u statusu KREIRANA.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rezervacija.Termin <= DateTime.Now)
            {
                MessageBox.Show("Nije moguće stornirati rezervaciju čiji je termin već prošao.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite da stornirate rezervaciju #{rezervacija.IdRezervacija}?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.StornirajRezervaciju, rezervacija);

                if (odgovor.Uspesno)
                {
                    MessageBox.Show("Rezervacija je uspešno stornirana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Osvezi();
                }
                else
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
