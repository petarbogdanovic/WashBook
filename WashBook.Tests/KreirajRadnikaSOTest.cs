using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using Sistemske_operacije;
using Zajednicki.Domen;

namespace WashBook.Tests
{
    public class KreirajRadnikaSOTest
    {
        private Radnik Novi() => new Radnik
        {
            KorisnickoIme = "pera",
            Sifra = "123",
            Ime = "Petar",
            Prezime = "Peric",
            DatumRodjenja = new DateTime(1990, 1, 1),
            Adresa = "Glavna 1",
            Telefon = "0601112223"
        };

        [Fact]
        public void KorisnickoImeZauzeto_BacaIzuzetak_IRadiRollback()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(
                    It.Is<IEntity>(e => e is Radnik),
                    "r.korisnickoIme = @ki",
                    It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { new Radnik { IdRadnik = 9, KorisnickoIme = "pera" } });

            var so = new KreirajRadnikaSO(broker.Object, Novi(), TestPomocnik.Prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());
            broker.Verify(b => b.Add(It.IsAny<IEntity>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void ValidanRadnik_Dodat_IDobioId()
        {
            var broker = new Mock<IBroker>();
            TestPomocnik.PodesiPrijavljenog(broker);
            broker.Setup(b => b.Get(
                    It.Is<IEntity>(e => e is Radnik),
                    "r.korisnickoIme = @ki",
                    It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>());
            broker.Setup(b => b.GetLastInsertedId("Radnik", "idRadnik")).Returns(12);

            var novi = Novi();
            var so = new KreirajRadnikaSO(broker.Object, novi, TestPomocnik.Prijavljeni);

            so.ExecuteTemplate();

            broker.Verify(b => b.Add(novi), Times.Once);
            Assert.Equal(12, so.Result.IdRadnik);
            broker.Verify(b => b.Commit(), Times.Once);
        }
    }
}
