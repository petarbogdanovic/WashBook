using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Zajednicki.Domen
{
    public class Grad : IEntity
    {
        public int IdGrad { get; set; }
        public string Naziv { get; set; }

        [JsonIgnore] public string PrimaryKey => $"idGrad = {IdGrad}";
        [JsonIgnore] public string UpdateValues => $"naziv = '{Naziv}'";

        [JsonIgnore] public string TableName => "Grad";

        [JsonIgnore] public string Values => $"'{Naziv}'";

        [JsonIgnore] public string SelectFrom => "Grad";

        [JsonIgnore] public string SelectColumns => "*";

        [JsonIgnore] public string JoinClause => "";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Grad g = new Grad
                {
                    IdGrad = (int)reader["idGrad"],
                    Naziv = (string)reader["naziv"]
                };
                lista.Add(g);
            }
            return lista;

        }
        

        public override string ToString() => $"{Naziv}";
        public override bool Equals(object? obj) => obj is Grad g && g.IdGrad == IdGrad;

        public override int GetHashCode() => IdGrad.GetHashCode();

    }
}
