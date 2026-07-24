namespace Klijent.forme
{
    partial class FrmNoviRadnik
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
            btnSacuvaj = new Button();
            btnOdustani = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            chkJeMenadzer = new CheckBox();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            dtpDatumRodjenja = new DateTimePicker();
            txtAdresa = new TextBox();
            txtTelefon = new TextBox();
            txtKorisnickoIme = new TextBox();
            txtSifra = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(125, 352);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(154, 44);
            btnSacuvaj.TabIndex = 15;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // btnOdustani
            // 
            btnOdustani.BackColor = Color.Firebrick;
            btnOdustani.Cursor = Cursors.Hand;
            btnOdustani.FlatAppearance.BorderSize = 0;
            btnOdustani.FlatStyle = FlatStyle.Flat;
            btnOdustani.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOdustani.ForeColor = Color.White;
            btnOdustani.Location = new Point(285, 352);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(154, 44);
            btnOdustani.TabIndex = 14;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = false;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 37);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 16;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 67);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 17;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 98);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 18;
            label3.Text = "Datum rođenja:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 130);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 19;
            label4.Text = "Adresa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 162);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 20;
            label5.Text = "Telefon:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 228);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 21;
            label6.Text = "Korisničko ime:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 263);
            label7.Name = "label7";
            label7.Size = new Size(42, 20);
            label7.TabIndex = 22;
            label7.Text = "Šifra:";
            // 
            // chkJeMenadzer
            // 
            chkJeMenadzer.AutoSize = true;
            chkJeMenadzer.Location = new Point(317, 296);
            chkJeMenadzer.Name = "chkJeMenadzer";
            chkJeMenadzer.Size = new Size(97, 24);
            chkJeMenadzer.TabIndex = 23;
            chkJeMenadzer.Text = "Menadžer";
            chkJeMenadzer.UseVisualStyleBackColor = true;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(154, 34);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(260, 27);
            txtIme.TabIndex = 24;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(154, 64);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(260, 27);
            txtPrezime.TabIndex = 25;
            // 
            // dtpDatumRodjenja
            // 
            dtpDatumRodjenja.Location = new Point(154, 93);
            dtpDatumRodjenja.MaxDate = new DateTime(2026, 7, 24, 0, 0, 0, 0);
            dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            dtpDatumRodjenja.Size = new Size(260, 27);
            dtpDatumRodjenja.TabIndex = 26;
            dtpDatumRodjenja.Value = new DateTime(2026, 7, 24, 0, 0, 0, 0);
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(154, 126);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(260, 27);
            txtAdresa.TabIndex = 27;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(154, 159);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(260, 27);
            txtTelefon.TabIndex = 28;
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(154, 221);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(260, 27);
            txtKorisnickoIme.TabIndex = 29;
            // 
            // txtSifra
            // 
            txtSifra.Location = new Point(154, 256);
            txtSifra.Name = "txtSifra";
            txtSifra.Size = new Size(260, 27);
            txtSifra.TabIndex = 30;
            txtSifra.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ActiveCaptionText;
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(-1, 200);
            label8.Name = "label8";
            label8.Size = new Size(450, 3);
            label8.TabIndex = 31;
            // 
            // FrmNoviRadnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 411);
            Controls.Add(label8);
            Controls.Add(txtSifra);
            Controls.Add(txtKorisnickoIme);
            Controls.Add(txtTelefon);
            Controls.Add(txtAdresa);
            Controls.Add(dtpDatumRodjenja);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(chkJeMenadzer);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnOdustani);
            Name = "FrmNoviRadnik";
            Text = "Novi radnik";
            Load += FrmNoviRadnik_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSacuvaj;
        private Button btnOdustani;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private CheckBox chkJeMenadzer;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private DateTimePicker dtpDatumRodjenja;
        private TextBox txtAdresa;
        private TextBox txtTelefon;
        private TextBox txtKorisnickoIme;
        private TextBox txtSifra;
        private Label label8;
    }
}