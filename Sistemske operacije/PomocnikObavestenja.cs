using DBBroker;
using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Sistemske_operacije
{
    internal static class PomocnikObavestenja
    {
        public static string UcitajEmail(IBroker broker, Korisnik korisnik)
        {
            if (korisnik == null) return null;

            Korisnik izBaze = (Korisnik)broker.GetById(
                new Korisnik { IdKorisnik = korisnik.IdKorisnik });

            return izBaze?.Email;
        }
    }
}
