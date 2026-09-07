using System.Text;
using Zajednicki.Domen;

namespace Zajednicki.Servisi
{
    public enum IcsMetod { REQUEST, CANCEL }

    public static class IcsGenerator
    {
        private const string CRLF = "\r\n";

        public static EmailPrilog Kreiraj(Rezervacija r, string organizator,
                                          string emailKorisnika, int sekvenca, IcsMetod metod)
        {
            bool otkazivanje = metod == IcsMetod.CANCEL;

            StringBuilder sb = new StringBuilder();
            sb.Append("BEGIN:VCALENDAR").Append(CRLF);
            sb.Append("VERSION:2.0").Append(CRLF);
            sb.Append("PRODID:-//WashBook//Rezervacije//SR").Append(CRLF);
            sb.Append("CALSCALE:GREGORIAN").Append(CRLF);
            sb.Append("METHOD:").Append(metod).Append(CRLF);
            sb.Append("BEGIN:VEVENT").Append(CRLF);

            sb.Append(Red($"UID:rezervacija-{r.IdRezervacija}@washbook"));
            sb.Append(Red($"DTSTAMP:{DateTime.UtcNow:yyyyMMdd'T'HHmmss'Z'}"));
            sb.Append(Red($"DTSTART:{Lokalno(r.Termin)}"));
            sb.Append(Red($"DTEND:{Lokalno(r.Termin.AddHours(1))}"));
            sb.Append(Red($"SEQUENCE:{sekvenca}"));
            sb.Append(Red($"STATUS:{(otkazivanje ? "CANCELLED" : "CONFIRMED")}"));
            sb.Append(Red($"SUMMARY:{Escape("WashBook — pranje vozila")}"));
            sb.Append(Red($"DESCRIPTION:{Escape(Opis(r))}"));
            sb.Append(Red($"ORGANIZER;CN=WashBook:mailto:{organizator}"));
            sb.Append(Red($"ATTENDEE;CN={Escape(r.ImeKorisnika)};RSVP=FALSE;" +
                          $"PARTSTAT=ACCEPTED:mailto:{emailKorisnika}"));

            if (!otkazivanje)
            {
                sb.Append("BEGIN:VALARM").Append(CRLF);
                sb.Append("TRIGGER:-PT1H").Append(CRLF);
                sb.Append("ACTION:DISPLAY").Append(CRLF);
                sb.Append(Red($"DESCRIPTION:{Escape("Podsetnik: termin u perionici")}"));
                sb.Append("END:VALARM").Append(CRLF);
            }

            sb.Append("END:VEVENT").Append(CRLF);
            sb.Append("END:VCALENDAR").Append(CRLF);

            return new EmailPrilog
            {
                Naziv = $"rezervacija-{r.IdRezervacija}.ics",
                Sadrzaj = sb.ToString(),
                MimeTip = "text/calendar",
                Metod = metod.ToString()
            };
        }

        private static string Opis(Rezervacija r)
        {
            if (r.Stavke == null || r.Stavke.Count == 0)
                return $"Rezervacija #{r.IdRezervacija}";

            string usluge = string.Join(", ", r.Stavke.Select(s => s.NazivUsluge));
            return $"Rezervacija #{r.IdRezervacija}. Usluge: {usluge}";
        }

        private static string Lokalno(DateTime vreme) =>
            vreme.ToString("yyyyMMdd'T'HHmmss");

        private static string Escape(string tekst) =>
            (tekst ?? "").Replace("\\", "\\\\")
                         .Replace(";", "\\;")
                         .Replace(",", "\\,")
                         .Replace("\r\n", "\\n")
                         .Replace("\n", "\\n");

        private static string Red(string sadrzaj)
        {
            byte[] bajtovi = Encoding.UTF8.GetBytes(sadrzaj);
            if (bajtovi.Length <= 75) return sadrzaj + CRLF;

            StringBuilder sb = new StringBuilder();
            int pozicija = 0;
            int granica = 75;

            while (pozicija < bajtovi.Length)
            {
                int duzina = Math.Min(granica, bajtovi.Length - pozicija);

                while (duzina > 0 && pozicija + duzina < bajtovi.Length &&
                       (bajtovi[pozicija + duzina] & 0xC0) == 0x80)
                    duzina--;

                sb.Append(Encoding.UTF8.GetString(bajtovi, pozicija, duzina)).Append(CRLF);
                pozicija += duzina;
                granica = 74;                       
                if (pozicija < bajtovi.Length) sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}