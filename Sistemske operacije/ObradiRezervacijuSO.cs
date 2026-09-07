using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace Sistemske_operacije
{
    public class ObradiRezervacijuSO : BaseSO
    {
        private int idRezervacije;
        private Radnik prijavljeni;
        private IEmailServis emailServis;

        private Rezervacija rezervacija;
        private string emailPrimaoca;

        public ObradiRezervacijuSO(IBroker broker, IEmailServis emailServis,
                                   int idRezervacije, Radnik prijavljeni) : base(broker)
        {
            this.emailServis = emailServis;
            this.idRezervacije = idRezervacije;
            this.prijavljeni = prijavljeni;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (prijavljeni == null)
                throw new Exception("Operacija zahteva prijavljenog radnika.");

            List<IEntity> lista = broker.Get(
                new Rezervacija(),
                "r.idRezervacija = @idr",
                new SqlParameter("@idr", idRezervacije));

            if (lista == null || lista.Count == 0)
                throw new Exception("Rezervacija nije pronađena.");

            rezervacija = (Rezervacija)lista[0];

            if (rezervacija.Radnik.IdRadnik != prijavljeni.IdRadnik)
                Autorizacija.ProveriMenadzera(broker, prijavljeni);

            if (rezervacija.StatusRezervacije != StatusRezervacije.KREIRANA)
                throw new Exception("Obraditi se može samo rezervacija u statusu KREIRANA.");

            if (DateTime.Now < rezervacija.Termin.AddMinutes(50))
                throw new Exception("Rezervacija se može označiti kao obrađena najranije 10 minuta pre isteka termina.");

            rezervacija.StatusRezervacije = StatusRezervacije.OBRADJENA;
            broker.Update(rezervacija);

            emailPrimaoca = PomocnikObavestenja.UcitajEmail(broker, rezervacija.Korisnik);
        }

        protected override void PosleCommita()
        {
            if (string.IsNullOrWhiteSpace(emailPrimaoca)) return;

            emailServis.Posalji(emailPrimaoca, SastaviNaslov(), SastaviTelo());
        }

        private string SastaviNaslov() => $"Rezervacija #{rezervacija.IdRezervacija} je obrađena";

        private string SastaviTelo() =>
            "Poštovani,\n\n" +
            $"Vaša rezervacija za termin {rezervacija.Termin:dd.MM.yyyy HH:mm} je obrađena.\n\n" +
            "Hvala što koristite WashBook.";
    }
}