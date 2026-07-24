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
    public partial class FrmNovaPerionica : Form
    {
        public FrmNovaPerionica()
        {
            InitializeComponent();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Unesite naziv perionice.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                MessageBox.Show("Unesite adresu perionice.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdresa.Focus();
                return;
            }

            Perionica perionica = new Perionica
            {
                Naziv = txtNaziv.Text.Trim(),
                Adresa = txtAdresa.Text.Trim()
            };

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.KreirajPerionicu, perionica);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Perionica je uspešno kreirana.", "Uspeh",
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
