using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class KreirajPerionicuSOTest
    {
        private Perionica Validna() => new Perionica { Naziv = "Centar", Adresa = "Glavna 1" };

        [Fact]
        public void BezPrijavljenogRadnika_BacaIzuzetak_IRadiRollback()
        {
            var broker = new Mock<IBroker>();

            var so = new KreirajPerionicuSO(broker.Object, Validna(), null);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
            broker.Verify(b => b.Commit(), Times.Never);
        }

        [Fact]
        public void PrijavljeniNijeMenadzer_BacaIzuzetak_IRadiRollback()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker, jeMenadzer: false);

            var so = new KreirajPerionicuSO(broker.Object, Validna(), TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void NazivVecPostoji_BacaIzuzetak_IRadiRollback()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(
                    It.Is<IEntity>(e => e is Perionica),
                    It.IsAny<string>(),
                    It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { new Perionica { IdPerionica = 5, Naziv = "Centar" } });

            var so = new KreirajPerionicuSO(broker.Object, Validna(), TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void ValidnaPerionica_Dodata_DobilaId_ITransakcijaPotvrdjena()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(
                    It.Is<IEntity>(e => e is Perionica),
                    It.IsAny<string>(),
                    It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>());
            broker.Setup(b => b.GetLastInsertedId("Perionica", "idPerionica")).Returns(7);

            var perionica = Validna();
            var so = new KreirajPerionicuSO(broker.Object, perionica, TestPomocnik.Prijavljeni);

            so.ExecuteTemplate();

            broker.Verify(b => b.Add(perionica), Times.Once);
            Assert.Equal(7, so.Result.IdPerionica);
            broker.Verify(b => b.Commit(), Times.Once);
            broker.Verify(b => b.Rollback(), Times.Never);
        }
    }
}
