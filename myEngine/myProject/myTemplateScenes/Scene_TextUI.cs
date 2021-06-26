using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Scene_TextUI : IScene
    {
        //FIELDS 
        Text text;

        //CONSTRUCTOR
        public Scene_TextUI()
        {
            text = new Text();
            text.s = "CECI EST MON TEXT";
            text.color = Color.White;
            text.fontSize = 60;
            //text.transform.position = Settings.Get_Screen_Center();

            Console.WriteLine("Font pos : " + text.transform.position);
            //Console.WriteLine("Font mesure : " + text.font.MeasureString(text.s));

            //Console.WriteLine("DynaFont : " + text.font.TextBounds(text.s, text.transform.position, FontStashSharp.Bounds, text.transform.scale));


            //Vector2 size = new Vector2(text.font.Texture.Width, text.font.Texture.Height);
            //Console.WriteLine("Font size : " + size);

            //Console.WriteLine("Bonds : " + text.font.Texture.Bounds);
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch sprite)
        {
            DrawSimpleShape.DrawRuller(text.transform.position + Vector2.One, Color.Red);
            DrawSimpleShape.DrawRuller(text.font.MeasureString(text.s), Color.Green);
            Vector2 size = new Vector2(text.font.Texture.Width, text.font.Texture.Height);
            DrawSimpleShape.DrawRuller(size, Color.Blue);
        }
    }
}
