using Klijent.GuiControllers;
using System.ComponentModel;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.forme
{
    public partial class FrmDetaljiRezervacije : Form
    {
        private Rezervacija rezervacija;
        private BindingList<StavkaRezervacije> stavkaRezervacije;

        public FrmDetaljiRezervacije(Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;

        }


        private void FrmDetaljiRezervacije_Load(object sender, EventArgs e)
        {
            StilTabele.Primeni(dgvStavkeDetalji);
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

            stavkaRezervacije = new BindingList<StavkaRezervacije>(rezervacija.Stavke);
            dgvStavkeDetalji.DataSource = null;
            dgvStavkeDetalji.DataSource = stavkaRezervacije;

            UcitajUsluge();


            double ukupno = stavkaRezervacije?.Sum(s => s.Cena) ?? 0;
            lblUkupno.Text = $"Ukupno: {ukupno:N2} RSD";
            PodesiVidljivost();
        }

        private void UcitajUsluge()
        {
            Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveUsluge);
            if (!odgovor.Uspesno) return;
            List<Usluga> sve = Komunikacija.Instance.Serializer.ReadType<List<Usluga>>(odgovor.Objekat);
            cmbUsluga.DataSource = sve;
            cmbUsluga.DisplayMember = "Naziv";
            cmbUsluga.ValueMember = "IdUsluga";
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
           

            if (!MozeDaSeMenja()) return;

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




        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            if (cmbUsluga.SelectedItem is not Usluga usluga)
            {
                MessageBox.Show("Izaberite uslugu.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stavkaRezervacije.Any(s => s.Usluga?.IdUsluga == usluga.IdUsluga))
            {
                MessageBox.Show($"{usluga.Naziv}  usluga je već dodata", "Upozorenje",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            stavkaRezervacije.Add(new StavkaRezervacije
            {
                Usluga = usluga,
                Cena = usluga.Cena
            });

        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            if (dgvStavkeDetalji.CurrentRow?.DataBoundItem is StavkaRezervacije s)
            {
                stavkaRezervacije.Remove(s);

            }
        }

        private void cmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsluga.SelectedItem is Usluga u)
                lblCena.Text = $"{u.Cena} RSD";
        }

        private bool MozeDaSeMenja()
        {
            if (rezervacija.StatusRezervacije != StatusRezervacije.KREIRANA)
            {
                MessageBox.Show("Izmene su moguće samo dok je rezervacija u statusu KREIRANA.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rezervacija.Termin <= DateTime.Now)
            {
                MessageBox.Show("Nije moguće menjati rezervaciju čiji je termin već prošao.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool StavkeSeMoguMenjti()
        {
            return rezervacija.StatusRezervacije == StatusRezervacije.KREIRANA
                && rezervacija.Termin > DateTime.Now;
        }

        private void PodesiVidljivost()
        {
            bool moze = StavkeSeMoguMenjti();

            cmbUsluga.Enabled = moze;
            btnDodajStavku.Enabled = moze;
            btnObrisiStavku.Enabled = moze;
            btnSacuvajIzmene.Enabled = moze;
        }

        private void btnSacuvajIzmene_Click(object sender, EventArgs e)
        {
            if (!MozeDaSeMenja()) return;

            if(stavkaRezervacije.Count == 0)
            {
                MessageBox.Show("Rezervacija mora imati bar jednu uslugu.",
                     "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rezervacija.Stavke = new List<StavkaRezervacije>(stavkaRezervacije);

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.IzmeniRezervaciju, rezervacija);
                if (odgovor.Uspesno)
                {
                    MessageBox.Show("Rezervacija je uspešno izmenjena.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Osvezi();
                }
                else
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
