using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
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

        public static Mock<IBroker> BrokerSaRezervacijom(Rezervacija rezervacija)
        {
            var broker = new Mock<IBroker>();
            broker.Setup(b => b.Get(
                    It.Is<IEntity>(e => e is Rezervacija),
                    It.IsAny<string>(),
                    It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { rezervacija });
            return broker;
        }
    }
}
