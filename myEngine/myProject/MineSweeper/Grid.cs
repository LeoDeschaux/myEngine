using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.MineSweeper
{
    public class Grid
    {
        //FIELDS
        public Cell[,] cells;

        public int rows = 9, collumns = 9;
        int spriteSizeX = 76, spriteSizeY = 76;
        public static int marginX = 0, marginY = 0;
        int offSetX = 0, offSetY = 0;

        int currentBlocksLeft;
        int totalBlocks;

        Vector2 startPoint;
        Vector2 endPoint;

        //CONSTRUCTOR
        public Grid()
        {
            totalBlocks = rows * collumns;
            currentBlocksLeft = totalBlocks;

            cells = new Cell[collumns, rows];

            Vector2 start = new Vector2(Settings.Get_Screen_Center().X - ((collumns * (spriteSizeX + marginX)) / 2),
                                                Settings.Get_Screen_Center().Y - ((rows * (spriteSizeY + marginY)) / 2));
            start = new Vector2(start.X + ((spriteSizeX + marginX) / 2), start.Y + ((spriteSizeY + marginY) / 2));

            for (int y = 0; y < rows; y++)
                for (int x = 0; x < collumns; x++)
                {
                    Vector2 position = new Vector2(offSetX + start.X + (x * (spriteSizeX + marginX)), offSetY + start.Y + (y * (spriteSizeY + marginY)));
                    Vector2 dimension = new Vector2(spriteSizeX, spriteSizeY);

                    cells[x, y] = new Cell_Empty(position, dimension, x, y);
                }

            startPoint = new Vector2(start.X - (spriteSizeX / 2), start.Y - (spriteSizeY / 2));
            endPoint = new Vector2((spriteSizeX * rows) + (marginX * (rows - 1)), (spriteSizeY * collumns) + (marginY * (collumns - 1)));
        }

        //METHODS
    }
}
