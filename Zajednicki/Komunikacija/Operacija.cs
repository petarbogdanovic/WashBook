
namespace Zajednicki.Komunikacija
{
    public enum Operacija
    {
        // Radnik
        KreirajRadnika,
        PrijaviRadnika,
        VratiSveRadnike,
        RasporediRadnika,
        PromeniSmenu,
        ObrisiRadnika,

        // Korisnik
        PrijaviKorisnika,
        VratiSveKorisnike,

        // Rezervacija
        KreirajRezervaciju,
        UbaciRezervaciju,
        IzmeniRezervaciju,
        ObrisiRezervaciju,
        PretraziRezervaciju,
        VratiListuRezervacija,
        VratiZauzeteTermine,
        StornirajRezervaciju,
        VratiRezervacijeZaPeriod,
        ObradiRezervaciju,


        // Ostalo
        VratiSveUsluge,

        //Perionica
        KreirajPerionicu,
        VratiSvePerionice,
        VratiPerionicaZaRadnika

    }
}
