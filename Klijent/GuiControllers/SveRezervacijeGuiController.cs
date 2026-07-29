//using Klijent.forme;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;
//using Zajednicki.Domen;
//using Zajednicki.Komunikacija;
//using Font = System.Drawing.Font;

//namespace Klijent.GuiControllers
//{
//    public class SveRezervacijeGuiController
//    {
//        // Singleton
//        private static SveRezervacijeGuiController instance;
//        public static SveRezervacijeGuiController Instance
//        {
//            get
//            {
//                if (instance == null) instance = new SveRezervacijeGuiController();
//                return instance;
//            }
//        }
//        private SveRezervacijeGuiController() { }

//        private UcSveRezervacije uc;

//        public Control CreateUC()
//        {
//            uc = new UcSveRezervacije();

//            StilTabele.Primeni(uc.dgvRezervacije);

//            uc.btnRefresh.Click += BtnRefresh_Click;
//            uc.btnObrisi.Click += BtnObrisi_Click;
//            uc.dgvRezervacije.CellDoubleClick += DgvRezervacije_CellDoubleClick;

//            UcitajRezervacije();

//            return uc;
//        }


//        private void BtnRefresh_Click(object sender, EventArgs e)
//        {
//            UcitajRezervacije();
//        }

//        private void UcitajRezervacije()
//        {
//            try
//            {
//                RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
//                {
//                    IdPerionica = MainCoordinator.Instanca.PrijavljenaRadnikPerionica.IdPerionica

//                };
//                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
//                    Operacija.VratiListuRezervacija, kriterijum);

//                if (!odgovor.Uspesno)
//                {
//                    MessageBox.Show(odgovor.Greska, "Greška",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                List<Rezervacija> lista = Komunikacija.Instance
//                    .Serializer.ReadType<List<Rezervacija>>(odgovor.Objekat);

//                uc.dgvRezervacije.DataSource = lista;
//                PodesiKolone();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Greška",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void PodesiKolone()
//        {
//            if (uc.dgvRezervacije.Columns.Count == 0) return;

//            foreach (DataGridViewColumn col in uc.dgvRezervacije.Columns)
//                col.Visible = false;

//            string[] vidljive = {  "DatumRezervacije",
//                                   "Termin", "ImeKorisnika",
//                                   "StatusRezervacije", "Registracija" };

//            foreach (string ime in vidljive)
//            {
//                if (uc.dgvRezervacije.Columns.Contains(ime))
//                    uc.dgvRezervacije.Columns[ime].Visible = true;

//            }



//            if (uc.dgvRezervacije.Columns.Contains("Termin"))
//            {
//                uc.dgvRezervacije.Columns["Termin"].HeaderText = "Termin";
//                uc.dgvRezervacije.Columns["Termin"].DefaultCellStyle.Format = "dd.MM.yyyy. | HH:mm";
//            }
//            if (uc.dgvRezervacije.Columns.Contains("ImeKorisnika"))
//                uc.dgvRezervacije.Columns["ImeKorisnika"].HeaderText = "Korisnik";
//            if (uc.dgvRezervacije.Columns.Contains("IdRezervacija"))
//                uc.dgvRezervacije.Columns["IdRezervacija"].HeaderText = "ID";
//            if (uc.dgvRezervacije.Columns.Contains("DatumRezervacije"))
//            {
//                uc.dgvRezervacije.Columns["DatumRezervacije"].HeaderText = "Datum rezervacije";
//                uc.dgvRezervacije.Columns["DatumRezervacije"].DefaultCellStyle.Format = "dd.MM.yyyy.";
//            }
//            if (uc.dgvRezervacije.Columns.Contains("StatusRezervacije"))
//                uc.dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";
//            if (uc.dgvRezervacije.Columns.Contains("Registracija"))
//                uc.dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";  
//        }

//        private void DgvRezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            Rezervacija izabrana = (Rezervacija)uc.dgvRezervacije.Rows[e.RowIndex].DataBoundItem;

//            new FrmDetaljiRezervacije(izabrana).ShowDialog();

//            UcitajRezervacije();
//        }

//        private void BtnObrisi_Click(object sender, EventArgs e)
//        {
//            if (uc.dgvRezervacije.SelectedRows.Count == 0)
//            {
//                MessageBox.Show("Molimo odaberite rezervaciju.", "Upozorenje",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            Rezervacija selected = (Rezervacija)uc.dgvRezervacije.SelectedRows[0].DataBoundItem;

//            var potvrda = MessageBox.Show(
//                $"Da li ste sigurni da želite da obrišete rezervaciju #{selected.IdRezervacija}?",
//                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

//            if (potvrda != DialogResult.Yes) return;

//            try
//            {
//                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
//                    Operacija.ObrisiRezervaciju, selected);

//                if (odgovor.Uspesno)
//                {
//                    MessageBox.Show("Rezervacija je uspešno obrisana.", "Uspeh",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    UcitajRezervacije();
//                }
//                else
//                {
//                    MessageBox.Show(odgovor.Greska, "Greška",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}

using Klijent.forme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using Font = System.Drawing.Font;

namespace Klijent.GuiControllers
{
    public class SveRezervacijeGuiController
    {
        private static SveRezervacijeGuiController instance;
        public static SveRezervacijeGuiController Instance =>
            instance ??= new SveRezervacijeGuiController();
        private SveRezervacijeGuiController() { }

        private UcSveRezervacije uc;

        private List<Radnik> radniciCache;
        private const int PrviSat = 8;
        private const int PoslednjiSat = 18;                        // poslednji slot počinje u 18:00
        private const int BrojRedova = PoslednjiSat - PrviSat + 1;  // 11

        private DateTime pocetakNedelje;   // ponedeljak 00:00 prikazane nedelje
        private int idRadnikPrikaz;        // čiji se kalendar prikazuje

        private Button btnPrethodna, btnSledeca, btnOsvezi;
        private Label lblNedelja;
        private ComboBox cmbRadnik;        // samo za menadžera

        private bool inicijalizacija = true;

        public Control CreateUC()
        {
            try
            {
                uc = new UcSveRezervacije();

                idRadnikPrikaz = MainCoordinator.Instanca.PrijavljeniRadnik.IdRadnik;
                pocetakNedelje = PocetakNedelje(DateTime.Now);

                PripremiGrid();

                IzgradiZaglavlje();

                uc.dgvRezervacije.CellDoubleClick += Dgv_CellDoubleClick;
                uc.dgvRezervacije.CellPainting += Dgv_CellPainting;

                inicijalizacija = false;
             
                Ucitaj();
                return uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "STACK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // ---------- izgled mreže ----------
        //private void PripremiGrid()
        //{
        //    var dgv = uc.dgvRezervacije;

        //    StilTabele.Primeni(dgv);   // pokupi zaglavlje/osnovu iz zajedničkog stila

        //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        //    // kalendarske ispravke preko osnove
        //    dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
        //    dgv.MultiSelect = false;
        //    dgv.AllowUserToResizeColumns = false;
        //    dgv.AllowUserToResizeRows = false;
        //    dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        //    dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle(); // gasimo zebru
        //    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 246);
        //    dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        //    dgv.RowTemplate.Height = 42;
        //    dgv.Dock = DockStyle.Fill;

        //    dgv.AutoGenerateColumns = false;
        //    dgv.Columns.Clear();
        //    dgv.Rows.Clear();

        //    // kolona 0: satnica
        //    var kolSat = new DataGridViewTextBoxColumn
        //    {
        //        Name = "colSat",
        //        HeaderText = "",
        //        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
        //        Width = 64,
        //        SortMode = DataGridViewColumnSortMode.NotSortable,
        //        ReadOnly = true
        //    };
        //    kolSat.DefaultCellStyle.BackColor = Color.FromArgb(45, 74, 105);
        //    kolSat.DefaultCellStyle.ForeColor = Color.White;
        //    kolSat.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        //    kolSat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    kolSat.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 105);
        //    kolSat.DefaultCellStyle.SelectionForeColor = Color.White;
        //    dgv.Columns.Add(kolSat);

        //    // kolone 1..7: dani
        //    for (int i = 0; i < 7; i++)
        //    {
        //        var kol = new DataGridViewTextBoxColumn
        //        {
        //            Name = "colDan" + i,
        //            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        //            FillWeight = 100,
        //            SortMode = DataGridViewColumnSortMode.NotSortable,
        //            ReadOnly = true
        //        };
        //        kol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        kol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //        dgv.Columns.Add(kol);
        //    }

        //    // redovi 08:00 .. 18:00
        //    for (int sat = PrviSat; sat <= PoslednjiSat; sat++)
        //    {
        //        int idx = dgv.Rows.Add();
        //        dgv.Rows[idx].Cells[0].Value = $"{sat:00}:00";
        //    }
        //}

        private void PripremiGrid()
        {
            var dgv = uc.dgvRezervacije;

            StilTabele.Primeni(dgv);

            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 48;   // dva reda teksta stanu
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // KLJUČNO: ugasi Fill PRE dodavanja kolona (StilTabele ga je uključio)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 246);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 42;
            dgv.Dock = DockStyle.Fill;

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            // kolona 0: satnica — fiksna
            var kolSat = new DataGridViewTextBoxColumn
            {
                Name = "colSat",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 64,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = true
            };
            kolSat.DefaultCellStyle.BackColor = Color.FromArgb(45, 74, 105);
            kolSat.DefaultCellStyle.ForeColor = Color.White;
            kolSat.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            kolSat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            kolSat.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 105);
            kolSat.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.Columns.Add(kolSat);

            // kolone 1..7: dani — bez Fill dok se dodaju
            for (int i = 0; i < 7; i++)
            {
                var kol = new DataGridViewTextBoxColumn
                {
                    Name = "colDan" + i,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,   // NE Fill ovde
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    ReadOnly = true
                };
                kol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                kol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.Columns.Add(kol);
            }

            // redovi 08:00 .. 18:00
            for (int sat = PrviSat; sat <= PoslednjiSat; sat++)
            {
                int idx = dgv.Rows.Add();
                dgv.Rows[idx].Cells[0].Value = $"{sat:00}:00";
            }

            // TEK SAD uključi Fill, i to samo na dan-kolonama
            for (int i = 1; i <= 7; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[i].FillWeight = 100;
            }
            // colSat ostaje None + Width 64
        }


        // ---------- traka: navigacija + combobox ----------
        private void IzgradiZaglavlje()
        {
            uc.btnRefresh.Visible = false;   // stara dugmiće gasimo da ne preklapaju mrežu
            uc.btnObrisi.Visible = false;

            var traka = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 44,
                Padding = new Padding(6),
                BackColor = Color.White,
                WrapContents = false
            };

            btnPrethodna = new Button { Text = "◄", Width = 40, Height = 30 };
            lblNedelja = new Label
            {
                Width = 210,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnSledeca = new Button { Text = "►", Width = 40, Height = 30 };
            btnOsvezi = new Button { Text = "Osveži", Width = 80, Height = 30 };

            btnPrethodna.Click += (s, e) => { pocetakNedelje = pocetakNedelje.AddDays(-7); Ucitaj(); };
            btnSledeca.Click += (s, e) => { pocetakNedelje = pocetakNedelje.AddDays(7); Ucitaj(); };
            btnOsvezi.Click += (s, e) => Ucitaj();

            traka.Controls.Add(btnPrethodna);
            traka.Controls.Add(lblNedelja);
            traka.Controls.Add(btnSledeca);
            traka.Controls.Add(btnOsvezi);

            if (MainCoordinator.Instanca.PrijavljeniRadnik.JeMenadzer)
            {
                cmbRadnik = new ComboBox
                {
                    Width = 260,
                    Height = 30,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Margin = new Padding(20, 6, 3, 3)
                };

                UcitajRadnike();                       // napuni Items (sinhrono, bez binding-timinga)
                traka.Controls.Add(cmbRadnik);

                // vizuelno selektuj prijavljenog menadžera — radi ODMAH jer je Items kolekcija
                Radnik meni = radniciCache?.FirstOrDefault(r => r.IdRadnik == idRadnikPrikaz);
                if (meni != null)
                    cmbRadnik.SelectedItem = meni;
                else if (cmbRadnik.Items.Count > 0)
                    cmbRadnik.SelectedIndex = 0;

                // handler TEK SAD → početna selekcija ne okida učitavanje (radi ga CreateUC)
                cmbRadnik.SelectedIndexChanged += CmbRadnik_SelectedIndexChanged;
            }

            uc.dgvRezervacije.Dock = DockStyle.Fill;   // grid popuni ostatak
            uc.Controls.Add(traka);                    // traka u kolekciju
            uc.Controls.SetChildIndex(traka, 0);       // traka na vrh z-ordera
            traka.Dock = DockStyle.Top;                // traka zauzme gornji pojas
            uc.dgvRezervacije.BringToFront();
        }

        private void UcitajRadnike()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(Operacija.VratiSveRadnike);
                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                radniciCache = Komunikacija.Instance
                    .Serializer.ReadType<List<Radnik>>(odgovor.Objekat)
                    .OrderBy(r => r.Perionica?.Naziv ?? "\uFFFF")
                    .ThenBy(r => r.Ime)
                    .ToList();

                cmbRadnik.DisplayMember = "ImePrezimePerionica";
                cmbRadnik.Items.Clear();
                foreach (Radnik r in radniciCache)
                    cmbRadnik.Items.Add(r);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbRadnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRadnik.SelectedItem is Radnik r)
            {
                idRadnikPrikaz = r.IdRadnik;
                Ucitaj();
            }
        }

        // ---------- učitavanje + punjenje ----------
        private void Ucitaj()
        {
            if (inicijalizacija) return;
            try
            {
                RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
                {
                    IdRadnik = idRadnikPrikaz,
                    DatumOd = pocetakNedelje,
                    DatumDo = pocetakNedelje.AddDays(7)   // half-open, poklapa se sa SO (termin < @datumDo)
                };

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiRezervacijeZaPeriod, kriterijum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Rezervacija> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Rezervacija>>(odgovor.Objekat);

                PopuniMrezu(lista);
                AzurirajZaglavlje();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopuniMrezu(List<Rezervacija> lista)
        {
            var dgv = uc.dgvRezervacije;

            // očisti dan-ćelije (satnica u koloni 0 ostaje)
            foreach (DataGridViewRow row in dgv.Rows)
                for (int c = 1; c <= 7; c++)
                {
                    row.Cells[c].Value = null;
                    row.Cells[c].Tag = null;
                    row.Cells[c].Style.BackColor = Color.White;
                    row.Cells[c].ToolTipText = "";
                }

            foreach (Rezervacija r in lista)
            {
                int red = r.Termin.Hour - PrviSat;
                if (red < 0 || red >= BrojRedova) continue;   // pojas: ako uzvodni invarijant ikad pukne, ne gubi red tiho

                int kolona = ((int)r.Termin.DayOfWeek + 6) % 7 + 1;   // Pon=1 ... Ned=7

                DataGridViewCell celija = dgv.Rows[red].Cells[kolona];
                celija.Value = r.ImeKorisnika;
                celija.Tag = r;
                celija.Style.BackColor = Boja(r);
                celija.ToolTipText = $"{r.ImeKorisnika} • {r.StatusRezervacije} • {r.Termin:HH:mm}";
            }
        }

        private static Color Boja(Rezervacija r)
        {
            if (r.StatusRezervacije == StatusRezervacije.STORNIRANA)
                return Color.FromArgb(247, 136, 146);   // crvena
            if (r.StatusRezervacije == StatusRezervacije.OBRADJENA)
                return Color.FromArgb(255, 243, 205);    // žuta — obrađena je obrađena bez obzira na vreme
            if (r.Termin < DateTime.Now)
                return Color.FromArgb(255, 243, 205);    // žuta — prošlo
            return Color.FromArgb(212, 237, 218);        // zelena — KREIRANA u budućnosti
        }

        private void AzurirajZaglavlje()
        {
            var dgv = uc.dgvRezervacije;
            string[] dani = { "Ponedeljak", "Utorak", "Sreda", "Četvrtak", "Petak", "Subota", "Nedelja" };
            for (int i = 0; i < 7; i++)
            {
                DateTime d = pocetakNedelje.AddDays(i);
                dgv.Columns[i + 1].HeaderText = $"{dani[i]}{Environment.NewLine}{d:dd.MM.yyyy.}";
            }
            lblNedelja.Text = $"{pocetakNedelje:dd.MM.} – {pocetakNedelje.AddDays(6):dd.MM.yyyy.}";
        }

        // ---------- interakcija ----------
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            var celija = uc.dgvRezervacije.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (celija.Tag is Rezervacija r)
            {
                new FrmDetaljiRezervacije(r).ShowDialog();
                Ucitaj();   // osveži posle eventualne izmene/storna
            }
        }

        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            DateTime sada = DateTime.Now;
            if (sada < pocetakNedelje || sada >= pocetakNedelje.AddDays(7)) return;  // "sada" nije u prikazanoj nedelji

            int redSad = sada.Hour - PrviSat;
            int kolonaSad = ((int)sada.DayOfWeek + 6) % 7 + 1;

            if (e.RowIndex == redSad && e.ColumnIndex == kolonaSad)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);   // prvo normalno (status-boja ostaje)
                using (var pen = new Pen(Color.FromArgb(0, 120, 215), 2))
                {
                    Rectangle rct = e.CellBounds;
                    rct.Width -= 1; rct.Height -= 1;
                    e.Graphics.DrawRectangle(pen, rct);              // pa plava ivica preko
                }
                e.Handled = true;
            }
        }

        private static DateTime PocetakNedelje(DateTime d)
        {
            int pomeraj = ((int)d.DayOfWeek + 6) % 7;   // Pon=0 ... Ned=6
            return d.Date.AddDays(-pomeraj);
        }
    }
}