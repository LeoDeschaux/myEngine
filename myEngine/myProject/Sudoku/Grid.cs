using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Grid
    {
        //FIELDS
        public Cell[,] cells;
        int rows = 9, collumns = 9;
        int spriteSizeX = 76, spriteSizeY = 76;
        public static int marginX = 2, marginY = 2;
        int offSetX = 0, offSetY = 0;

        int currentBlocksLeft;
        int totalBlocks;

        //CONSTRUCTOR
        public Grid()
        {
            float maxSize = (Settings.SCREEN_HEIGHT - (marginY*10)) / 10;
            Console.WriteLine(maxSize);

            totalBlocks = rows * collumns;
            currentBlocksLeft = totalBlocks;

            cells = new Cell[collumns, rows];

            for (int y = 0; y < rows; y++)
                for (int x = 0; x < collumns; x++)
                {
                    Vector2 start = new Vector2(Settings.Get_Screen_Center().X - ((collumns * (spriteSizeX + marginX)) / 2),
                                                Settings.Get_Screen_Center().Y - ((rows * (spriteSizeY + marginY)) / 2));
                    start = new Vector2(start.X + ((spriteSizeX + marginX) / 2), start.Y + ((spriteSizeY + marginY) / 2));

                    Vector2 position = new Vector2(offSetX + start.X + (x * (spriteSizeX + marginX)), offSetY + start.Y + (y * (spriteSizeY + marginY)));

                    cells[x, y] = new Cell(position, new Vector2(spriteSizeX, spriteSizeY), x, y);
                    cells[x, y].name = "" + x + ", " + y;
                }

            //SET GRID
            GridUtils.SetGrid(this);
        }
    }
}
