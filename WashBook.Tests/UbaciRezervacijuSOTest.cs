using DBBroker;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;
using Zajednicki.Servisi;

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
            var so = new UbaciRezervacijuSO(brokerMock.Object, new Mock<IEmailServis>().Object, rezervacija);

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

        [Fact]
        public void SaljeMejlPosleUspesnogCommita()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Korisnik = new Korisnik { IdKorisnik = 7 },
                Stavke = new List<StavkaRezervacije> { new StavkaRezervacije() }
            };

            var brokerMock = new Mock<IBroker>();
            brokerMock.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                      .Returns(new Korisnik { IdKorisnik = 7, Email = "pera@primer.rs" });

            var emailMock = new Mock<IEmailServis>();
            emailMock.Setup(e => e.AdresaPosiljaoca).Returns("perionica@test.rs");

            var so = new UbaciRezervacijuSO(brokerMock.Object, emailMock.Object, rezervacija);

            so.ExecuteTemplateIObavesti();

            brokerMock.Verify(b => b.Commit(), Times.Once);
            emailMock.Verify(e => e.Posalji("pera@primer.rs", It.IsAny<string>(), It.IsAny<string>(),
                                            It.IsAny<EmailPrilog>()), Times.Once);
        }

        [Fact]
        public void NeSaljeMejlAkoTransakcijaPadne()   
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Korisnik = new Korisnik { IdKorisnik = 7 },
                Stavke = new List<StavkaRezervacije> { new StavkaRezervacije() }
            };

            var brokerMock = new Mock<IBroker>();
            brokerMock.Setup(b => b.Update(It.IsAny<IEntity>())).Throws(new Exception("pad baze"));

            var emailMock = new Mock<IEmailServis>();
            var so = new UbaciRezervacijuSO(brokerMock.Object, emailMock.Object, rezervacija);

            Assert.Throws<Exception>(() => so.ExecuteTemplateIObavesti());

            brokerMock.Verify(b => b.Rollback(), Times.Once);
            brokerMock.Verify(b => b.Commit(), Times.Never);
            emailMock.Verify(e => e.Posalji(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EmailPrilog>()), Times.Never);
        }


        [Fact]
        public void MejlNosiIcsPrilog()
        {
            var rezervacija = new Rezervacija
            {
                IdRezervacija = 42,
                Termin = new DateTime(2026, 9, 15, 9, 0, 0),
                Korisnik = new Korisnik { IdKorisnik = 7 },
                Stavke = new List<StavkaRezervacije> { new StavkaRezervacije() }
            };

            var brokerMock = new Mock<IBroker>();
            brokerMock.Setup(b => b.GetById(It.IsAny<Korisnik>()))
                      .Returns(new Korisnik { IdKorisnik = 7, Email = "pera@primer.rs" });

            var emailMock = new Mock<IEmailServis>();
            emailMock.Setup(e => e.AdresaPosiljaoca).Returns("perionica@test.rs");

            EmailPrilog uhvacen = null;
            emailMock.Setup(e => e.Posalji(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                                           It.IsAny<EmailPrilog>()))
                     .Callback<string, string, string, EmailPrilog>((_, _, _, p) => uhvacen = p);

            var so = new UbaciRezervacijuSO(brokerMock.Object, emailMock.Object, rezervacija);

            so.ExecuteTemplateIObavesti();

            Assert.NotNull(uhvacen);
            Assert.Equal("text/calendar", uhvacen.MimeTip);
            Assert.Equal("rezervacija-42.ics", uhvacen.Naziv);
            Assert.Equal("REQUEST", uhvacen.Metod);
            Assert.Contains("mailto:perionica@test.rs", uhvacen.Sadrzaj);
        }
    }
}
