using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class DebugInput : Entity
    {
        //FIELDS
        private Input input;

        //CONSTRUCTOR
        public DebugInput()
        {
            input = new Input();
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

        }
    }
}
