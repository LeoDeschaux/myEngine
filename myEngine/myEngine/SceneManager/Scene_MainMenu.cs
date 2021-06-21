using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Scene_MainMenu : IScene
    {
        //FIELDS
        public static Input input;
        public static Game_Pong game;
        public UI ui;

        //CONSTRUCTOR
        public Scene_MainMenu()
        {
            input = new Input();

            Settings.BACKGROUND_COLOR = Color.PaleGoldenrod;
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
