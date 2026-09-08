using DBBroker;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace WashBook.Tests
{
    public class StornirajRezervacijuSOTest
    {
        private const int IdVlasnika = 7;

        private static Rezervacija Rez(StatusRezervacije status, DateTime termin) =>
            new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = status,
                Termin = termin,
                Radnik = new Radnik { IdRadnik = TestPomocnik.IdPrijavljenog },
                Korisnik = new Korisnik { IdKorisnik = IdVlasnika, Ime = "Pera", Prezime = "Perić" }
            };

        private static StornirajRezervacijuSO Napravi(Mock<IBroker> broker,
                                                      Mock<IEmailServis> email = null) =>
            new StornirajRezervacijuSO(broker.Object,
                                       (email ?? new Mock<IEmailServis>()).Object,
                                       42,
                                       null,
                                       new Korisnik { IdKorisnik = IdVlasnika });

        [Fact]
        public void KadaStatusNijeKreirana_BacaIzuzetakIRadiRollback()
        {
            var rezervacija = Rez(StatusRezervacije.STORNIRANA, DateTime.Now.AddDays(1));

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(rezervacija);

            var so = Napravi(brokerMock);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);

            brokerMock.Verify(b => b.Rollback(), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Never);
        }

        [Fact]
        public void KadaJeTerminProsao_BacaIzuzetakIRadiRollback()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddDays(-1));

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(rezervacija);

            var so = Napravi(brokerMock);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Rollback(), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Never);
        }

        [Fact]
        public void KadaJeSveValidno_PostavljaStatusStorniranaICommituje()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddDays(1));

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(rezervacija);

            var so = Napravi(brokerMock);

            so.ExecuteTemplateIObavesti();

            Assert.Equal(StatusRezervacije.STORNIRANA, rezervacija.StatusRezervacije);
            brokerMock.Verify(b => b.Update(rezervacija), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Once);
            brokerMock.Verify(b => b.Rollback(), Times.Never);
        }

        [Fact]
        public void TudjaRezervacija_BacaIzuzetakIRadiRollback()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddDays(1));

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(rezervacija);   

            var so = new StornirajRezervacijuSO(brokerMock.Object, new Mock<IEmailServis>().Object,
                                                42, null, new Korisnik { IdKorisnik = 99 });

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            brokerMock.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void RadnikSmeTudjuRezervaciju()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddDays(1));

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(rezervacija);

            var so = new StornirajRezervacijuSO(brokerMock.Object, new Mock<IEmailServis>().Object,
                                                42, TestPomocnik.Prijavljeni, null);

            so.ExecuteTemplateIObavesti();

            Assert.Equal(StatusRezervacije.STORNIRANA, rezervacija.StatusRezervacije);
            brokerMock.Verify(b => b.Commit(), Times.Once);
        }

        [Fact]
        public void MejlNosiCancelPrilogSaIstimUid()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddDays(1));

            var brokerMock = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            brokerMock.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                      .Returns(new Korisnik { IdKorisnik = IdVlasnika, Email = "pera@primer.rs" });

            var emailMock = new Mock<IEmailServis>();
            emailMock.Setup(e => e.AdresaPosiljaoca).Returns("perionica@test.rs");

            EmailPrilog uhvacen = null;
            emailMock.Setup(e => e.Posalji(It.IsAny<string>(), It.IsAny<string>(),
                                           It.IsAny<string>(), It.IsAny<EmailPrilog>()))
                     .Callback<string, string, string, EmailPrilog>((_, _, _, p) => uhvacen = p);

            var so = Napravi(brokerMock, emailMock);

            so.ExecuteTemplateIObavesti();

            Assert.NotNull(uhvacen);
            Assert.Equal("CANCEL", uhvacen.Metod);
            Assert.Equal("text/calendar", uhvacen.MimeTip);
            Assert.Equal("rezervacija-42.ics", uhvacen.Naziv);
            Assert.Contains("UID:rezervacija-42@washbook", uhvacen.Sadrzaj);
            Assert.Contains("STATUS:CANCELLED", uhvacen.Sadrzaj);
            Assert.Contains("SEQUENCE:1", uhvacen.Sadrzaj);
        }
    }
}