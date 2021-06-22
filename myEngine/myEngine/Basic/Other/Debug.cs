using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Debug : Entity
    {
        //FIELDS
        private Input input;

        public static Text t;

        //CONSTRUCTOR
        public Debug()
        {
            input = new Input();
            t = new Text();
            t.color = Color.White;
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            //STOP TIME
            if (input.GetKeyDown(Keys.NumPad0) && Settings.GAME_SPEED != 0f)
                Settings.GAME_SPEED = 0.0f;
            else if (input.GetKeyDown(Keys.NumPad0) && Settings.GAME_SPEED == 0f)
                Settings.GAME_SPEED = 1f;

            //SLOW MOTION
            if (input.GetKeyDown(Keys.NumPad1) && Settings.GAME_SPEED == 1f)
                Settings.GAME_SPEED = 0.1f;
            else if (input.GetKeyDown(Keys.NumPad1) && Settings.GAME_SPEED == 0.1f)
                Settings.GAME_SPEED = 1f;

            if (input.GetKeyDown(Keys.F12) && !Settings.DEBUG_MODE)
                Settings.DEBUG_MODE = true;
            else if (input.GetKeyDown(Keys.F12) && Settings.DEBUG_MODE)
                Settings.DEBUG_MODE = false;

        }

        public override void Draw(SpriteBatch sprite)
        {
            //MOUSE CURSOR
            //DrawSimpleShape.DrawRuller(input.mousePos.ToVector2(), Color.Red);
            t.s = input.mousePos.ToVector2().ToString();
        }
    }
}
