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
    public partial class FrmNoviRadnik : Form
    {
        public FrmNoviRadnik()
        {
            InitializeComponent();
        }

        private void FrmNoviRadnik_Load(object sender, EventArgs e)
        {
            dtpDatumRodjenja.MaxDate = DateTime.Today;
            dtpDatumRodjenja.Value = new DateTime(2000, 1, 1);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (!ValidnaForma()) return;

            Radnik noviRadnik = new Radnik
            {
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                DatumRodjenja = dtpDatumRodjenja.Value.Date,
                Adresa = txtAdresa.Text.Trim(),
                Telefon = txtTelefon.Text.Trim(),
                KorisnickoIme = txtKorisnickoIme.Text.Trim(),
                Sifra = txtSifra.Text,
                JeMenadzer = chkJeMenadzer.Checked
            };

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.KreirajRadnika, noviRadnik);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Radnik je uspešno kreiran.", "Uspeh",
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

        private bool ValidnaForma()
        {
            if (!Popunjeno(txtIme, "ime")) return false;
            if (!Popunjeno(txtPrezime, "prezime")) return false;
            if (!Popunjeno(txtAdresa, "adresu")) return false;
            if (!Popunjeno(txtTelefon, "telefon")) return false;
            if (!Popunjeno(txtKorisnickoIme, "korisničko ime")) return false;
            if (!Popunjeno(txtSifra, "šifru")) return false;

            if (dtpDatumRodjenja.Value.Date > DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("Radnik mora biti punoletan.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDatumRodjenja.Focus();
                return false;
            }

            return true;
        }

        private bool Popunjeno(TextBox txt, string naziv)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show($"Unesite {naziv}.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                return false;
            }
            return true;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
