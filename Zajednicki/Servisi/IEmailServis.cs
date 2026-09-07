
namespace Zajednicki.Servisi
{
    public interface IEmailServis
    {
        string AdresaPosiljaoca { get; }
        void Posalji(string primalac, string naslov, string telo, EmailPrilog prilog = null);
    }
}
