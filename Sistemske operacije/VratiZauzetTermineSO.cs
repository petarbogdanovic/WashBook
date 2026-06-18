using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Sistemske_operacije
{
    public class VratiZauzetTermineSO : BaseSO
    {
        private readonly RezervacijaKriterijum kriterijum;
        public List<DateTime> Result { get; set; }

        public VratiZauzetTermineSO(RezervacijaKriterijum kriterijum)
        {
            this.kriterijum = kriterijum;
        }

        protected override void ExecuteConcreteOperation()
        {

            string cmdText = @"
                SELECT r.*
                FROM Rezervacija r
                JOIN RadnikPerionica rp ON r.idRadnik = rp.idRadnik
                WHERE CAST(r.termin AS DATE) = @datum
                  AND r.statusRezervacije != 'STORNIRANA'
                  AND rp.idPerionica = @idPerionica";

            SqlParameter[] parametri = new[]
            {
                new SqlParameter("@datum", SqlDbType.Date) { Value = kriterijum.Datum.Value.Date },
                new SqlParameter("@idPerionica", kriterijum.IdPerionica.Value)
            };

            Result = broker.Get(cmdText, new Rezervacija(), parametri)
                           .Cast<Rezervacija>()
                           .Select(r => r.Termin)
                           .ToList();
        }
    }
}
