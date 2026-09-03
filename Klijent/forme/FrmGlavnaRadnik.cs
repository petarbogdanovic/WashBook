using Klijent.GuiControllers;
using Zajednicki.Domen;


namespace Klijent
{
    public partial class FrmGlavnaRadnik : Form
    {
        public FrmGlavnaRadnik()
        {
            InitializeComponent();
            MainCoordinator.Instanca.RegistrujFrmGlavnaRadnik(this);
        }


        private void FrmGlavnaRadnik_Load(object sender, EventArgs e)
        {
            Radnik r = MainCoordinator.Instanca.PrijavljeniRadnik;
            lblKorisnik.Text = $"{r.Ime} {r.Prezime}";
            btnUpravljanje.Visible = r.JeMenadzer;
            PrikaziPerionicu(r);
            MainCoordinator.Instanca.ShowSveRezervacije(sender, e);
        }

        private void PrikaziPerionicu(Radnik r)
        {
            RadnikPerionica rp = MainCoordinator.Instanca.PrijavljenaRadnikPerionica;
            if (rp != null)
            {
                lblKorisnik.Text = $"{r.Ime} {r.Prezime} | {rp.NazivPerionica} (smena {rp.Smena})";
            }
        }



        public void PrikaziKontrol(UserControl uc)
        {
            pnlSadrzaj.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlSadrzaj.Controls.Add(uc);
        }



        private void btnSveRezervacije_Click(object sender, EventArgs e) => MainCoordinator.Instanca.ShowSveRezervacije(sender, e);


        private void btnNovaRezervacija_Click(object sender, EventArgs e) => MainCoordinator.Instanca.ShowNovaRezervacijaRadnik(sender, e);


        private void btnPretraga_Click(object sender, EventArgs e) => MainCoordinator.Instanca.ShowPretraga(sender, e);

        private void btnUpravljanje_Click(object sender, EventArgs e) => MainCoordinator.Instanca.ShowUpravljanje(sender, e);



        private void btnOdjava_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
               "Da li ste sigurni da želite da se odjavite?",
               "Odjava", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                MainCoordinator.Instanca.Odjavi();
        }

        private void FrmGlavnaRadnik_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !NovaRezGuiController.Instance.MozeNapustiti())
            {
                e.Cancel = true;
            }
        }

    }
}
