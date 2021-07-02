using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace myEngine
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphicDevice;

        public Game1()
        {
            graphicDevice = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Engine.Initialize(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Engine.LoadContent(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            Engine.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Engine.Draw();
            base.Draw(gameTime);
        }
    }
}