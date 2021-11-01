using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

using ImGuiNET;

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
            if (Input.GetMouseDown(MouseButtons.Left))
            {
                draw = true;
                pos = Mouse.position.ToVector2();
            }
            if (Input.GetMouseUp(MouseButtons.Left))
                draw = false;

            text.s = "" + Mouse.position.ToVector2();
            text.color = Color.White;
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            DrawSimpleShape.DrawRuller(Mouse.position.ToVector2());

            if (draw)
            {
                Vector2 endPos = (Mouse.position.ToVector2() - pos);

                Shapes s = new Shapes(Engine.game);

                s.Begin(null);
                s.DrawRectangle(pos.X,pos.Y, endPos.X, endPos.Y, 4, Color.Green);
                s.End();
            }
        }
    }
}