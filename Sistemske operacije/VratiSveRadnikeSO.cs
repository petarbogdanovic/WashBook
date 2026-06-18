using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveRadnikeSO : BaseSO
    {
        public List<Radnik> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            string cmdText = @"SELECT r.*,
                       p.idPerionica AS idPerionica,
                       p.naziv       AS nazivPerionica,
                       p.adresa      AS adresaPerionica,
                       rp.smena      AS smena
                FROM Radnik r
                LEFT JOIN RadnikPerionica rp ON r.idRadnik = rp.idRadnik
                LEFT JOIN Perionica p ON rp.idPerionica = p.idPerionica";

            Result = broker.Get(cmdText, new Radnik()).Cast<Radnik>().ToList();

        }
    }
}
