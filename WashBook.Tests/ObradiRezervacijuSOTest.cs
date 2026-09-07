using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace WashBook.Tests
{
    public class ObradiRezervacijuSOTest
    {
        private static Rezervacija Rez(StatusRezervacije status, DateTime termin, int idRadnik) =>
            new Rezervacija
            {
                IdRezervacija = 42,
                StatusRezervacije = status,
                Termin = termin,
                Radnik = new Radnik { IdRadnik = idRadnik },
                Korisnik = new Korisnik { IdKorisnik = 7 }
            };

        private static Mock<IEmailServis> Email()
        {
            var mock = new Mock<IEmailServis>();
            mock.Setup(e => e.AdresaPosiljaoca).Returns("perionica@test.rs");
            return mock;
        }

        [Fact]
        public void SvojaRezervacija_NeDiraAutorizaciju()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA,
                                  DateTime.Now.AddHours(-1),
                                  TestPomocnik.IdPrijavljenog);

            var broker = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            broker.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                  .Returns(new Korisnik { IdKorisnik = 7, Email = "pera@primer.rs" });

            var email = Email();
            var so = new ObradiRezervacijuSO(broker.Object, email.Object, 42, TestPomocnik.Prijavljeni);

            so.ExecuteTemplateIObavesti();

            broker.Verify(b => b.Get(It.Is<IEntity>(e => e is Radnik),
                                     It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Never);
            Assert.Equal(StatusRezervacije.OBRADJENA, rezervacija.StatusRezervacije);
            broker.Verify(b => b.Commit(), Times.Once);
        }

        [Fact]
        public void TudjaRezervacija_PayloadTvrdiMenadzer_BazaKazeNe_BacaIRadiRollback()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddHours(-1), idRadnik: 99);

            var broker = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            TestPomocnik.PodesiPrijavljenog(broker, jeMenadzer: false);

            var email = Email();
            var so = new ObradiRezervacijuSO(broker.Object, email.Object, 42, TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            broker.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
            email.Verify(e => e.Posalji(It.IsAny<string>(), It.IsAny<string>(),
                                        It.IsAny<string>(), It.IsAny<EmailPrilog>()), Times.Never);
        }

        [Fact]
        public void TudjaRezervacija_BazaPotvrdjujeMenadzera_Prolazi()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA, DateTime.Now.AddHours(-1), idRadnik: 99);

            var broker = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            TestPomocnik.PodesiPrijavljenog(broker, jeMenadzer: true);
            broker.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                  .Returns(new Korisnik { IdKorisnik = 7, Email = "pera@primer.rs" });

            var so = new ObradiRezervacijuSO(broker.Object, Email().Object, 42, TestPomocnik.Prijavljeni);

            so.ExecuteTemplateIObavesti();

            Assert.Equal(StatusRezervacije.OBRADJENA, rezervacija.StatusRezervacije);
            broker.Verify(b => b.Commit(), Times.Once);
        }

        [Fact]
        public void StatusNijeKreirana_BacaIRadiRollback()
        {
            var rezervacija = Rez(StatusRezervacije.STORNIRANA,
                                  DateTime.Now.AddHours(-1),
                                  TestPomocnik.IdPrijavljenog);

            var broker = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            var so = new ObradiRezervacijuSO(broker.Object, Email().Object, 42, TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            broker.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void TerminJosNijePriKraju_BacaIRadiRollback()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA,
                                  DateTime.Now.AddMinutes(-30),   
                                  TestPomocnik.IdPrijavljenog);

            var broker = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            var so = new ObradiRezervacijuSO(broker.Object, Email().Object, 42, TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            broker.Verify(b => b.Update(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void MejlOdlaziPosleCommita_BezIcsPriloga()
        {
            var rezervacija = Rez(StatusRezervacije.KREIRANA,
                                  DateTime.Now.AddHours(-1),
                                  TestPomocnik.IdPrijavljenog);

            var broker = TestPomocnik.BrokerSaRezervacijom(rezervacija);
            broker.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                  .Returns(new Korisnik { IdKorisnik = 7, Email = "pera@primer.rs" });

            var email = Email();
            var so = new ObradiRezervacijuSO(broker.Object, email.Object, 42, TestPomocnik.Prijavljeni);

            so.ExecuteTemplateIObavesti();

            email.Verify(e => e.Posalji("pera@primer.rs", It.IsAny<string>(),
                                        It.IsAny<string>(), null), Times.Once);
        }
    }
}