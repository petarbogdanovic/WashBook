using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Perionica : IEntity
    {
        public int IdPerionica { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        [JsonIgnore] public string PrimaryKey => $"idPerionica = {IdPerionica}";
        [JsonIgnore] public string UpdateValues =>
            $"naziv = '{Naziv}', adresa = '{Adresa}'";
        [JsonIgnore] public string TableName => "Perionica";
        [JsonIgnore] public string Values => $"'{Naziv}', '{Adresa}'";
        [JsonIgnore] public string SelectFrom => "Perionica";
        [JsonIgnore] public string SelectColumns => "*";
        [JsonIgnore] public string JoinClause => "";
        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Perionica p = new Perionica
                {
                    IdPerionica = (int)reader["idPerionica"],
                    Naziv = (string)reader["naziv"],
                    Adresa = (string)reader["adresa"]
                };
                lista.Add(p);
            }
            return lista;
        }

        public override string ToString() => Naziv;
        public override bool Equals(object? obj) => obj is Perionica p && p.IdPerionica == IdPerionica;
        public override int GetHashCode() => IdPerionica.GetHashCode();
    }
}
