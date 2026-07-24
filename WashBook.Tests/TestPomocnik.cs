using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public static class TestPomocnik
    {
        public const int IdPrijavljenog = 1;

        public static Radnik Prijavljeni =>
            new Radnik { IdRadnik = IdPrijavljenog, JeMenadzer = true };

        public static void PodesiPrijavljenog(Mock<IBroker> broker, bool jeMenadzer = true)
        {
            broker.Setup(b => b.Get(
                    It.Is<IEntity>(e => e is Radnik),
                    "r.idRadnik = @id",
                    It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>
                  {
                      new Radnik { IdRadnik = IdPrijavljenog, JeMenadzer = jeMenadzer }
                  });
        }
    }
}
