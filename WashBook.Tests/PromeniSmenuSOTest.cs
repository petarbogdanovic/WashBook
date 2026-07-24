using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class PromeniSmenuSOTest
    {
        private RadnikPerionica Dodela() =>
            new RadnikPerionica { IdRadnik = 5, IdPerionica = 2, Smena = Smena.Popodnevna };

        [Fact]
        public void DodelaNePostoji_BacaIzuzetak_UpdateNikad()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is RadnikPerionica),
                    It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>());

            var so = new PromeniSmenuSO(broker.Object, Dodela(), TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void PostojecaDodela_Azurirana_ITransakcijaPotvrdjena()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(It.Is<IEntity>(e => e is RadnikPerionica),
                    It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>
                  {
                  new RadnikPerionica { IdRadnik = 5, IdPerionica = 2, Smena = Smena.Jutarnja }
                  });

            var dodela = Dodela();
            var so = new PromeniSmenuSO(broker.Object, dodela, TestPomocnik.Prijavljeni);

            so.ExecuteTemplate();

            broker.Verify(b => b.Update(dodela), Times.Once);
            broker.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Commit(), Times.Once);
        }
    }
}
