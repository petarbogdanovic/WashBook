using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiPerionicuZaRadnikaSO : BaseSO
    {
        private int idRadnik;
        public List<RadnikPerionica> Result { get; set; }

        public VratiPerionicuZaRadnikaSO(IBroker broker, int idRadnik) : base(broker)
        {
            this.idRadnik = idRadnik;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get(new RadnikPerionica(), "rp.idRadnik = @idRadnik",
                new SqlParameter("@idRadnik", idRadnik))
                .Cast<RadnikPerionica>().ToList();
        }
    }
}
