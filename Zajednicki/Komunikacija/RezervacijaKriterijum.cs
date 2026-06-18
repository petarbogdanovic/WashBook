using System;
using System.Collections.Generic;
using System.Text;
using Zajednicki.Domen;

namespace Zajednicki.Komunikacija
{
    public class RezervacijaKriterijum
    {
        public int? IdPerionica { get; set; }
        public int? IdKorisnik { get; set; }
        public DateTime? Datum { get; set; }
        public StatusRezervacije? Status { get; set; }
    }
}
