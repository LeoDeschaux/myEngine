using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace myEngine
{
    public class RendererEngine
    {
        //FIELDS
        public static SpriteBatch spriteBatch;

        public RenderTarget2D renderTarget;

        private static ImGuiRenderer imGuiRenderer;

        //CONSTRUCTOR
        public RendererEngine()
        {
            spriteBatch = new SpriteBatch(Engine.game.GraphicsDevice);

            renderTarget = new RenderTarget2D(
            Engine.game.GraphicsDevice,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferWidth,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferHeight,
            false,
            Engine.game.GraphicsDevice.PresentationParameters.BackBufferFormat,
            DepthFormat.Depth24);

            //GUI
            imGuiRenderer = new ImGuiRenderer(Engine.game);
            imGuiRenderer.RebuildFontAtlas();
        }

        //METHODS
        public void Draw()
        {
            RenderScene();

            DrawTextureToScreen();
        }

        private void RenderScene()
        {
            // Set the render target
            Engine.game.GraphicsDevice.SetRenderTarget(renderTarget);
            Engine.game.GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            Engine.game.GraphicsDevice.Clear(Settings.BACKGROUND_COLOR);

            //DRAW BACKGROUND
            spriteBatch.Begin();
            //..
            spriteBatch.End();

            //DRAW SCENE
            Matrix matrix = Engine.sceneManager.currentScene.camera.transformMatrix;
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, transformMatrix: matrix);
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            //spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive);

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, effect, null);

            Engine.world.Draw(spriteBatch);

            //spriteBatch.End();

            //DRAW UI
            spriteBatch.Begin();
            //..
            spriteBatch.End();

            //ImGUI
            imGuiRenderer.BeforeLayout(Time.gameTime);
            Engine.sceneManager.currentScene.DrawGUI();
            imGuiRenderer.AfterLayout();

            Engine.game.GraphicsDevice.SetRenderTarget(null);
        }

        protected void DrawTextureToScreen()
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                SamplerState.LinearClamp, DepthStencilState.Default,
                RasterizerState.CullNone);

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
    }
}
