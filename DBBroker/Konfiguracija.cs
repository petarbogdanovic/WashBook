using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DBBroker
{
    public static class Konfiguracija
    {
        private static string _connectionString;
        public static string ConnectionString => _connectionString ??= Ucitaj();

        private static string Ucitaj()
        {
            string putanja = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            if (!File.Exists(putanja))
                throw new FileNotFoundException($"Konfiguracioni fajl nije pronađen: {putanja}.");
            
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
            return podaci.ConnectionString;
        }
    }

    internal class KonfiguracijaPodaci
    {
        public string ConnectionString { get; set; }
    }
}

