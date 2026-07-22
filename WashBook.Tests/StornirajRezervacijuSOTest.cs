using DBBroker;
using Moq;
using Sistemske_operacije;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class StornirajRezervacijuSOTest
    {
        [Fact]
        public void KadaStatusNijeKreirana_BacaIzuzetakIRadiRollback()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = StatusRezervacije.STORNIRANA,  
                Termin = DateTime.Now.AddDays(1)
            };

            var brokerMock = new Mock<IBroker>();
            brokerMock.Setup(b => b.GetById(It.IsAny<IEntity>())).Returns(rezervacija);

            var so = new StornirajRezervacijuSO(brokerMock.Object, 42);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);

            brokerMock.Verify(b => b.Rollback(), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Never);
        }

        [Fact]
        public void KadaJeTerminProsao_BacaIzuzetakIRadiRollback()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = StatusRezervacije.KREIRANA,   
                Termin = DateTime.Now.AddDays(-1)                 
            };

            var brokerMock = new Mock<IBroker>();
            brokerMock.Setup(b => b.GetById(It.IsAny<IEntity>())).Returns(rezervacija);

            var so = new StornirajRezervacijuSO(brokerMock.Object, 42);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Rollback(), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Never);
        }

        [Fact]
        public void KadaJeSveValidno_PostavljaStatusStorniranaICommituje()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = StatusRezervacije.KREIRANA,
                Termin = DateTime.Now.AddDays(1)
            };

            var brokerMock = new Mock<IBroker>();
            brokerMock.Setup(b => b.GetById(It.IsAny<IEntity>())).Returns(rezervacija);

            var so = new StornirajRezervacijuSO(brokerMock.Object, 42);

            so.ExecuteTemplate();

            Assert.Equal(StatusRezervacije.STORNIRANA, rezervacija.StatusRezervacije);
            brokerMock.Verify(b => b.Update(rezervacija), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Once);
            brokerMock.Verify(b => b.Rollback(), Times.Never);
        }
    }
}
