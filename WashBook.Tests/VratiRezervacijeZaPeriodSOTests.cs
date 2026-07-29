using DBBroker;
using Microsoft.Data.SqlClient;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using Sistemske_operacije;

namespace WashBook.Tests
{
    public class VratiRezervacijeZaPeriodSOTests
    {
        private static RezervacijaKriterijum Kriterijum(int idRadnik) => new RezervacijaKriterijum
        {
            IdRadnik = idRadnik,
            DatumOd = new DateTime(2026, 1, 26),
            DatumDo = new DateTime(2026, 2, 2)
        };

        [Fact]
        public void GledaSvojKalendar_ProlazBezProvereMenadzera()
        {
            var broker = new Mock<IBroker>();
            var prijavljeni = new Radnik { IdRadnik = 5, JeMenadzer = false };

            broker.Setup(b => b.Get(It.IsAny<Rezervacija>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>());

            var so = new VratiRezervacijeZaPeriodSO(broker.Object, Kriterijum(5), prijavljeni);
            so.ExecuteTemplate();

            broker.Verify(b => b.Get(It.IsAny<Radnik>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Never);
            broker.Verify(b => b.Commit(), Times.Once);
        }

        [Fact]
        public void GledaTudjiKalendar_NijeMenadzer_BacaIzuzetak()
        {
            var broker = new Mock<IBroker>();
            var prijavljeni = new Radnik { IdRadnik = 5, JeMenadzer = true };

            broker.Setup(b => b.Get(It.IsAny<Radnik>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { new Radnik { IdRadnik = 5, JeMenadzer = false } });

            var so = new VratiRezervacijeZaPeriodSO(broker.Object, Kriterijum(9), prijavljeni);

            Assert.Throws<Exception>(() => so.ExecuteTemplate());

            broker.Verify(b => b.Get(It.IsAny<Rezervacija>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Never);
            broker.Verify(b => b.Rollback(), Times.Once);
        }

        [Fact]
        public void GledaTudjiKalendar_Menadzer_Prolaz()
        {
            var broker = new Mock<IBroker>();
            var prijavljeni = new Radnik { IdRadnik = 5, JeMenadzer = true };

            broker.Setup(b => b.Get(It.IsAny<Radnik>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity> { new Radnik { IdRadnik = 5, JeMenadzer = true } });
            broker.Setup(b => b.Get(It.IsAny<Rezervacija>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                  .Returns(new List<IEntity>());

            var so = new VratiRezervacijeZaPeriodSO(broker.Object, Kriterijum(9), prijavljeni);
            so.ExecuteTemplate();

            broker.Verify(b => b.Get(It.IsAny<Rezervacija>(), It.IsAny<string>(), It.IsAny<SqlParameter[]>()), Times.Once);
            broker.Verify(b => b.Commit(), Times.Once);
        }
    }
}