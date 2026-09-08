using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent
{
    public partial class FrmPromeniStatus : Form
    {
        private Rezervacija rezervacija;
        public FrmPromeniStatus(Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;

        }

       


        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StatusRezervacije izabrani = (StatusRezervacije)cmbStatus.SelectedItem;

            if (izabrani == rezervacija.StatusRezervacije)
            {
                MessageBox.Show("Status nije promenjen.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Operacija operacija = izabrani == StatusRezervacije.OBRADJENA
                ? Operacija.ObradiRezervaciju
                : Operacija.StornirajRezervaciju;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(operacija, rezervacija);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Status je uspešno promenjen!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPromeniStatus_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Rezervacija #{rezervacija.IdRezervacija}\n" +
                           $"Termin: {rezervacija.Termin:dd.MM.yyyy HH:mm}";

            cmbStatus.Items.Add(StatusRezervacije.OBRADJENA);
            cmbStatus.Items.Add(StatusRezervacije.STORNIRANA);

            cmbStatus.SelectedItem = null;
        }
    }
}
