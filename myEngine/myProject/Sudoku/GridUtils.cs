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
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                {
                    //grid.cells[x, y].button.text.s = grid.cells[x, y].posX.ToString() + ", " + grid.cells[x, y].posY.ToString();
                }

            SetDefaultGrid(grid);
            //ColorSquares(grid);

            //grid.cells[3, 0].button.text.s = "0";
            //grid.cells[0, 3].button.text.s = "0";
            //grid.cells[1, 1].button.text.s = "0";

            delay = new Delay(200, () => CheckFunc(grid));

            CheckCell(grid, grid.cells[0, 0]);
            //CheckGrid(grid);
        }

        static Delay delay;
        static int myX = 0;
        static int myY = 0;
        public static void CheckFunc(Grid grid)
        {
            //SetCellsColorToWhite(grid);

            CheckCell(grid, grid.cells[myX, myY]);

            /*
            int squareIndex = FindSquareFromCellPosition(grid.cells[myX, myY]);
            ColorCells(GetSquare(grid, squareIndex));
            */
            //grid.cells[myX, myY].button.defaultColor = Color.Red;


            if (myY < 9)
            {
                //DO
                if (myX < 8)
                {
                    myX++;
                }
                else
                {
                    if(myY != 8)
                    {
                        myX = 0;
                        myY++;
                    }
                }
            }
        }

        public static void SetCellsColorToWhite(Grid grid)
        {
            //SHOW SELECTED CELLS
            for (int j = 0; j < 9; j++)
            {
                Cell[] cells = GetSquare(grid, j);

                for (int k = 0; k < 9; k++)
                {
                    cells[k].button.defaultColor = Color.White;
                }
            }
        }

        public static void ColorCells(Cell[] cells)
        {
            for (int i = 0; i < 9; i++)
            {
                cells[i].button.defaultColor = Color.Blue;
            }
        }

        public static void CheckGrid(Grid grid)
        {
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                {
                    CheckCell(grid, grid.cells[x, y]);
                }
        }

        public static void CheckCell(Grid grid, Cell cell)
        {
            bool isValide = true;

            //CHECK ROW
            Cell[] row = GetRow(grid, cell.posY);
            for (int i = 0; i < 9; i++)
            {
                if (row[i].button.text.s == cell.button.text.s && i != cell.posX)
                {
                    isValide = false;
                }
            }

            //CHECK COLLUMNS
            Cell[] collumn = GetCollumn(grid, cell.posX);
            for (int i = 0; i < 9; i++)
            {
                if (collumn[i].button.text.s == cell.button.text.s && i != cell.posY)
                {
                    isValide = false;
                }
            }

            //CHECK SQUARE
            Cell[] square = GetSquare(grid, FindSquareFromCellPosition(cell));
            for (int i = 0; i < 9; i++)
            {
                if (square[i].button.text.s == cell.button.text.s && (square[i].posX != cell.posX && square[i].posY != cell.posY))
                {
                    isValide = false;
                }
            }

            if (isValide)
                cell.button.defaultColor = Color.Green;
            else
                cell.button.defaultColor = Color.Red;
        }

        public static int FindSquareFromCellPosition(Cell cell)
        {
            int x = cell.posX / 3;
            int y = cell.posY / 3;

            int square = (x + (y * 3));
            
            return square;
        }

        public static void ColorSquares(Grid grid)
        {
            //SHOW SELECTED CELLS
            for (int j = 0; j < 9; j++)
            {
                Cell[] cells = GetSquare(grid, j);

                for (int k = 0; k < 9; k++)
                {
                    cells[k].button.defaultColor = new Color(100 + (j * 20), 100 + (j * 20), 100 + (j * 20));
                    //cells[k].button.text.s = "" + (k + 1);
                }
            }
        }

        public static void SetDefaultGrid(Grid grid)
        {
            int i = 0;
            for (int y = 0; y < 9; y++)
            {
                if (y == 0)
                    i += 0;
                else if (y == 3 || y == 6)
                    i += 1;
                else
                    i += 3;

                for (int x = 0; x < 9; x++)
                {
                    grid.cells[x, y].button.text.s = "" + ((x + i) % 9);
                }
            }
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
