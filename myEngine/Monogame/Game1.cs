﻿using Microsoft.Xna.Framework;
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

        public static AudioEngine audioEngine;
        public static PhysicEngine physicEngine;

        public static Settings settings;

        //DEBUG
        public static Debug debug;

        private static bool isGameRunning = true;

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

            audioEngine = new AudioEngine();

            // TODO: use this.Content to load your game content here
            Ressources.LoadRessources(this.Content);

            Save_RunTime.Init();

            Time.InitTime();

            physicEngine = new PhysicEngine();
            world = new World();
            sceneManager = new SceneManager();

            //DEBUG
            debug = new Debug();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!isGameRunning || (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)))
                Exit();

            // TODO: Add your update logic here
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * Settings.GAME_SPEED;
            Time.UpdateGameTime(gameTime, deltaTime);

            Mouse.Update();

            settings.Update();

            world.Update();
            physicEngine.Update();

            base.Update(gameTime);
        }

        public static void ExitGame()
        {
            isGameRunning = false;
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