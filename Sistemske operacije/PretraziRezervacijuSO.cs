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

            // Header sa imenima radnika i korisnika
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

            // Sve stavke sa nazivom usluge
            string stavkeCmd = $@"
                SELECT st.*, u.naziv AS nazivUsluge
                FROM StavkaRezervacije st
                JOIN Usluga u ON u.idUsluga = st.idUsluga
                WHERE st.idRezervacija = {idRezervacija}";

            rezervacija.Stavke = broker.Get(stavkeCmd, new StavkaRezervacije())
                .Cast<StavkaRezervacije>()
                .ToList();

            // Sve podstavke odjednom, pa ih razvrstamo po rbStavka
            string ssCmd = $@"
                SELECT ss.*, tv.naziv AS nazivTipVozila
                FROM SStavkaRezervacije ss
                JOIN TipVozila tv ON tv.idTipVozila = ss.idTipVozila
                WHERE ss.idRezervacija = {idRezervacija}";

            List<SStavkaRezervacije> sveSStavke = broker.Get(ssCmd, new SStavkaRezervacije())
                .Cast<SStavkaRezervacije>()
                .ToList();

            foreach (StavkaRezervacije stavka in rezervacija.Stavke)
                stavka.SStavke = sveSStavke.Where(ss => ss.RbStavka == stavka.RbStavka).ToList();

            Result = rezervacija;
        }
    }
}
