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

        public void ExecuteTemplateIObavesti()
        {
            ExecuteTemplate();

            try
            {
                PosleCommita();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[{GetType().Name}] Obaveštenje nije poslato: {ex.Message}");
            }
        }

        protected virtual void PosleCommita() { }

        protected abstract void ExecuteConcreteOperation();
    }
}