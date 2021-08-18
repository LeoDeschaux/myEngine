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
            t.s = "SCENE_DEFAULT (screen coord)";
            t.color = Color.White;

            Text center = new Text();
            center.s = "CENTER OF THE SCREEN (world coord)";
            center.color = Color.White;
            center.alignment = Alignment.Center;
            center.useScreenCoord = false;
        }

        //METHODS
        private Vector2 WorldToScreen(Vector2 position, Matrix matrix)
        {
            Vector2 result = Vector2.Zero;
            return result;
        }
    }
}