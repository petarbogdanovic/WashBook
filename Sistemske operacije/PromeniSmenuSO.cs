using DBBroker;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    public class PromeniSmenuSO : BaseSO
    {
        private RadnikPerionica dodela;
        private Radnik prijavljeni;

        public PromeniSmenuSO(IBroker broker, RadnikPerionica dodela, Radnik prijavljeni) : base(broker)
        {
            this.dodela = dodela;
            this.prijavljeni = prijavljeni;
        }

        protected override void ExecuteConcreteOperation()
        {
            Autorizacija.ProveriMenadzera(broker, prijavljeni);

            List<IEntity> postojeca = broker.Get(
                new RadnikPerionica(),
                "rp.idRadnik = @idr AND rp.idPerionica = @idp",
                new SqlParameter("@idr", dodela.IdRadnik),
                new SqlParameter("@idp", dodela.IdPerionica));

            if (postojeca.Count == 0)
                throw new Exception("Radnik nije raspoređen u zadatu perionicu.");

            broker.Update(dodela);
        }
    }
}
