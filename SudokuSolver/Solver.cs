// A Backtracking program  in C++ to solve Sudoku problem
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Solver
    {

        public int[,] solvedGrid;          // some place to store the solved grid

        // UNASSIGNED is used for empty cells in sudoku grid
        private const int UNASSIGNED = 0;

        /* Takes a partially filled-in grid and attempts to assign values to
          all unassigned locations in such a way to meet the requirements
          for Sudoku solution (non-duplication across rows, columns, and boxes) */
        // public bool SolveSudoku(int[,] grid)
        public bool SolveSudoku(int[,] grid, int gridSize)
        {

            int row = 0, col = 0;

            // If there is no unassigned location, we are done
            if (!FindUnassignedLocation(grid, ref row, ref col, gridSize))
            {
                return true; // success!
            }

            // consider digits 1 to 9
            for (int num = 1; num <= 9; num++)
            {
                // if looks promising
                if (IsSafe(grid, row, col, num, gridSize))
                {
                    // make tentative assignment
                    grid[row, col] = num;

                    // return, if success, yay!
                    if (SolveSudoku(grid, gridSize))
                    {
                        this.solvedGrid = grid;
                        return true;
                    }

                    // failure, unmake & try again
                    grid[row, col] = UNASSIGNED;
                }
            }
            return false; // this triggers backtracking
        }

        // This function finds an entry in grid that is still unassigned
        // private bool FindUnassignedLocation(int[,] grid, int row, int col);
        /* Searches the grid to find an entry that is still unassigned. If
        found, the reference parameters row, col will be set the location
        that is unassigned, and true is returned. If no unassigned entries
        remain, false is returned. */
        private bool FindUnassignedLocation(int[,] grid, ref int row, ref int col, int gridSize)
        {
            for (row = 0; row < gridSize; row++)
                for (col = 0; col < gridSize; col++)
                    if (grid[row, col] == UNASSIGNED)
                        return true;
            return false;
        }

        /* Returns a boolean which indicates whether any assigned entry
           in the specified row matches the given number. */
        bool UsedInRow(int[,] grid, int row, int num, int gridSize)
        {
            for (int col = 0; col < gridSize; col++)
                if (grid[row, col] == num)
                    return true;
            return false;
        }

        /* Returns a boolean which indicates whether any assigned entry
        in the specified column matches the given number. */
        bool UsedInCol(int[,] grid, int col, int num, int gridSize)
        {
            for (int row = 0; row < gridSize; row++)
                if (grid[row, col] == num)
                    return true;
            return false;
        }

        /* Returns a boolean which indicates whether any assigned entry
           within the specified 3x3 box matches the given number. */
        bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (grid[row + boxStartRow, col + boxStartCol] == num)
                        return true;
            return false;
        }

        // Checks whether it will be legal to assign num to the given row,col
        // private bool IsSafe(int[,] grid, int row, int col, int num);
        /* Returns a boolean which indicates whether it will be legal to assign
           num to the given row,col location. */
        private bool IsSafe(int[,] grid, int row, int col, int num, int gridSize)
        {
            /* Check if 'num' is not already placed in current row,
               current column and current 3x3 box */
            return !UsedInRow(grid, row, num, gridSize) &&
                   !UsedInCol(grid, col, num, gridSize) &&
                   !UsedInBox(grid, row - row % 3, col - col % 3, num);
        }

        /* A utility function to print grid  */
        /*
        void printGrid(int[,] grid)
        {
            for (int row = 0; row < N; row++)
            {
               for (int col = 0; col < N; col++)
                     printf("%2d", grid[row][col]);
                printf("\n");
            }
        }
        */
    }

}