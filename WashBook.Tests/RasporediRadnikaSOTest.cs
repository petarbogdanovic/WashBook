using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class RasporediRadnikaSOTest
    {
        private RadnikPerionica Dodela() =>
            new RadnikPerionica { IdRadnik = 5, IdPerionica = 2, Smena = Smena.Jutarnja };

        private static void PodesiPostojanje(Mock<IBroker> broker, List<IEntity> postojecaDodela)
        {
            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is Radnik),
                    "r.idRadnik = @idr", It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { new Radnik { IdRadnik = 5 } });

            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is Perionica),
                    It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { new Perionica { IdPerionica = 2 } });

            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is RadnikPerionica),
                    It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(postojecaDodela);
        }

        [Fact]
        public void RadnikNePostoji_BacaIzuzetak_IRadiRollback()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is Radnik),
                    "r.idRadnik = @idr", It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>());

            var so = new RasporediRadnikaSO(broker.Object, Dodela(), TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void PrvaDodela_SamoAdd_BezDelete()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            PodesiPostojanje(broker, new List<IEntity>());

            var dodela = Dodela();
            var so = new RasporediRadnikaSO(broker.Object, dodela, TestPomocnik.Prijavljeni);

            so.ExecuteTemplate();

            broker.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Add(dodela), Times.Once);
            broker.Verify(b => b.Commit(), Times.Once);
        }

        [Fact]
        public void Premestaj_StaraDodelaObrisanaPreNove()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            PodesiPostojanje(broker, new List<IEntity>
        {
            new RadnikPerionica { IdRadnik = 5, IdPerionica = 1, Smena = Smena.Popodnevna }
        });

            var seq = new MockSequence();
            broker.InSequence(seq).Setup(b => b.Delete(It.IsAny<IEntity>()));
            broker.InSequence(seq).Setup(b => b.Add(It.IsAny<IEntity>()));

            var dodela = Dodela();
            var so = new RasporediRadnikaSO(broker.Object, dodela, TestPomocnik.Prijavljeni);

            so.ExecuteTemplate();

            broker.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Once);
            broker.Verify(b => b.Add(dodela), Times.Once);
            broker.Verify(b => b.Commit(), Times.Once);
        }
    }
}
