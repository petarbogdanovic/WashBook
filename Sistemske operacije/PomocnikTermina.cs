using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

internal static class PomocnikTermina
{
  
        public static void ProveriSlobodan(IBroker broker, int idRadnik, DateTime termin, int idRezervacija)
        {
            List<IEntity> zauzete = broker.Get(new Rezervacija(),
                "r.idRadnik = @idr AND r.termin = @termin " +
                "AND r.statusRezervacije <> 'STORNIRANA' " +
                "AND r.idRezervacija <> @idrez",
                new SqlParameter("@idr", idRadnik),
                new SqlParameter("@termin", termin),
                new SqlParameter("@idrez", idRezervacija));

            if (zauzete.Count > 0)
                throw new Exception("Termin je već zauzet.");
       }
    
}