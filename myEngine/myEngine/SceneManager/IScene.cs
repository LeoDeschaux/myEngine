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

        //CONSTRUCTOR
        public IScene()
        {
            Settings.BACKGROUND_COLOR = Color.Black;
            Settings.GAME_SPEED = 1;

            camera = new Camera2D();
        }

        public virtual void DrawUI()
        {

        }
    }
}
