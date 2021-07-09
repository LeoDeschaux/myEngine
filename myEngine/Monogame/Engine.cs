using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Engine
    {
        //BASE
        public static Game1 game;
        public static GraphicsDeviceManager graphicDevice;
        public static SpriteBatch spriteBatch;

        //FIELDS
        public static World world;
        public static SceneManager sceneManager;

        public static AudioEngine audioEngine;
        public static PhysicEngine physicEngine;

        public static Settings settings;

        public static Debug debug;

        public static bool isGameRunning = true;

        //METHODS
        public static void Initialize(Game1 game)
        {
            Engine.game = game;
            graphicDevice = game.graphicDevice;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);

            settings = new Settings(game);
            Settings_Init.InitSettingsFromFile(settings);

            Save_RunTime.Init();
            Time.InitTime();

            audioEngine = new AudioEngine();
            physicEngine = new PhysicEngine();

            LoadContent(game.Content);

            world = new World();
            sceneManager = new SceneManager();
            debug = new Debug();
        }

        private static void LoadContent(ContentManager content)
        {
            game.Content.RootDirectory = "Content";
            Ressources.LoadRessources(content);
        }

        public static void Update(GameTime gameTime)
        {
            if (!Engine.isGameRunning)
                game.Exit();

            if (!Settings.RELEASE_MODE && (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)))
                game.Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * Settings.GAME_SPEED;
            Time.UpdateGameTime(gameTime, deltaTime);

            Input.StaticUpdate();
            Mouse.Update();

            settings.Update();

            world.Update();
            physicEngine.Update();
        }

        public static void Draw()
        {
            game.GraphicsDevice.Clear(Settings.BACKGROUND_COLOR);

            //DRAW BACKGROUND
            spriteBatch.Begin();
            //..
            spriteBatch.End();

            //DRAW SCENE
            Matrix matrix = sceneManager.currentScene.camera.transformMatrix;
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, transformMatrix: matrix);

            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive);

            world.Draw(spriteBatch);

            spriteBatch.End();

            //DRAW UI
            spriteBatch.Begin();
            //..
            spriteBatch.End();

            //ImGUI
            sceneManager.currentScene.DrawUI();
        }

        //METHODS
        public static void ExitGame()
        {
            isGameRunning = false;
        }
    }
}
