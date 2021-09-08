using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using myEngine;

namespace zzMathVisu
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //TODO: define the ressources repertoir of the ressource manager when instanciating the engine
        }

        protected override void Initialize()
        {
            Engine.Initialize(this, graphics);
            SceneManager.ChangeScene(typeof(Scene_Main));

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
