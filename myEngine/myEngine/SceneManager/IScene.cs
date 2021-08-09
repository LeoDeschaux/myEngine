using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public abstract class IScene : Entity
    {
        //FIELDS
        public Camera2D camera;
        public PostProcessingProfile postProcessingProfile;

        //CONSTRUCTOR
        public IScene()
        {
            Settings.BACKGROUND_COLOR = Color.Black;
            Settings.GAME_SPEED = 1;

            camera = new Camera2D();
            postProcessingProfile = new PostProcessingProfile();
            RenderingEngine.postProcessingProfile = postProcessingProfile;
        }

        public virtual void DrawGUI() { }
    }
}
