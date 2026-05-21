using System;
using System.Windows.Forms;
using Zajednicki.Domen;

namespace Klijent.GuiControllers
{
    public class MainCoordinator
    {
        // Singleton
        private static MainCoordinator instanca;
        public static MainCoordinator Instanca
        {
            get
            {
                if (instanca == null) instanca = new MainCoordinator();
                return instanca;
            }
        }
        private MainCoordinator() { }

        public Radnik PrijavljeniRadnik { get; set; }
        public Korisnik PrijavljeniKorisnik { get; set; }

       
        private FrmGlavnaRadnik frmGlavnaRadnik;
        private FrmGlavnaKorisnik frmGlavnaKorisnik;

        
        public void PrijaviRadnika(Radnik radnik)
        {
            PrijavljeniRadnik = radnik;
            PrijavljeniKorisnik = null;
            frmGlavnaRadnik = new FrmGlavnaRadnik();
            frmGlavnaRadnik.Show();
        }

        public void PrijaviKorisnika(Korisnik korisnik)
        {
            PrijavljeniKorisnik = korisnik;
            PrijavljeniRadnik = null;
            frmGlavnaKorisnik = new FrmGlavnaKorisnik();
            frmGlavnaKorisnik.Show();
        }

        public void Odjavi()
        {
            PrijavljeniRadnik = null;
            PrijavljeniKorisnik = null;
            frmGlavnaRadnik?.Close();
            frmGlavnaKorisnik?.Close();
            frmGlavnaRadnik = null;
            frmGlavnaKorisnik = null;

            FrmPrijava frmPrijava = new FrmPrijava();
            frmPrijava.Show();
        }

      
        public void RegistrujFrmGlavnaRadnik(FrmGlavnaRadnik frm) => frmGlavnaRadnik = frm;
        public void RegistrujFrmGlavnaKorisnik(FrmGlavnaKorisnik frm) => frmGlavnaKorisnik = frm;

        
        public void ShowSveRezervacije(object sender, EventArgs e)
        {
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)SveRezervacijeGuiController.Instance.CreateUC());
        }

        public void ShowNovaRezervacijaRadnik(object sender, EventArgs e)
        {
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)NovaRezGuiController.Instance.CreateUC());
        }

        public void ShowPretraga(object sender, EventArgs e)
        {
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)PretragaGuiController.Instance.CreateUC());
        }

   
        public void ShowMojeRezervacije(object sender, EventArgs e)
        {
            if (frmGlavnaKorisnik != null)
                frmGlavnaKorisnik.PrikaziKontrol((UserControl)MojeRezervacijeGuiController.Instance.CreateUC());
        }

        public void ShowNovaRezervacijaKorisnik(object sender, EventArgs e)
        {
            if (frmGlavnaKorisnik != null)
                frmGlavnaKorisnik.PrikaziKontrol((UserControl)NovaRezGuiController.Instance.CreateUC());
        }
    }
}