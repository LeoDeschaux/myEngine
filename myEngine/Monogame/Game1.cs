using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace myEngine
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static World world;
        public SceneManager sceneManager;
        public static PhysicEngine physicEngine;

        private Settings settings;

        //DEBUG
        public static DebugInput debugInput;

        public Game1()
        { 
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            settings = new Settings(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Ressources.LoadImages(this.Content);
            Ressources.LoadFont(this.Content);
            Ressources.LoadRessources(this.Content);

            physicEngine = new PhysicEngine();
            world = new World();
            sceneManager = new SceneManager();

            //DEBUG
            debugInput = new DebugInput();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * Settings.GAME_SPEED;
            Time.UpdateGameTime(gameTime, deltaTime);

            settings.Update();

            world.Update();
            physicEngine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Settings.BACKGROUND_COLOR);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            world.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}