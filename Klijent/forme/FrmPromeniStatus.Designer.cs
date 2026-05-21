namespace Klijent
{
    partial class FrmPromeniStatus
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
            cmbStatus = new ComboBox();
            btnSacuvaj = new Button();
            lblStatus = new Label();
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
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(164, 86);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 31);
            cmbStatus.TabIndex = 1;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.Cursor = Cursors.Hand;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Location = new Point(113, 160);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(125, 44);
            btnSacuvaj.TabIndex = 2;
            btnSacuvaj.Text = "💾 Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(80, 100, 120);
            lblStatus.Location = new Point(43, 89);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(93, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Novi status:";
            // 
            // FrmPromeniStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(382, 253);
            Controls.Add(lblStatus);
            Controls.Add(btnSacuvaj);
            Controls.Add(cmbStatus);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmPromeniStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promeni status rezervacije";
            Load += FrmPromeniStatus_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private ComboBox cmbStatus;
        private Button btnSacuvaj;
        private Label lblStatus;
    }
}