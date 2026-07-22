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
    public class IzmeniRezervacijuSOTest
    {
        [Fact]
        public void BriseStarePaUbacujeNoveStavke_TimRedom()
        {
            var postojece = new List<IEntity>
            {
                new StavkaRezervacije(),
                new StavkaRezervacije()
            };

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
            brokerMock
                .Setup(b => b.Get(It.IsAny<IEntity>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                .Returns(postojece);

            var sequence = new MockSequence();
            brokerMock.InSequence(sequence).Setup(b => b.Delete(It.IsAny<IEntity>()));
            brokerMock.InSequence(sequence).Setup(b => b.Add(It.IsAny<IEntity>()));

            var so = new IzmeniRezervacijuSO(brokerMock.Object, rezervacija);

            so.ExecuteTemplate();

            brokerMock.Verify(b => b.Update(rezervacija), Times.Once);

            brokerMock.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Exactly(2));

            brokerMock.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Exactly(3));

            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(42, rezervacija.Stavke[i].IdRezervacija);
                Assert.Equal(i + 1, rezervacija.Stavke[i].RbStavka);
            }

            brokerMock.Verify(b => b.Commit(), Times.Once);
            brokerMock.Verify(b => b.Rollback(), Times.Never);
        }

        [Fact]
        public void KadaNemaStavki_MenjaSamoHeder_NeDiraStavke()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Stavke = new List<StavkaRezervacije>()   
            };

            var brokerMock = new Mock<IBroker>();
            var so = new IzmeniRezervacijuSO(brokerMock.Object, rezervacija);

            so.ExecuteTemplate();

            brokerMock.Verify(b => b.Update(rezervacija), Times.Once);

            brokerMock.Verify(b => b.Get(It.IsAny<IEntity>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Never);
            brokerMock.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
        }
    }

    
}
