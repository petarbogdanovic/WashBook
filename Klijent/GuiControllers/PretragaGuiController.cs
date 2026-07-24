using Klijent.forme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class PretragaGuiController
    {
        
        private static PretragaGuiController instance;
        public static PretragaGuiController Instance
        {
            get
            {
                if (instance == null) instance = new PretragaGuiController();
                return instance;
            }
        }
        private PretragaGuiController() { }

        private UcPretragaRezervacija uc;

        public Control CreateUC()
        {
            uc = new UcPretragaRezervacija();
            InicijalizujFilter();

            StilTabele.Primeni(uc.dgvRezervacije);

            uc.btnPretrazi.Click += BtnPretrazi_Click;
            uc.dgvRezervacije.CellDoubleClick += DgvRezervacije_CellDoubleClick;

            return uc;
        }

       

        private void InicijalizujFilter()
        {
            // Popuni status ComboBox
            uc.cmbStatus.Items.Clear();
            uc.cmbStatus.Items.Add("Svi");
            foreach (StatusRezervacije s in Enum.GetValues(typeof(StatusRezervacije)))
                uc.cmbStatus.Items.Add(s);
            uc.cmbStatus.SelectedIndex = 0;

            uc.dtpDatum.Value = DateTime.Today;
        }

        private void BtnPretrazi_Click(object sender, EventArgs e)
        {
            IzvrsiPretragu();
        }
        private void DgvRezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Rezervacija izabrana = (Rezervacija)uc.dgvRezervacije.Rows[e.RowIndex].DataBoundItem;

            new FrmDetaljiRezervacije(izabrana).ShowDialog();

            IzvrsiPretragu();
        }

        private void IzvrsiPretragu()
        {
            try
            {
                RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
                {
                    Datum = uc.dtpDatum.Value
                };

                if (uc.cmbStatus.SelectedItem?.ToString() != "Svi")
                    kriterijum.Status = (StatusRezervacije)uc.cmbStatus.SelectedItem;

                if (MainCoordinator.Instanca.PrijavljeniKorisnik != null)
                    kriterijum.IdKorisnik = MainCoordinator.Instanca.PrijavljeniKorisnik.IdKorisnik;
                else if (MainCoordinator.Instanca.PrijavljenaRadnikPerionica != null)
                    kriterijum.IdPerionica = MainCoordinator.Instanca.PrijavljenaRadnikPerionica.IdPerionica;

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiListuRezervacija, kriterijum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Rezervacija> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Rezervacija>>(odgovor.Objekat);

                uc.dgvRezervacije.DataSource = lista;
                PodesiKolone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodesiKolone()
        {
            if (uc.dgvRezervacije.Columns.Count == 0) return;

            // Sakrij nepotrebne kolone
            foreach (DataGridViewColumn col in uc.dgvRezervacije.Columns)
                col.Visible = false;

            // Prikaži samo relevantne
            string[] vidljive = {  "DatumRezervacije",
                                   "Termin", "ImeKorisnika",
                                   "StatusRezervacije",
                                    "NazivUsluge","Registracija", "Cena" };

            foreach (string ime in vidljive)
            {
                if (uc.dgvRezervacije.Columns.Contains(ime))
                {
                    uc.dgvRezervacije.Columns[ime].Visible = true;
                }
            }

            if (uc.dgvRezervacije.Columns.Contains("Termin"))
            {
                uc.dgvRezervacije.Columns["Termin"].HeaderText = "Termin";
                uc.dgvRezervacije.Columns["Termin"].DefaultCellStyle.Format = "dd.MM.yyyy. | HH:mm";
            }
            if (uc.dgvRezervacije.Columns.Contains("ImeKorisnika"))
                uc.dgvRezervacije.Columns["ImeKorisnika"].HeaderText = "Korisnik";
            if (uc.dgvRezervacije.Columns.Contains("IdRezervacija"))
                uc.dgvRezervacije.Columns["IdRezervacija"].HeaderText = "ID";
            if (uc.dgvRezervacije.Columns.Contains("DatumRezervacije"))
            {
                uc.dgvRezervacije.Columns["DatumRezervacije"].HeaderText = "Datum rezervacije";
                uc.dgvRezervacije.Columns["DatumRezervacije"].DefaultCellStyle.Format = "dd.MM.yyyy.";
            }
            if (uc.dgvRezervacije.Columns.Contains("StatusRezervacije"))
                uc.dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";
            if (uc.dgvRezervacije.Columns.Contains("NazivUsluge"))
                uc.dgvRezervacije.Columns["NazivUsluge"].HeaderText = "Usluga";
            if (uc.dgvRezervacije.Columns.Contains("Registracija"))
                uc.dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";
            if (uc.dgvRezervacije.Columns.Contains("Cena"))
                uc.dgvRezervacije.Columns["Cena"].HeaderText = "Cena";
        }

        
    }
}