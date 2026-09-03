using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class KreirajPerionicuSO : BaseSO
    {

        private Perionica perionica;
        private Radnik prijavljeni;

        public Perionica Result { get; set; }
        public KreirajPerionicuSO(IBroker broker, Perionica perionica, Radnik prijavljeni) : base(broker)
        {
            this.perionica = perionica;
            this.prijavljeni = prijavljeni;

        }

        protected override void ExecuteConcreteOperation()
        {
            Autorizacija.ProveriMenadzera(broker, prijavljeni);

            if (string.IsNullOrWhiteSpace(perionica.Naziv))
                throw new Exception("Naziv perionice ne sme biti prazan.");
            if (string.IsNullOrWhiteSpace(perionica.Adresa))
                throw new Exception("Adresa perionice ne sme biti prazna.");

            List<IEntity> postojece = broker.Get(
                new Perionica(),
                "naziv = @naziv",
                new SqlParameter("@naziv", perionica.Naziv));

            if (postojece.Count > 0)
                throw new Exception("Perionica sa zadatim nazivom već postoji.");

            broker.Add(perionica);

            perionica.IdPerionica = broker.GetLastInsertedId("Perionica", "idPerionica");

            Result = perionica;

        }
    }
}
