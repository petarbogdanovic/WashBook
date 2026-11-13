using System.Text.Json;

namespace DBBroker
{
    public static class Konfiguracija
    {
        private static KonfiguracijaPodaci _podaci;
        private static KonfiguracijaPodaci Podaci => _podaci ??= Ucitaj();

        public static string ConnectionString => Podaci.ConnectionString;

        public static SmtpPodaci Smtp =>
            Podaci.Smtp ?? throw new InvalidOperationException(
                "U fajlu 'appsettings.json' nedostaje sekcija 'Smtp'.");

        private static KonfiguracijaPodaci Ucitaj()
        {
            string putanja = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            if (!File.Exists(putanja))
                throw new FileNotFoundException($"Konfiguracioni fajl nije pronađen: {putanja}. Kopiraj Server/appsettings.example.json u Server/appsettings.json i upiši svoje podatke.");

            string json = File.ReadAllText(putanja);

            KonfiguracijaPodaci podaci;
            try
            {
                podaci = JsonSerializer.Deserialize<KonfiguracijaPodaci>(json);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Fajl 'appsettings.json' nije ispravan JSON: {ex.Message}", ex);
            }

            if (podaci == null || string.IsNullOrWhiteSpace(podaci.ConnectionString))
                throw new InvalidOperationException("U fajlu 'appsettings.json' nedostaje ili je prazan ključ 'ConnectionString'.");

            return podaci;
        }
    }

    internal class KonfiguracijaPodaci
    {
        public string ConnectionString { get; set; }
        public SmtpPodaci Smtp { get; set; }
    }

    public class SmtpPodaci
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Korisnik { get; set; }
        public string Sifra { get; set; }
        public string Posiljalac { get; set; }
        public string ImePosiljaoca { get; set; }
    }
}