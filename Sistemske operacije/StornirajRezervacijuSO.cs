using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace Sistemske_operacije
{
    public class StornirajRezervacijuSO : BaseSO
    {
        private int idRezervacije;
        private Radnik prijavljeniRadnik;
        private Korisnik prijavljeniKorisnik;
        private IEmailServis emailServis;

        private Rezervacija rezervacija;
        private string emailPrimaoca;

        public StornirajRezervacijuSO(IBroker broker, IEmailServis emailServis, int idRezervacije,
                                      Radnik prijavljeniRadnik, Korisnik prijavljeniKorisnik)
            : base(broker)
        {
            this.emailServis = emailServis;
            this.idRezervacije = idRezervacije;
            this.prijavljeniRadnik = prijavljeniRadnik;
            this.prijavljeniKorisnik = prijavljeniKorisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.Get(
                new Rezervacija(),
                "r.idRezervacija = @idr",
                new SqlParameter("@idr", idRezervacije));

            if (lista == null || lista.Count == 0)
                throw new Exception("Rezervacija nije pronađena.");

            rezervacija = (Rezervacija)lista[0];

            Autorizacija.ProveriPristupRezervaciji(rezervacija, prijavljeniRadnik, prijavljeniKorisnik);

            if (rezervacija.StatusRezervacije != StatusRezervacije.KREIRANA)
                throw new Exception("Nije moguće stornirati rezervaciju koja nije u statusu KREIRANA.");

            if (rezervacija.Termin < DateTime.Now)
                throw new Exception("Nije moguće stornirati rezervaciju čiji je termin prošao.");

            rezervacija.StatusRezervacije = StatusRezervacije.STORNIRANA;
            broker.Update(rezervacija);

            emailPrimaoca = PomocnikObavestenja.UcitajEmail(broker, rezervacija.Korisnik);
        }

        protected override void PosleCommita()
        {
            if (string.IsNullOrWhiteSpace(emailPrimaoca)) return;

            EmailPrilog prilog = IcsGenerator.Kreiraj(
                rezervacija,
                emailServis.AdresaPosiljaoca,
                emailPrimaoca,
                sekvenca: 1,
                IcsMetod.CANCEL);

            emailServis.Posalji(emailPrimaoca, SastaviNaslov(), SastaviTelo(), prilog);
        }

        private string SastaviNaslov() => $"Storniranje rezervacije #{rezervacija.IdRezervacija}";

        private string SastaviTelo() =>
            "Poštovani,\n\n" +
            $"Vaša rezervacija za termin {rezervacija.Termin:dd.MM.yyyy HH:mm} je stornirana.\n" +
            "Događaj je uklonjen iz vašeg kalendara.\n\n" +
            "Hvala što koristite WashBook.";
    }
}