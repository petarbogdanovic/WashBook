using DBBroker;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveUslugeSO : BaseSO
    {
        public VratiSveUslugeSO(IBroker broker) : base(broker)
        {
        }

        public List<Usluga> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get(new Usluga()).Cast<Usluga>().ToList();
        }
    }
}
