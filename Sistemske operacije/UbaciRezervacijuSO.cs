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
        private IEmailServis emailServis;
        private string emailPrimaoca;

        public UbaciRezervacijuSO(IBroker broker,IEmailServis emailServis, Rezervacija rezervacija) : base(broker)
        {
            this.emailServis = emailServis;
            this.rezervacija = rezervacija;
        }

        public void UbaciIObavesti()
        {
            ExecuteTemplate();

            if (!string.IsNullOrWhiteSpace(emailPrimaoca))
                emailServis.Posalji(emailPrimaoca, SastaviNaslov(), SastaviTelo());
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

            if (rezervacija.Korisnik != null)
            {
                 Korisnik korisnik = (Korisnik)broker.GetById(
                    new Korisnik { IdKorisnik = rezervacija.Korisnik.IdKorisnik });
                if (korisnik != null)
                    emailPrimaoca = korisnik.Email;
            }

        }
        private string SastaviTelo() =>
            "Poštovani,\n\n" +
            "Vaša rezervacija je uspešno evidentirana.\n" +
            $"Termin: {rezervacija.Termin:dd.MM.yyyy HH:mm}\n" +
            $"Broj stavki: {rezervacija.Stavke.Count}\n\n" +
            "Hvala što koristite WashBook.";

        private string SastaviNaslov() => $"Potvrda rezervacije #{rezervacija.IdRezervacija}";
    }
}
