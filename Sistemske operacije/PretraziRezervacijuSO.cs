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

        public PretraziRezervacijuSO(int idRezervacija)
        {
            this.idRezervacija = idRezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            string headerCmd = $@"
                SELECT r.*,
                       ra.ime AS imeRadnika, ra.prezime AS prezimeRadnika,
                       k.ime AS imeKorisnika, k.prezime AS prezimeKorisnika
                FROM Rezervacija r
                JOIN Radnik ra ON r.idRadnik = ra.idRadnik
                JOIN Korisnik k ON r.idKorisnik = k.idKorisnik
                WHERE r.idRezervacija = {idRezervacija}";

            Rezervacija rezervacija = broker.Get(headerCmd, new Rezervacija())
                .Cast<Rezervacija>()
                .FirstOrDefault()
                ?? throw new Exception($"Rezervacija sa ID {idRezervacija} nije pronađena.");

            string stavkeCmd = $@"
                SELECT st.*, u.naziv AS nazivUsluga
                FROM StavkaRezervacije st
                JOIN Usluga u ON u.idUsluga = st.idUsluga
                WHERE st.idRezervacija = {idRezervacija}";

            rezervacija.Stavke = broker.Get(stavkeCmd, new StavkaRezervacije())
                .Cast<StavkaRezervacije>()
                .ToList();

            Result = rezervacija;
        }
    }
}
