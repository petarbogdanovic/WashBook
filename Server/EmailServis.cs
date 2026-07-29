using DBBroker;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class EmailServis : IEmailServis
    {
        public void Posalji(string primalac, string naslov, string telo)
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
                    poruka.Body = new TextPart("plain") { Text = telo };

                    using var klijent = new SmtpClient();
                    klijent.Connect(p.Host, p.Port, SecureSocketOptions.StartTls);
                    klijent.Authenticate(p.Korisnik, p.Sifra);
                    klijent.Send(poruka);
                    klijent.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Loguj($"Neuspešno slanje mejla ka '{primalac}': {ex.Message}");
                }
            });
        }

        private static void Loguj(string poruka)
        {
            try
            {
                string putanja = Path.Combine(AppContext.BaseDirectory, "email-log.txt");
                File.AppendAllText(putanja, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  {poruka}{Environment.NewLine}");
            }
            catch
            {
                // i logovanje sme da padne tiho — ne rušimo server zbog log fajla
            }
        }
    }
}
