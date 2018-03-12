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
        public Form1()
        {
            InitializeComponent();

            int[,] theData = new int[9, 9] {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            int height = theData.GetLength(0);
            int width = theData.GetLength(1);

            this.dataGridView1.ColumnCount = width;

            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int s = 0; s < width; s++)
            {
                DataGridViewColumn column = dataGridView1.Columns[s];
                column.Width = 20;
            }
            
            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < width; c++)
                {
                    if (theData[r, c] == 0)
                    {
                        row.Cells[c].Value = null;
                    } else { 
                        row.Cells[c].Value = theData[r, c];
                    }
                }

                this.dataGridView1.Rows.Add(row);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
