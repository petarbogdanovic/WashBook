using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiListuRezervacijaSO : BaseSO
    {
        private string condition;
        public List<Rezervacija> Result { get; set; }

        public VratiListuRezervacijaSO(string condition)
        {
            this.condition = condition;
        }

        protected override void ExecuteConcreteOperation()
        {
            string cmdText = $@"
                        SELECT r.*,
                               ra.ime as imeRadnika, ra.prezime as prezimeRadnika,
                               k.ime as imeKorisnika, k.prezime as prezimeKorisnika,
                        FROM Rezervacija r
                        JOIN Radnik ra ON r.idRadnik = ra.idRadnik
                        JOIN Korisnik k ON r.idKorisnik = k.idKorisnik
                        WHERE {condition}";

            Result = broker.Get(cmdText, new Rezervacija()).Cast<Rezervacija>().ToList();
        }
    }
}
