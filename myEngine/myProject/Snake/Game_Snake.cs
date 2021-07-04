using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using myEngine.myProject.Snake;

namespace myEngine.myProject.Snake
{
    public class Game_Snake : Entity
    {
        //FIELDS
        Grid grid;
        Player player;

        //APPLE SPAWNER

        //CONSTRUCTOR
        public Game_Snake()
        {
            Console.WriteLine("NEW GAME");
            player = new Player();
            grid = new Grid();
        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.P))
                grid.DisplayGridToConsole();
        }

    }
}
