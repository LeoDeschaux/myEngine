using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System.IO;
using System.Linq;

using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using FontStashSharp;

namespace myEngine
{
    public class Scene_TextUI : IScene
    {
        //FIELDS 
        Text origin;
        Text textCenter;

		//CONSTRUCTOR
		public Scene_TextUI()
        {
            origin = new Text();
            origin.s = "TEXT ORIGIN";
            origin.color = Color.White;
            origin.fontSize = 60;

            textCenter = new Text();
            textCenter.s = "CECI EST \nMON TEXT";
            textCenter.color = Color.White;
            textCenter.fontSize = 60;
            textCenter.transform.position = Settings.GetScreenCenter();
            textCenter.alignment = Alignment.Center;
		}

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            DrawSimpleShape.DrawRectangle(origin.GetRectangle(), 0f, Color.Green);

            DrawSimpleShape.DrawRuller(textCenter.transform.position + Vector2.One, Color.Red);
            DrawSimpleShape.DrawRectangle(textCenter.GetRectangle(), 0f, Color.Green);
		}
	}
}
