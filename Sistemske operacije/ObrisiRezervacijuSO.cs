using DBBroker;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class ObrisiRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;
        public ObrisiRezervacijuSO(IBroker broker, Rezervacija rezervacija) : base(broker)
        {
            this.rezervacija = rezervacija;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(rezervacija);

    

        }
    }
}
