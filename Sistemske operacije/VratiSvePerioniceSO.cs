using DBBroker;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSvePerioniceSO : BaseSO
    {
        public VratiSvePerioniceSO(IBroker broker) : base(broker) {}

        public List<Perionica> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get(new Perionica()).Cast<Perionica>().ToList() ;
        }
    }
}
