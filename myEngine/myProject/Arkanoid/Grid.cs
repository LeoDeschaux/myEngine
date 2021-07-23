using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Arkanoid
{
    public class Grid
    {
        //FIELDS
        Sprite[,] blocks;
        int sizeX = 8, sizeY = 5;
        int spriteSizeX = 100, spriteSizeY = 40;
        int marginX = 10, marginY = 10;
        int offSetX = 0, offSetY = -150;

        //CONSTRUCTOR
        public Grid()
        {
            blocks = new Sprite[sizeX, sizeY];

            for (int y = 0; y < sizeY; y++)
                for (int x = 0; x < sizeX; x++)
                {
                    Vector2 start = new Vector2(Settings.Get_Screen_Center().X - ((sizeX * (spriteSizeX + marginX)) / 2),
                                                Settings.Get_Screen_Center().Y - ((sizeY * (spriteSizeY + marginY)) / 2));
                    start = new Vector2(start.X + ((spriteSizeX + marginX) / 2), start.Y + ((spriteSizeY + marginY) / 2));

                    Vector2 position = new Vector2(offSetX + start.X + (x * (spriteSizeX + marginX)), offSetY + start.Y + (y * (spriteSizeY + marginY)));

                    blocks[x, y] = new Sprite();
                    blocks[x, y].color = Color.Orange;
                    blocks[x, y].transform.position = position;
                    blocks[x, y].dimension = new Vector2(spriteSizeX, spriteSizeY);

                    blocks[x, y].AddComponent(new Collider2D(blocks[x, y]));
                    blocks[x, y].name = "" + x + ", " + y;
                }
        }
    }
}
