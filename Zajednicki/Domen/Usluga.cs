using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Usluga : IEntity
    {
        public int IdUsluga { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }
        [JsonIgnore] public string PrimaryKey => $"idUsluga = {IdUsluga}";
        [JsonIgnore] public string UpdateValues => $"naziv = '{Naziv}'";
        [JsonIgnore] public string TableName => "Usluga";
        [JsonIgnore] public string Values => $"'{Naziv}'";

        [JsonIgnore] public string SelectFrom => "Usluga";

        [JsonIgnore] public string SelectColumns => "*";

        [JsonIgnore] public string JoinClause => "";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Usluga u = new Usluga
                {
                    IdUsluga = (int)reader["idUsluga"],
                    Naziv = (string)reader["naziv"],
                    Cena = Convert.ToDouble(reader["cena"]) 
                };
                lista.Add(u);
            }
            return lista;
        }

        public override string ToString() => Naziv;
        public override bool Equals(object? obj) => obj is Usluga u && u.IdUsluga == IdUsluga;
        public override int GetHashCode() => IdUsluga.GetHashCode();
    }
}
