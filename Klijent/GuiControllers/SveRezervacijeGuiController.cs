using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using Font = System.Drawing.Font;

namespace Klijent.GuiControllers
{
    public class SveRezervacijeGuiController
    {
        // Singleton
        private static SveRezervacijeGuiController instance;
        public static SveRezervacijeGuiController Instance
        {
            get
            {
                if (instance == null) instance = new SveRezervacijeGuiController();
                return instance;
            }
        }
        private SveRezervacijeGuiController() { }

        private UcSveRezervacije uc;

        public Control CreateUC()
        {
            uc = new UcSveRezervacije();

            // Vezivanje event handlera
            uc.btnRefresh.Click += BtnRefresh_Click;
            uc.btnObrisi.Click += BtnObrisi_Click;
            uc.dgvRezervacije.CellDoubleClick += DgvRezervacije_CellDoubleClick;

            // Inicijalno učitavanje
            UcitajRezervacije();

            return uc;
        }

        
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            UcitajRezervacije();
        }

        private void UcitajRezervacije()
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiListuRezervacija, "1=1");

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Rezervacija> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Rezervacija>>(odgovor.Objekat);

                uc.dgvRezervacije.DataSource = lista;
                PodesiKolone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodesiKolone()
        {
            if (uc.dgvRezervacije.Columns.Count == 0) return;

            // Sakrij nepotrebne kolone
            foreach (DataGridViewColumn col in uc.dgvRezervacije.Columns)
                col.Visible = false;

            // Prikaži samo relevantne
            string[] vidljive = {  "DatumRezervacije",
                                   "Termin", "ImeKorisnika",
                                   "StatusRezervacije","NazivTipVozila",
                                    "NazivUsluge","Registracija", "Cena" };

            foreach (string ime in vidljive)
            {
                if (uc.dgvRezervacije.Columns.Contains(ime))
                {
                    uc.dgvRezervacije.Columns[ime].Visible = true;
                }
            }

            if (uc.dgvRezervacije.Columns.Contains("Termin"))
            {
                uc.dgvRezervacije.Columns["Termin"].HeaderText = "Termin";
                uc.dgvRezervacije.Columns["Termin"].DefaultCellStyle.Format = "dd.MM.yyyy. | HH:mm";
            }
            if (uc.dgvRezervacije.Columns.Contains("ImeKorisnika"))
                uc.dgvRezervacije.Columns["ImeKorisnika"].HeaderText = "Korisnik";
            if (uc.dgvRezervacije.Columns.Contains("IdRezervacija"))
                uc.dgvRezervacije.Columns["IdRezervacija"].HeaderText = "ID";
            if (uc.dgvRezervacije.Columns.Contains("DatumRezervacije"))
            {
                uc.dgvRezervacije.Columns["DatumRezervacije"].HeaderText = "Datum rezervacije";
                uc.dgvRezervacije.Columns["DatumRezervacije"].DefaultCellStyle.Format = "dd.MM.yyyy.";
            }
            if (uc.dgvRezervacije.Columns.Contains("StatusRezervacije"))
                uc.dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";
            if (uc.dgvRezervacije.Columns.Contains("NazivTipVozila"))
                uc.dgvRezervacije.Columns["NazivTipVozila"].HeaderText = "Tip vozila";
            if (uc.dgvRezervacije.Columns.Contains("NazivUsluge"))
                uc.dgvRezervacije.Columns["NazivUsluge"].HeaderText = "Usluga";
            if (uc.dgvRezervacije.Columns.Contains("Registracija"))
                uc.dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";
            if (uc.dgvRezervacije.Columns.Contains("Cena"))
                uc.dgvRezervacije.Columns["Cena"].HeaderText = "Cena";
        }

        private void DgvRezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Rezervacija izabrana = (Rezervacija)uc.dgvRezervacije.Rows[e.RowIndex].DataBoundItem;

            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
            {
                FrmPromeniStatus frm = new FrmPromeniStatus(izabrana);
                frm.ShowDialog();
            }
            else
            {
                FrmPromeniTermin frm = new FrmPromeniTermin(izabrana);
                frm.ShowDialog();
            }

            UcitajRezervacije();
        }

        private void BtnObrisi_Click(object sender, EventArgs e)
        {
            if (uc.dgvRezervacije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite rezervaciju.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rezervacija selected = (Rezervacija)uc.dgvRezervacije.SelectedRows[0].DataBoundItem;

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete rezervaciju #{selected.IdRezervacija}?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.ObrisiRezervaciju, selected);

                if (odgovor.Uspesno)
                {
                    MessageBox.Show("Rezervacija je uspešno obrisana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajRezervacije();
                }
                else
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}