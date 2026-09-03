using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace DBBroker
{
    public interface IBroker
    {
        void OpenConnection();
        void CloseConnection();
        void BeginTransaction();
        void Commit();
        void Rollback();

        List<IEntity> Get(IEntity entity, string where = null, params SqlParameter[] parameters);
        IEntity GetById(IEntity entity);
        void Add(IEntity entity);
        void Update(IEntity entity);
        void Delete(IEntity entity);
        int GetLastInsertedId(string tableName, string idColumn);
    }
}
