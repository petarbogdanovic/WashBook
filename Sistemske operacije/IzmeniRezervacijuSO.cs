using DBBroker;
using Microsoft.Data.SqlClient;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class IzmeniRezervacijuSO : BaseSO
    {
        private Rezervacija rezervacija;

        public IzmeniRezervacijuSO(IBroker broker, Rezervacija rezervacija) : base(broker) 
        {
            this.rezervacija = rezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update(rezervacija);   

           
            if (rezervacija.Stavke != null && rezervacija.Stavke.Count > 0)
            {
                List<IEntity> postojece = broker.Get(new StavkaRezervacije(), "st.idRezervacija = @id",
                    new SqlParameter("@id", rezervacija.IdRezervacija));


                foreach (IEntity s in postojece)
                    broker.Delete(s);

                int rb = 1;
                foreach (StavkaRezervacije stavka in rezervacija.Stavke)
                {
                    stavka.IdRezervacija = rezervacija.IdRezervacija;
                    stavka.RbStavka = rb++;
                    broker.Add(stavka);
                }
            }

        }
    }
}
