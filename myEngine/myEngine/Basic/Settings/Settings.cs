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
        public static bool RELEASE_MODE = false;

        //REF
        //public Game1 game;

        //CONSTRUCTOR
        public Settings(Game game)
        {
            //this.game = game;

            game.IsMouseVisible = true;
            game.IsFixedTimeStep = false;

            Engine.graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            Engine.graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;

            Engine.graphics.SynchronizeWithVerticalRetrace = false;
            //Engine.game.TargetElapsedTime = TimeSpan.FromTicks((long)(TimeSpan.TicksPerSecond / 60L));

            ASPECT_RATIO = (float)SCREEN_WIDTH / (float)SCREEN_HEIGHT;

            game.Window.AllowUserResizing = true;
            game.Window.ClientSizeChanged += OnResize;

            game.Window.IsBorderless = false;

            game.Window.Title = "MonogameV2";
            Engine.graphics.ApplyChanges();
        }
        
        public void OnResize(Object sender, EventArgs e)
        {
            /*
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
            */

            //Engine.graphicDevice.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            //Engine.graphicDevice.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;

            Engine.graphics.ApplyChanges();

            //Settings.SCREEN_WIDTH = game.Window.ClientBounds.Width;
            //Settings.SCREEN_HEIGHT = game.Window.ClientBounds.Height;

            Console.WriteLine("ratio: " + ASPECT_RATIO + ", dimension: " + Settings.SCREEN_WIDTH + "x" + Settings.SCREEN_HEIGHT);
        }

        public static void SetScreenSize(int x, int y)
        {
            Settings.SCREEN_WIDTH = x;
            Settings.SCREEN_HEIGHT = y;

            Engine.graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            Engine.graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;

            ASPECT_RATIO = (float)SCREEN_WIDTH / (float)SCREEN_HEIGHT;

            Engine.graphics.ApplyChanges();
        }

        //UPDATE & DRAW
        public void Update()
        {
        }

        //PROPS
        public static Vector2 GetScreenCenter()
        {
            return new Vector2((float)SCREEN_WIDTH / 2, (float)SCREEN_HEIGHT / 2);
        }
    }
}