using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Solver
    {
        // A Backtracking program  in C++ to solve Sudoku problem
        #include <stdio.h>

        // UNASSIGNED is used for empty cells in sudoku grid
        #define UNASSIGNED 0

        // N is used for size of Sudoku grid. Size will be NxN
        #define N 9

        // This function finds an entry in grid that is still unassigned
        bool FindUnassignedLocation(int grid[N][N], int &row, int &col);

        // Checks whether it will be legal to assign num to the given row,col
        bool isSafe(int grid[N][N], int row, int col, int num);

        /* Takes a partially filled-in grid and attempts to assign values to
          all unassigned locations in such a way to meet the requirements
          for Sudoku solution (non-duplication across rows, columns, and boxes) */
        bool SolveSudoku(int grid[N][N])
        {
            int row, col;

            // If there is no unassigned location, we are done
            if (!FindUnassignedLocation(grid, row, col))
               return true; // success!

            // consider digits 1 to 9
            for (int num = 1; num <= 9; num++)
            {
                // if looks promising
                if (isSafe(grid, row, col, num))
                {
                    // make tentative assignment
                    grid[row][col] = num;

                    // return, if success, yay!
                    if (SolveSudoku(grid))
                        return true;

                    // failure, unmake & try again
                    grid[row][col] = UNASSIGNED;
                }
                                                                                                                               1,1           Top

                                                                                                                                   132,1         Bot

    }
}
