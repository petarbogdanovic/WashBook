namespace Klijent.forme
{
    partial class FrmRasporedRadnika
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
            lblRadnik = new Label();
            lblTrenutno = new Label();
            lblPerionica = new Label();
            lblSmena = new Label();
            label1 = new Label();
            label2 = new Label();
            cmbPerionica = new ComboBox();
            cmbSmena = new ComboBox();
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
            btnSacuvaj.Location = new Point(117, 294);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(154, 44);
            btnSacuvaj.TabIndex = 15;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += this.btnSacuvaj_Click;
            // 
            // btnOdustani
            // 
            btnOdustani.BackColor = Color.Firebrick;
            btnOdustani.Cursor = Cursors.Hand;
            btnOdustani.FlatAppearance.BorderSize = 0;
            btnOdustani.FlatStyle = FlatStyle.Flat;
            btnOdustani.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOdustani.ForeColor = Color.White;
            btnOdustani.Location = new Point(277, 294);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(154, 44);
            btnOdustani.TabIndex = 14;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = false;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // lblRadnik
            // 
            lblRadnik.AutoSize = true;
            lblRadnik.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRadnik.Location = new Point(154, 64);
            lblRadnik.Name = "lblRadnik";
            lblRadnik.Size = new Size(51, 20);
            lblRadnik.TabIndex = 16;
            lblRadnik.Text = "label1";
            // 
            // lblTrenutno
            // 
            lblTrenutno.AutoSize = true;
            lblTrenutno.Location = new Point(154, 108);
            lblTrenutno.Name = "lblTrenutno";
            lblTrenutno.Size = new Size(50, 20);
            lblTrenutno.TabIndex = 17;
            lblTrenutno.Text = "label1";
            // 
            // lblPerionica
            // 
            lblPerionica.AutoSize = true;
            lblPerionica.Location = new Point(31, 177);
            lblPerionica.Name = "lblPerionica";
            lblPerionica.Size = new Size(72, 20);
            lblPerionica.TabIndex = 18;
            lblPerionica.Text = "Perionica:";
            // 
            // lblSmena
            // 
            lblSmena.AutoSize = true;
            lblSmena.Location = new Point(31, 217);
            lblSmena.Name = "lblSmena";
            lblSmena.Size = new Size(57, 20);
            lblSmena.TabIndex = 19;
            lblSmena.Text = "Smena:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 108);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 21;
            label1.Text = "Smena:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(31, 64);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 20;
            label2.Text = "Radnik:";
            // 
            // cmbPerionica
            // 
            cmbPerionica.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerionica.FormattingEnabled = true;
            cmbPerionica.Location = new Point(154, 174);
            cmbPerionica.Name = "cmbPerionica";
            cmbPerionica.Size = new Size(151, 28);
            cmbPerionica.TabIndex = 22;
            // 
            // cmbSmena
            // 
            cmbSmena.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSmena.FormattingEnabled = true;
            cmbSmena.Location = new Point(154, 214);
            cmbSmena.Name = "cmbSmena";
            cmbSmena.Size = new Size(151, 28);
            cmbSmena.TabIndex = 23;
            // 
            // FrmRasporedRadnika
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 354);
            Controls.Add(cmbSmena);
            Controls.Add(cmbPerionica);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblSmena);
            Controls.Add(lblPerionica);
            Controls.Add(lblTrenutno);
            Controls.Add(lblRadnik);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnOdustani);
            Name = "FrmRasporedRadnika";
            Text = "FrmRasporedRadnika";
            Load += FrmRasporedRadnika_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSacuvaj;
        private Button btnOdustani;
        private Label lblRadnik;
        private Label lblTrenutno;
        private Label lblPerionica;
        private Label lblSmena;
        private Label label1;
        private Label label2;
        private ComboBox cmbPerionica;
        private ComboBox cmbSmena;
    }
}