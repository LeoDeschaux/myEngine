using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using myEngine;

namespace zzMathVisu
{
    public class Scene_EarthGlobe : IScene
    {
        //FIELDS
        Camera3D camera;

        //CONSTRUCTOR
        public Scene_EarthGlobe()
        {
            Settings.BACKGROUND_COLOR = Color.Gray;
            camera = new Camera3D(Engine.game, new Vector3(0, 1.5f,0), Vector3.Zero, 15);

            Floor f = new Floor(Engine.game.GraphicsDevice, camera, 4, 4, 1);
        }

        //METHODS
    }
}
