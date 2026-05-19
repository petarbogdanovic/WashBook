using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using Font = System.Drawing.Font;

namespace Klijent.GuiControllers
{
    public class SveRezervacijeGuiController
    {
        // Singleton
        private static SveRezervacijeGuiController instance;
        public static SveRezervacijeGuiController Instance
        {
            get
            {
                if (instance == null) instance = new SveRezervacijeGuiController();
                return instance;
            }
        }
        private SveRezervacijeGuiController() { }

        private UcSveRezervacije uc;

        public Control CreateUC()
        {
            uc = new UcSveRezervacije();
            StilizujKontrole();

            // Vezivanje event handlera
            uc.btnRefresh.Click += BtnRefresh_Click;
            uc.btnObrisi.Click += BtnObrisi_Click;
            uc.dgvRezervacije.CellDoubleClick += DgvRezervacije_CellDoubleClick;

            // Inicijalno učitavanje
            UcitajRezervacije();

            return uc;
        }

        private void StilizujKontrole()
        {
            // Header
            uc.pnlHeader.BackColor = Color.White;
            uc.pnlHeader.Padding = new Padding(20, 0, 20, 0);

            uc.lblNaslov.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            uc.lblNaslov.ForeColor = Color.FromArgb(30, 42, 58);
            uc.lblNaslov.TextAlign = ContentAlignment.MiddleLeft;

            uc.btnRefresh.FlatStyle = FlatStyle.Flat;
            uc.btnRefresh.FlatAppearance.BorderSize = 0;
            uc.btnRefresh.BackColor = Color.FromArgb(46, 134, 222);
            uc.btnRefresh.ForeColor = Color.White;
            uc.btnRefresh.Font = new Font("Segoe UI", 9);
            uc.btnRefresh.Height = 34;
            uc.btnRefresh.Width = 100;
            uc.btnRefresh.Cursor = Cursors.Hand;

            // DataGridView
            uc.dgvRezervacije.BackgroundColor = Color.FromArgb(244, 246, 249);
            uc.dgvRezervacije.BorderStyle = BorderStyle.None;
            uc.dgvRezervacije.RowHeadersVisible = false;
            uc.dgvRezervacije.AllowUserToAddRows = false;
            uc.dgvRezervacije.ReadOnly = true;
            uc.dgvRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            uc.dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            uc.dgvRezervacije.Font = new Font("Segoe UI", 9);
            uc.dgvRezervacije.RowTemplate.Height = 40;
            uc.dgvRezervacije.GridColor = Color.FromArgb(220, 228, 240);

            // Header stil
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 42, 58);
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            uc.dgvRezervacije.ColumnHeadersHeight = 44;
            uc.dgvRezervacije.EnableHeadersVisualStyles = false;

            // Row stil
            uc.dgvRezervacije.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 134, 222);
            uc.dgvRezervacije.DefaultCellStyle.SelectionForeColor = Color.White;
            uc.dgvRezervacije.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            uc.dgvRezervacije.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            UcitajRezervacije();
        }

        private void UcitajRezervacije()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiListuRezervacija, "1=1");

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
                                   "StatusRezervacije","NazivTipVozila",
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
            if (uc.dgvRezervacije.Columns.Contains("NazivTipVozila"))
                uc.dgvRezervacije.Columns["NazivTipVozila"].HeaderText = "Tip vozila";
            if (uc.dgvRezervacije.Columns.Contains("NazivUsluge"))
                uc.dgvRezervacije.Columns["NazivUsluge"].HeaderText = "Usluga";
            if (uc.dgvRezervacije.Columns.Contains("Registracija"))
                uc.dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";
            if (uc.dgvRezervacije.Columns.Contains("Cena"))
                uc.dgvRezervacije.Columns["Cena"].HeaderText = "Cena";
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

        private void BtnObrisi_Click(object sender, EventArgs e)
        {
            if (uc.dgvRezervacije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite rezervaciju.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rezervacija selected = (Rezervacija)uc.dgvRezervacije.SelectedRows[0].DataBoundItem;

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete rezervaciju #{selected.IdRezervacija}?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.ObrisiRezervaciju, selected);

                if (odgovor.Uspesno)
                {
                    MessageBox.Show("Rezervacija je uspešno obrisana.", "Uspeh",
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