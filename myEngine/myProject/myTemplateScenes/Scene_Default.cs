using System;
using System.Collections.Generic;
using System.Text;

using myEngine;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Scene_Default : IScene
    {
        //FIELDS

        //CONSTRUCTOR
        public Scene_Default()
        {
            Settings.BACKGROUND_COLOR = Color.Pink;

            Text t = new Text();
            t.s = "SCENE_DEFAULT";
            t.color = Color.White;
        }

        //METHODS
    }
}
