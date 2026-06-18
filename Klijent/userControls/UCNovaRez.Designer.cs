namespace Klijent
{
    partial class UCNovaRez
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblNaslov = new Label();
            pnlForma = new Panel();
            dgvStavke = new DataGridView();
            colUsluga = new DataGridViewTextBoxColumn();
            colCena = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btnObrisiStavku = new Button();
            lblUsluga = new Label();
            lblC = new Label();
            lblCena = new Label();
            btnDodajStavku = new Button();
            cmbUsluga = new ComboBox();
            lblUkupno = new Label();
            txtRegistracija = new TextBox();
            btnRezervisi = new Button();
            dtpDatum = new DateTimePicker();
            lblRegistracija = new Label();
            cmbTermin = new ComboBox();
            cmbIzbor = new ComboBox();
            lblTermin = new Label();
            lblDatum = new Label();
            lblIzbor = new Label();
            pnlHeader = new Panel();
            pnlForma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            groupBox1.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Dock = DockStyle.Left;
            lblNaslov.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNaslov.ForeColor = Color.FromArgb(30, 42, 58);
            lblNaslov.Location = new Point(20, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(234, 38);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Nova rezervacija";
            lblNaslov.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlForma
            // 
            pnlForma.Controls.Add(dgvStavke);
            pnlForma.Controls.Add(groupBox1);
            pnlForma.Controls.Add(lblUkupno);
            pnlForma.Controls.Add(txtRegistracija);
            pnlForma.Controls.Add(btnRezervisi);
            pnlForma.Controls.Add(dtpDatum);
            pnlForma.Controls.Add(lblRegistracija);
            pnlForma.Controls.Add(cmbTermin);
            pnlForma.Controls.Add(cmbIzbor);
            pnlForma.Controls.Add(lblTermin);
            pnlForma.Controls.Add(lblDatum);
            pnlForma.Controls.Add(lblIzbor);
            pnlForma.Dock = DockStyle.Fill;
            pnlForma.Location = new Point(0, 60);
            pnlForma.Name = "pnlForma";
            pnlForma.Padding = new Padding(30);
            pnlForma.Size = new Size(900, 540);
            pnlForma.TabIndex = 3;
            // 
            // dgvStavke
            // 
            dgvStavke.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvStavke.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStavke.BackgroundColor = Color.FromArgb(244, 246, 249);
            dgvStavke.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 42, 58);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStavke.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Columns.AddRange(new DataGridViewColumn[] { colUsluga, colCena });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(46, 134, 222);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStavke.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStavke.EnableHeadersVisualStyles = false;
            dgvStavke.GridColor = Color.FromArgb(220, 228, 240);
            dgvStavke.Location = new Point(20, 227);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.ReadOnly = true;
            dgvStavke.RowHeadersVisible = false;
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.RowTemplate.Height = 40;
            dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavke.Size = new Size(860, 228);
            dgvStavke.TabIndex = 11;
            // 
            // colUsluga
            // 
            colUsluga.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colUsluga.DataPropertyName = "NazivUsluge";
            colUsluga.HeaderText = "Usluga";
            colUsluga.MinimumWidth = 6;
            colUsluga.Name = "colUsluga";
            colUsluga.ReadOnly = true;
            // 
            // colCena
            // 
            colCena.DataPropertyName = "Cena";
            colCena.HeaderText = "Cena";
            colCena.MinimumWidth = 6;
            colCena.Name = "colCena";
            colCena.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnObrisiStavku);
            groupBox1.Controls.Add(lblUsluga);
            groupBox1.Controls.Add(lblC);
            groupBox1.Controls.Add(lblCena);
            groupBox1.Controls.Add(btnDodajStavku);
            groupBox1.Controls.Add(cmbUsluga);
            groupBox1.Location = new Point(20, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(860, 102);
            groupBox1.TabIndex = 10;
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
            btnObrisiStavku.Location = new Point(690, 36);
            btnObrisiStavku.Name = "btnObrisiStavku";
            btnObrisiStavku.Size = new Size(160, 46);
            btnObrisiStavku.TabIndex = 9;
            btnObrisiStavku.Text = "Obriši stavku";
            btnObrisiStavku.UseVisualStyleBackColor = false;
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
            btnDodajStavku.Location = new Point(524, 36);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(160, 46);
            btnDodajStavku.TabIndex = 5;
            btnDodajStavku.Text = "Dodaj stavku";
            btnDodajStavku.UseVisualStyleBackColor = false;
            // 
            // cmbUsluga
            // 
            cmbUsluga.FormattingEnabled = true;
            cmbUsluga.Location = new Point(16, 59);
            cmbUsluga.Name = "cmbUsluga";
            cmbUsluga.Size = new Size(175, 28);
            cmbUsluga.TabIndex = 1;
            // 
            // lblUkupno
            // 
            lblUkupno.AutoSize = true;
            lblUkupno.Location = new Point(576, 410);
            lblUkupno.Name = "lblUkupno";
            lblUkupno.Size = new Size(0, 20);
            lblUkupno.TabIndex = 7;
            // 
            // txtRegistracija
            // 
            txtRegistracija.Location = new Point(705, 75);
            txtRegistracija.Name = "txtRegistracija";
            txtRegistracija.Size = new Size(175, 27);
            txtRegistracija.TabIndex = 4;
            // 
            // btnRezervisi
            // 
            btnRezervisi.BackColor = Color.FromArgb(46, 134, 222);
            btnRezervisi.Cursor = Cursors.Hand;
            btnRezervisi.FlatAppearance.BorderSize = 0;
            btnRezervisi.FlatStyle = FlatStyle.Flat;
            btnRezervisi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRezervisi.ForeColor = Color.White;
            btnRezervisi.Location = new Point(720, 471);
            btnRezervisi.Name = "btnRezervisi";
            btnRezervisi.Size = new Size(160, 46);
            btnRezervisi.TabIndex = 3;
            btnRezervisi.Text = "Rezerviši";
            btnRezervisi.UseVisualStyleBackColor = false;
            // 
            // dtpDatum
            // 
            dtpDatum.Font = new Font("Segoe UI", 10F);
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(174, 69);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(359, 30);
            dtpDatum.TabIndex = 2;
            // 
            // lblRegistracija
            // 
            lblRegistracija.AutoSize = true;
            lblRegistracija.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegistracija.ForeColor = Color.FromArgb(8, 100, 120);
            lblRegistracija.Location = new Point(557, 78);
            lblRegistracija.Name = "lblRegistracija";
            lblRegistracija.Size = new Size(94, 20);
            lblRegistracija.TabIndex = 0;
            lblRegistracija.Text = "Registracija:";
            // 
            // cmbTermin
            // 
            cmbTermin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTermin.Font = new Font("Segoe UI", 10F);
            cmbTermin.FormatString = "HH:mm";
            cmbTermin.FormattingEnabled = true;
            cmbTermin.Location = new Point(705, 24);
            cmbTermin.Name = "cmbTermin";
            cmbTermin.Size = new Size(175, 31);
            cmbTermin.TabIndex = 1;
            // 
            // cmbIzbor
            // 
            cmbIzbor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIzbor.Font = new Font("Segoe UI", 10F);
            cmbIzbor.FormattingEnabled = true;
            cmbIzbor.Location = new Point(174, 19);
            cmbIzbor.Name = "cmbIzbor";
            cmbIzbor.Size = new Size(359, 31);
            cmbIzbor.TabIndex = 1;
            // 
            // lblTermin
            // 
            lblTermin.AutoSize = true;
            lblTermin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTermin.ForeColor = Color.FromArgb(8, 100, 120);
            lblTermin.Location = new Point(557, 27);
            lblTermin.Name = "lblTermin";
            lblTermin.Size = new Size(62, 20);
            lblTermin.TabIndex = 0;
            lblTermin.Text = "Termin:";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatum.ForeColor = Color.FromArgb(8, 100, 120);
            lblDatum.Location = new Point(26, 71);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(140, 20);
            lblDatum.TabIndex = 0;
            lblDatum.Text = "Datum rezervacije:";
            // 
            // lblIzbor
            // 
            lblIzbor.AutoSize = true;
            lblIzbor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIzbor.ForeColor = Color.FromArgb(8, 100, 120);
            lblIzbor.Location = new Point(23, 24);
            lblIzbor.Name = "lblIzbor";
            lblIzbor.Size = new Size(62, 20);
            lblIzbor.TabIndex = 0;
            lblIzbor.Text = "lblIzbor";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 0);
            pnlHeader.Size = new Size(900, 60);
            pnlHeader.TabIndex = 2;
            // 
            // UCNovaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlForma);
            Controls.Add(pnlHeader);
            Name = "UCNovaRez";
            Size = new Size(900, 600);
            pnlForma.ResumeLayout(false);
            pnlForma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Label lblNaslov;
        public Panel pnlForma;
        public Button btnRezervisi;
        public DateTimePicker dtpDatum;
        public ComboBox cmbTermin;
        public ComboBox cmbIzbor;
        public Label lblTermin;
        public Label lblDatum;
        public Label lblIzbor;
        public Panel pnlHeader;
        public ComboBox cmbUsluga;
        public Label lblUsluga;
        public TextBox txtRegistracija;
        public Label lblCena;
        public Label lblC;
        public Label lblRegistracija;
        public DataGridView dgvStavke;
        public Button btnDodajStavku;
        public Label lblUkupno;
        public Button btnObrisiStavku;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn colUsluga;
        private DataGridViewTextBoxColumn colCena;
    }
}
