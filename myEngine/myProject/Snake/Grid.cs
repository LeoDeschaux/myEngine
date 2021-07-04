using System;
using System.Collections.Generic;
using System.Text;

using myEngine.myProject.Snake;

namespace myEngine.myProject.Snake
{
    public enum CellState
    {
        empty,
        head,
        body,
        apple
    }

    public class Grid
    {
        //FIELDS
        private int size = 5;
        private CellState[,] grid;

        //CONSTRUCTOR
        public Grid()
        {
            grid = new CellState[5, 5];

            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    grid[x, y] = CellState.empty;

            grid[2, 2] = CellState.head;
        }

        //METHODS
        public void DisplayGridToConsole()
        {
            for(int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.Write("|");

                    //FILL CELL
                    if (grid[x, y] == CellState.empty)
                        Console.Write(".");
                    else if (grid[x, y] == CellState.head)
                        Console.Write("X");
                    else if (grid[x, y] == CellState.body)
                        Console.Write("+");
                    else if (grid[x, y] == CellState.apple)
                        Console.Write("o");
                }
                Console.Write("|");
                
                Console.WriteLine();
            }
            

        }

    }
}
