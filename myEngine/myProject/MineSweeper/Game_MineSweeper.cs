using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace myEngine.myProject.MineSweeper
{
    class Game_MineSweeper : Entity
    {
        //FIELDS
        public static Grid grid;
        UI_MineSweeper ui;
        static bool isGameLoose = false;

        //CONSTRUCTOR
        public Game_MineSweeper()
        {
            grid = new Grid();
            ui = new UI_MineSweeper();
            isGameLoose = false;
        }

        public override void Update()
        {
        }

        public static void OnGameLoose()
        {
            Console.WriteLine("YOU LOOSE");
            GridUtils.ShowEveryCells(grid);
            isGameLoose = true;
        }

        public static void OnGameWin()
        {
            if (isGameLoose == false)
            {
                Console.WriteLine("YOU WIN !");
            }
        }
    }
}
