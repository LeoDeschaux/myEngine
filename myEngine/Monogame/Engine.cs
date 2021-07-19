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
        public static Game1 game;
        public static GraphicsDeviceManager graphicDevice;

        //FIELDS
        public static World world;
        public static SceneManager sceneManager;

        public static AudioEngine audioEngine;
        public static PhysicEngine physicEngine;
        public static RendererEngine rendererEngine;

        public static Settings settings;

        public static Debug debug;

        public static bool isGameRunning = true;


        //METHODS
        public static void Initialize(Game1 game)
        {
            Engine.game = game;
            graphicDevice = game.graphicDevice;

            settings = new Settings(game);
            //Settings_Init.InitSettingsFromFile(settings);

            Save_RunTime.Init();
            Time.Init();

            rendererEngine = new RendererEngine();
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

            Input.StaticUpdate();
            Mouse.Update();

            settings.Update();

            world.Update();
            physicEngine.Update();
        }

        public static void Draw()
        {
            rendererEngine.Draw();
        }

        //METHODS
        public static void ExitGame()
        {
            isGameRunning = false;
        }
    }
}
