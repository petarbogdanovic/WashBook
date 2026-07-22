using DBBroker;

namespace Sistemske_operacije
{
    public abstract class BaseSO
    {
        protected IBroker broker;

        public BaseSO(IBroker broker)
        {
            this.broker = broker;
        }

        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                ExecuteConcreteOperation();
                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw;
            }
            finally
            {
                broker.CloseConnection();
            }

        }

        protected abstract void ExecuteConcreteOperation();
    }
}
