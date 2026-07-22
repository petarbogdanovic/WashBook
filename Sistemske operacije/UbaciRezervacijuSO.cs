using DBBroker;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class UbaciRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;

        public UbaciRezervacijuSO(IBroker broker, Rezervacija rezervacija) : base(broker)
        {
            this.rezervacija = rezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {

            broker.Update(rezervacija);

            int rbStavka = 1;
            foreach (StavkaRezervacije stavka in rezervacija.Stavke)
            {
                stavka.IdRezervacija = rezervacija.IdRezervacija;
                stavka.RbStavka = rbStavka;
                broker.Add(stavka);
                rbStavka++;
            }
        }
    }
}
