using System;
using System.Collections.Generic;
using System.Text;

using myEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {

            Shapes s = new Shapes(Engine.game);

            s.Begin(camera);

            s.DrawCircleFill(new Vector2(0, 200), 128, 12, Color.White);

            s.End();
        }
    }
}