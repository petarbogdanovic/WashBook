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
        public FrmGlavnaKorisnik()
        {
            InitializeComponent();
            MainCoordinator.Instanca.RegistrujFrmGlavnaKorisnik(this);


        }

        private void btnMojeRezervacije_Click(object sender, EventArgs e) => MainCoordinator.Instanca.ShowMojeRezervacije(sender, e);
        

        private void btnNovaRezervacija_Click(object sender, EventArgs e) => MainCoordinator.Instanca.ShowNovaRezervacijaKorisnik(sender, e);
      

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
            MainCoordinator.Instanca.ShowMojeRezervacije(sender, e);
        }

       
        public void PrikaziKontrol(UserControl uc)
        {
            pnlSadrzaj.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlSadrzaj.Controls.Add(uc);
        }

        private void FrmGlavnaKorisnik_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !NovaRezGuiController.Instance.MozeNapustiti())
            {
                e.Cancel = true;  
            }
        }
    }
}
