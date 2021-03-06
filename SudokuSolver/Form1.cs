﻿using System;
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
        DataHandler dataHandler = new DataHandler();

        public int[,] grid;


        public Form1()
        {
            InitializeComponent();

            // load the dataGridView with the initial grid data from the datahandler
            
            // InitializeDataGridView(this.dataHandler.defaultGrid);
            this.dataHandler.LoadGridFromFile();
            InitializeDataGridView(this.dataHandler.loadedGrid);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // load the dataGridView with data!
        // also set it's width and other visual properties
        private void InitializeDataGridView(int[,] grid)
        {

            dataGridView1.ColumnHeadersVisible = false; // remove headers
            dataGridView1.RowHeadersVisible = false; // remove headers
            this.dataGridView1.ColumnCount = this.dataHandler.gridSize;

            // grid cell alignment, centered
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // set the column width of all the cells
            for (int s = 0; s < this.dataHandler.gridSize; s++)
            {
                DataGridViewColumn column = dataGridView1.Columns[s];
                column.Width = 20;
            }

            LoadDataGridView(grid);
            
        }

        // populate the DataGridView with data
        private void LoadDataGridView(int[,] grid)
        {
            // clear out the grid first, lest the data get appended to the existing grid
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            for (int r = 0; r < this.dataHandler.gridSize; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < this.dataHandler.gridSize; c++) // lol c++
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
            int[,] newGrid = new int[this.dataHandler.gridSize, this.dataHandler.gridSize];

            // get the data out of the current grid
            // and assign it to the grid 2D array
            for (int i = 0; i < this.dataHandler.gridSize; i++)
                 for (int j = 0; j < this.dataHandler.gridSize; j++)
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

            // get data from the DataGridView and load it into the solvable grid
            this.solver.solvedGrid = GetDataGridViewData();

            // if the solver solves it
            if (this.solver.SolveSudoku(this.solver.solvedGrid, this.dataHandler.gridSize))
            {
                LoadDataGridView(this.solver.solvedGrid);
            } else
            {
                MessageBox.Show("This puzzle could not be solved");
            }
            
        }
    }
}
