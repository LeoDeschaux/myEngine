using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using myEngine.myProject.Snake;

namespace myEngine.myProject.Snake
{
    public struct GridPosition
    {
        public int X;
        public int Y;

        public override string ToString()
        {
            return "{"+X+","+Y+"}";
        }
    }

    public class Player : GameObject
    {
        //FIELDS
        private GridPosition gridPosition;

        //CONSTRUCTOR
        public Player()
        {
            gridPosition = new GridPosition();
            
            Game_Snake.grid.SetPlayerPos(gridPosition);
            Console.WriteLine(gridPosition);
        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Up))
            {
                if(gridPosition.Y - 1 >= 0)
                {
                    gridPosition.Y--;
                    Game_Snake.grid.SetPlayerPos(gridPosition);
                    Console.WriteLine(gridPosition);
                }
            }

            if (Input.GetKeyDown(Keys.Down))
            {
                if (gridPosition.Y + 1 < Game_Snake.grid.size)
                {
                    gridPosition.Y++;
                    Game_Snake.grid.SetPlayerPos(gridPosition);
                    Console.WriteLine(gridPosition);
                }
            }

            if (Input.GetKeyDown(Keys.Left))
            {
                if (gridPosition.X - 1 >= 0)
                {
                    gridPosition.X--;
                    Game_Snake.grid.SetPlayerPos(gridPosition);
                    Console.WriteLine(gridPosition);
                }
            }

            if (Input.GetKeyDown(Keys.Right))
            {
                if (gridPosition.X + 1 < Game_Snake.grid.size)
                {
                    gridPosition.X++;
                    Game_Snake.grid.SetPlayerPos(gridPosition);
                    Console.WriteLine(gridPosition);
                }
            }
        }

    }
}
