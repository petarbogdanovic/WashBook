using Klijent.forme;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class MojeRezervacijeGuiController
    {
        
        private static MojeRezervacijeGuiController instance;
        public static MojeRezervacijeGuiController Instance => instance ??= new MojeRezervacijeGuiController();
       
        private MojeRezervacijeGuiController() { }

        private UcMojeRezervacije uc;

        public Control CreateUC()
        {
            uc = new UcMojeRezervacije();
            PostaviNaslov();

            StilTabele.Primeni(uc.dgvRezervacije);

            uc.btnRefresh.Click += BtnRefresh_Click;
            uc.dgvRezervacije.CellDoubleClick += DgvRezervacije_CellDoubleClick;
            uc.dgvRezervacije.DataBindingComplete += DgvRezervacije_DataBindingComplete;

            UcitajRezervacije();

            return uc;
        }

        private void DgvRezervacije_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow red in uc.dgvRezervacije.Rows)
            {
                if (!(red.DataBoundItem is Rezervacija r)) continue;

                Color boja = StilTabele.BojaStatusa(r);
                red.DefaultCellStyle.BackColor = boja;
                red.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(boja, 0.1f);
                red.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
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
                RezervacijaKriterijum kriterijum = new RezervacijaKriterijum
                {
                    IdKorisnik = MainCoordinator.Instanca.PrijavljeniKorisnik.IdKorisnik
                };


                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiListuRezervacija, kriterijum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Rezervacija> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Rezervacija>>(odgovor.Objekat)
                    .OrderByDescending(r => r.Termin)
                    .ToList();

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

            string[] vidljive = { "Termin", "ImeRadnika", "StatusRezervacije", "Registracija" };
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
            if (uc.dgvRezervacije.Columns.Contains("Registracija"))
                uc.dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            UcitajRezervacije();
        }

        private void DgvRezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Rezervacija izabrana = (Rezervacija)uc.dgvRezervacije.Rows[e.RowIndex].DataBoundItem;

            new FrmDetaljiRezervacije(izabrana).ShowDialog();

            UcitajRezervacije();
        }

       
    }
}