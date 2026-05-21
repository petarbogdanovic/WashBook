namespace Klijent
{
    partial class UcMojeRezervacije
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
            btnStorniraj = new Button();
            btnRefresh = new Button();
            lblNaslov = new Label();
            dgvRezervacije = new DataGridView();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnStorniraj);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 0);
            pnlHeader.Size = new Size(833, 60);
            pnlHeader.TabIndex = 0;
            // 
            // btnStorniraj
            // 
            btnStorniraj.Dock = DockStyle.Right;
            btnStorniraj.Location = new Point(619, 0);
            btnStorniraj.Name = "btnStorniraj";
            btnStorniraj.Size = new Size(94, 60);
            btnStorniraj.TabIndex = 2;
            btnStorniraj.Text = "❌Storniraj";
            btnStorniraj.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(46, 134, 222);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Dock = DockStyle.Right;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(713, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 60);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Osveži";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Dock = DockStyle.Left;
            lblNaslov.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblNaslov.Location = new Point(20, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(230, 37);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Moje rezervacije";
            lblNaslov.TextAlign = ContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 42, 58);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
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
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRezervacije.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRezervacije.Dock = DockStyle.Fill;
            dgvRezervacije.EnableHeadersVisualStyles = false;
            dgvRezervacije.GridColor = Color.FromArgb(220, 228, 240);
            dgvRezervacije.Location = new Point(0, 60);
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.ReadOnly = true;
            dgvRezervacije.RowHeadersVisible = false;
            dgvRezervacije.RowHeadersWidth = 51;
            dgvRezervacije.RowTemplate.Height = 40;
            dgvRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRezervacije.Size = new Size(833, 435);
            dgvRezervacije.TabIndex = 1;
            // 
            // UcMojeRezervacije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRezervacije);
            Controls.Add(pnlHeader);
            Name = "UcMojeRezervacije";
            Size = new Size(833, 495);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Panel pnlHeader;
        public Label lblNaslov;
        public Button btnRefresh;
        public DataGridView dgvRezervacije;
        public Button btnStorniraj;
    }
}
