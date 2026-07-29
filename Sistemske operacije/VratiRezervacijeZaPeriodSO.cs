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
    public class VratiRezervacijeZaPeriodSO : BaseSO
    {
        private readonly RezervacijaKriterijum kriterijum;
        private readonly Radnik prijavljeni;
        public List<Rezervacija> Result { get; set; }


        public VratiRezervacijeZaPeriodSO(IBroker broker, RezervacijaKriterijum kriterijum, Radnik prijavljeni) : base(broker)
        {
            this.kriterijum = kriterijum;
            this.prijavljeni = prijavljeni;
        }
        protected override void ExecuteConcreteOperation()
        {
            if (prijavljeni == null)
                throw new Exception("Operacija zahteva prijavljenog radnika.");

            if (kriterijum.IdRadnik.Value != prijavljeni.IdRadnik)
                Autorizacija.ProveriMenadzera(broker, prijavljeni);

            string where =
                 "r.idRadnik = @idRadnik AND " +
                 "r.termin >= @datumOd AND " +
                 "r.termin < @datumDo";

            SqlParameter[] parametri =
            {
                new SqlParameter("@idRadnik", kriterijum.IdRadnik.Value),
                new SqlParameter("@datumOd", SqlDbType.DateTime) { Value = kriterijum.DatumOd.Value },
                new SqlParameter("@datumDo", SqlDbType.DateTime) { Value = kriterijum.DatumDo.Value }
            };

            Result = broker.Get(new Rezervacija(), where, parametri)
                           .Cast<Rezervacija>()
                           .ToList();
        }


    }
}
