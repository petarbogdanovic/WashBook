using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class RadnikPerionica : IEntity
    {
        public int IdRadnik { get; set; }
        public int IdPerionica { get; set; }
        public int Smena { get; set; }
        public Perionica Perionica { get; set; }

        [JsonIgnore] public string NazivPerionica => Perionica?.Naziv ?? "";
        [JsonIgnore] public string AdresaPerionica => Perionica?.Adresa ?? "";

        [JsonIgnore] public string TableName => "RadnikPerionica";

        [JsonIgnore] public string Values => $"{IdRadnik}, {IdPerionica}, {Smena}";

        [JsonIgnore] public string PrimaryKey => $"idRadnik = {IdRadnik} AND idPerionica = {IdPerionica} ";

        [JsonIgnore] public string UpdateValues => $"smena = {Smena}";

        [JsonIgnore] public string SelectFrom => "RadnikPerionica rp";
        [JsonIgnore] public string JoinClause => "JOIN Perionica p ON rp.idPerionica = p.idPerionica";
        [JsonIgnore] public string SelectColumns => "rp.idRadnik, rp.idPerionica, rp.smena, p.naziv AS nazivPerionica, p.adresa AS adresaPerionica";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                RadnikPerionica rp = new RadnikPerionica
                {
                    IdRadnik = reader.GetInt32(0),
                    IdPerionica = reader.GetInt32(1),
                    Smena = reader.GetInt32(2),
                    Perionica = new Perionica
                    {
                        IdPerionica = reader.GetInt32(1),
                        Naziv = ReaderHasColumn(reader, "nazivPerionica") ? (string)reader["nazivPerionica"] : "",
                        Adresa = ReaderHasColumn(reader, "adresaPerionica") ? (string)reader["adresaPerionica"] : ""
                    }
                };
                lista.Add(rp);
            }
            return lista;
        }

        private bool ReaderHasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i) == columnName) return true;
             return false;
        }

        public override string ToString() => $"{NazivPerionica} (smena {Smena})";
        public override bool Equals(object? obj) =>
            obj is RadnikPerionica rp && rp.IdRadnik == IdRadnik && rp.IdPerionica == IdPerionica;
        public override int GetHashCode() => HashCode.Combine(IdRadnik, IdPerionica);


    }
}
