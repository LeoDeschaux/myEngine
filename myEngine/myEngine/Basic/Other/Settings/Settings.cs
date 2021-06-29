using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public class Settings
    {
        //FIELDS
        public static int SCREEN_WIDTH = 1280;
        public static int SCREEN_HEIGHT = 720;

        public static float ASPECT_RATIO { get; private set; }

        public static float GAME_SPEED = 1f;

        public static Color BACKGROUND_COLOR = Color.Black;

        public static bool DEBUG_MODE = false;

        //REF
        public Game1 game;

        //CONSTRUCTOR
        public Settings(Game1 game)
        {
            this.game = game;

            game.graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            game.graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;

            ASPECT_RATIO = (float)SCREEN_WIDTH / (float)SCREEN_HEIGHT;

            /*
            game.Window.AllowUserResizing = true;
            game.Window.ClientSizeChanged += OnResize;
            */

            game.Window.Title = "MonogameV2";
            game.graphics.ApplyChanges();
        }
        
        public void OnResize(Object sender, EventArgs e)
        {
            if (game.Window.ClientBounds.Width != Settings.SCREEN_WIDTH)
            {
                Settings.SCREEN_WIDTH = game.Window.ClientBounds.Width;
                Settings.SCREEN_HEIGHT = (int)((float)Settings.SCREEN_WIDTH / ASPECT_RATIO);
            }

            else if (game.Window.ClientBounds.Height != Settings.SCREEN_HEIGHT)
            {
                Settings.SCREEN_HEIGHT = game.Window.ClientBounds.Height;
                Settings.SCREEN_WIDTH = (int)((float)Settings.SCREEN_HEIGHT * ASPECT_RATIO);
            }
            
            game.graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            game.graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;

            game.graphics.ApplyChanges();

            Console.WriteLine("ratio: " + ASPECT_RATIO + ", dimension: " + Settings.SCREEN_WIDTH + "x" + Settings.SCREEN_HEIGHT);
        }

        //UPDATE & DRAW
        public void Update()
        {
            Debug();
        }

        public void Debug()
        {
            //DEBUG
            float frameRate = 1 / (float)Time.gameTime.ElapsedGameTime.TotalSeconds;
            game.Window.Title = "FPS:" + frameRate.ToString();
        }

        //PROPS
        public static Vector2 Get_Screen_Center()
        {
            return new Vector2((float)SCREEN_WIDTH / 2, (float)SCREEN_HEIGHT / 2);
        }
    }
}