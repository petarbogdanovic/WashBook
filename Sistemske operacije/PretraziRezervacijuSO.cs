using DBBroker;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PretraziRezervacijuSO : BaseSO
    {
        private int idRezervacija;
        public Rezervacija? Result { get; set; }

        public PretraziRezervacijuSO(IBroker broker, int idRezervacija) : base (broker)
        {
            this.idRezervacija = idRezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {

            Rezervacija rezervacija = broker.Get(new Rezervacija(), "r.idRezervacija = @id", new SqlParameter("@id", idRezervacija))
                .Cast<Rezervacija>().FirstOrDefault()  ?? throw new Exception($"Rezervacija sa ID {idRezervacija} nije pronađena.");

            rezervacija.Stavke = broker.Get(new StavkaRezervacije(), "st.idRezervacija = @id",
                    new SqlParameter("@id", idRezervacija))
                    .Cast<StavkaRezervacije>().ToList();

            Result = rezervacija;

        }
    }
}
