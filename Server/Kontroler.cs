using DBBroker;
using Sistemske_operacije;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using Zajednicki.Servisi;

namespace Server
{
    public class Kontroler
    {
        private static Kontroler instance;

        public static Kontroler Instance => instance ??= new Kontroler();

        private Kontroler() { }

        public Radnik PrijaviRadnika(string korisnickoIme, string sifra)
        {
            IBroker broker = new Broker();
            PrijaviRadnikaSO so = new PrijaviRadnikaSO(broker,korisnickoIme, sifra);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Korisnik PrijaviKorisnika(string korisnickoIme, string sifra)
        {
            IBroker broker = new Broker();
            PrijavaKorisnikaSO so = new PrijavaKorisnikaSO(broker, korisnickoIme, sifra);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Radnik> VratiSveRadnike()
        {
            IBroker broker = new Broker();
            VratiSveRadnikeSO so = new VratiSveRadnikeSO(broker);
            so.ExecuteTemplate();
            return so.Result.Cast<Radnik>().ToList();
        }

        public List<Usluga> VratiSveUsluge()
        {
            IBroker broker = new Broker();
            VratiSveUslugeSO so = new VratiSveUslugeSO(broker);
            so.ExecuteTemplate();
            return so.Result;
        }

      
        public List<DateTime> VratiZauzetTermine(RezervacijaKriterijum kriterijum)
        {
            IBroker broker = new Broker();
            VratiZauzetTermineSO so = new VratiZauzetTermineSO(broker, kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Rezervacija KreirajRezervaciju()
        {
            IBroker broker = new Broker();
            KreirajRezervacijuSO so = new KreirajRezervacijuSO(broker);
            so.ExecuteTemplate();
            return so.Result;
        }
        public void UbaciRezervaciju(Rezervacija rezervacija)
        {
            IBroker broker = new Broker();
            IEmailServis emailServis = new EmailServis();
            UbaciRezervacijuSO so = new UbaciRezervacijuSO(broker, emailServis, rezervacija);
            so.ExecuteTemplateIObavesti();
        }


        public void ObrisiRezervaciju(Rezervacija rezervacija)
        {
            IBroker broker = new Broker();
            ObrisiRezervacijuSO so = new ObrisiRezervacijuSO(broker,rezervacija);
            so.ExecuteTemplate();
        }

        public void StornirajRezervaciju(int idRezervacije, Radnik prijavljeniRadnik, Korisnik prijavljeniKorisnik)
        {
            IBroker broker = new Broker();
            IEmailServis emailServis = new EmailServis();
            StornirajRezervacijuSO so = new StornirajRezervacijuSO(broker, emailServis, idRezervacije,prijavljeniRadnik, prijavljeniKorisnik);
            so.ExecuteTemplateIObavesti();
        }

        public Rezervacija PretraziRezervaciju(int idRezervacija)
        {
            IBroker broker = new Broker();
            PretraziRezervacijuSO so = new PretraziRezervacijuSO(broker, idRezervacija);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Rezervacija> VratiListuRezervacija(RezervacijaKriterijum kriterijum)
        {
            IBroker broker = new Broker();
            VratiListuRezervacijaSO so = new VratiListuRezervacijaSO(broker, kriterijum);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Korisnik> VratiSveKorisnike()
        {
            IBroker broker = new Broker();
            VratiSveKorisnikeSO so = new VratiSveKorisnikeSO(broker);
            so.ExecuteTemplate();
            return so.Result.Cast<Korisnik>().ToList();
        }

        public List<RadnikPerionica> VratiPerionicaZaRadnika(int idRadnik)
        {
            IBroker broker = new Broker();
            VratiPerionicuZaRadnikaSO so = new VratiPerionicuZaRadnikaSO(broker, idRadnik);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void IzmeniRezervaciju(Rezervacija rezervacija, Radnik prijavljeniRadnik, Korisnik prijavljeniKorisnik)
        {
            IBroker broker = new Broker();
            IEmailServis emailServis = new EmailServis();
            IzmeniRezervacijuSO so = new IzmeniRezervacijuSO(broker, emailServis, rezervacija,prijavljeniRadnik, prijavljeniKorisnik);
            so.ExecuteTemplateIObavesti();
        }

        public Perionica KreirajPerionicu(Perionica perionica, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            KreirajPerionicuSO so = new KreirajPerionicuSO(broker, perionica, prijavljeni);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Perionica> VratiSvePerionice()
        {
            IBroker broker = new Broker();
            VratiSvePerioniceSO so = new VratiSvePerioniceSO(broker);
            so.ExecuteTemplate();
            return so.Result;
        }

        public Radnik KreirajRadnika(Radnik noviRadnik, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            KreirajRadnikaSO so = new KreirajRadnikaSO(broker, noviRadnik, prijavljeni);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void RasporediRadnika(RadnikPerionica dodela, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            RasporediRadnikaSO so = new RasporediRadnikaSO(broker, dodela, prijavljeni);
            so.ExecuteTemplate();
        }

        public void PromeniSmenu(RadnikPerionica dodela, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            PromeniSmenuSO so = new PromeniSmenuSO(broker, dodela, prijavljeni);
            so.ExecuteTemplate();
        }

        public void ObrisiRadnika(Radnik radnik, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            ObrisiRadnikaSO so = new ObrisiRadnikaSO(broker, radnik, prijavljeni);
            so.ExecuteTemplate();
        }

        public List<Rezervacija> VratiRezervacijeZaPeriod(RezervacijaKriterijum kriterijum, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            VratiRezervacijeZaPeriodSO so = new VratiRezervacijeZaPeriodSO(broker, kriterijum, prijavljeni);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void ObradiRezervaciju(int idRezervacije, Radnik prijavljeni)
        {
            IBroker broker = new Broker();
            IEmailServis emailServis = new EmailServis();
            ObradiRezervacijuSO so = new ObradiRezervacijuSO(broker, emailServis, idRezervacije, prijavljeni);
            so.ExecuteTemplateIObavesti();
        }
    }
}
