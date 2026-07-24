using System;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class MainCoordinator
    {
      
        private static MainCoordinator instanca;
        public static MainCoordinator Instanca => instanca ??= new MainCoordinator();
        private MainCoordinator() { }

        public Radnik PrijavljeniRadnik { get; set; }
        public Korisnik PrijavljeniKorisnik { get; set; }
        public RadnikPerionica PrijavljenaRadnikPerionica { get; set; }


        private FrmGlavnaRadnik frmGlavnaRadnik;
        private FrmGlavnaKorisnik frmGlavnaKorisnik;

        
        public void PrijaviRadnika(Radnik radnik)
        {
            PrijavljeniRadnik = radnik;
            PrijavljeniKorisnik = null;
            Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                Operacija.VratiPerionicaZaRadnika, radnik.IdRadnik);

            if (odgovor.Uspesno)
            {
                List<RadnikPerionica> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<RadnikPerionica>>(odgovor.Objekat);

                if (lista != null && lista.Count > 0)
                    PrijavljenaRadnikPerionica = lista[0];
            }
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
            NovaRezGuiController.Instance.ObrisiNesacuvanu();

            PrijavljeniRadnik = null;
            PrijavljeniKorisnik = null;
            PrijavljenaRadnikPerionica = null;
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
            if (!NovaRezGuiController.Instance.MozeNapustiti()) return;
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)SveRezervacijeGuiController.Instance.CreateUC());
        }

        public void ShowNovaRezervacijaRadnik(object sender, EventArgs e)
        {
            if (!NovaRezGuiController.Instance.MozeNapustiti()) return;
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)NovaRezGuiController.Instance.CreateUC());
        }

        public void ShowPretraga(object sender, EventArgs e)
        {
            if (!NovaRezGuiController.Instance.MozeNapustiti()) return;
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)PretragaGuiController.Instance.CreateUC());
        }

   
        public void ShowMojeRezervacije(object sender, EventArgs e)
        {
            if (!NovaRezGuiController.Instance.MozeNapustiti()) return;
            if (frmGlavnaKorisnik != null)
                frmGlavnaKorisnik.PrikaziKontrol((UserControl)MojeRezervacijeGuiController.Instance.CreateUC());
        }

        public void ShowNovaRezervacijaKorisnik(object sender, EventArgs e)
        {
            if (!NovaRezGuiController.Instance.MozeNapustiti()) return;
            if (frmGlavnaKorisnik != null)
                frmGlavnaKorisnik.PrikaziKontrol((UserControl)NovaRezGuiController.Instance.CreateUC());
        }

        public void ShowUpravljanje(object sender, EventArgs e)
        {
            if (!NovaRezGuiController.Instance.MozeNapustiti()) return;
            if (frmGlavnaRadnik != null)
                frmGlavnaRadnik.PrikaziKontrol((UserControl)UpravljanjeGuiController.Instance.CreateUC());
        }
    }
}