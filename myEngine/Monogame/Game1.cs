using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace myEngine
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static World world;
        public static SceneManager sceneManager;
        public static PhysicEngine physicEngine;

        public static Settings settings;

        //DEBUG
        public static Debug debug;

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
            Settings_Init.InitSettingsFromFile(settings);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Ressources.LoadImages(this.Content);
            Ressources.LoadFont(this.Content);
            Ressources.LoadRessources(this.Content);

            Time.InitTime();

            physicEngine = new PhysicEngine();
            world = new World();
            sceneManager = new SceneManager();

            //DEBUG
            debug = new Debug();
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
            //spriteBatch.Begin();
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive);

            world.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}