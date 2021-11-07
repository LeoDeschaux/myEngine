using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace myEngine
{
    public class RenderingEngine
    {
        //FIELDS
        public static SpriteBatch spriteBatch;
        private RenderTarget2D renderTarget;

        public static ImGuiRenderer imGuiRenderer;

        public static PostProcessingProfile postProcessingProfile;

        public static GraphicsDeviceManager graphics;

        public Viewport viewPort;

        bool skipGUI = false;

        //CONSTRUCTOR
        public RenderingEngine()
        {
            spriteBatch = new SpriteBatch(Engine.graphics.GraphicsDevice);

            viewPort = new Viewport();
            viewPort.X = 0;
            viewPort.Y = 0;
            viewPort.Width = Settings.SCREEN_WIDTH;
            viewPort.Height = Settings.SCREEN_HEIGHT;
            viewPort.MinDepth = 0;
            viewPort.MaxDepth = 1;

            renderTarget = new RenderTarget2D(
            Engine.game.GraphicsDevice,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferWidth,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferHeight,
            false,
            SurfaceFormat.Color,
            DepthFormat.Depth24Stencil8,
            0,
            RenderTargetUsage.DiscardContents);

            //POST PROCESSING
            postProcessingProfile = new PostProcessingProfile();

            //GUI
            imGuiRenderer = new ImGuiRenderer(Engine.game);
            imGuiRenderer.RebuildFontAtlas();
        }

        //METHODS
        public void Draw()
        {
            Engine.game.GraphicsDevice.SetRenderTarget(renderTarget);
            
            Viewport original = Engine.graphics.GraphicsDevice.Viewport;
            Engine.graphics.GraphicsDevice.Viewport = viewPort;
            
            Engine.game.GraphicsDevice.Clear(Color.HotPink);
            RenderScene();
            DrawSceneToScreen();
            Engine.graphics.GraphicsDevice.Viewport = original;
        }

        private void RenderScene()
        {
            //DRAW BACKGROUND
            DrawSimpleShape.DrawRectangleFull(new Vector2(0, 0), new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT), Settings.BACKGROUND_COLOR, null);
            
            Matrix matrix = SceneManager.currentScene.camera.transformMatrix;
            Engine.world.Draw(spriteBatch, matrix);

            //DRAW UI - ImGUI
            imGuiRenderer.BeforeLayout(Time.gameTime);
            SceneManager.currentScene?.DrawGUI();
            if(!skipGUI)
                imGuiRenderer.AfterLayout();
            skipGUI = false;

            //DRAW RULLER CENTER VIEWPORT
            //DrawSimpleShape.DrawRuller(new Vector2(viewPort.Width/2, viewPort.Height/2));

            Engine.game.GraphicsDevice.SetRenderTarget(null);
        }

        protected void DrawSceneToScreen()
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, postProcessingProfile.effect, null);
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, Engine.game.Window.ClientBounds.Width, Engine.game.Window.ClientBounds.Height), Color.White);
            spriteBatch.End();
        }

        public void SaveScreenAsPng()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\screenShoot.png";
            Stream stream = File.Create(path);
            renderTarget.SaveAsPng(stream, renderTarget.Width, renderTarget.Height);
            stream.Dispose();
            renderTarget.Dispose();

            Console.WriteLine("Screenshoot : " + path);
        }

        public void SkipGUI()
        {
            skipGUI = true;
            imGuiRenderer.AfterLayout();
        }
    }
}
