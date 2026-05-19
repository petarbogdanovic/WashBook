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
        // Singleton
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
            StilizujKontrole();
            InicijalizujFilter();

            // Vezivanje event handlera
            uc.btnPretrazi.Click += BtnPretrazi_Click;

            return uc;
        }

        private void StilizujKontrole()
        {
            uc.pnlHeader.BackColor = Color.White;
            uc.pnlHeader.Padding = new Padding(20, 0, 20, 0);

            uc.lblNaslov.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            uc.lblNaslov.ForeColor = Color.FromArgb(30, 42, 58);
            uc.lblNaslov.TextAlign = ContentAlignment.MiddleLeft;

            uc.pnlFilter.BackColor = Color.FromArgb(244, 246, 249);
            uc.pnlFilter.Padding = new Padding(20, 10, 20, 10);

            Font labelFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Color labelColor = Color.FromArgb(80, 100, 120);
            foreach (Control c in uc.pnlFilter.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Font = labelFont;
                    lbl.ForeColor = labelColor;
                }
            }

            uc.dtpDatum.Font = new Font("Segoe UI", 10);

            uc.cmbStatus.Font = new Font("Segoe UI", 10);
            uc.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            uc.btnPretrazi.FlatStyle = FlatStyle.Flat;
            uc.btnPretrazi.FlatAppearance.BorderSize = 0;
            uc.btnPretrazi.BackColor = Color.FromArgb(46, 134, 222);
            uc.btnPretrazi.ForeColor = Color.White;
            uc.btnPretrazi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            uc.btnPretrazi.Height = 36;
            uc.btnPretrazi.Width = 120;
            uc.btnPretrazi.Cursor = Cursors.Hand;

            // DGV stil
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
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 42, 58);
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            uc.dgvRezervacije.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            uc.dgvRezervacije.ColumnHeadersHeight = 44;
            uc.dgvRezervacije.EnableHeadersVisualStyles = false;
            uc.dgvRezervacije.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 134, 222);
            uc.dgvRezervacije.DefaultCellStyle.SelectionForeColor = Color.White;
            uc.dgvRezervacije.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            uc.dgvRezervacije.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
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
            try
            {
                string condition = IzgradiUslov();

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

            string[] vidljive = { "IdRezervacija", "Termin", "StatusRezervacije" };
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
            if (uc.dgvRezervacije.Columns.Contains("StatusRezervacije"))
                uc.dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";
        }

        private string IzgradiUslov()
        {
            List<string> uslovi = new List<string>();

            // Datum filter
            uslovi.Add($"CAST(r.termin AS DATE) = '{uc.dtpDatum.Value:yyyy-MM-dd}'");

            // Status filter
            if (uc.cmbStatus.SelectedItem?.ToString() != "Svi")
                uslovi.Add($"r.statusRezervacije = '{uc.cmbStatus.SelectedItem}'");

            // Ako je korisnik ulogovan, vidi samo svoje rezervacije
            if (MainCoordinator.Instanca.PrijavljeniKorisnik != null)
                uslovi.Add($"r.idKorisnik = {MainCoordinator.Instanca.PrijavljeniKorisnik.IdKorisnik}");

            return string.Join(" AND ", uslovi);
        }
    }
}