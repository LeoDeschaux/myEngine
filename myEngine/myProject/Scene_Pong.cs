using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_Pong : IScene
    {
        //FIELDS
        public static Input input;
        public static Game_Pong game;
        public UI ui;

        

        //CONSTRUCTOR
        public Scene_Pong()
        {
            input = new Input();
            game = new Game_Pong();
            ui = new UI_Pong();
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            //Console.WriteLine(Game1.world.entities.Count);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
