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
        public int? IdRadnik { get; set; }
        public DateTime? Datum { get; set; }
        public StatusRezervacije? Status { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
    }
}
