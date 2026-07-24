namespace Klijent.UserControls
{
    partial class UcUpravljanje
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
            groupBox1 = new GroupBox();
            btnNovaPerionica = new Button();
            dgvPerionice = new DataGridView();
            groupBox2 = new GroupBox();
            btnObrisiRadnika = new Button();
            btnRasporedi = new Button();
            btnNoviRadnik = new Button();
            dgvRadnici = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPerionice).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRadnici).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Controls.Add(dgvPerionice);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 495);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Perionice";
            // 
            // btnNovaPerionica
            // 
            btnNovaPerionica.BackColor = Color.FromArgb(46, 134, 222);
            btnNovaPerionica.Cursor = Cursors.Hand;
            btnNovaPerionica.FlatAppearance.BorderSize = 0;
            btnNovaPerionica.FlatStyle = FlatStyle.Flat;
            btnNovaPerionica.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNovaPerionica.ForeColor = Color.White;
            btnNovaPerionica.Location = new Point(3, 3);
            btnNovaPerionica.Name = "btnNovaPerionica";
            btnNovaPerionica.Size = new Size(163, 36);
            btnNovaPerionica.TabIndex = 4;
            btnNovaPerionica.Text = "Nova perionica";
            btnNovaPerionica.TextAlign = ContentAlignment.MiddleLeft;
            btnNovaPerionica.UseVisualStyleBackColor = false;
            // 
            // dgvPerionice
            // 
            dgvPerionice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerionice.Dock = DockStyle.Fill;
            dgvPerionice.Location = new Point(3, 23);
            dgvPerionice.Name = "dgvPerionice";
            dgvPerionice.RowHeadersWidth = 51;
            dgvPerionice.Size = new Size(382, 469);
            dgvPerionice.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel2);
            groupBox2.Controls.Add(dgvRadnici);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(397, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(439, 495);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Radnici";
            // 
            // btnObrisiRadnika
            // 
            btnObrisiRadnika.BackColor = Color.FromArgb(46, 134, 222);
            btnObrisiRadnika.Cursor = Cursors.Hand;
            btnObrisiRadnika.FlatAppearance.BorderSize = 0;
            btnObrisiRadnika.FlatStyle = FlatStyle.Flat;
            btnObrisiRadnika.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnObrisiRadnika.ForeColor = Color.White;
            btnObrisiRadnika.Location = new Point(3, 45);
            btnObrisiRadnika.Name = "btnObrisiRadnika";
            btnObrisiRadnika.Size = new Size(196, 36);
            btnObrisiRadnika.TabIndex = 7;
            btnObrisiRadnika.Text = "Obrisi radnika";
            btnObrisiRadnika.TextAlign = ContentAlignment.MiddleLeft;
            btnObrisiRadnika.UseVisualStyleBackColor = false;
            // 
            // btnRasporedi
            // 
            btnRasporedi.BackColor = Color.FromArgb(46, 134, 222);
            btnRasporedi.Cursor = Cursors.Hand;
            btnRasporedi.FlatAppearance.BorderSize = 0;
            btnRasporedi.FlatStyle = FlatStyle.Flat;
            btnRasporedi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRasporedi.ForeColor = Color.White;
            btnRasporedi.Location = new Point(205, 3);
            btnRasporedi.Name = "btnRasporedi";
            btnRasporedi.Size = new Size(196, 36);
            btnRasporedi.TabIndex = 6;
            btnRasporedi.Text = "Rasporedi radnika";
            btnRasporedi.TextAlign = ContentAlignment.MiddleLeft;
            btnRasporedi.UseVisualStyleBackColor = false;
            // 
            // btnNoviRadnik
            // 
            btnNoviRadnik.BackColor = Color.FromArgb(46, 134, 222);
            btnNoviRadnik.Cursor = Cursors.Hand;
            btnNoviRadnik.FlatAppearance.BorderSize = 0;
            btnNoviRadnik.FlatStyle = FlatStyle.Flat;
            btnNoviRadnik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNoviRadnik.ForeColor = Color.White;
            btnNoviRadnik.Location = new Point(3, 3);
            btnNoviRadnik.Name = "btnNoviRadnik";
            btnNoviRadnik.Size = new Size(196, 36);
            btnNoviRadnik.TabIndex = 5;
            btnNoviRadnik.Text = "Novi radnik";
            btnNoviRadnik.TextAlign = ContentAlignment.MiddleLeft;
            btnNoviRadnik.UseVisualStyleBackColor = false;
            // 
            // dgvRadnici
            // 
            dgvRadnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRadnici.Dock = DockStyle.Fill;
            dgvRadnici.Location = new Point(3, 23);
            dgvRadnici.Name = "dgvRadnici";
            dgvRadnici.RowHeadersWidth = 51;
            dgvRadnici.Size = new Size(433, 469);
            dgvRadnici.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.9606667F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.0393333F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(839, 501);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnNovaPerionica);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(3, 392);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(382, 100);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnNoviRadnik);
            flowLayoutPanel2.Controls.Add(btnRasporedi);
            flowLayoutPanel2.Controls.Add(btnObrisiRadnika);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(3, 392);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(433, 100);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // UcUpravljanje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UcUpravljanje";
            Size = new Size(839, 501);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPerionice).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRadnici).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        public DataGridView dgvPerionice;
        public DataGridView dgvRadnici;
        public Button btnNovaPerionica;
        public Button btnObrisiRadnika;
        public Button btnRasporedi;
        public Button btnNoviRadnik;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
