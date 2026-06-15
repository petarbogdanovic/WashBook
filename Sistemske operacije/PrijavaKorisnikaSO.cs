using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;
using Microsoft.Data.SqlClient;

namespace Sistemske_operacije
{
    public class PrijavaKorisnikaSO : BaseSO
    {
        private string korisnickoIme;
        private string sifra;
        public Korisnik Result { get; set; }

        public PrijavaKorisnikaSO(string korisnickoIme, string sifra)
        {
            this.korisnickoIme = korisnickoIme;
            this.sifra = sifra;
        }

        protected override void ExecuteConcreteOperation()
        {

            string cmdText = "SELECT * FROM Korisnik WHERE KorisnickoIme=@kime AND Sifra=@sifra";

            List<IEntity> lista = broker.Get(cmdText, new Korisnik(),
                new SqlParameter("@kime", korisnickoIme),
                new SqlParameter("@sifra", sifra));

            Result = lista.Cast<Korisnik>().FirstOrDefault() 
                ?? throw new Exception("Korisničko ime ili šifra nisu ispravni.");
        }
    }
}
