using DBBroker;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Text;
using Zajednicki.Servisi;

namespace Server
{
    public class EmailServis : IEmailServis
    {
        public string AdresaPosiljaoca => Konfiguracija.Smtp.Posiljalac;
        private static readonly object brava = new object();
        public void Posalji(string primalac, string naslov, string telo, EmailPrilog prilog = null)
        {
            Task.Run(() =>
            {
                try
                {
                    SmtpPodaci p = Konfiguracija.Smtp;

                    var poruka = new MimeMessage();
                    poruka.From.Add(new MailboxAddress(p.ImePosiljaoca, p.Posiljalac));
                    poruka.To.Add(MailboxAddress.Parse(primalac));
                    poruka.Subject = naslov;

                    var tekst = new TextPart("plain") { Text = telo };

                    if (prilog == null)
                    {
                        poruka.Body = tekst;
                    }
                    else
                    {
                        var kalendar = new MimePart("text", "calendar")
                        {
                            Content = new MimeContent(
                                new MemoryStream(Encoding.UTF8.GetBytes(prilog.Sadrzaj))),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = prilog.Naziv
                        };
                        kalendar.ContentType.Parameters.Add("method", prilog.Metod);
                        kalendar.ContentType.Parameters.Add("charset", "UTF-8");

                        var multipart = new Multipart("mixed") { tekst, kalendar };
                        poruka.Body = multipart;
                    }

                    using var klijent = new SmtpClient();
                    klijent.Connect(p.Host, p.Port, SecureSocketOptions.StartTls);
                    klijent.Authenticate(p.Korisnik, p.Sifra);
                    klijent.Send(poruka);
                    klijent.Disconnect(true);

                    Loguj($"OK  Mejl poslat ka '{primalac}' — '{naslov}'" +
                          (prilog != null ? $" (+{prilog.Naziv})" : ""));
                }
                catch (Exception ex)
                {
                    Loguj($"GREŠKA Neuspešno slanje mejla ka '{primalac}': {ex.Message}");
                }
            });
        }

        private static void Loguj(string poruka)
        {
            try
            {
                string putanja = Path.Combine(AppContext.BaseDirectory, "email-log.txt");
                lock (brava)
                {
                    File.AppendAllText(putanja, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  {poruka}{Environment.NewLine}");
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"[EmailServis] Log nije upisan: {ex.Message}");
            }
        }
    }
}
