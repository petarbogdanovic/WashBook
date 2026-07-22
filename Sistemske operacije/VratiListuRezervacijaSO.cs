using DBBroker;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Sistemske_operacije
{
    public class VratiListuRezervacijaSO : BaseSO
    {
        private readonly RezervacijaKriterijum kriterijum;
        public List<Rezervacija> Result { get; set; }

        public VratiListuRezervacijaSO(IBroker broker, RezervacijaKriterijum condition) : base (broker)
        {
            this.kriterijum = condition;
        }

        protected override void ExecuteConcreteOperation()
        {
            
            List<string> uslovi = new();
            List<SqlParameter> parametri = new();

            if (kriterijum.IdPerionica.HasValue)
            {
                uslovi.Add("r.idRadnik IN (SELECT rp.idRadnik FROM RadnikPerionica rp WHERE rp.idPerionica = @idPerionica)");
                parametri.Add(new SqlParameter("@idPerionica", kriterijum.IdPerionica.Value));
            }
            if (kriterijum.IdKorisnik.HasValue)
            {
                uslovi.Add("r.idKorisnik = @idKorisnik");
                parametri.Add(new SqlParameter("@idKorisnik", kriterijum.IdKorisnik.Value));
            }
            if (kriterijum.Datum.HasValue)
            {
                uslovi.Add("CAST(r.termin AS DATE) = @datum");
                parametri.Add(new SqlParameter("@datum", SqlDbType.Date) { Value = kriterijum.Datum.Value.Date });
            }
            if (kriterijum.Status.HasValue)
            {
                uslovi.Add("r.statusRezervacije = @status");
                parametri.Add(new SqlParameter("@status", kriterijum.Status.Value.ToString()));
            }

            string where = uslovi.Count > 0 ? string.Join(" AND ", uslovi) : null;
            Result = broker.Get(new Rezervacija(), where, parametri.ToArray())
                           .Cast<Rezervacija>().ToList();

        }
    }
}
