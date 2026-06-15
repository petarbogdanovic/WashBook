using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveUslugeSO : BaseSO
    {
        public List<Usluga> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get("SELECT * FROM Usluga", new Usluga()).Cast<Usluga>().ToList();
        }
    }
}
