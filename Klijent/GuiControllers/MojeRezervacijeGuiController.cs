using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class MojeRezervacijeGuiController
    {
        // Singleton
        private static MojeRezervacijeGuiController instance;
        public static MojeRezervacijeGuiController Instance
        {
            get
            {
                if (instance == null) instance = new MojeRezervacijeGuiController();
                return instance;
            }
        }
        private MojeRezervacijeGuiController() { }

        private UcMojeRezervacije uc;

        public Control CreateUC()
        {
            uc = new UcMojeRezervacije();
            PostaviNaslov();

            // Vezivanje event handlera
            uc.btnRefresh.Click += BtnRefresh_Click;
            uc.btnStorniraj.Click += BtnStorniraj_Click;
            uc.dgvRezervacije.CellDoubleClick += DgvRezervacije_CellDoubleClick;

            // Inicijalno učitavanje
            UcitajRezervacije();

            return uc;
        }

       

        private void PostaviNaslov()
        {
            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
                uc.lblNaslov.Text = "Moje zakazane rezervacije";
            else
                uc.lblNaslov.Text = "Moje rezervacije";
        }

        private void UcitajRezervacije()
        {
            try
            {
                string condition;

                if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
                    condition = $"r.idRadnik = {MainCoordinator.Instanca.PrijavljeniRadnik.IdRadnik}";
                else
                    condition = $"r.idKorisnik = {MainCoordinator.Instanca.PrijavljeniKorisnik.IdKorisnik}";

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiListuRezervacija, condition);

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

            foreach (DataGridViewColumn col in uc.dgvRezervacije.Columns)
                col.Visible = false;

            string[] vidljive = { "Termin", "ImeRadnika", "StatusRezervacije", "NazivTipVozila", "NazivUsluge", "Registracija", "Cena" };
            foreach (string ime in vidljive)
                if (uc.dgvRezervacije.Columns.Contains(ime))
                    uc.dgvRezervacije.Columns[ime].Visible = true;

            if (uc.dgvRezervacije.Columns.Contains("IdRezervacija"))
                uc.dgvRezervacije.Columns["IdRezervacija"].HeaderText = "ID";
            if (uc.dgvRezervacije.Columns.Contains("Termin"))
            {
                uc.dgvRezervacije.Columns["Termin"].HeaderText = "Termin";
                uc.dgvRezervacije.Columns["Termin"].DefaultCellStyle.Format = "dd.MM.yyyy. HH:mm";
            }
            if (uc.dgvRezervacije.Columns.Contains("ImeRadnika"))
                uc.dgvRezervacije.Columns["ImeRadnika"].HeaderText = "Radnik";
            if (uc.dgvRezervacije.Columns.Contains("StatusRezervacije"))
                uc.dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";
            if (uc.dgvRezervacije.Columns.Contains("NazivTipVozila"))
                uc.dgvRezervacije.Columns["NazivTipVozila"].HeaderText = "Tip vozila";
            if (uc.dgvRezervacije.Columns.Contains("NazivUsluge"))
                uc.dgvRezervacije.Columns["NazivUsluge"].HeaderText = "Usluga";
            if (uc.dgvRezervacije.Columns.Contains("Registracija"))
                uc.dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";
            if (uc.dgvRezervacije.Columns.Contains("Cena"))
                uc.dgvRezervacije.Columns["Cena"].HeaderText = "Cena (RSD)";
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            UcitajRezervacije();
        }

        private void DgvRezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Rezervacija izabrana = (Rezervacija)uc.dgvRezervacije.Rows[e.RowIndex].DataBoundItem;

            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
            {
                FrmPromeniStatus frm = new FrmPromeniStatus(izabrana);
                frm.ShowDialog();
            }
            else
            {
                FrmPromeniTermin frm = new FrmPromeniTermin(izabrana);
                frm.ShowDialog();
            }

            UcitajRezervacije();
        }

        private void BtnStorniraj_Click(object sender, EventArgs e)
        {
            if (uc.dgvRezervacije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite rezervaciju.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rezervacija selected = (Rezervacija)uc.dgvRezervacije.SelectedRows[0].DataBoundItem;

            if (selected.StatusRezervacije != StatusRezervacije.KREIRANA)
            {
                MessageBox.Show("Moguće je stornirati samo rezervacije u statusu KREIRANA.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selected.Termin <= DateTime.Now)
            {
                MessageBox.Show("Nije moguće stornirati rezervaciju čiji je termin već prošao.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite da stornirate rezervaciju #{selected.IdRezervacija}?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.StornirajRezervaciju, selected);

                if (odgovor.Uspesno)
                {
                    MessageBox.Show("Rezervacija je uspešno stornirana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajRezervacije();
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
    }
}