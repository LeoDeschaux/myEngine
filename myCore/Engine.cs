using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using ImGuiNET;

namespace myEngine
{
    public class Engine
    {
        //BASE
        public static Game game;
        public static GraphicsDeviceManager graphics;

        //FIELDS
        public static World world;

        public static AudioEngine audioEngine;
        public static PhysicEngine physicEngine;
        public static RenderingEngine renderingEngine;

        public static Settings settings;
        public static Debug debug;
        public static LateEventSystem lateEventSystem;

        public static bool isGameRunning = true;

        //METHODS
        private void myEngine() { }

        public static void Initialize(Game game, GraphicsDeviceManager graphics)
        {
            Engine.game = game;
            Engine.graphics = graphics;

            settings = new Settings(game);
            //Settings_Init.InitSettingsFromFile(settings);

            SaveSystem_RunTime.Init();
            Time.Init();

            LoadContent(game.Content);

            renderingEngine = new RenderingEngine();
            audioEngine = new AudioEngine();
            physicEngine = new PhysicEngine();

            world = new World();
            debug = new Debug();

            lateEventSystem = new LateEventSystem();
        }

        private static void LoadContent(ContentManager content)
        {
            game.Content.RootDirectory = "Content";
            Ressources.Init(content);
        }

        public static void Update(GameTime gameTime)
        {
            if (!Engine.isGameRunning)
                game.Exit();

            if (!Settings.RELEASE_MODE && (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)))
                game.Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * Settings.GAME_SPEED;
            Time.UpdateGameTime(gameTime, deltaTime);

            Input.Update();
            Mouse.Update();
            
            world.Update();
            world.LateUpdate();
            physicEngine.Update();
        }

        public static void Draw()
        {
            renderingEngine.Draw();
            lateEventSystem.Update();
        }

        //METHODS
        public static void ExitGame()
        {
            isGameRunning = false;
        }
    }
}