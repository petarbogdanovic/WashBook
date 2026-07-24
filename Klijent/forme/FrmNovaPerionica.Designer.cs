namespace Klijent.forme
{
    partial class FrmNovaPerionica
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
            btnOdustani = new Button();
            btnSacuvaj = new Button();
            lblNaziv = new Label();
            lblAdresa = new Label();
            txtNaziv = new TextBox();
            txtAdresa = new TextBox();
            SuspendLayout();
            // 
            // btnOdustani
            // 
            btnOdustani.BackColor = Color.Firebrick;
            btnOdustani.Cursor = Cursors.Hand;
            btnOdustani.FlatAppearance.BorderSize = 0;
            btnOdustani.FlatStyle = FlatStyle.Flat;
            btnOdustani.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOdustani.ForeColor = Color.White;
            btnOdustani.Location = new Point(219, 225);
            btnOdustani.Name = "btnOdustani";
            btnOdustani.Size = new Size(154, 44);
            btnOdustani.TabIndex = 12;
            btnOdustani.Text = "Odustani";
            btnOdustani.UseVisualStyleBackColor = false;
            btnOdustani.Click += btnOdustani_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(59, 225);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(154, 44);
            btnSacuvaj.TabIndex = 13;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Location = new Point(18, 47);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(49, 20);
            lblNaziv.TabIndex = 14;
            lblNaziv.Text = "Naziv:";
            // 
            // lblAdresa
            // 
            lblAdresa.AutoSize = true;
            lblAdresa.Location = new Point(18, 111);
            lblAdresa.Name = "lblAdresa";
            lblAdresa.Size = new Size(58, 20);
            lblAdresa.TabIndex = 15;
            lblAdresa.Text = "Adresa:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(138, 44);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(232, 27);
            txtNaziv.TabIndex = 16;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(138, 104);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(232, 27);
            txtAdresa.TabIndex = 17;
            // 
            // FrmNovaPerionica
            // 
            AcceptButton = btnSacuvaj;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnOdustani;
            ClientSize = new Size(387, 280);
            Controls.Add(txtAdresa);
            Controls.Add(txtNaziv);
            Controls.Add(lblAdresa);
            Controls.Add(lblNaziv);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnOdustani);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNovaPerionica";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nova perionica";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOdustani;
        private Button btnSacuvaj;
        private Label lblNaziv;
        private Label lblAdresa;
        private TextBox txtNaziv;
        private TextBox txtAdresa;
    }
}