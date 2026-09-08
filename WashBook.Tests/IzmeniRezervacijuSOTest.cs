using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace WashBook.Tests
{
    public class IzmeniRezervacijuSOTest
    {
        private const int IdVlasnika = 7;

        private static Rezervacija IzBaze(StatusRezervacije status = StatusRezervacije.KREIRANA) =>
            new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = status,
                Termin = DateTime.Now.AddDays(1),
                Radnik = new Radnik { IdRadnik = TestPomocnik.IdPrijavljenog },
                Korisnik = new Korisnik { IdKorisnik = IdVlasnika }
            };

        // podrazumevano: vlasnik menja svoju rezervaciju
        private static IzmeniRezervacijuSO Napravi(Mock<IBroker> broker, Rezervacija rezervacija,
                                                   Mock<IEmailServis> email = null) =>
            new IzmeniRezervacijuSO(broker.Object,
                                    (email ?? new Mock<IEmailServis>()).Object,
                                    rezervacija,
                                    null,
                                    new Korisnik { IdKorisnik = IdVlasnika });

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
                Termin = DateTime.Now.AddDays(1),
                Stavke = new List<StavkaRezervacije>
                {
                    new StavkaRezervacije(),
                    new StavkaRezervacije(),
                    new StavkaRezervacije()
                }
            };

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());
            brokerMock
                .Setup(b => b.Get(It.Is<IEntity>(e => e is StavkaRezervacije),
                                  It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                .Returns(postojece);

            var sequence = new MockSequence();
            brokerMock.InSequence(sequence).Setup(b => b.Delete(It.IsAny<IEntity>()));
            brokerMock.InSequence(sequence).Setup(b => b.Add(It.IsAny<IEntity>()));

            var so = Napravi(brokerMock, rezervacija);

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
                Termin = DateTime.Now.AddDays(1),
                Stavke = new List<StavkaRezervacije>()
            };

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());

            var so = Napravi(brokerMock, rezervacija);

            so.ExecuteTemplate();

            brokerMock.Verify(b => b.Update(rezervacija), Times.Once);

            brokerMock.Verify(b => b.Get(It.Is<IEntity>(e => e is StavkaRezervacije),
                                         It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Never);
            brokerMock.Verify(b => b.Delete(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
        }

        [Fact]
        public void StatusNijeKreirana_BacaIRadiRollback()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Termin = DateTime.Now.AddDays(1)
            };

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(
                IzBaze(StatusRezervacije.STORNIRANA));

            var so = Napravi(brokerMock, rezervacija);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Rollback(), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Never);
        }

        [Fact]
        public void PayloadNeMozeDaPromeniStatusNiVlasnika()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = StatusRezervacije.OBRADJENA,
                Korisnik = new Korisnik { IdKorisnik = 99 },
                Termin = DateTime.Now.AddDays(1)
            };

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());

            var so = Napravi(brokerMock, rezervacija);

            so.ExecuteTemplateIObavesti();

            Assert.Equal(StatusRezervacije.KREIRANA, rezervacija.StatusRezervacije);
            Assert.Equal(IdVlasnika, rezervacija.Korisnik.IdKorisnik);
            brokerMock.Verify(b => b.Commit(), Times.Once);
        }

        [Fact]
        public void MejlOdlaziPosleCommita_BezIcsPriloga()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Termin = DateTime.Now.AddDays(1),
                Stavke = new List<StavkaRezervacije>()
            };

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());
            brokerMock.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                      .Returns(new Korisnik { IdKorisnik = IdVlasnika, Email = "pera@primer.rs" });

            var emailMock = new Mock<IEmailServis>();
            emailMock.Setup(e => e.AdresaPosiljaoca).Returns("perionica@test.rs");

            var so = Napravi(brokerMock, rezervacija, emailMock);

            so.ExecuteTemplateIObavesti();

            emailMock.Verify(e => e.Posalji("pera@primer.rs", It.IsAny<string>(),
                                            It.IsAny<string>(), null), Times.Once);
        }

        [Fact]
        public void NemaPrijavljenog_BacaIRadiRollback()
        {
            var rezervacija = new Rezervacija { IdRezervacija = 42, Termin = DateTime.Now.AddDays(1) };
            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());

            var so = new IzmeniRezervacijuSO(brokerMock.Object, new Mock<IEmailServis>().Object,
                                             rezervacija, null, null);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void TudjaRezervacija_BacaIRadiRollback()
        {
            var rezervacija = new Rezervacija { IdRezervacija = 42, Termin = DateTime.Now.AddDays(1) };
            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());   // vlasnik je 7

            var so = new IzmeniRezervacijuSO(brokerMock.Object, new Mock<IEmailServis>().Object,
                                             rezervacija, null, new Korisnik { IdKorisnik = 99 });

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void RadnikSmeTudjuRezervaciju()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Termin = DateTime.Now.AddDays(1),
                Stavke = new List<StavkaRezervacije>()
            };
            var brokerMock = TestPomocnik.BrokerSaRezervacijom(IzBaze());

            var so = new IzmeniRezervacijuSO(brokerMock.Object, new Mock<IEmailServis>().Object,
                                             rezervacija, TestPomocnik.Prijavljeni, null);

            so.ExecuteTemplateIObavesti();

            brokerMock.Verify(b => b.Commit(), Times.Once);
        }
    }
}