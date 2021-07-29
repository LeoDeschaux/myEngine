using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public static class GridUtils
    {
        public static void SetGrid(Grid grid)
        {
            int i = 0;
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                {
                    i++;
                    grid.cells[x, y].button.text.s = "" + i;
                }

            //SHOW SELECTED CELLS
            for (int j = 0; j < 9; j++)
            {
                Cell[] cells = GetSquare(grid, j);

                for(int k = 0; k < 9; k++)
                {
                    cells[k].button.defaultColor = new Color(100 + (j*20),100 + (j*20),100 +(j*20));
                    cells[k].button.text.s = "" + (k+1);
                }
            }
        }

        public static void IsSquareValide(Grid grid)
        {

        }

        public static Cell[] GetRow(Grid grid, int index)
        {
            Cell[] cells = new Cell[9];

            for (int i = 0; i < 9; i++)
            {
                cells[i] = grid.cells[i, index];
            }

            return cells;
        }

        public static Cell[] GetCollumn(Grid grid, int index)
        {
            Cell[] cells = new Cell[9];

            for (int i = 0; i < 9; i++)
            {
                cells[i] = grid.cells[index, i];
            }

            return cells;
        }

        public static Cell[] GetSquare(Grid grid, int index)
        {
            Cell[] cells = new Cell[9];

            if (index < 0 || index >= 9)
                throw new ArgumentException("[unvalid argument exception (index)]");

            int x = (index % 3) * 3;
            int y = (index / 3) * 3;

            cells[0] = grid.cells[x, y];
            cells[1] = grid.cells[x+1, y];
            cells[2] = grid.cells[x+2, y];

            cells[3] = grid.cells[x, y+1];
            cells[4] = grid.cells[x+1, y+1];
            cells[5] = grid.cells[x+2, y+1];

            cells[6] = grid.cells[x, y+2];
            cells[7] = grid.cells[x+1, y+2];
            cells[8] = grid.cells[x+2, y+2];

            return cells;
        }

        public static void GetDiagonal(Grid grid)
        {
            throw new NotImplementedException();
        }

        public static string PrintCells(Cell[] cells)
        {
            string s = "";
            for (int i = 0; i < cells.Length; i++)
                s += cells[i] + ", ";

            return s;
        }
    }
}
