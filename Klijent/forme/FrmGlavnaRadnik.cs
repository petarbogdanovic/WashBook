using Klijent.GuiControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Klijent
{
    public partial class FrmGlavnaRadnik : Form
    {
        private Button aktivnoDugme;
        public FrmGlavnaRadnik()
        {
            InitializeComponent();
            MainCoordinator.Instanca.RegistrujFrmGlavnaRadnik(this);
        }


        private void FrmGlavnaRadnik_Load(object sender, EventArgs e)
        {
            Radnik r = MainCoordinator.Instanca.PrijavljeniRadnik;
            lblKorisnik.Text = $"{r.Ime} {r.Prezime}";
            PrikaziPerionicu(r);
            PrikaziKontrol((UserControl)SveRezervacijeGuiController.Instance.CreateUC());
            PostaviAktivnoDugme(btnSveRezervacije);
        }

        private void PrikaziPerionicu(Radnik r)
        {
            RadnikPerionica rp = MainCoordinator.Instanca.PrijavljenaRadnikPerionica;
            if (rp != null)
            {
                lblKorisnik.Text = $"{r.Ime} {r.Prezime} | {rp.NazivPerionica} (smena {rp.Smena})";
            }
        }

        private void PostaviAktivnoDugme(Button btn)
        {
            if (aktivnoDugme != null)
            {
                aktivnoDugme.BackColor = Color.Transparent;
                aktivnoDugme.ForeColor = Color.FromArgb(200, 220, 240);
            }
            aktivnoDugme = btn;
            aktivnoDugme.BackColor = Color.FromArgb(46, 134, 222);
            aktivnoDugme.ForeColor = Color.White;
        }

        public void PrikaziKontrol(UserControl uc)
        {
            pnlSadrzaj.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlSadrzaj.Controls.Add(uc);
        }



        private void btnSveRezervacije_Click(object sender, EventArgs e)
        {
            PostaviAktivnoDugme(btnSveRezervacije);
            PrikaziKontrol((UserControl)SveRezervacijeGuiController.Instance.CreateUC());
        }

        private void btnNovaRezervacija_Click(object sender, EventArgs e)
        {
            PostaviAktivnoDugme(btnNovaRezervacija);
            PrikaziKontrol((UserControl)NovaRezGuiController.Instance.CreateUC());
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            PostaviAktivnoDugme(btnPretraga);
            PrikaziKontrol((UserControl)PretragaGuiController.Instance.CreateUC());
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
               "Da li ste sigurni da želite da se odjavite?",
               "Odjava", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                MainCoordinator.Instanca.Odjavi();
        }
    }
}
