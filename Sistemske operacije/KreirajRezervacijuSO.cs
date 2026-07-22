using DBBroker;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class KreirajRezervacijuSO : BaseSO
    {
        public KreirajRezervacijuSO(IBroker broker) : base(broker)
        {
        }

        public Rezervacija Result { get; set; }


        protected override void ExecuteConcreteOperation()
        {
            Rezervacija prazna = new Rezervacija
            {
                DatumRezervacije = DateTime.Today,
                StatusRezervacije = StatusRezervacije.KREIRANA
            };
            broker.Add( prazna );
            prazna.IdRezervacija = broker.GetLastInsertedId("Rezervacija","IdRezervacija");
            Result = prazna;
        }
    }
}
