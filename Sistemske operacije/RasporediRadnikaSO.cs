using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class RasporediRadnikaSO : BaseSO
    {
        private RadnikPerionica dodela;
        private Radnik prijavljeni;

        public RadnikPerionica Result { get; set; }

        public RasporediRadnikaSO(IBroker broker, RadnikPerionica dodela, Radnik prijavljeni) : base(broker)
        {
            this.dodela = dodela;
            this.prijavljeni = prijavljeni;
        }

        protected override void ExecuteConcreteOperation()
        {
            Autorizacija.ProveriMenadzera(broker, prijavljeni);


            List<IEntity> nadjeniRadnici = broker.Get(
                new Radnik(),
                "r.idRadnik = @idr",
                new SqlParameter("@idr", dodela.IdRadnik));

            if (nadjeniRadnici.Count == 0)
                throw new Exception("Radnik ne postoji.");

            List<IEntity> nadjenePerionice = broker.Get(
                new Perionica(),
                "idPerionica = @idp",
                new SqlParameter("@idp", dodela.IdPerionica));

            if (nadjenePerionice.Count == 0)
                throw new Exception("Perionica ne postoji.");

            List<IEntity> postojeca = broker.Get(
                new RadnikPerionica(),
                "rp.idRadnik = @idr",
                new SqlParameter("@idr", dodela.IdRadnik));

            foreach (RadnikPerionica stara in postojeca)
                broker.Delete(stara);

            broker.Add(dodela);

            Result = dodela;
        }
    }
}
