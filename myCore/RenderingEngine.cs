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

        private static ImGuiRenderer imGuiRenderer;

        public static PostProcessingProfile postProcessingProfile;

        public static GraphicsDeviceManager graphics;

        private Shapes shapes;

        public Viewport viewPort;

        //CONSTRUCTOR
        public RenderingEngine()
        {
            spriteBatch = new SpriteBatch(Engine.graphics.GraphicsDevice);

            /*
            renderTarget = new RenderTarget2D(
            Engine.game.GraphicsDevice,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferWidth,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferHeight,
            false,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferFormat,
            DepthFormat.Depth24);
            */

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


            viewPort = new Viewport();
            //viewPort.X = -150;
            viewPort.X = 0;
            viewPort.Y = 0;
            viewPort.Width = Settings.SCREEN_WIDTH;
            viewPort.Height = Settings.SCREEN_HEIGHT;
            viewPort.MinDepth = 0;
            viewPort.MaxDepth = 1;
        }

        //METHODS
        public void Draw()
        {
            //Engine.game.GraphicsDevice.Clear(Settings.BACKGROUND_COLOR);
            //Engine.game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            Engine.game.GraphicsDevice.SetRenderTarget(renderTarget);
            Engine.game.GraphicsDevice.Clear(Color.Black);
            
            Viewport original = Engine.graphics.GraphicsDevice.Viewport;

            Engine.graphics.GraphicsDevice.Viewport = viewPort;
            
            Engine.game.GraphicsDevice.Clear(Color.Gray);
            RenderScene();
            
            DrawSceneToScreen();
            Engine.graphics.GraphicsDevice.Viewport = original;

        }

        private void RenderScene()
        {
            // Set the render target
            //Engine.game.GraphicsDevice.SetRenderTarget(renderTarget);
            //Engine.game.GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            //Engine.game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            //Engine.game.GraphicsDevice.BlendState = BlendState.AlphaBlend;

            //Engine.game.GraphicsDevice.Clear(Settings.BACKGROUND_COLOR);

            //DRAW BACKGROUND
            spriteBatch.Begin();
            //..
            spriteBatch.End();

            //DRAW SCENE
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, transformMatrix: matrix);
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive);

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, effect, null);

            Matrix matrix = SceneManager.currentScene.camera.transformMatrix;
            Engine.world.Draw(spriteBatch, matrix);

            DrawSimpleShape.DrawRuller(Settings.GetScreenCenter(), Color.Red);

            //spriteBatch.End();

            //DRAW UI
            spriteBatch.Begin();
            //..
            spriteBatch.End();

            //ImGUI
            imGuiRenderer.BeforeLayout(Time.gameTime);
            SceneManager.currentScene?.DrawGUI();
            imGuiRenderer.AfterLayout();

            Engine.game.GraphicsDevice.SetRenderTarget(null);
        }

        protected void DrawSceneToScreen()
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, postProcessingProfile.effect, null);
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, Engine.game.Window.ClientBounds.Width, Engine.game.Window.ClientBounds.Height), Color.White);
            spriteBatch.End();

            /*
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, postProcessingProfile.effect, null);
            spriteBatch.Draw(renderTarget, new Rectangle(0, 0, renderTarget.Width, renderTarget.Height), Color.White);
            spriteBatch.End();
            */
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
    }
}
