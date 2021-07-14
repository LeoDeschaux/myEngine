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
        public static Grid grid;
        public Player player;

        Delay delay;

        //APPLE SPAWNER

        //CONSTRUCTOR
        public Game_Snake()
        {
            player = new Player();
            grid = new Grid(player);

            delay = new Delay(200, () =>
            {
                grid.UpdateGrid();
            });
        }

        //METHODS
        public override void Update()
        {
            return;

            if (Input.GetKeyDown(Keys.Enter))
                grid.UpdateGrid();
        }
    }
}
