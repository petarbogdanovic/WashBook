using DBBroker;
using Microsoft.Data.SqlClient;
using System.Data;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Sistemske_operacije
{
    public class VratiZauzetTermineSO : BaseSO
    {
        private readonly RezervacijaKriterijum kriterijum;
        public List<DateTime> Result { get; set; }

        public VratiZauzetTermineSO(IBroker broker, RezervacijaKriterijum kriterijum) : base(broker) 
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {

            List<string> uslovi = new()
            {
                "CAST(r.termin AS DATE) = @datum",
                "r.statusRezervacije != 'STORNIRANA'"
            };
            
            List<SqlParameter> parametri = new()
            {
                new SqlParameter("@datum", SqlDbType.Date) { Value = kriterijum.Datum.Value.Date }
            };

            if (kriterijum.IdPerionica.HasValue)
            {
                uslovi.Add("r.idRadnik IN (SELECT idRadnik FROM RadnikPerionica WHERE idPerionica = @idPerionica)");
                parametri.Add(new SqlParameter("@idPerionica", kriterijum.IdPerionica.Value));
            }
            else
            {
                uslovi.Add("r.idRadnik IN (SELECT idRadnik FROM RadnikPerionica WHERE idPerionica IN " +
                           "(SELECT idPerionica FROM RadnikPerionica WHERE idRadnik = @idRadnik))");
                parametri.Add(new SqlParameter("@idRadnik", kriterijum.IdRadnik.Value));
            }

            string where = string.Join(" AND ", uslovi);
            Result = broker.Get(new Rezervacija(), where, parametri.ToArray())
                           .Cast<Rezervacija>()
                           .Select(r => r.Termin)
                           .ToList();
        }
    }
}
