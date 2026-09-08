using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    internal static class Autorizacija
    {
        public static void ProveriMenadzera(IBroker broker, Radnik prijavljeni)
        {
            if (prijavljeni == null)
                throw new Exception("Operacija zahteva prijavljenog radnika.");

            List<IEntity> lista = broker.Get(
                                new Radnik(),
                                "r.idRadnik = @id",
                                new SqlParameter("@id", prijavljeni.IdRadnik));

            if (lista == null || !((Radnik)lista[0]).JeMenadzer)
                throw new Exception("Operacija zahteva menadžerska ovlašćenja.");
        }

        public static void ProveriPristupRezervaciji(Rezervacija izBaze,Radnik prijavljeniRadnik,Korisnik prijavljeniKorisnik)
        {
            if (prijavljeniRadnik != null) return;

            if (prijavljeniKorisnik == null)
                throw new Exception("Operacija zahteva prijavljenog korisnika ili radnika.");

            if (izBaze.Korisnik == null || izBaze.Korisnik.IdKorisnik != prijavljeniKorisnik.IdKorisnik)
                throw new Exception("Nije moguće menjati tuđu rezervaciju.");
        }
    }
}
