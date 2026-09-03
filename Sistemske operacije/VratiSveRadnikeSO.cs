using DBBroker;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveRadnikeSO : BaseSO
    {
        public VratiSveRadnikeSO(IBroker broker) : base(broker)
        {
        }

        public List<Radnik> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get(new Radnik()).Cast<Radnik>().ToList();

        }
    }
}
