using System.Text;
using Zajednicki.Domen;
using Zajednicki.Servisi;

namespace WashBook.Tests
{
    public class IcsGeneratorTest
    {
        private static Rezervacija NapraviRezervaciju(params string[] nazivi)
        {
            var r = new Rezervacija
            {
                IdRezervacija = 42,
                Termin = new DateTime(2026, 9, 15, 9, 0, 0),
                Korisnik = new Korisnik { Ime = "Pera", Prezime = "Perić" },
                Stavke = new List<StavkaRezervacije>()
            };

            foreach (string naziv in nazivi)
                r.Stavke.Add(new StavkaRezervacije
                {
                    Usluga = new Usluga { IdUsluga = 1, Naziv = naziv }
                });

            return r;
        }

        [Fact]
        public void ZarezUNazivuUsluge_JeEskejpovan()
        {
            Rezervacija r = NapraviRezervaciju("Pranje, voskiranje i sušenje");

            EmailPrilog prilog = IcsGenerator.Kreiraj(
                r, "perionica@test.rs", "pera@primer.rs", 0, IcsMetod.REQUEST);

            // zarez iz naziva mora izaći kao \, — nezaštićen bi razdvojio vrednost polja
            Assert.Contains("Pranje\\, voskiranje", prilog.Sadrzaj);

            // a zarez koji generator sam ubacuje između usluga takođe je unutar iste
            // TEXT vrednosti, pa i on mora biti eskejpovan
            Assert.DoesNotContain("DESCRIPTION:Rezervacija #42. Usluge: Pranje,", prilog.Sadrzaj);
        }

        [Fact]
        public void DugackaCirilicnaVrednost_NemaPolomljenihKaraktera()
        {
            // preko 75 okteta u UTF-8 (ćirilica nosi 2 bajta po slovu) → aktivira prelamanje
            string dugNaziv = string.Concat(Enumerable.Repeat("Прање и полирање возила ", 4));
            Rezervacija r = NapraviRezervaciju(dugNaziv);

            EmailPrilog prilog = IcsGenerator.Kreiraj(
                r, "perionica@test.rs", "pera@primer.rs", 0, IcsMetod.REQUEST);

            // U+FFFD nastaje kad se višebajtna sekvenca preseče na pola
            Assert.DoesNotContain("\uFFFD", prilog.Sadrzaj);

            // nijedan red ne sme preći 75 okteta
            foreach (string red in prilog.Sadrzaj.Split("\r\n"))
                Assert.True(Encoding.UTF8.GetByteCount(red) <= 75,
                            $"Red duži od 75 okteta: {red}");

            // sadržaj preživeo prelamanje: spajanjem nastavaka vraća se original
            string sklopljeno = prilog.Sadrzaj.Replace("\r\n ", "");
            Assert.Contains("Прање и полирање возила", sklopljeno);
        }

        [Fact]
        public void UidJeIstiZaRequestICancel()
        {
            Rezervacija r = NapraviRezervaciju("Osnovno pranje");

            EmailPrilog zahtev = IcsGenerator.Kreiraj(
                r, "perionica@test.rs", "pera@primer.rs", 0, IcsMetod.REQUEST);

            EmailPrilog otkaz = IcsGenerator.Kreiraj(
                r, "perionica@test.rs", "pera@primer.rs", 2, IcsMetod.CANCEL);

            const string ocekivaniUid = "UID:rezervacija-42@washbook";

            Assert.Contains(ocekivaniUid, zahtev.Sadrzaj);
            Assert.Contains(ocekivaniUid, otkaz.Sadrzaj);

            // CANCEL mora nositi veći SEQUENCE, inače ga kalendar ignoriše kao stariju poruku
            Assert.Contains("SEQUENCE:0", zahtev.Sadrzaj);
            Assert.Contains("SEQUENCE:2", otkaz.Sadrzaj);

            Assert.Contains("STATUS:CANCELLED", otkaz.Sadrzaj);
            Assert.DoesNotContain("BEGIN:VALARM", otkaz.Sadrzaj);
        }
    }
}