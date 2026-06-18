using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiPerionicuZaRadnikaSO : BaseSO
    {
        private int idRadnik;
        public List<RadnikPerionica> Result { get; set; }

        public VratiPerionicuZaRadnikaSO(int idRadnik)
        {
            this.idRadnik = idRadnik;
        }
        protected override void ExecuteConcreteOperation()
        {
            string cmdText = $@"
                    SELECT rp.idRadnik, rp.idPerionica, rp.smena, p.naziv AS nazivPerionica, p.adresa AS adresaPerionica
                    FROM RadnikPerionica rp
                    JOIN Perionica p ON rp.idPerionica = p.idPerionica
                    WHERE rp.idRadnik = @idRadnik";

            Result = broker.Get(cmdText, new RadnikPerionica(), 
                new SqlParameter("@idRadnik", idRadnik))
                .Cast<RadnikPerionica>().ToList();
        }
    }
}
