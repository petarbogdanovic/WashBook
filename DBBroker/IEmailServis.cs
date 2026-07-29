using System;
using System.Collections.Generic;
using System.Text;

namespace DBBroker
{
    public interface IEmailServis
    {
        void Posalji(string primalac, string naslov, string telo);
    }
}
