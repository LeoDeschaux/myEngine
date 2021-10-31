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

            camera = new Camera2D();
            postProcessingProfile = new PostProcessingProfile();
            RenderingEngine.postProcessingProfile = postProcessingProfile;

            camControl = new CameraMouseController(camera);
        }

        public virtual void DrawGUI() { }
    }
}
