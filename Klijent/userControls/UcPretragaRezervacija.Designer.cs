namespace Klijent
{
    partial class UcPretragaRezervacija
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
            pnlHeader = new Panel();
            lblNaslov = new Label();
            pnlFilter = new Panel();
            btnPretrazi = new Button();
            cmbStatus = new ComboBox();
            dtpDatum = new DateTimePicker();
            lblStatus = new Label();
            lblDatumOd = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvRezervacije = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 0);
            pnlHeader.Size = new Size(899, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Dock = DockStyle.Left;
            lblNaslov.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNaslov.ForeColor = Color.FromArgb(30, 42, 58);
            lblNaslov.Location = new Point(20, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(277, 38);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Pretraga rezervacija";
            lblNaslov.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(244, 246, 249);
            pnlFilter.Controls.Add(btnPretrazi);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Controls.Add(dtpDatum);
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(lblDatumOd);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pnlFilter.ForeColor = Color.FromArgb(80, 100, 120);
            pnlFilter.Location = new Point(0, 60);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(20);
            pnlFilter.Size = new Size(899, 70);
            pnlFilter.TabIndex = 1;
            // 
            // btnPretrazi
            // 
            btnPretrazi.BackColor = Color.FromArgb(46, 134, 222);
            btnPretrazi.Cursor = Cursors.Hand;
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Location = new Point(678, 21);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(120, 36);
            btnPretrazi.TabIndex = 3;
            btnPretrazi.Text = "🔍 Pretraži";
            btnPretrazi.UseVisualStyleBackColor = false;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(391, 22);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 31);
            cmbStatus.TabIndex = 2;
            // 
            // dtpDatum
            // 
            dtpDatum.Font = new Font("Segoe UI", 10F);
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(98, 22);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(163, 30);
            dtpDatum.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(80, 100, 120);
            lblStatus.Location = new Point(300, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblDatumOd
            // 
            lblDatumOd.AutoSize = true;
            lblDatumOd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatumOd.ForeColor = Color.FromArgb(80, 100, 120);
            lblDatumOd.Location = new Point(23, 27);
            lblDatumOd.Name = "lblDatumOd";
            lblDatumOd.Size = new Size(61, 20);
            lblDatumOd.TabIndex = 0;
            lblDatumOd.Text = "Datum:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvRezervacije
            // 
            dgvRezervacije.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvRezervacije.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRezervacije.BackgroundColor = Color.FromArgb(244, 246, 249);
            dgvRezervacije.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 42, 58);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRezervacije.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(46, 134, 222);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRezervacije.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRezervacije.Dock = DockStyle.Fill;
            dgvRezervacije.EnableHeadersVisualStyles = false;
            dgvRezervacije.GridColor = Color.FromArgb(220, 228, 240);
            dgvRezervacije.Location = new Point(0, 130);
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.ReadOnly = true;
            dgvRezervacije.RowHeadersVisible = false;
            dgvRezervacije.RowHeadersWidth = 51;
            dgvRezervacije.RowTemplate.Height = 40;
            dgvRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRezervacije.Size = new Size(899, 374);
            dgvRezervacije.TabIndex = 3;
            // 
            // UcPretragaRezervacija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRezervacije);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "UcPretragaRezervacija";
            Size = new Size(899, 504);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Panel pnlHeader;
        public Label lblNaslov;
        public Panel pnlFilter;
        public DateTimePicker dtpDatum;
        public Label lblStatus;
        public Label lblDatumOd;
        public Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        public Button btnPretrazi;
        public ComboBox cmbStatus;
        public DataGridView dgvRezervacije;
    }
}
