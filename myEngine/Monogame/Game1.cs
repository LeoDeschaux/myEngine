using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphicDevice;

        public Game1()
        {
            graphicDevice = new GraphicsDeviceManager(this);
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