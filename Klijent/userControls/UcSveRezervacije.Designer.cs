namespace Klijent
{
    partial class UcSveRezervacije
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblNaslov = new Label();
            dgvRezervacije = new DataGridView();
            colSat = new DataGridViewTextBoxColumn();
            colDan0 = new DataGridViewTextBoxColumn();
            colDan1 = new DataGridViewTextBoxColumn();
            colDan2 = new DataGridViewTextBoxColumn();
            colDan3 = new DataGridViewTextBoxColumn();
            colDan4 = new DataGridViewTextBoxColumn();
            colDan5 = new DataGridViewTextBoxColumn();
            colDan6 = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.ForeColor = SystemColors.ControlText;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 0, 20, 0);
            pnlHeader.Size = new Size(736, 60);
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
            lblNaslov.Size = new Size(210, 38);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Sve rezervacije";
            lblNaslov.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvRezervacije
            // 
            dgvRezervacije.AllowUserToAddRows = false;
            dgvRezervacije.AllowUserToResizeColumns = false;
            dgvRezervacije.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dgvRezervacije.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRezervacije.BackgroundColor = Color.FromArgb(244, 246, 249);
            dgvRezervacije.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 42, 58);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRezervacije.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRezervacije.ColumnHeadersHeight = 48;
            dgvRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRezervacije.Columns.AddRange(new DataGridViewColumn[] { colSat, colDan0, colDan1, colDan2, colDan3, colDan4, colDan5, colDan6 });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(46, 134, 222);
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvRezervacije.DefaultCellStyle = dataGridViewCellStyle11;
            dgvRezervacije.Dock = DockStyle.Fill;
            dgvRezervacije.EnableHeadersVisualStyles = false;
            dgvRezervacije.GridColor = Color.FromArgb(220, 228, 240);
            dgvRezervacije.Location = new Point(0, 60);
            dgvRezervacije.MultiSelect = false;
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.ReadOnly = true;
            dgvRezervacije.RowHeadersVisible = false;
            dgvRezervacije.RowHeadersWidth = 51;
            dgvRezervacije.RowTemplate.Height = 42;
            dgvRezervacije.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvRezervacije.Size = new Size(736, 360);
            dgvRezervacije.TabIndex = 1;
            // 
            // colSat
            // 
            colSat.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 74, 105);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(45, 74, 105);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            colSat.DefaultCellStyle = dataGridViewCellStyle3;
            colSat.HeaderText = "";
            colSat.MinimumWidth = 6;
            colSat.Name = "colSat";
            colSat.ReadOnly = true;
            colSat.Resizable = DataGridViewTriState.False;
            colSat.SortMode = DataGridViewColumnSortMode.NotSortable;
            colSat.Width = 187;
            // 
            // colDan0
            // 
            colDan0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            colDan0.DefaultCellStyle = dataGridViewCellStyle4;
            colDan0.HeaderText = "";
            colDan0.MinimumWidth = 6;
            colDan0.Name = "colDan0";
            colDan0.ReadOnly = true;
            colDan0.Resizable = DataGridViewTriState.False;
            colDan0.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDan1
            // 
            colDan1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            colDan1.DefaultCellStyle = dataGridViewCellStyle5;
            colDan1.HeaderText = "";
            colDan1.MinimumWidth = 6;
            colDan1.Name = "colDan1";
            colDan1.ReadOnly = true;
            colDan1.Resizable = DataGridViewTriState.False;
            colDan1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDan2
            // 
            colDan2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            colDan2.DefaultCellStyle = dataGridViewCellStyle6;
            colDan2.HeaderText = "";
            colDan2.MinimumWidth = 6;
            colDan2.Name = "colDan2";
            colDan2.ReadOnly = true;
            colDan2.Resizable = DataGridViewTriState.False;
            colDan2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDan3
            // 
            colDan3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            colDan3.DefaultCellStyle = dataGridViewCellStyle7;
            colDan3.HeaderText = "";
            colDan3.MinimumWidth = 6;
            colDan3.Name = "colDan3";
            colDan3.ReadOnly = true;
            colDan3.Resizable = DataGridViewTriState.False;
            colDan3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDan4
            // 
            colDan4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            colDan4.DefaultCellStyle = dataGridViewCellStyle8;
            colDan4.HeaderText = "";
            colDan4.MinimumWidth = 6;
            colDan4.Name = "colDan4";
            colDan4.ReadOnly = true;
            colDan4.Resizable = DataGridViewTriState.False;
            colDan4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDan5
            // 
            colDan5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            colDan5.DefaultCellStyle = dataGridViewCellStyle9;
            colDan5.HeaderText = "";
            colDan5.MinimumWidth = 6;
            colDan5.Name = "colDan5";
            colDan5.ReadOnly = true;
            colDan5.Resizable = DataGridViewTriState.False;
            colDan5.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDan6
            // 
            colDan6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            colDan6.DefaultCellStyle = dataGridViewCellStyle10;
            colDan6.HeaderText = "";
            colDan6.MinimumWidth = 6;
            colDan6.Name = "colDan6";
            colDan6.ReadOnly = true;
            colDan6.Resizable = DataGridViewTriState.False;
            colDan6.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // UcSveRezervacije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRezervacije);
            Controls.Add(pnlHeader);
            Name = "UcSveRezervacije";
            Size = new Size(736, 420);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Panel pnlHeader;
        public Label lblNaslov;
        public DataGridView dgvRezervacije;
        private DataGridViewTextBoxColumn colSat;
        private DataGridViewTextBoxColumn colDan0;
        private DataGridViewTextBoxColumn colDan1;
        private DataGridViewTextBoxColumn colDan2;
        private DataGridViewTextBoxColumn colDan3;
        private DataGridViewTextBoxColumn colDan4;
        private DataGridViewTextBoxColumn colDan5;
        private DataGridViewTextBoxColumn colDan6;
    }
}
