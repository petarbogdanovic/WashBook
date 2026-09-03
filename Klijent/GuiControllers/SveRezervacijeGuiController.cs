using Klijent.forme;
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
        private const int PoslednjiSat = 18;                        
        private const int BrojRedova = PoslednjiSat - PrviSat + 1;  

        private DateTime pocetakNedelje;   
        private int idRadnikPrikaz;        

        private Button btnPrethodna, btnSledeca, btnOsvezi;
        private Label lblNedelja;
        private ComboBox cmbRadnik;        

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

        private void PripremiGrid()
        {
            

            var dgv = uc.dgvRezervacije;

            StilTabele.PrimeniZaglavlje(dgv);   
            dgv.AutoGenerateColumns = false;
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();

            dgv.Rows.Clear();
            for (int sat = PrviSat; sat <= PoslednjiSat; sat++)
            {
                int idx = dgv.Rows.Add();
                dgv.Rows[idx].Cells[0].Value = $"{sat:00}:00";
            }

        }


        private void IzgradiZaglavlje()
        {
          

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

                UcitajRadnike();                       
                traka.Controls.Add(cmbRadnik);

                Radnik meni = radniciCache?.FirstOrDefault(r => r.IdRadnik == idRadnikPrikaz);
                if (meni != null)
                    cmbRadnik.SelectedItem = meni;
                else if (cmbRadnik.Items.Count > 0)
                    cmbRadnik.SelectedIndex = 0;

                cmbRadnik.SelectedIndexChanged += CmbRadnik_SelectedIndexChanged;
            }

            uc.dgvRezervacije.Dock = DockStyle.Fill;   
            uc.Controls.Add(traka);                    
            uc.Controls.SetChildIndex(traka, 0);       
            traka.Dock = DockStyle.Top;                
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

        private void Ucitaj()
        {
            if (inicijalizacija) return;
            try
            {
                RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
                {
                    IdRadnik = idRadnikPrikaz,
                    DatumOd = pocetakNedelje,
                    DatumDo = pocetakNedelje.AddDays(7)   
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
                if (red < 0 || red >= BrojRedova) continue;   

                int kolona = ((int)r.Termin.DayOfWeek + 6) % 7 + 1;  

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
                return Color.FromArgb(247, 136, 146);   
            if (r.StatusRezervacije == StatusRezervacije.OBRADJENA)
                return Color.FromArgb(255, 243, 205);    
            if (r.Termin < DateTime.Now)
                return Color.FromArgb(255, 243, 205);    
            return Color.FromArgb(212, 237, 218);        
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

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            var celija = uc.dgvRezervacije.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (celija.Tag is Rezervacija r)
            {
                new FrmDetaljiRezervacije(r).ShowDialog();
                Ucitaj();  
            }
        }

        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            DateTime sada = DateTime.Now;
            if (sada < pocetakNedelje || sada >= pocetakNedelje.AddDays(7)) return;  

            int redSad = sada.Hour - PrviSat;
            int kolonaSad = ((int)sada.DayOfWeek + 6) % 7 + 1;

            if (e.RowIndex == redSad && e.ColumnIndex == kolonaSad)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);   
                using (var pen = new Pen(Color.FromArgb(0, 120, 215), 2))
                {
                    Rectangle rct = e.CellBounds;
                    rct.Width -= 1; rct.Height -= 1;
                    e.Graphics.DrawRectangle(pen, rct);              
                }
                e.Handled = true;
            }
        }

        private static DateTime PocetakNedelje(DateTime d)
        {
            int pomeraj = ((int)d.DayOfWeek + 6) % 7;   
            return d.Date.AddDays(-pomeraj);
        }
    }
}