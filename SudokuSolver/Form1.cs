using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SudokuSolver
{
    public partial class Form1 : Form
    {

        Solver solver = new Solver();

        public int[,] grid;

        private const int gridSize = 9;     // the sudoku grid will always be a square

        public Form1()
        {
            InitializeComponent();

            // load the dataGridView with the initial grid data from the solver
            InitializeDataGridView(solver.grid);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // load the dataGridView with data!
        // also set it's width and other visual properties
        private void InitializeDataGridView(int[,] grid)
        {

            this.dataGridView1.ColumnCount = gridSize;

            // grid cell alignment, centered
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // set the column width of all the cells
            for (int s = 0; s < gridSize; s++)
            {
                DataGridViewColumn column = dataGridView1.Columns[s];
                column.Width = 20;
            }

            LoadDataGridView(grid, gridSize);
            
        }

        // populate the DataGridView with data
        private void LoadDataGridView(int[,] grid, int gridSize)
        {
            // clear out the grid first, lest the data get appended to the existing grid
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            for (int r = 0; r < gridSize; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < gridSize; c++)
                {
                    if (grid[r, c] == 0)
                    {
                        row.Cells[c].Value = null;  // if there's nothing, it needs to be blank
                    } else { 
                        row.Cells[c].Value = grid[r, c];
                    }
                }

                this.dataGridView1.Rows.Add(row);   // add new row to the dataGridView
            }

        }
        
        private int[,] GetDataGridViewData()
        {
            // gotta initialize this or the poor compiler will whine
            int[,] newGrid = new int[gridSize,gridSize];

            // get the data out of the current grid
            // and assign it to the grid 2D array
            for (int i = 0; i < gridSize; i++)
                 for (int j = 0; j < gridSize; j++)
                    // the DataGridView will contain the occasional null value
                    // which, natch, can't be passed back into an int array
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        newGrid[i, j] = 0;  // so when it's null we gotta manually put a 0 in 
                    } else {
                        //newGrid[i, j] = (int)dataGridView1.Rows[i].Cells[j].Value;
                        newGrid[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }

            return newGrid;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.grid = GetDataGridViewData();

            LoadDataGridView(this.grid, gridSize);

            this.solver.SolveSudoku(this.grid);
            
        }
    }
}
