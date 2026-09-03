using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiRadnikaSO : BaseSO
    {
        private Radnik radnik;
        private Radnik prijavljeni;

        public ObrisiRadnikaSO(IBroker broker, Radnik radnik, Radnik prijavljeni) : base(broker)
        {
            this.radnik = radnik;
            this.prijavljeni = prijavljeni;
        }

        protected override void ExecuteConcreteOperation()
        {
            Autorizacija.ProveriMenadzera(broker, prijavljeni);

            if (radnik.IdRadnik == prijavljeni.IdRadnik)
                throw new Exception("Menadžer ne može obrisati sopstveni nalog.");

            List<IEntity> nadjeni = broker.Get(
                new Radnik(),
                "r.idRadnik = @idr",
                new SqlParameter("@idr", radnik.IdRadnik));

            if (nadjeni.Count == 0)
                throw new Exception("Radnik ne postoji.");

            Radnik izBaze = (Radnik)nadjeni[0];

            List<IEntity> rezervacije = broker.Get(
                new Rezervacija(),
                "r.idRadnik = @idr",
                new SqlParameter("@idr", radnik.IdRadnik));

            if (rezervacije.Count > 0)
                throw new Exception("Radnik ima evidentirane rezervacije i ne može biti obrisan.");

            

            List<IEntity> dodele = broker.Get(
                new RadnikPerionica(),
                "rp.idRadnik = @idr",
                new SqlParameter("@idr", radnik.IdRadnik));

            foreach (RadnikPerionica d in dodele)
                broker.Delete(d);

            broker.Delete(izBaze);
        }
    }
}
