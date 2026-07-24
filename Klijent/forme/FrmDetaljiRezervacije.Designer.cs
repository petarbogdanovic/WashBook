namespace Klijent.forme
{
    partial class FrmDetaljiRezervacije
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblDatum = new Label();
            lblTermin = new Label();
            lblStatus = new Label();
            lblKorisnik = new Label();
            lblRadnik = new Label();
            lblUkupno = new Label();
            btnPromeniStatus = new Button();
            btnPromeniTermin = new Button();
            btnStorniraj = new Button();
            btnZatvori = new Button();
            lblRegistracija = new Label();
            dgvStavkeDetalji = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btnObrisiStavku = new Button();
            lblUsluga = new Label();
            lblC = new Label();
            lblCena = new Label();
            btnDodajStavku = new Button();
            cmbUsluga = new ComboBox();
            btnSacuvajIzmene = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStavkeDetalji).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Location = new Point(75, 26);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(50, 20);
            lblDatum.TabIndex = 1;
            lblDatum.Text = "label1";
            // 
            // lblTermin
            // 
            lblTermin.AutoSize = true;
            lblTermin.Location = new Point(75, 59);
            lblTermin.Name = "lblTermin";
            lblTermin.Size = new Size(50, 20);
            lblTermin.TabIndex = 2;
            lblTermin.Text = "label1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(356, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "label1";
            // 
            // lblKorisnik
            // 
            lblKorisnik.AutoSize = true;
            lblKorisnik.Location = new Point(665, 26);
            lblKorisnik.Name = "lblKorisnik";
            lblKorisnik.Size = new Size(50, 20);
            lblKorisnik.TabIndex = 4;
            lblKorisnik.Text = "label1";
            // 
            // lblRadnik
            // 
            lblRadnik.AutoSize = true;
            lblRadnik.Location = new Point(665, 59);
            lblRadnik.Name = "lblRadnik";
            lblRadnik.Size = new Size(50, 20);
            lblRadnik.TabIndex = 5;
            lblRadnik.Text = "label1";
            // 
            // lblUkupno
            // 
            lblUkupno.AutoSize = true;
            lblUkupno.Location = new Point(665, 437);
            lblUkupno.Name = "lblUkupno";
            lblUkupno.Size = new Size(50, 20);
            lblUkupno.TabIndex = 6;
            lblUkupno.Text = "label1";
            // 
            // btnPromeniStatus
            // 
            btnPromeniStatus.BackColor = Color.FromArgb(46, 134, 222);
            btnPromeniStatus.Cursor = Cursors.Hand;
            btnPromeniStatus.FlatAppearance.BorderSize = 0;
            btnPromeniStatus.FlatStyle = FlatStyle.Flat;
            btnPromeniStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPromeniStatus.ForeColor = Color.White;
            btnPromeniStatus.Location = new Point(12, 478);
            btnPromeniStatus.Name = "btnPromeniStatus";
            btnPromeniStatus.Size = new Size(154, 44);
            btnPromeniStatus.TabIndex = 8;
            btnPromeniStatus.Text = "Promeni status";
            btnPromeniStatus.UseVisualStyleBackColor = false;
            btnPromeniStatus.Click += btnPromeniStatus_Click;
            // 
            // btnPromeniTermin
            // 
            btnPromeniTermin.BackColor = Color.FromArgb(46, 134, 222);
            btnPromeniTermin.Cursor = Cursors.Hand;
            btnPromeniTermin.FlatAppearance.BorderSize = 0;
            btnPromeniTermin.FlatStyle = FlatStyle.Flat;
            btnPromeniTermin.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPromeniTermin.ForeColor = Color.White;
            btnPromeniTermin.Location = new Point(177, 478);
            btnPromeniTermin.Name = "btnPromeniTermin";
            btnPromeniTermin.Size = new Size(154, 44);
            btnPromeniTermin.TabIndex = 9;
            btnPromeniTermin.Text = "Promeni termin";
            btnPromeniTermin.UseVisualStyleBackColor = false;
            btnPromeniTermin.Click += btnPromeniTermin_Click;
            // 
            // btnStorniraj
            // 
            btnStorniraj.BackColor = Color.FromArgb(46, 134, 222);
            btnStorniraj.Cursor = Cursors.Hand;
            btnStorniraj.FlatAppearance.BorderSize = 0;
            btnStorniraj.FlatStyle = FlatStyle.Flat;
            btnStorniraj.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStorniraj.ForeColor = Color.White;
            btnStorniraj.Location = new Point(342, 478);
            btnStorniraj.Name = "btnStorniraj";
            btnStorniraj.Size = new Size(154, 44);
            btnStorniraj.TabIndex = 10;
            btnStorniraj.Text = "Storniraj";
            btnStorniraj.UseVisualStyleBackColor = false;
            btnStorniraj.Click += btnStorniraj_Click;
            // 
            // btnZatvori
            // 
            btnZatvori.BackColor = Color.Firebrick;
            btnZatvori.Cursor = Cursors.Hand;
            btnZatvori.FlatAppearance.BorderSize = 0;
            btnZatvori.FlatStyle = FlatStyle.Flat;
            btnZatvori.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZatvori.ForeColor = Color.White;
            btnZatvori.Location = new Point(672, 478);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(154, 44);
            btnZatvori.TabIndex = 11;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = false;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // lblRegistracija
            // 
            lblRegistracija.AutoSize = true;
            lblRegistracija.Location = new Point(356, 59);
            lblRegistracija.Name = "lblRegistracija";
            lblRegistracija.Size = new Size(50, 20);
            lblRegistracija.TabIndex = 12;
            lblRegistracija.Text = "label1";
            // 
            // dgvStavkeDetalji
            // 
            dgvStavkeDetalji.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvStavkeDetalji.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStavkeDetalji.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStavkeDetalji.BackgroundColor = Color.FromArgb(244, 246, 249);
            dgvStavkeDetalji.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 42, 58);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStavkeDetalji.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStavkeDetalji.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavkeDetalji.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(46, 134, 222);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStavkeDetalji.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStavkeDetalji.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStavkeDetalji.EnableHeadersVisualStyles = false;
            dgvStavkeDetalji.GridColor = Color.FromArgb(220, 228, 240);
            dgvStavkeDetalji.Location = new Point(12, 231);
            dgvStavkeDetalji.Name = "dgvStavkeDetalji";
            dgvStavkeDetalji.ReadOnly = true;
            dgvStavkeDetalji.RowHeadersVisible = false;
            dgvStavkeDetalji.RowHeadersWidth = 51;
            dgvStavkeDetalji.RowTemplate.Height = 40;
            dgvStavkeDetalji.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavkeDetalji.Size = new Size(814, 203);
            dgvStavkeDetalji.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "NazivUsluge";
            dataGridViewTextBoxColumn1.HeaderText = "Usluga";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Cena";
            dataGridViewTextBoxColumn2.HeaderText = "Cena";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnObrisiStavku);
            groupBox1.Controls.Add(lblUsluga);
            groupBox1.Controls.Add(lblC);
            groupBox1.Controls.Add(lblCena);
            groupBox1.Controls.Add(btnDodajStavku);
            groupBox1.Controls.Add(cmbUsluga);
            groupBox1.Location = new Point(12, 123);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(814, 102);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stavke pranja";
            // 
            // btnObrisiStavku
            // 
            btnObrisiStavku.BackColor = Color.FromArgb(46, 134, 222);
            btnObrisiStavku.Cursor = Cursors.Hand;
            btnObrisiStavku.FlatAppearance.BorderSize = 0;
            btnObrisiStavku.FlatStyle = FlatStyle.Flat;
            btnObrisiStavku.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnObrisiStavku.ForeColor = Color.White;
            btnObrisiStavku.Location = new Point(648, 47);
            btnObrisiStavku.Name = "btnObrisiStavku";
            btnObrisiStavku.Size = new Size(160, 46);
            btnObrisiStavku.TabIndex = 9;
            btnObrisiStavku.Text = "Obriši stavku";
            btnObrisiStavku.UseVisualStyleBackColor = false;
            btnObrisiStavku.Click += btnObrisiStavku_Click;
            // 
            // lblUsluga
            // 
            lblUsluga.AutoSize = true;
            lblUsluga.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsluga.ForeColor = Color.FromArgb(8, 100, 120);
            lblUsluga.Location = new Point(16, 36);
            lblUsluga.Name = "lblUsluga";
            lblUsluga.Size = new Size(61, 20);
            lblUsluga.TabIndex = 0;
            lblUsluga.Text = "Usluga:";
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblC.ForeColor = Color.FromArgb(8, 100, 120);
            lblC.Location = new Point(203, 36);
            lblC.Name = "lblC";
            lblC.Size = new Size(47, 20);
            lblC.TabIndex = 0;
            lblC.Text = "Cena:";
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Location = new Point(212, 62);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(0, 20);
            lblCena.TabIndex = 0;
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.BackColor = Color.FromArgb(46, 134, 222);
            btnDodajStavku.Cursor = Cursors.Hand;
            btnDodajStavku.FlatAppearance.BorderSize = 0;
            btnDodajStavku.FlatStyle = FlatStyle.Flat;
            btnDodajStavku.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDodajStavku.ForeColor = Color.White;
            btnDodajStavku.Location = new Point(482, 47);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(160, 46);
            btnDodajStavku.TabIndex = 5;
            btnDodajStavku.Text = "Dodaj stavku";
            btnDodajStavku.UseVisualStyleBackColor = false;
            btnDodajStavku.Click += btnDodajStavku_Click;
            // 
            // cmbUsluga
            // 
            cmbUsluga.FormattingEnabled = true;
            cmbUsluga.Location = new Point(16, 59);
            cmbUsluga.Name = "cmbUsluga";
            cmbUsluga.Size = new Size(175, 28);
            cmbUsluga.TabIndex = 1;
            cmbUsluga.SelectedIndexChanged += cmbUsluga_SelectedIndexChanged;
            // 
            // btnSacuvajIzmene
            // 
            btnSacuvajIzmene.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvajIzmene.Cursor = Cursors.Hand;
            btnSacuvajIzmene.FlatAppearance.BorderSize = 0;
            btnSacuvajIzmene.FlatStyle = FlatStyle.Flat;
            btnSacuvajIzmene.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSacuvajIzmene.ForeColor = Color.White;
            btnSacuvajIzmene.Location = new Point(507, 478);
            btnSacuvajIzmene.Name = "btnSacuvajIzmene";
            btnSacuvajIzmene.Size = new Size(154, 44);
            btnSacuvajIzmene.TabIndex = 10;
            btnSacuvajIzmene.Text = "Sacuvaj izmene";
            btnSacuvajIzmene.UseVisualStyleBackColor = false;
            btnSacuvajIzmene.Click += btnSacuvajIzmene_Click;
            // 
            // FrmDetaljiRezervacije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 534);
            Controls.Add(groupBox1);
            Controls.Add(dgvStavkeDetalji);
            Controls.Add(lblRegistracija);
            Controls.Add(btnSacuvajIzmene);
            Controls.Add(btnZatvori);
            Controls.Add(btnStorniraj);
            Controls.Add(btnPromeniTermin);
            Controls.Add(btnPromeniStatus);
            Controls.Add(lblUkupno);
            Controls.Add(lblRadnik);
            Controls.Add(lblKorisnik);
            Controls.Add(lblStatus);
            Controls.Add(lblTermin);
            Controls.Add(lblDatum);
            Name = "FrmDetaljiRezervacije";
            Text = "Form1";
            Load += FrmDetaljiRezervacije_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStavkeDetalji).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDatum;
        private Label lblTermin;
        private Label lblStatus;
        private Label lblKorisnik;
        private Label lblRadnik;
        private Label lblUkupno;
        private Button btnPromeniStatus;
        private Button btnPromeniTermin;
        private Button btnStorniraj;
        private Button btnZatvori;
        private Label lblRegistracija;
        public DataGridView dgvStavkeDetalji;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private GroupBox groupBox1;
        public Button btnObrisiStavku;
        public Label lblUsluga;
        public Label lblC;
        public Label lblCena;
        public Button btnDodajStavku;
        public ComboBox cmbUsluga;
        private Button btnSacuvajIzmene;
    }
}