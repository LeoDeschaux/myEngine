using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_DrawSimpleShape : IScene
    {
        //FIELDS
        bool draw;
        Vector2 pos;

        Text text;

        //CONSTRUCTOR
        public Scene_DrawSimpleShape()
        {
            text = new Text("DRAG LEFT CLICK \nTO DRAW A RECTANGLE");
            text.color = new Color(50, 50, 50);
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (Input.GetMouseDown(0))
            {
                draw = true;
                pos = Mouse.position.ToVector2();
            }
            if (Input.GetMouseUp(0))
                draw = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            text.Draw(spriteBatch);

            if (draw)
                DrawSimpleShape.DrawRectangle(pos, Mouse.position.ToVector2() - pos, 0f, Color.Red);
        }
    }
}