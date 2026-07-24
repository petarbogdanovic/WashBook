namespace Klijent
{
    partial class FrmGlavnaRadnik
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
            btnUpravljanje = new Button();
            btnPretraga = new Button();
            btnNovaRezervacija = new Button();
            btnSveRezervacije = new Button();
            lblKorisnik = new Label();
            lblLogo = new Label();
            pnlSadrzaj = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(50, 80, 110);
            pnlSidebar.Controls.Add(btnOdjava);
            pnlSidebar.Controls.Add(btnUpravljanje);
            pnlSidebar.Controls.Add(btnPretraga);
            pnlSidebar.Controls.Add(btnNovaRezervacija);
            pnlSidebar.Controls.Add(btnSveRezervacije);
            pnlSidebar.Controls.Add(lblKorisnik);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.ForeColor = Color.FromArgb(50, 80, 110);
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(10, 0, 10, 0);
            pnlSidebar.Size = new Size(329, 670);
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
            btnOdjava.Location = new Point(10, 270);
            btnOdjava.Name = "btnOdjava";
            btnOdjava.Padding = new Padding(20, 0, 0, 0);
            btnOdjava.Size = new Size(309, 48);
            btnOdjava.TabIndex = 4;
            btnOdjava.Text = "🚪  Odjava";
            btnOdjava.TextAlign = ContentAlignment.MiddleLeft;
            btnOdjava.UseVisualStyleBackColor = false;
            btnOdjava.Click += btnOdjava_Click;
            // 
            // btnUpravljanje
            // 
            btnUpravljanje.BackColor = Color.Transparent;
            btnUpravljanje.Cursor = Cursors.Hand;
            btnUpravljanje.Dock = DockStyle.Top;
            btnUpravljanje.FlatAppearance.BorderSize = 0;
            btnUpravljanje.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btnUpravljanje.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btnUpravljanje.FlatStyle = FlatStyle.Flat;
            btnUpravljanje.Font = new Font("Segoe UI", 10F);
            btnUpravljanje.ForeColor = Color.FromArgb(200, 220, 240);
            btnUpravljanje.Location = new Point(10, 222);
            btnUpravljanje.Name = "btnUpravljanje";
            btnUpravljanje.Padding = new Padding(20, 0, 0, 0);
            btnUpravljanje.Size = new Size(309, 48);
            btnUpravljanje.TabIndex = 5;
            btnUpravljanje.Text = "⚙️  Upravljanje";
            btnUpravljanje.TextAlign = ContentAlignment.MiddleLeft;
            btnUpravljanje.UseVisualStyleBackColor = false;
            btnUpravljanje.Click += btnUpravljanje_Click;
            // 
            // btnPretraga
            // 
            btnPretraga.BackColor = Color.Transparent;
            btnPretraga.Cursor = Cursors.Hand;
            btnPretraga.Dock = DockStyle.Top;
            btnPretraga.FlatAppearance.BorderSize = 0;
            btnPretraga.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btnPretraga.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btnPretraga.FlatStyle = FlatStyle.Flat;
            btnPretraga.Font = new Font("Segoe UI", 10F);
            btnPretraga.ForeColor = Color.FromArgb(200, 220, 240);
            btnPretraga.Location = new Point(10, 174);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Padding = new Padding(20, 0, 0, 0);
            btnPretraga.Size = new Size(309, 48);
            btnPretraga.TabIndex = 3;
            btnPretraga.Text = "🔍  Pretraga";
            btnPretraga.TextAlign = ContentAlignment.MiddleLeft;
            btnPretraga.UseVisualStyleBackColor = false;
            btnPretraga.Click += btnPretraga_Click;
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
            btnNovaRezervacija.Location = new Point(10, 126);
            btnNovaRezervacija.Name = "btnNovaRezervacija";
            btnNovaRezervacija.Padding = new Padding(20, 0, 0, 0);
            btnNovaRezervacija.Size = new Size(309, 48);
            btnNovaRezervacija.TabIndex = 2;
            btnNovaRezervacija.Text = "➕  Nova rezervacija";
            btnNovaRezervacija.TextAlign = ContentAlignment.MiddleLeft;
            btnNovaRezervacija.UseVisualStyleBackColor = false;
            btnNovaRezervacija.Click += btnNovaRezervacija_Click;
            // 
            // btnSveRezervacije
            // 
            btnSveRezervacije.BackColor = Color.Transparent;
            btnSveRezervacije.Cursor = Cursors.Hand;
            btnSveRezervacije.Dock = DockStyle.Top;
            btnSveRezervacije.FlatAppearance.BorderSize = 0;
            btnSveRezervacije.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btnSveRezervacije.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btnSveRezervacije.FlatStyle = FlatStyle.Flat;
            btnSveRezervacije.Font = new Font("Segoe UI", 10F);
            btnSveRezervacije.ForeColor = Color.FromArgb(200, 220, 240);
            btnSveRezervacije.Location = new Point(10, 78);
            btnSveRezervacije.Name = "btnSveRezervacije";
            btnSveRezervacije.Padding = new Padding(20, 0, 0, 0);
            btnSveRezervacije.Size = new Size(309, 48);
            btnSveRezervacije.TabIndex = 2;
            btnSveRezervacije.Text = "📋  Sve rezervacije";
            btnSveRezervacije.TextAlign = ContentAlignment.MiddleLeft;
            btnSveRezervacije.UseVisualStyleBackColor = false;
            btnSveRezervacije.Click += btnSveRezervacije_Click;
            // 
            // lblKorisnik
            // 
            lblKorisnik.AutoSize = true;
            lblKorisnik.Dock = DockStyle.Top;
            lblKorisnik.ForeColor = Color.FromArgb(150, 180, 210);
            lblKorisnik.Location = new Point(10, 58);
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
            lblLogo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(10, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Padding = new Padding(0, 10, 0, 10);
            lblLogo.Size = new Size(203, 58);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🚗 WashBook";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSadrzaj
            // 
            pnlSadrzaj.Dock = DockStyle.Fill;
            pnlSadrzaj.Location = new Point(329, 0);
            pnlSadrzaj.Name = "pnlSadrzaj";
            pnlSadrzaj.Padding = new Padding(20);
            pnlSadrzaj.Size = new Size(953, 670);
            pnlSadrzaj.TabIndex = 1;
            // 
            // FrmGlavnaRadnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(1282, 670);
            Controls.Add(pnlSadrzaj);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1100, 650);
            Name = "FrmGlavnaRadnik";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WashBook";
            FormClosing += FrmGlavnaRadnik_FormClosing;
            Load += FrmGlavnaRadnik_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlSadrzaj;
        private Button btnPretraga;
        private Button btnNovaRezervacija;
        private Button btnSveRezervacije;
        private Label lblKorisnik;
        private Label lblLogo;
        private Button btnOdjava;
        private Button btnUpravljanje;
    }
}