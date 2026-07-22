namespace Klijent
{
    partial class FrmGlavnaKorisnik
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnOdjava = new Button();
            btnNovaRezervacija = new Button();
            btnMojeRezervacije = new Button();
            lblKorisnik = new Label();
            lblLogo = new Label();
            pnlSadrzaj = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(50, 82, 110);
            pnlSidebar.Controls.Add(btnOdjava);
            pnlSidebar.Controls.Add(btnNovaRezervacija);
            pnlSidebar.Controls.Add(btnMojeRezervacije);
            pnlSidebar.Controls.Add(lblKorisnik);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(238, 653);
            pnlSidebar.TabIndex = 0;
            // 
            // btnOdjava
            // 
            btnOdjava.BackColor = Color.Transparent;
            btnOdjava.Cursor = Cursors.Hand;
            btnOdjava.Dock = DockStyle.Top;
            btnOdjava.FlatAppearance.BorderSize = 0;
            btnOdjava.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btnOdjava.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btnOdjava.FlatStyle = FlatStyle.Flat;
            btnOdjava.Font = new Font("Segoe UI", 10F);
            btnOdjava.ForeColor = Color.FromArgb(220, 100, 100);
            btnOdjava.Location = new Point(0, 177);
            btnOdjava.Name = "btnOdjava";
            btnOdjava.Padding = new Padding(20, 0, 0, 0);
            btnOdjava.Size = new Size(238, 48);
            btnOdjava.TabIndex = 4;
            btnOdjava.Text = "🚪  Odjava";
            btnOdjava.TextAlign = ContentAlignment.MiddleLeft;
            btnOdjava.UseVisualStyleBackColor = false;
            btnOdjava.Click += btnOdjava_Click;
            // 
            // btnNovaRezervacija
            // 
            btnNovaRezervacija.BackColor = Color.Transparent;
            btnNovaRezervacija.Cursor = Cursors.Hand;
            btnNovaRezervacija.Dock = DockStyle.Top;
            btnNovaRezervacija.FlatAppearance.BorderSize = 0;
            btnNovaRezervacija.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btnNovaRezervacija.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btnNovaRezervacija.FlatStyle = FlatStyle.Flat;
            btnNovaRezervacija.Font = new Font("Segoe UI", 10F);
            btnNovaRezervacija.ForeColor = Color.FromArgb(200, 220, 240);
            btnNovaRezervacija.Location = new Point(0, 129);
            btnNovaRezervacija.Name = "btnNovaRezervacija";
            btnNovaRezervacija.Padding = new Padding(20, 0, 0, 0);
            btnNovaRezervacija.Size = new Size(238, 48);
            btnNovaRezervacija.TabIndex = 3;
            btnNovaRezervacija.Text = "➕  Nova rezervacija";
            btnNovaRezervacija.TextAlign = ContentAlignment.MiddleLeft;
            btnNovaRezervacija.UseVisualStyleBackColor = false;
            btnNovaRezervacija.Click += btnNovaRezervacija_Click;
            // 
            // btnMojeRezervacije
            // 
            btnMojeRezervacije.BackColor = Color.Transparent;
            btnMojeRezervacije.Cursor = Cursors.Hand;
            btnMojeRezervacije.Dock = DockStyle.Top;
            btnMojeRezervacije.FlatAppearance.BorderSize = 0;
            btnMojeRezervacije.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btnMojeRezervacije.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btnMojeRezervacije.FlatStyle = FlatStyle.Flat;
            btnMojeRezervacije.Font = new Font("Segoe UI", 10F);
            btnMojeRezervacije.ForeColor = Color.FromArgb(200, 220, 240);
            btnMojeRezervacije.Location = new Point(0, 81);
            btnMojeRezervacije.Name = "btnMojeRezervacije";
            btnMojeRezervacije.Padding = new Padding(20, 0, 0, 0);
            btnMojeRezervacije.Size = new Size(238, 48);
            btnMojeRezervacije.TabIndex = 2;
            btnMojeRezervacije.Text = "📋  Moje rezervacije";
            btnMojeRezervacije.TextAlign = ContentAlignment.MiddleLeft;
            btnMojeRezervacije.UseVisualStyleBackColor = false;
            btnMojeRezervacije.Click += btnMojeRezervacije_Click;
            // 
            // lblKorisnik
            // 
            lblKorisnik.AutoSize = true;
            lblKorisnik.Dock = DockStyle.Top;
            lblKorisnik.ForeColor = Color.FromArgb(150, 180, 210);
            lblKorisnik.Location = new Point(0, 61);
            lblKorisnik.Name = "lblKorisnik";
            lblKorisnik.Size = new Size(50, 20);
            lblKorisnik.TabIndex = 1;
            lblKorisnik.Text = "label1";
            lblKorisnik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Padding = new Padding(0, 10, 0, 10);
            lblLogo.Size = new Size(216, 61);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🚗 WashBook";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSadrzaj
            // 
            pnlSadrzaj.Dock = DockStyle.Fill;
            pnlSadrzaj.Location = new Point(238, 0);
            pnlSadrzaj.Name = "pnlSadrzaj";
            pnlSadrzaj.Padding = new Padding(20);
            pnlSadrzaj.Size = new Size(1046, 653);
            pnlSadrzaj.TabIndex = 1;
            // 
            // FrmGlavnaKorisnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(1284, 653);
            Controls.Add(pnlSadrzaj);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1100, 650);
            Name = "FrmGlavnaKorisnik";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WashBook";
            FormClosing += FrmGlavnaKorisnik_FormClosing;
            Load += FrmGlavnaKorisnik_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnMojeRezervacije;
        private Label lblKorisnik;
        private Label lblLogo;
        private Panel pnlSadrzaj;
        private Button btnOdjava;
        private Button btnNovaRezervacija;
    }
}