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
    public partial class FrmRasporedRadnika : Form
    {
        private Radnik radnik;

        public FrmRasporedRadnika(Radnik radnik)
        {
            InitializeComponent();
            this.radnik = radnik;
        }

        private void FrmRasporedRadnika_Load(object sender, EventArgs e)
        {
            lblRadnik.Text = radnik.ImePrezime;

            lblTrenutno.Text = radnik.Perionica != null
                ? $"{radnik.Perionica.Naziv} ({radnik.Smena})"
                : "Nije raspoređen";

            UcitajSmene();
            UcitajPerionice();
        }

        private void UcitajSmene()
        {
            cmbSmena.Items.Clear();
            foreach (Smena s in Enum.GetValues(typeof(Smena)))
                cmbSmena.Items.Add(s);

            cmbSmena.SelectedItem = radnik.Smena ?? Smena.Jutarnja;
        }

        private void UcitajPerionice()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiSvePerionice, null);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Perionica> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Perionica>>(odgovor.Objekat);

                cmbPerionica.DataSource = lista;
                cmbPerionica.DisplayMember = "Naziv";

                if (radnik.Perionica != null)
                    foreach (Perionica p in lista)
                        if (p.IdPerionica == radnik.Perionica.IdPerionica)
                        {
                            cmbPerionica.SelectedItem = p;
                            break;
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            Perionica izabrana = cmbPerionica.SelectedItem as Perionica;
            if (izabrana == null)
            {
                MessageBox.Show("Izaberite perionicu.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Smena izabranaSmena = (Smena)cmbSmena.SelectedItem;

            bool istaPerionica = radnik.Perionica != null
                              && radnik.Perionica.IdPerionica == izabrana.IdPerionica;

            if (istaPerionica && radnik.Smena == izabranaSmena)
            {
                MessageBox.Show("Nema izmena.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RadnikPerionica dodela = new RadnikPerionica
            {
                IdRadnik = radnik.IdRadnik,
                IdPerionica = izabrana.IdPerionica,
                Smena = izabranaSmena
            };

            Operacija operacija = istaPerionica
                ? Operacija.PromeniSmenu
                : Operacija.RasporediRadnika;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(operacija, dodela);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Raspored je uspešno sačuvan.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
