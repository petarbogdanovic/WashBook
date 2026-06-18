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
            ((System.ComponentModel.ISupportInitialize)dgvStavkeDetalji).BeginInit();
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
            lblKorisnik.Location = new Point(356, 59);
            lblKorisnik.Name = "lblKorisnik";
            lblKorisnik.Size = new Size(50, 20);
            lblKorisnik.TabIndex = 4;
            lblKorisnik.Text = "label1";
            // 
            // lblRadnik
            // 
            lblRadnik.AutoSize = true;
            lblRadnik.Location = new Point(356, 92);
            lblRadnik.Name = "lblRadnik";
            lblRadnik.Size = new Size(50, 20);
            lblRadnik.TabIndex = 5;
            lblRadnik.Text = "label1";
            // 
            // lblUkupno
            // 
            lblUkupno.AutoSize = true;
            lblUkupno.Location = new Point(623, 59);
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
            btnPromeniStatus.Location = new Point(12, 378);
            btnPromeniStatus.Name = "btnPromeniStatus";
            btnPromeniStatus.Size = new Size(171, 44);
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
            btnPromeniTermin.Location = new Point(213, 378);
            btnPromeniTermin.Name = "btnPromeniTermin";
            btnPromeniTermin.Size = new Size(171, 44);
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
            btnStorniraj.Location = new Point(414, 378);
            btnStorniraj.Name = "btnStorniraj";
            btnStorniraj.Size = new Size(171, 44);
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
            btnZatvori.Location = new Point(615, 378);
            btnZatvori.Name = "btnZatvori";
            btnZatvori.Size = new Size(171, 44);
            btnZatvori.TabIndex = 11;
            btnZatvori.Text = "Zatvori";
            btnZatvori.UseVisualStyleBackColor = false;
            btnZatvori.Click += btnZatvori_Click;
            // 
            // lblRegistracija
            // 
            lblRegistracija.AutoSize = true;
            lblRegistracija.Location = new Point(75, 89);
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
            dgvStavkeDetalji.EnableHeadersVisualStyles = false;
            dgvStavkeDetalji.GridColor = Color.FromArgb(220, 228, 240);
            dgvStavkeDetalji.Location = new Point(12, 156);
            dgvStavkeDetalji.Name = "dgvStavkeDetalji";
            dgvStavkeDetalji.ReadOnly = true;
            dgvStavkeDetalji.RowHeadersVisible = false;
            dgvStavkeDetalji.RowHeadersWidth = 51;
            dgvStavkeDetalji.RowTemplate.Height = 40;
            dgvStavkeDetalji.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStavkeDetalji.Size = new Size(774, 203);
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
            // FrmDetaljiRezervacije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStavkeDetalji);
            Controls.Add(lblRegistracija);
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
    }
}