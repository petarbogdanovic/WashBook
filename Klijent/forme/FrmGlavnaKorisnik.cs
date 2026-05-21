using Klijent.GuiControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Klijent
{
    public partial class FrmGlavnaKorisnik : Form
    {
        private Button aktivnoDugme;
        public FrmGlavnaKorisnik()
        {
            InitializeComponent();
            MainCoordinator.Instanca.RegistrujFrmGlavnaKorisnik(this);

            
        }

        private void btnMojeRezervacije_Click(object sender, EventArgs e)
        {
            PostaviAktivnoDugme(btnMojeRezervacije);
            PrikaziKontrol((UserControl)MojeRezervacijeGuiController.Instance.CreateUC());
        }

        private void btnNovaRezervacija_Click(object sender, EventArgs e)
        {

            PostaviAktivnoDugme(btnNovaRezervacija);
            PrikaziKontrol((UserControl)NovaRezGuiController.Instance.CreateUC());
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Da li ste sigurni da želite da se odjavite?",
                "Odjava", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                MainCoordinator.Instanca.Odjavi();
        }

        private void FrmGlavnaKorisnik_Load(object sender, EventArgs e)
        {
            Korisnik k = MainCoordinator.Instanca.PrijavljeniKorisnik;
            lblKorisnik.Text = $"{k.Ime} {k.Prezime}";
            PrikaziKontrol((UserControl)MojeRezervacijeGuiController.Instance.CreateUC());
            PostaviAktivnoDugme(btnMojeRezervacije);
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
    }
}
