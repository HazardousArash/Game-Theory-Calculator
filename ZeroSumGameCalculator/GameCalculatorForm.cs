using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZeroSumGameCalculator.Domain;
using ZeroSumGameCalculator.Solvers;

namespace ZeroSumGameCalculator
{
    public partial class GameCalculatorForm : Form
    {
        private readonly IZeroSumGameSolver _solver = new ZeroSumGameSolver();

        public GameCalculatorForm()
        {
            InitializeComponent();

            ApplyDarkTheme();
            ConfigureGridDefaults();

            this.AcceptButton = SolveButton;

            RowsNumericUpDown.ValueChanged += Size_ValueChanged;
            ColsNumericUpDown.ValueChanged += Size_ValueChanged;

            ResizeMatrixGrid((int)RowsNumericUpDown.Value, (int)ColsNumericUpDown.Value);

            this.Resize += (_, __) => UpdateGridFillMode();
        }

        private void ConfigureGridDefaults()
        {
            gridPayoff.AllowUserToAddRows = false;
            gridPayoff.AllowUserToDeleteRows = false;
            gridPayoff.AllowUserToResizeRows = false;
            gridPayoff.MultiSelect = false;

            gridPayoff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridPayoff.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridPayoff.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            // Single click to edit
            gridPayoff.EditMode = DataGridViewEditMode.EditOnEnter;
            gridPayoff.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    gridPayoff.BeginEdit(true);
            };

            // Enter behaves like Tab
            gridPayoff.KeyDown += GridPayoff_KeyDown;

            // Allow arrow keys to navigate even while editing
            gridPayoff.EditingControlShowing += GridPayoff_EditingControlShowing;

            // Ctrl+V paste block (Excel-like)
            gridPayoff.KeyDown += GridPayoff_PasteKeyDown;
        }

        private void Size_ValueChanged(object? sender, EventArgs e)
        {
            ResizeMatrixGrid((int)RowsNumericUpDown.Value, (int)ColsNumericUpDown.Value);
            textOutput.Clear();
        }

        private void ResizeMatrixGrid(int newRows, int newCols)
        {
            var old = TryReadGridAsString(gridPayoff);

            gridPayoff.Columns.Clear();
            for (int j = 0; j < newCols; j++)
            {
                gridPayoff.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = $"C{j + 1}",
                    HeaderText = $"C{j + 1}",
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }

            gridPayoff.Rows.Clear();
            gridPayoff.Rows.Add(newRows);

            for (int i = 0; i < newRows; i++)
                gridPayoff.Rows[i].HeaderCell.Value = $"R{i + 1}";

            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newCols; j++)
                {
                    string value =
                        (old != null && i < old.GetLength(0) && j < old.GetLength(1))
                        ? old[i, j]
                        : "0";

                    gridPayoff.Rows[i].Cells[j].Value = value;
                }
            }

            gridPayoff.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // NEW: stretch rows/cols to fill when matrix is small
            UpdateGridFillMode();
        }

        private static string[,]? TryReadGridAsString(DataGridView grid)
        {
            int rows = grid.Rows.Count;
            int cols = grid.Columns.Count;
            if (rows <= 0 || cols <= 0) return null;

            var data = new string[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    data[i, j] = grid.Rows[i].Cells[j].Value?.ToString() ?? "0";

            return data;
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SolveButton.Enabled = false;
                SolveButton.Text = "Solving...";
                Application.DoEvents(); // quick UI refresh

                var A = ReadMatrixFromGrid(gridPayoff);
                var result = _solver.Solve(A);

                textOutput.Text = ZeroSumGameSolution.ToPrettyString(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SolveButton.Text = "Solve Game";
                SolveButton.Enabled = true;
            }
        }

        private static double[,] ReadMatrixFromGrid(DataGridView grid)
        {
            int rows = grid.Rows.Count;
            int cols = grid.Columns.Count;
            if (rows <= 0 || cols <= 0)
                throw new Exception("Matrix is empty.");

            var A = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var raw = grid.Rows[i].Cells[j].Value?.ToString()?.Trim();
                    if (string.IsNullOrWhiteSpace(raw))
                        throw new Exception($"Cell ({i + 1},{j + 1}) is empty.");

                    if (!double.TryParse(raw, out double v))
                        throw new Exception($"Invalid number at ({i + 1},{j + 1}): '{raw}'");

                    A[i, j] = v;
                }
            }

            return A;
        }
        private void ApplyDarkTheme()
        {
            // Form
            BackColor = Theme.Bg;
            ForeColor = Theme.Text;

            panelMatrix.BackColor = Theme.Bg;
            settingsPanel.BackColor = Theme.Surface;
            resultsPanel.BackColor = Theme.Surface;

            // Labels
            lblRows.ForeColor = Theme.Text;
            lblCols.ForeColor = Theme.Text;
            lblResults.ForeColor = Theme.Text;

            // NumericUpDowns (force dark)
            StyleNumeric(RowsNumericUpDown);
            StyleNumeric(ColsNumericUpDown);

            // Button (orange accent)
            SolveButton.FlatStyle = FlatStyle.Flat;
            SolveButton.FlatAppearance.BorderSize = 0;
            SolveButton.UseVisualStyleBackColor = false;
            SolveButton.BackColor = Theme.Warn;
            SolveButton.ForeColor = Color.Black;
            SolveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 200, 40);
            SolveButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 150, 0);

            // Results box
            textOutput.BackColor = Theme.Surface2;
            textOutput.ForeColor = Theme.Text;
            textOutput.BorderStyle = BorderStyle.None;

            // Grid (fix ALL layers)
            ApplyGridTheme();
        }

        private void StyleNumeric(NumericUpDown n)
        {
            n.BackColor = Theme.Surface2;
            n.ForeColor = Theme.Text;
        }
        private void ApplyGridTheme()
        {
            var g = gridPayoff;

            g.BackgroundColor = Theme.Bg;                 // empty area below rows
            g.BorderStyle = BorderStyle.None;
            g.GridColor = Theme.GridLines;

            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            g.ColumnHeadersDefaultCellStyle.BackColor = Theme.GridHeader;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Text;
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            g.ColumnHeadersHeight = 36;

            g.RowHeadersDefaultCellStyle.BackColor = Theme.GridHeader;
            g.RowHeadersDefaultCellStyle.ForeColor = Theme.Text;
            g.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

            g.DefaultCellStyle.BackColor = Theme.GridCell;
            g.DefaultCellStyle.ForeColor = Theme.Text;
            g.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            g.DefaultCellStyle.SelectionBackColor = Theme.GridSelect;
            g.DefaultCellStyle.SelectionForeColor = Theme.Text;

            g.AlternatingRowsDefaultCellStyle.BackColor = Theme.GridAlt;
            g.AlternatingRowsDefaultCellStyle.ForeColor = Theme.Text;

            // The editing textbox was white for you — fix it:
            g.EditingControlShowing -= Grid_EditingControlShowing_Theme;
            g.EditingControlShowing += Grid_EditingControlShowing_Theme;
        }

        private void Grid_EditingControlShowing_Theme(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.BackColor = Theme.Surface2;
                tb.ForeColor = Theme.Text;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
        }



        // ---------------- UX HANDLERS ----------------

        private void GridPayoff_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                gridPayoff.EndEdit();
                SendKeys.Send("{TAB}");
            }
        }

        private void GridPayoff_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.PreviewKeyDown -= Tb_PreviewKeyDown;
                tb.PreviewKeyDown += Tb_PreviewKeyDown;
            }
        }

        private void Tb_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode is Keys.Up or Keys.Down or Keys.Left or Keys.Right)
                e.IsInputKey = true;
        }

        private void GridPayoff_PasteKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteIntoGrid();
                e.Handled = true;
            }
        }

        private void PasteIntoGrid()
        {
            if (gridPayoff.CurrentCell == null) return;

            var text = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(text)) return;

            var rows = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(line => line.Split('\t'))
                           .ToArray();

            int startR = gridPayoff.CurrentCell.RowIndex;
            int startC = gridPayoff.CurrentCell.ColumnIndex;

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    int r = startR + i;
                    int c = startC + j;

                    if (r < gridPayoff.RowCount && c < gridPayoff.ColumnCount)
                        gridPayoff.Rows[r].Cells[c].Value = rows[i][j];
                }
            }
        }
        private void UpdateGridFillMode()
        {
            if (gridPayoff.RowCount == 0 || gridPayoff.ColumnCount == 0) return;

            // Columns fill available width
            gridPayoff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in gridPayoff.Columns)
                col.MinimumWidth = 60;

            int rows = gridPayoff.RowCount;

            // Approx available height for data rows
            int available =
                gridPayoff.ClientSize.Height
                - gridPayoff.ColumnHeadersHeight
                - 2;

            if (available <= 0) return;

            // Small matrices: stretch rows to fill
            if (rows <= 12)
            {
                int target = Math.Max(28, available / rows);
                target = Math.Min(target, 90);

                gridPayoff.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                gridPayoff.RowTemplate.Height = target;

                for (int i = 0; i < rows; i++)
                    gridPayoff.Rows[i].Height = target;

                // If content fits, no scrollbars; otherwise show them
                bool needsV = (rows * target) > available;
                gridPayoff.ScrollBars = needsV ? ScrollBars.Vertical : ScrollBars.None;
            }
            else
            {
                // Large matrices: readable size + scrolling
                const int normal = 32;

                gridPayoff.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                gridPayoff.RowTemplate.Height = normal;

                for (int i = 0; i < rows; i++)
                    gridPayoff.Rows[i].Height = normal;

                gridPayoff.ScrollBars = ScrollBars.Both;
            }
        }

    }
    public static class Theme
    {
        // Base
        public static readonly Color Bg = Color.FromArgb(20, 22, 26);        // app background
        public static readonly Color Surface = Color.FromArgb(28, 31, 37);   // panels
        public static readonly Color Surface2 = Color.FromArgb(34, 38, 46);  // slightly lighter
        public static readonly Color Border = Color.FromArgb(55, 60, 72);

        // Text
        public static readonly Color Text = Color.FromArgb(235, 237, 242);
        public static readonly Color MutedText = Color.FromArgb(180, 185, 195);

        // Accents
        public static readonly Color Accent = Color.FromArgb(0, 166, 255);   // blue
        public static readonly Color Accent2 = Color.FromArgb(0, 204, 170);  // teal
        public static readonly Color Warn = Color.FromArgb(255, 179, 0);     // orange

        // Grid
        public static readonly Color GridCell = Color.FromArgb(28, 31, 37);
        public static readonly Color GridAlt = Color.FromArgb(32, 36, 44);
        public static readonly Color GridHeader = Color.FromArgb(36, 40, 49);
        public static readonly Color GridLines = Color.FromArgb(55, 60, 72);
        public static readonly Color GridSelect = Color.FromArgb(40, 110, 170);
    }

}




