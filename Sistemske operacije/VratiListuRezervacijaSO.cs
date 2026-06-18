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

        public VratiListuRezervacijaSO(RezervacijaKriterijum condition)
        {
            this.kriterijum = condition;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<string> uslovi = new List<string>();
            List<SqlParameter> parametri = new List<SqlParameter>();

            string joinPerionica = "";
            if (kriterijum.IdPerionica.HasValue)
            {
                joinPerionica = "JOIN RadnikPerionica rp ON r.idRadnik = rp.idRadnik";
                uslovi.Add("rp.idPerionica = @idPerionica");
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

            string where = uslovi.Count > 0 ? string.Join(" AND ", uslovi) : "1=1";

            string cmdText = $@"
                SELECT r.*,
                       ra.ime AS imeRadnika, ra.prezime AS prezimeRadnika,
                       k.ime AS imeKorisnika, k.prezime AS prezimeKorisnika
                FROM Rezervacija r
                JOIN Radnik ra ON r.idRadnik = ra.idRadnik
                JOIN Korisnik k ON r.idKorisnik = k.idKorisnik
                {joinPerionica}
                WHERE {where}";

            Result = broker.Get(cmdText, new Rezervacija(), parametri.ToArray())
                           .Cast<Rezervacija>().ToList();
        }
    }
}
