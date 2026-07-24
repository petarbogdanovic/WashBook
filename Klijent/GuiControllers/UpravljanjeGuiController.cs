using Klijent.forme;
using Klijent.UserControls;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent.GuiControllers
{
    public class UpravljanjeGuiController
    {
        private static UpravljanjeGuiController instance;

        public static UpravljanjeGuiController Instance => instance ??= new UpravljanjeGuiController();

        private UpravljanjeGuiController() { }

        private UcUpravljanje uc;

        public Control CreateUC()
        {
            uc = new UcUpravljanje();

            StilTabele.Primeni(uc.dgvPerionice);
            StilTabele.Primeni(uc.dgvRadnici);

            uc.btnNovaPerionica.Click += BtnNovaPerionica_Click;
            uc.btnNoviRadnik.Click += BtnNoviRadnik_Click;
            uc.btnRasporedi.Click += BtnRasporediRadnika_Click;
            uc.btnObrisiRadnika.Click += BtnObrisiRadnika_Click;

            UcitajPerionie();
            UcitajRadnike();

            return uc;
        }

        private void UcitajRadnike()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiSveRadnike, null);

                if (!odgovor.Uspesno)
                {
                    Greska(odgovor.Greska);
                    return;
                }

                List<Radnik> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Radnik>>(odgovor.Objekat);

                uc.dgvRadnici.DataSource = lista;
                PodesiKoloneRadnici();


            }
            catch (Exception ex)
            {
                Greska(ex.Message);
            }
        }


        private void UcitajPerionie()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiSvePerionice, null);

                if (!odgovor.Uspesno)
                {
                    Greska(odgovor.Greska);
                    return;
                }

                List<Perionica> lista = Komunikacija.Instance.Serializer.ReadType<List<Perionica>>(odgovor.Objekat);

                uc.dgvPerionice.DataSource = lista;
                PodesiKolonePerionice();
            }
            catch (Exception ex)
            {
                Greska(ex.Message);
            }
        }


        private void BtnNovaPerionica_Click(object? sender, EventArgs e)
        {
            if (new FrmNovaPerionica().ShowDialog() == DialogResult.OK)
                UcitajPerionie();
        }
        private void BtnNoviRadnik_Click(object? sender, EventArgs e)
        {
            if (new FrmNoviRadnik().ShowDialog() == DialogResult.OK)
                UcitajRadnike();
        }

        private void BtnRasporediRadnika_Click(object? sender, EventArgs e)
        {
            Radnik izabrani = IzabraniRadnik();
            if(izabrani == null)
            {
                MessageBox.Show("Izaberite radnika.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (new FrmRasporedRadnika(izabrani).ShowDialog() == DialogResult.OK)
                UcitajRadnike();
        }

        private Radnik IzabraniRadnik() => uc.dgvRadnici.CurrentRow?.DataBoundItem as Radnik;

        private void BtnObrisiRadnika_Click(object? sender, EventArgs e)
        {
            Radnik izabrani = IzabraniRadnik();
            if (izabrani == null)
            {
                MessageBox.Show("Izaberite radnika.", "Obaveštenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete radnika {izabrani.ImePrezime}?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.ObrisiRadnika, izabrani);

                if (!odgovor.Uspesno)
                {
                    Greska(odgovor.Greska);
                    return;
                }

                MessageBox.Show("Radnik je obrisan.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UcitajRadnike();
            }
            catch (Exception ex)
            {
                Greska(ex.Message);
            }
        }
        private void Greska(string prouka)
            => MessageBox.Show(prouka, "Greška",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void PodesiKolonePerionice()
        {
            if (uc.dgvPerionice.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in uc.dgvPerionice.Columns)
                col.Visible = false;

            string[] vidljive = { "Naziv", "Adresa" };
            foreach (string ime in vidljive)
                if (uc.dgvPerionice.Columns.Contains(ime))
                    uc.dgvPerionice.Columns[ime].Visible = true;

            if (uc.dgvPerionice.Columns.Contains("Naziv"))
                uc.dgvPerionice.Columns["Naziv"].HeaderText = "Naziv";
            if (uc.dgvPerionice.Columns.Contains("Adresa"))
                uc.dgvPerionice.Columns["Adresa"].HeaderText = "Adresa";
        }
        private void PodesiKoloneRadnici()
        {
            if (uc.dgvRadnici.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in uc.dgvRadnici.Columns)
                col.Visible = false;

            string[] vidljive = { "ImePrezime", "KorisnickoIme", "Telefon", "JeMenadzer" };
            foreach (string ime in vidljive)
                if (uc.dgvRadnici.Columns.Contains(ime))
                    uc.dgvRadnici.Columns[ime].Visible = true;

            if (uc.dgvRadnici.Columns.Contains("ImePrezime"))
                uc.dgvRadnici.Columns["ImePrezime"].HeaderText = "Radnik";
            if (uc.dgvRadnici.Columns.Contains("KorisnickoIme"))
                uc.dgvRadnici.Columns["KorisnickoIme"].HeaderText = "Korisničko ime";
            if (uc.dgvRadnici.Columns.Contains("Telefon"))
                uc.dgvRadnici.Columns["Telefon"].HeaderText = "Telefon";
            if (uc.dgvRadnici.Columns.Contains("JeMenadzer"))
                uc.dgvRadnici.Columns["JeMenadzer"].HeaderText = "Menadžer";
        }
    }
}
