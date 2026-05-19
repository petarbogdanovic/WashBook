using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class KreirajRezervacijuSO : BaseSO
    {
        public Rezervacija Result { get; set; }


        protected override void ExecuteConcreteOperation()
        {
            Result = new Rezervacija
            {
                DatumRezervacije = DateTime.Today,
                StatusRezervacije = StatusRezervacije.KREIRANA
            };
        }
    }
}
