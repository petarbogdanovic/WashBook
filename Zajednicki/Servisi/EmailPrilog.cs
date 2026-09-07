using System;
using System.Collections.Generic;
using System.Text;

namespace Zajednicki.Servisi
{
    public class EmailPrilog
    {
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public string MimeTip { get; set; } = "text/calendar";
        public string Metod { get; set; } = "REQUEST";
    }
}
