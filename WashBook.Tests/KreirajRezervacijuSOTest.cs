using DBBroker;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class KreirajRezervacijuSOTest
    {
        [Fact]
        public void KreiraPlaceholderRezervacijuSaStatusomKreirana()
        {
            var brokerMock = new Mock<IBroker>();
            brokerMock
                .Setup(b => b.GetLastInsertedId("Rezervacija", "IdRezervacija"))
                .Returns(42);

            var so = new KreirajRezervacijuSO(brokerMock.Object);

            so.ExecuteTemplate();

            brokerMock.Verify(b => b.Add(
                It.Is<IEntity>(e => ((Rezervacija)e).StatusRezervacije == StatusRezervacije.KREIRANA)),
                Times.Once);

            brokerMock.Verify(b => b.GetLastInsertedId("Rezervacija", "IdRezervacija"), Times.Once);
            Assert.Equal(42, so.Result.IdRezervacija);

            brokerMock.Verify(b => b.Commit(), Times.Once);
            brokerMock.Verify(b => b.Rollback(), Times.Never);
        }
    }
}
