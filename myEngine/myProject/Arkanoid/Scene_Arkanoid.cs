using System;
using System.Collections.Generic;
using System.Text;

using myEngine.myProject.Arkanoid;

namespace myEngine
{
    public class Scene_Arkanoid : IScene 
    {
        //FIELDS
        public Game_Arkanoid game;

        //CONSTRUCTOR
        public Scene_Arkanoid()
        {
            game = new Game_Arkanoid();
        }

        //METHODS

    }
}
