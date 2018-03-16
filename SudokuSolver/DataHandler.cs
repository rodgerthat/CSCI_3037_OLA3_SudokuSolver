using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class DataHandler
    {

        public int gridSize = 9;     // the sudoku grid will always be a square

        // default sudoku grid
        // 0 means unassigned cells
        public int[,] defaultGrid = new int[9, 9] {
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

        public int[,] loadedGrid = new int[9, 9];

        public void LoadGridFromFile()
        {
            // Read each line, store as "all_lines" array
            string[] all_lines = System.IO.File.ReadAllLines( @"../../Sudoku.txt");  

            char[] delim_chars = { ',' };               // Delimiter set to a comma, it's a CSV

            // loop through all the lines in the loaded string array, 
            int i = 0; int j = 0;
            foreach (string l in all_lines)
            {
                j = 0;
                string[] words = all_lines[i].Split(delim_chars);
                foreach (string s in words)
                {
                    this.loadedGrid[i, j] = Convert.ToInt32(s); //  convert it to an integer 
                    j++;
                }
                i++;
            }

        }


    }

}
