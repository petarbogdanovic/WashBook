using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace Sistemske_operacije
{
    public class IzmeniRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;
        private IEmailServis emailServis;
        private string emailPrimaoca;

        private Radnik prijavljeniRadnik;
        private Korisnik prijavljeniKorisnik;

        public IzmeniRezervacijuSO(IBroker broker, IEmailServis emailServis, Rezervacija rezervacija, Radnik prijavljeniRadnik, Korisnik prijavljeniKorisnik)
            : base(broker)
        {
            this.emailServis = emailServis;
            this.rezervacija = rezervacija;
            this.prijavljeniRadnik = prijavljeniRadnik;
            this.prijavljeniKorisnik = prijavljeniKorisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.Get(
                new Rezervacija(),
                "r.idRezervacija = @idr",
                new SqlParameter("@idr", rezervacija.IdRezervacija));

            if (lista == null || lista.Count == 0)
                throw new Exception("Rezervacija nije pronađena.");

            Rezervacija izBaze = (Rezervacija)lista[0];

            Autorizacija.ProveriPristupRezervaciji(izBaze, prijavljeniRadnik, prijavljeniKorisnik);

            

            if (izBaze.StatusRezervacije != StatusRezervacije.KREIRANA)
                throw new Exception("Izmena je moguća samo dok je rezervacija u statusu KREIRANA.");

            PomocnikTermina.ProveriSlobodan(broker, izBaze.Radnik.IdRadnik, rezervacija.Termin, rezervacija.IdRezervacija);

            rezervacija.StatusRezervacije = izBaze.StatusRezervacije;
            rezervacija.Korisnik = izBaze.Korisnik;
            rezervacija.Radnik = izBaze.Radnik;

            broker.Update(rezervacija);

            if (rezervacija.Stavke != null && rezervacija.Stavke.Count > 0)
            {
                List<IEntity> postojece = broker.Get(new StavkaRezervacije(), "st.idRezervacija = @id",
                    new SqlParameter("@id", rezervacija.IdRezervacija));

                foreach (IEntity s in postojece)
                    broker.Delete(s);

                int rb = 1;
                foreach (StavkaRezervacije stavka in rezervacija.Stavke)
                {
                    stavka.IdRezervacija = rezervacija.IdRezervacija;
                    stavka.RbStavka = rb++;
                    broker.Add(stavka);
                }
            }

            emailPrimaoca = PomocnikObavestenja.UcitajEmail(broker, izBaze.Korisnik);
        }

        protected override void PosleCommita()
        {
            if (string.IsNullOrWhiteSpace(emailPrimaoca)) return;

            emailServis.Posalji(emailPrimaoca, SastaviNaslov(), SastaviTelo());
        }

        private string SastaviNaslov() => $"Izmena rezervacije #{rezervacija.IdRezervacija}";

        private string SastaviTelo() =>
            "Poštovani,\n\n" +
            "Vaša rezervacija je izmenjena.\n" +
            $"Termin: {rezervacija.Termin:dd.MM.yyyy HH:mm}\n" +
            $"Broj stavki: {rezervacija.Stavke?.Count ?? 0}\n\n" +
            "Hvala što koristite WashBook.";

    }
}