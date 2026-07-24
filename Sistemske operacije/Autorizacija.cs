using DBBroker;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    internal static class Autorizacija
    {
        public static void ProveriMenadzera(IBroker broker, Radnik prijavljeni)
        {
            if (prijavljeni == null)
                throw new Exception("Operacija zahteva prijavljenog radnika.w");

            List<IEntity> lista = broker.Get(
                                new Radnik(),
                                "r.idRadnik = @id",
                                new SqlParameter("@id", prijavljeni.IdRadnik));

            if (lista == null || !((Radnik)lista[0]).JeMenadzer)
                throw new Exception("Operacija zahteva menadžerska ovlašćenja.");
        }
    }
}
