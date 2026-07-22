using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Rezervacija : IEntity
    {
        public int IdRezervacija { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime Termin{ get; set; }
        public StatusRezervacije StatusRezervacije { get; set; } = StatusRezervacije.KREIRANA;
        public string Registracija { get; set; }
        public Radnik Radnik { get; set; }
        public Korisnik Korisnik { get; set; }
        public List<StavkaRezervacije> Stavke { get; set; } = new List<StavkaRezervacije>();
        

        [JsonIgnore] public string ImeRadnika => $"{Radnik?.Ime} {Radnik?.Prezime}".Trim();
        [JsonIgnore] public string ImeKorisnika => $"{Korisnik?.Ime} {Korisnik?.Prezime}".Trim();
        [JsonIgnore] public string PrimaryKey => $"idRezervacija = {IdRezervacija}";
        [JsonIgnore]
        public string UpdateValues =>
            $"datumRezervacije = '{DatumRezervacije:yyyy-MM-dd}', " +
            $"termin = {(Termin == default ? "NULL" : $"'{Termin:yyyy-MM-dd HH:mm:ss}'")}, " +
            $"statusRezervacije = '{StatusRezervacije}', " +
            $"idRadnik = {(Radnik != null ? Radnik.IdRadnik.ToString() : "NULL")}, " +
            $"idKorisnik = {(Korisnik != null ? Korisnik.IdKorisnik.ToString() : "NULL")}, " +
            $"registracija = {(string.IsNullOrEmpty(Registracija) ? "NULL" : $"'{Registracija}'")}";
        [JsonIgnore] public string TableName => "Rezervacija";

        [JsonIgnore]
        public string Values =>
            $"'{DatumRezervacije:yyyy-MM-dd}', " +
            $"{(Termin == default ? "NULL" : $"'{Termin:yyyy-MM-dd HH:mm:ss}'")}, " +
            $"'{StatusRezervacije}', " +
            $"{(Radnik != null ? Radnik.IdRadnik.ToString() : "NULL")}, " +
            $"{(Korisnik != null ? Korisnik.IdKorisnik.ToString() : "NULL")}, " +
            $"{(string.IsNullOrEmpty(Registracija) ? "NULL" : $"'{Registracija}'")}";

        [JsonIgnore]
        public string SelectColumns =>
            "r.*, ra.ime AS imeRadnika, ra.prezime AS prezimeRadnika, " +
            "k.ime AS imeKorisnika, k.prezime AS prezimeKorisnika";

        [JsonIgnore]
        public string JoinClause =>
            "r Rezervacija".Length > 0 ?   
            "JOIN Radnik ra ON r.idRadnik = ra.idRadnik " +
            "JOIN Korisnik k ON r.idKorisnik = k.idKorisnik" : "";

        [JsonIgnore]
        public string SelectFrom => "Rezervacija r";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Rezervacija r = new Rezervacija
                {
                    IdRezervacija = (int)reader["idRezervacija"],
                    DatumRezervacije = (DateTime)reader["datumRezervacije"],
                    Termin = (DateTime)reader["termin"],
                    StatusRezervacije = Enum.Parse<StatusRezervacije>((string)reader["statusRezervacije"].ToString().Trim()),
                    Registracija = ReaderHasColumn(reader, "registracija") ? (string)reader["registracija"] : "",
                    Radnik = new Radnik
                    {
                        IdRadnik = (int)reader["idRadnik"],
                        Ime = ReaderHasColumn(reader, "imeRadnika") ? (string)reader["imeRadnika"] : "",
                        Prezime = ReaderHasColumn(reader, "prezimeRadnika") ? (string)reader["prezimeRadnika"] : ""
                    },
                    Korisnik = new Korisnik
                    {
                        IdKorisnik = (int)reader["idKorisnik"],
                        Ime = ReaderHasColumn(reader, "imeKorisnika") ? (string)reader["imeKorisnika"] : "",
                        Prezime = ReaderHasColumn(reader, "prezimeKorisnika") ? (string)reader["prezimeKorisnika"] : ""
                    },
                   
                };
                lista.Add(r);
            }
            return lista;
        }

        private bool ReaderHasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i) == columnName) return true;
            return false;
        }

        public override string ToString() => $"Rez. #{IdRezervacija} – {Termin:dd.MM.yyyy HH:mm} [{StatusRezervacije}]";
        public override bool Equals(object? obj) => obj is Rezervacija r && r.IdRezervacija == IdRezervacija;
        public override int GetHashCode() => IdRezervacija.GetHashCode();
    }
}

