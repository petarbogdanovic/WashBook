using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace DBBroker
{
    public class Broker : IBroker
    {
        private DbConnection connection;

        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.RollBack();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }
      
        public List<IEntity> Get( IEntity entity, string where = null, params SqlParameter[] parameters)
        {

            string sql = $"SELECT {entity.SelectColumns} FROM {entity.SelectFrom}";
            if (!string.IsNullOrWhiteSpace(entity.JoinClause))
                sql += $" {entity.JoinClause}";
            if (!string.IsNullOrWhiteSpace(where))
                sql += $" WHERE {where}";

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            using SqlDataReader reader = cmd.ExecuteReader();
            return entity.GetReaderList(reader);

        }

        public void Add(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {entity.TableName} values ({entity.Values})";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Update(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"update {entity.TableName} set {entity.UpdateValues} where {entity.PrimaryKey}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Delete(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"delete from {entity.TableName} where {entity.PrimaryKey}";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public int GetLastInsertedId(string tableName, string idColumn)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT MAX({idColumn}) FROM {tableName}";
            return (int)cmd.ExecuteScalar();
        }

        public IEntity GetById(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.PrimaryKey}";
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> lista = entity.GetReaderList(reader);
            if (lista.Count > 0)
                return lista[0];
            throw new Exception("Objekat nije pronađen.");
        }


     
    }
}
