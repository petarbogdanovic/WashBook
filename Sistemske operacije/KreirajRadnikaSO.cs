using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class KreirajRadnikaSO : BaseSO
    {
        private Radnik noviRadnik;
        private Radnik prijavljeni;

        public Radnik Result { get; set; }

        public KreirajRadnikaSO(IBroker broker, Radnik noviRadnik, Radnik prijavljeni) : base(broker)
        {
            this.noviRadnik = noviRadnik;
            this.prijavljeni = prijavljeni;
        }

        protected override void ExecuteConcreteOperation()
        {
            Autorizacija.ProveriMenadzera(broker, prijavljeni);

            if (string.IsNullOrWhiteSpace(noviRadnik.KorisnickoIme))
                throw new Exception("Korisničko ime ne sme biti prazno.");

            if (string.IsNullOrWhiteSpace(noviRadnik.Sifra))
                throw new Exception("Šifra ne sme biti prazna.");

            List<IEntity> postojeci = broker.Get(
                new Radnik(),
                "r.korisnickoIme = @ki",
                new SqlParameter("@ki", noviRadnik.KorisnickoIme));

            if (postojeci.Count > 0)
                throw new Exception("Radnik sa zadatim korisničkim imenom već postoji.");

            broker.Add(noviRadnik);
            noviRadnik.IdRadnik = broker.GetLastInsertedId("Radnik", "idRadnik");

            Result = noviRadnik;
        }
    }
}
