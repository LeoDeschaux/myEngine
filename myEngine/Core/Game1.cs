using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Game1 : Game
    {
        GraphicsDeviceManager g;
        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Engine.Create(this, g);
        }

        protected override void Initialize()
        {
            //Engine.Initialize();
            //Engine.sceneManager.ChangeScene(typeof(Scene_TwoBitCoding));
            //SceneManager.ChangeScene(typeof(Scene_TwoBitCoding));
            base.Initialize();
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
