using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using FontStashSharp;

namespace myEngine
{
    public class Text : GameObject
    {
        //COMPONENTS
        private FontSystem fontSystem;

        //FIELDS
        public string s;
        public SpriteFont font;
        public int fontSize;

        public Color color;

        public int orderInLayer = 0;

        public bool isVisible = true;

        //CONSTRUCTOR 
        public Text(string s = "new Text")
        {
            fontSystem = FontSystemFactory.CreateStroked(Game1.spriteBatch.GraphicsDevice, 1, Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            fontSystem.AddFont(File.ReadAllBytes(@"Content/myContent/UI/Fonts/arial.ttf"));

            this.s = s;
            this.fontSize = 32;

            this.color = Color.Black;

            if (Ressources.defaultFont != null)
                this.font = Ressources.defaultFont;
            else
                Console.WriteLine("ERROR - DEFAULT FONT NOT FOUND");
        }

        //METHODS

        //DRAW
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (font != null && s != null)
            {
                SpriteFontBase font18 = fontSystem.GetFont(fontSize);
                spriteBatch.DrawString(font18, s, new Vector2(transform.position.X, transform.position.Y), color);
                
            }
        }
    }
}
