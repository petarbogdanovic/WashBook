namespace Klijent
{
    partial class FrmPromeniTermin
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
            lblInfo = new Label();
            lblDatum = new Label();
            lblTermin = new Label();
            dtpDatum = new DateTimePicker();
            cmbTermin = new ComboBox();
            btnSacuvaj = new Button();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Dock = DockStyle.Top;
            lblInfo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfo.ForeColor = Color.FromArgb(30, 42, 58);
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Padding = new Padding(0, 10, 0, 10);
            lblInfo.Size = new Size(63, 45);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "label1";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Click += lblInfo_Click;
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatum.ForeColor = Color.FromArgb(80, 100, 120);
            lblDatum.Location = new Point(29, 65);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(117, 25);
            lblDatum.TabIndex = 1;
            lblDatum.Text = "Novi datum:";
            // 
            // lblTermin
            // 
            lblTermin.AutoSize = true;
            lblTermin.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTermin.ForeColor = Color.FromArgb(80, 100, 120);
            lblTermin.Location = new Point(29, 138);
            lblTermin.Name = "lblTermin";
            lblTermin.Size = new Size(118, 25);
            lblTermin.TabIndex = 2;
            lblTermin.Text = "Novi termin:";
            // 
            // dtpDatum
            // 
            dtpDatum.Font = new Font("Segoe UI", 10F);
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(153, 64);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(179, 30);
            dtpDatum.TabIndex = 3;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // cmbTermin
            // 
            cmbTermin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTermin.Font = new Font("Segoe UI", 10F);
            cmbTermin.FormatString = "HH:mm";
            cmbTermin.FormattingEnabled = true;
            cmbTermin.Location = new Point(153, 139);
            cmbTermin.Name = "cmbTermin";
            cmbTermin.Size = new Size(179, 31);
            cmbTermin.TabIndex = 4;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(111, 219);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(130, 44);
            btnSacuvaj.TabIndex = 5;
            btnSacuvaj.Text = "💾 Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // FrmPromeniTermin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(382, 303);
            Controls.Add(btnSacuvaj);
            Controls.Add(cmbTermin);
            Controls.Add(dtpDatum);
            Controls.Add(lblTermin);
            Controls.Add(lblDatum);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmPromeniTermin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promeni termin rezervacije";
            Load += FrmPromeniTermin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private Label lblDatum;
        private Label lblTermin;
        private DateTimePicker dtpDatum;
        private ComboBox cmbTermin;
        private Button btnSacuvaj;
    }
}