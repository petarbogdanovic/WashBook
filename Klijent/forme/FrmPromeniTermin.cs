using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent
{
    public partial class FrmPromeniTermin : Form
    {
        private Rezervacija rezervacija;
        private int? idPerionica;
        private bool inicijalizacija = true;

        public FrmPromeniTermin(Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;

        }

       

        private void FrmPromeniTermin_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Rezervacija #{rezervacija.IdRezervacija}\n" +
                         $"Trenutni termin: {rezervacija.Termin:dd.MM.yyyy HH:mm}";

            UcitajPerionicu();

            dtpDatum.Value = rezervacija.Termin.Date;
            dtpDatum.MinDate = DateTime.Today;

            inicijalizacija = false;

            UcitajSlobodneTermine(rezervacija.Termin.Date, rezervacija.Termin);


        }

        private void UcitajSlobodneTermine(DateTime datum, DateTime trenutniTermin)
        {
            if (idPerionica == null)
            {
                MessageBox.Show("Radnik nije raspoređen ni u jednu perionicu.", "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTermin.DataSource = null;
                return;
            }

            RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
            {
                Datum = datum,
                IdPerionica = idPerionica
            };

            try
            {
               
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiZauzeteTermine, kriterijum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<DateTime> zauzeti = Komunikacija.Instance
                    .Serializer.ReadType<List<DateTime>>(odgovor.Objekat);

                List<DateTime> slobodni = new List<DateTime>();
                for (int sat = 8; sat < 19; sat++)
                {
                    DateTime t = datum.Date.AddHours(sat);
                    bool jeZauzet = zauzeti.Any(z => z.Hour == sat);
                    bool jeKurrentni = t.Hour == trenutniTermin.Hour && datum.Date == trenutniTermin.Date;

                    if (t <= DateTime.Now && !jeKurrentni) continue;

                    if (!jeZauzet || jeKurrentni)
                        slobodni.Add(t);
                }

                cmbTermin.DataSource = null;
                cmbTermin.DataSource = slobodni;

                cmbTermin.SelectedItem = slobodni
                    .FirstOrDefault(t => t.Hour == trenutniTermin.Hour);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajPerionicu()
        {
            Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                Operacija.VratiPerionicaZaRadnika, rezervacija.Radnik.IdRadnik);

            if (!odgovor.Uspesno) return;

            List<RadnikPerionica> lista = Komunikacija.Instance
                .Serializer.ReadType<List<RadnikPerionica>>(odgovor.Objekat);

            if (lista != null && lista.Count > 0)
                idPerionica = lista[0].IdPerionica;
        }
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbTermin.SelectedItem == null)
            {
                MessageBox.Show("Izaberite termin.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime noviTermin = (DateTime)cmbTermin.SelectedItem;

            if (noviTermin == rezervacija.Termin)
            {
                MessageBox.Show("Termin nije promenjen.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                rezervacija.Termin = noviTermin;

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.IzmeniRezervaciju, rezervacija);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Termin je uspešno promenjen!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            if (inicijalizacija) return;
            UcitajSlobodneTermine(dtpDatum.Value, DateTime.MinValue);
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
