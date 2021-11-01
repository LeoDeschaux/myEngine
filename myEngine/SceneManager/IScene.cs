using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public abstract class IScene : EmptyObject
    {
        //FIELDS
        public Camera2D camera;
        public CameraMouseController camControl;

        public PostProcessingProfile postProcessingProfile;

        //CONSTRUCTOR
        public IScene()
        {
            Settings.BACKGROUND_COLOR = Color.Black;
            Settings.GAME_SPEED = 1;

            Engine.game.IsMouseVisible = true;

            Viewport viewPort = new Viewport();
            viewPort.X = 0;
            viewPort.Y = 0;
            viewPort.Width = Settings.SCREEN_WIDTH;
            viewPort.Height = Settings.SCREEN_HEIGHT;
            viewPort.MinDepth = 0;
            viewPort.MaxDepth = 1;

            Engine.renderingEngine.viewPort = viewPort;

            camera = new Camera2D();
            postProcessingProfile = new PostProcessingProfile();
            RenderingEngine.postProcessingProfile = postProcessingProfile;

            camControl = new CameraMouseController(camera);
        }

        public virtual void DrawGUI() { }
    }
}
