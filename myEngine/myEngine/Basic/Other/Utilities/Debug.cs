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
        Debug_UI UI;

        //CONSTRUCTOR
        public Debug()
        {
            this.dontDestroyOnLoad = true;

            UI = new Debug_UI();
            UI.SetVisible(false);
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (Settings.RELEASE_MODE)
                return;

            //STOP TIME
            if (Input.GetKeyDown(Keys.NumPad0) && Settings.GAME_SPEED != 0f)
                Settings.GAME_SPEED = 0.0f;
            else if (Input.GetKeyDown(Keys.NumPad0) && Settings.GAME_SPEED == 0f)
                Settings.GAME_SPEED = 1f;

            //SLOW MOTION
            if (Input.GetKeyDown(Keys.NumPad1) && Settings.GAME_SPEED == 1f)
                Settings.GAME_SPEED = 0.1f;
            else if (Input.GetKeyDown(Keys.NumPad1) && Settings.GAME_SPEED == 0.1f)
                Settings.GAME_SPEED = 1f;

            if (Input.GetKeyDown(Keys.NumPad9) && !Settings.DEBUG_MODE)
            {
                Settings.DEBUG_MODE = true;
                UI.SetVisible(true);
            }
            else if (Input.GetKeyDown(Keys.NumPad9) && Settings.DEBUG_MODE)
            {
                Settings.DEBUG_MODE = false;
                UI.SetVisible(false);
            }

            if (Input.GetKeyDown(Keys.PageUp))
                SceneManager_Utils.ChangeToPreviousScene();
            if (Input.GetKeyDown(Keys.PageDown))
                SceneManager_Utils.ChangeToNextScene();

            //FRAME RATE
            float frameRate = 1 / (float)Time.gameTime.ElapsedGameTime.TotalSeconds;
            Engine.game.Window.Title = "FPS:" + frameRate.ToString();
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            if(Settings.DEBUG_MODE)
                DrawSimpleShape.DrawRuller(Mouse.position.ToVector2(), Color.Red, orderInLayer: 999);
        }
    }
}
