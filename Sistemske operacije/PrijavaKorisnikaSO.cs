using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;
using Microsoft.Data.SqlClient;
using DBBroker;

namespace Sistemske_operacije
{
    public class PrijavaKorisnikaSO : BaseSO
    {
        private string korisnickoIme;
        private string sifra;
        public Korisnik Result { get; set; }

        public PrijavaKorisnikaSO(IBroker broker, string korisnickoIme, string sifra) : base(broker)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteConcreteOperation()
        {

            List<IEntity> lista = broker.Get(new Korisnik(),
                "korisnickoIme = @kime AND sifra = @sifra",
                new SqlParameter("@kime", korisnickoIme),
                new SqlParameter("@sifra", sifra));

            Result = lista.Cast<Korisnik>().FirstOrDefault()
                ?? throw new Exception("Korisničko ime ili šifra nisu ispravni.");
        }
    }
}
