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
        Player player;

        //APPLE SPAWNER

        //CONSTRUCTOR
        public Game_Snake()
        {
            grid = new Grid();
            player = new Player();
        }

        //METHODS
        public override void Update()
        {
        }
    }
}
