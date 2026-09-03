using DBBroker;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveKorisnikeSO : BaseSO
    {
        public List<Korisnik> Result { get; set; }

        public VratiSveKorisnikeSO(IBroker broker) : base (broker){ } 
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get(new Korisnik()).Cast<Korisnik>().ToList();
        }
    }
}
