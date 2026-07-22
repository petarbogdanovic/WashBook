using DBBroker;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PrijaviRadnikaSO : BaseSO
    {
        private string korisnickoIme;
        private string sifra;
        public Radnik Result { get; set; }

        public PrijaviRadnikaSO(IBroker broker,string korisnickoIme, string sifra) : base(broker)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteConcreteOperation()
        {

            List<IEntity> lista = broker.Get(new Radnik(),
               "r.korisnickoIme = @kime AND r.sifra = @sifra",
               new SqlParameter("@kime", korisnickoIme),
               new SqlParameter("@sifra", sifra));

            Result = lista.Cast<Radnik>().FirstOrDefault()
                ?? throw new Exception("Korisničko ime ili šifra nisu ispravni.");

        }
    }
}
