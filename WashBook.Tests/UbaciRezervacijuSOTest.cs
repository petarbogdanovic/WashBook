using DBBroker;
using Moq;
using Sistemske_operacije;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class UbaciRezervacijuSOTest
    {
        [Fact]
        public void UpisujeHederPaStavkeSaIspravnimIdIRednimBrojem()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Stavke = new List<StavkaRezervacije>
                {
                    new StavkaRezervacije(),
                    new StavkaRezervacije(),
                    new StavkaRezervacije()
                }
            };

            var brokerMock = new Mock<IBroker>();
            var so = new UbaciRezervacijuSO(brokerMock.Object, rezervacija);

            so.ExecuteTemplate();

            brokerMock.Verify(b => b.Update(rezervacija), Times.Once);

            brokerMock.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Exactly(3));

            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(42, rezervacija.Stavke[i].IdRezervacija);
                Assert.Equal(i + 1, rezervacija.Stavke[i].RbStavka);
            }

            brokerMock.Verify(b => b.Commit(), Times.Once);
            brokerMock.Verify(b => b.Rollback(), Times.Never);
        }
    }
}
