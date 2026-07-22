using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Radnik : IEntity
    {
        public int IdRadnik { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public Perionica Perionica { get; set; }
        public int? Smena { get; set; }

        [JsonIgnore] public string SelectFrom => "Radnik r";
        [JsonIgnore]
        public string JoinClause =>
            "LEFT JOIN RadnikPerionica rp ON r.idRadnik = rp.idRadnik " +
            "LEFT JOIN Perionica p ON rp.idPerionica = p.idPerionica";
        [JsonIgnore]
        public string SelectColumns =>
            "r.*, p.idPerionica AS idPerionica, p.naziv AS nazivPerionica, " +
            "p.adresa AS adresaPerionica, rp.smena AS smena";

        [JsonIgnore] public string ImePrezimePerionica
        {
            get
            {
                if (Perionica == null) return ImePrezime;
                string smenaDeo = Smena.HasValue ? $" (Smena: {Smena.Value})" : "";
                return $"{Ime} {Prezime} | {Perionica.Naziv}{smenaDeo}";   
            }
        }
        [JsonIgnore] public string PrimaryKey => $"idRadnik = {IdRadnik}";
        [JsonIgnore]
        public string UpdateValues =>
                     $"korisnickoIme = '{KorisnickoIme}', sifra = '{Sifra}', ime = '{Ime}', " +
                     $"prezime = '{Prezime}', datumRodjenja = '{DatumRodjenja:yyyyMMdd}', " +
                     $"adresa = '{Adresa}', telefon = '{Telefon}'";
        [JsonIgnore] public string ImePrezime => $"{Ime} {Prezime}";
        [JsonIgnore] public string TableName => "Radnik";
        [JsonIgnore]
        public string Values =>
             $"'{KorisnickoIme}', '{Sifra}', '{Ime}', '{Prezime}', " +
             $"'{DatumRodjenja:yyyyMMdd}', '{Adresa}', '{Telefon}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();

            while (reader.Read())
            {
                Radnik r = new Radnik
                {
                    IdRadnik = (int)reader["IdRadnik"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Sifra = (string)reader["sifra"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    DatumRodjenja = (DateTime)reader["datumRodjenja"],
                    Adresa = (string)reader["adresa"],
                    Telefon = (string)reader["telefon"]
                };

                if (ReaderHasColumn(reader, "nazivPerionica") && reader["nazivPerionica"] != DBNull.Value)
                {
                    r.Perionica = new Perionica
                    {
                        IdPerionica = ReaderHasColumn(reader, "idPerionica") && reader["idPerionica"] != DBNull.Value
                            ? (int)reader["idPerionica"] : 0,
                        Naziv = (string)reader["nazivPerionica"],
                        Adresa = ReaderHasColumn(reader, "adresaPerionica") && reader["adresaPerionica"] != DBNull.Value
                            ? (string)reader["adresaPerionica"] : ""
                    };
                    if (ReaderHasColumn(reader, "smena") && reader["smena"] != DBNull.Value)
                        r.Smena = (int)reader["smena"];
                }

                lista.Add(r);
            }
            return lista;
        }

        private bool ReaderHasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i) == columnName)
                    return true;
            return false;
        }

        public override string ToString() => ImePrezime;
        public override bool Equals(object? obj) => obj is Radnik r && r.IdRadnik == IdRadnik;
        public override int GetHashCode() => IdRadnik.GetHashCode();


    }
}
