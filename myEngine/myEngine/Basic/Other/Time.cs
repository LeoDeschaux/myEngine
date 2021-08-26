using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace myEngine
{
    public static class Time
    {
        //FIELDS
        public static GameTime gameTime;
        public static float deltaTime { get; private set; }

        //CONSTRUCTOR
        public static void UpdateGameTime(GameTime gameTime, float deltaTime)
        {
            Time.gameTime = gameTime;
            Time.deltaTime = deltaTime;
        }

        //METHODS
        public static void Init()
        {
            gameTime = new GameTime();
            deltaTime = 0;
        }
    }
}
