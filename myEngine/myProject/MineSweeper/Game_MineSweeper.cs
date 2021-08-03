using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.MineSweeper
{
    class Game_MineSweeper : Entity
    {
        //FIELDS
        public static Grid grid;

        //CONSTRUCTOR
        public Game_MineSweeper()
        {
            grid = new Grid();
        }

        public override void Update()
        {
            if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                GridUtils.SetBombs(grid, 15);
        }
    }
}
