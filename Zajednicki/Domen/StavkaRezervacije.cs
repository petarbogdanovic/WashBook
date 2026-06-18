using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class StavkaRezervacije : IEntity
    {
        public int IdRezervacija { get; set; }
        public int RbStavka { get; set; }
        public Usluga Usluga { get; set; }
        public double Cena { get; set; }

        [JsonIgnore] public string NazivUsluge => Usluga?.Naziv ?? "";
        [JsonIgnore] public string TableName => "StavkaRezervacije";
        [JsonIgnore] public string PrimaryKey => $"idRezervacija = {IdRezervacija} AND rbStavka = {RbStavka}";
        [JsonIgnore] public string Values => $"{IdRezervacija}, {RbStavka}, {Usluga.IdUsluga}, {Cena}";
        [JsonIgnore] public string UpdateValues => $"idUsluga = {Usluga.IdUsluga}, cena = {Cena}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                StavkaRezervacije s = new StavkaRezervacije
                {
                    IdRezervacija = (int)reader["idRezervacija"],
                    RbStavka = (int)reader["rbStavka"],
                    Cena = ReaderHasColumn(reader, "cena") ? Convert.ToDouble(reader["cena"]) : 0,
                    Usluga = new Usluga
                    {
                        IdUsluga = (int)reader["idUsluga"],
                        Naziv = ReaderHasColumn(reader, "nazivUsluga") ? (string)reader["nazivUsluga"] : ""
                    }
                };
                lista.Add(s);
            }
            return lista;
        }

        private bool ReaderHasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i) == columnName) return true;

            return false;

        }
    }
}
