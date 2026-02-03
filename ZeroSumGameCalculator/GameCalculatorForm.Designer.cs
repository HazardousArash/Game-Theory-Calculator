namespace ZeroSumGameCalculator
{
    partial class GameCalculatorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameCalculatorForm));
            rootLayout = new TableLayoutPanel();
            panelMatrix = new Panel();
            gridPayoff = new DataGridView();
            bottomLayout = new TableLayoutPanel();
            settingsPanel = new Panel();
            SolveButton = new Button();
            ColsNumericUpDown = new NumericUpDown();
            lblCols = new Label();
            RowsNumericUpDown = new NumericUpDown();
            lblRows = new Label();
            resultsPanel = new Panel();
            textOutput = new RichTextBox();
            lblResults = new Label();
            rootLayout.SuspendLayout();
            panelMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPayoff).BeginInit();
            bottomLayout.SuspendLayout();
            settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ColsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RowsNumericUpDown).BeginInit();
            resultsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.BackColor = Color.FromArgb(24, 24, 28);
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(panelMatrix, 0, 0);
            rootLayout.Controls.Add(bottomLayout, 0, 1);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            rootLayout.Size = new Size(1000, 700);
            rootLayout.TabIndex = 0;
            // 
            // panelMatrix
            // 
            panelMatrix.BackColor = Color.FromArgb(24, 24, 28);
            panelMatrix.Controls.Add(gridPayoff);
            panelMatrix.Dock = DockStyle.Fill;
            panelMatrix.Location = new Point(15, 15);
            panelMatrix.Name = "panelMatrix";
            panelMatrix.Size = new Size(970, 467);
            panelMatrix.TabIndex = 0;
            // 
            // gridPayoff
            // 
            gridPayoff.AllowUserToAddRows = false;
            gridPayoff.AllowUserToDeleteRows = false;
            gridPayoff.AllowUserToResizeColumns = false;
            gridPayoff.AllowUserToResizeRows = false;
            gridPayoff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPayoff.BackgroundColor = Color.FromArgb(30, 30, 34);
            gridPayoff.BorderStyle = BorderStyle.None;
            gridPayoff.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(40, 40, 46);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridPayoff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridPayoff.ColumnHeadersHeight = 36;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(32, 32, 36);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 120, 200);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridPayoff.DefaultCellStyle = dataGridViewCellStyle2;
            gridPayoff.Dock = DockStyle.Fill;
            gridPayoff.EditMode = DataGridViewEditMode.EditOnEnter;
            gridPayoff.EnableHeadersVisualStyles = false;
            gridPayoff.GridColor = Color.FromArgb(55, 55, 60);
            gridPayoff.Location = new Point(0, 0);
            gridPayoff.MultiSelect = false;
            gridPayoff.Name = "gridPayoff";
            gridPayoff.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(40, 40, 46);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridPayoff.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridPayoff.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            gridPayoff.RowTemplate.Height = 32;
            gridPayoff.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridPayoff.Size = new Size(970, 467);
            gridPayoff.TabIndex = 0;
            // 
            // bottomLayout
            // 
            bottomLayout.BackColor = Color.FromArgb(24, 24, 28);
            bottomLayout.ColumnCount = 1;
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomLayout.Controls.Add(settingsPanel, 0, 0);
            bottomLayout.Controls.Add(resultsPanel, 0, 1);
            bottomLayout.Dock = DockStyle.Fill;
            bottomLayout.Location = new Point(15, 488);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.RowCount = 2;
            bottomLayout.RowStyles.Add(new RowStyle());
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomLayout.Size = new Size(970, 197);
            bottomLayout.TabIndex = 1;
            // 
            // settingsPanel
            // 
            settingsPanel.BackColor = Color.FromArgb(32, 32, 36);
            settingsPanel.Controls.Add(SolveButton);
            settingsPanel.Controls.Add(ColsNumericUpDown);
            settingsPanel.Controls.Add(lblCols);
            settingsPanel.Controls.Add(RowsNumericUpDown);
            settingsPanel.Controls.Add(lblRows);
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(3, 3);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Padding = new Padding(12, 10, 12, 10);
            settingsPanel.Size = new Size(964, 52);
            settingsPanel.TabIndex = 0;
            // 
            // SolveButton
            // 
            SolveButton.BackColor = Color.Orange;
            SolveButton.Cursor = Cursors.Hand;
            SolveButton.Dock = DockStyle.Right;
            SolveButton.FlatAppearance.BorderSize = 0;
            SolveButton.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
            SolveButton.FlatAppearance.MouseOverBackColor = Color.DarkOrange;
            SolveButton.FlatStyle = FlatStyle.Flat;
            SolveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            SolveButton.ForeColor = Color.Black;
            SolveButton.Location = new Point(812, 10);
            SolveButton.Margin = new Padding(0);
            SolveButton.Name = "SolveButton";
            SolveButton.Size = new Size(140, 32);
            SolveButton.TabIndex = 0;
            SolveButton.Text = "Solve Game";
            SolveButton.UseVisualStyleBackColor = false;
            SolveButton.Click += SolveButton_Click;
            // 
            // ColsNumericUpDown
            // 
            ColsNumericUpDown.BackColor = Color.FromArgb(45, 45, 50);
            ColsNumericUpDown.ForeColor = Color.White;
            ColsNumericUpDown.Location = new Point(205, 12);
            ColsNumericUpDown.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            ColsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ColsNumericUpDown.Name = "ColsNumericUpDown";
            ColsNumericUpDown.Size = new Size(80, 30);
            ColsNumericUpDown.TabIndex = 1;
            ColsNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblCols
            // 
            lblCols.AutoSize = true;
            lblCols.ForeColor = Color.White;
            lblCols.Location = new Point(160, 14);
            lblCols.Name = "lblCols";
            lblCols.Size = new Size(42, 23);
            lblCols.TabIndex = 2;
            lblCols.Text = "Cols";
            // 
            // RowsNumericUpDown
            // 
            RowsNumericUpDown.BackColor = Color.FromArgb(45, 45, 50);
            RowsNumericUpDown.ForeColor = Color.White;
            RowsNumericUpDown.Location = new Point(62, 12);
            RowsNumericUpDown.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            RowsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RowsNumericUpDown.Name = "RowsNumericUpDown";
            RowsNumericUpDown.Size = new Size(80, 30);
            RowsNumericUpDown.TabIndex = 3;
            RowsNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.ForeColor = Color.White;
            lblRows.Location = new Point(12, 14);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(49, 23);
            lblRows.TabIndex = 4;
            lblRows.Text = "Rows";
            // 
            // resultsPanel
            // 
            resultsPanel.BackColor = Color.FromArgb(32, 32, 36);
            resultsPanel.Controls.Add(textOutput);
            resultsPanel.Controls.Add(lblResults);
            resultsPanel.Dock = DockStyle.Fill;
            resultsPanel.Location = new Point(3, 61);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Padding = new Padding(12);
            resultsPanel.Size = new Size(964, 133);
            resultsPanel.TabIndex = 1;
            // 
            // textOutput
            // 
            textOutput.BackColor = Color.FromArgb(32, 32, 36);
            textOutput.BorderStyle = BorderStyle.None;
            textOutput.Dock = DockStyle.Fill;
            textOutput.Font = new Font("Consolas", 10F);
            textOutput.ForeColor = Color.White;
            textOutput.Location = new Point(12, 36);
            textOutput.Margin = new Padding(0, 8, 0, 0);
            textOutput.Name = "textOutput";
            textOutput.ReadOnly = true;
            textOutput.Size = new Size(940, 85);
            textOutput.TabIndex = 0;
            textOutput.Text = "";
            // 
            // lblResults
            // 
            lblResults.Dock = DockStyle.Top;
            lblResults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResults.ForeColor = Color.White;
            lblResults.Location = new Point(12, 12);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(940, 24);
            lblResults.TabIndex = 1;
            lblResults.Text = "Results";
            // 
            // GameCalculatorForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 28);
            ClientSize = new Size(1000, 700);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 650);
            Name = "GameCalculatorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zero-Sum Game Calculator By Arash Behnamfar";
            rootLayout.ResumeLayout(false);
            panelMatrix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPayoff).EndInit();
            bottomLayout.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ColsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RowsNumericUpDown).EndInit();
            resultsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel rootLayout;
        private Panel panelMatrix;
        private DataGridView gridPayoff;

        private TableLayoutPanel bottomLayout;
        private Panel settingsPanel;

        private Label lblRows;
        private NumericUpDown RowsNumericUpDown;
        private Label lblCols;
        private NumericUpDown ColsNumericUpDown;
        private Button SolveButton;

        private Panel resultsPanel;
        private Label lblResults;
        private RichTextBox textOutput;
    }
}
