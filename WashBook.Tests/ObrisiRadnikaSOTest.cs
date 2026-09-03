using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class ObrisiRadnikaSOTest
    {
        private static void PodesiBazu(Mock<IBroker> broker, Radnik ciljni,
            List<IEntity> rezervacije, List<IEntity> dodele)
        {
            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is Radnik),
                    "r.idRadnik = @idr", It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { ciljni });

            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is Rezervacija),
                    It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(rezervacije);

            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is RadnikPerionica),
                    It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(dodele);
        }

        [Fact]
        public void BrisanjeSopstvenogNaloga_BacaIzuzetak_IRadiRollback()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);

            var so = new ObrisiRadnikaSO(broker.Object,
                new Radnik { IdRadnik = TestPomocnik.IdPrijavljenog },
                TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void RadnikSaRezervacijama_NeMozeBitiObrisan()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            PodesiBazu(broker,
                ciljni: new Radnik { IdRadnik = 5 },
                rezervacije: new List<IEntity> { new Rezervacija { IdRezervacija = 1 } },
                dodele: new List<IEntity>());

            var so = new ObrisiRadnikaSO(broker.Object,
                new Radnik { IdRadnik = 5 }, TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void ValidanRadnik_DodelaObrisanaPreRadnika()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            PodesiBazu(broker,
                ciljni: new Radnik { IdRadnik = 5 },
                rezervacije: new List<IEntity>(),
                dodele: new List<IEntity>
                {
                new RadnikPerionica { IdRadnik = 5, IdPerionica = 2 }
                });

            var redosled = new List<string>();
            broker.Setup(b => b.Delete(It.IsAny<IEntity>()))
                  .Callback<IEntity>(e => redosled.Add(e.GetType().Name));

            var so = new ObrisiRadnikaSO(broker.Object,
                new Radnik { IdRadnik = 5 }, TestPomocnik.Prijavljeni);

            so.ExecuteTemplate();

            Assert.Equal(new[] { "RadnikPerionica", "Radnik" }, redosled);
            broker.Verify(b => b.Commit(), Times.Once);
            broker.Verify(b => b.Rollback(), Times.Never);
        }
    }
}
