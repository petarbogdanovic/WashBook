using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class VratiSveTipoveVozilaSO : BaseSO
    {
        public List<TipVozila> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Get("SELECT * FROM TipVozila", new TipVozila()).Cast<TipVozila>().ToList();
        }
    }
}
