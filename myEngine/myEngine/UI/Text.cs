using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Text : GameObject
    {
        //COMPONENTS

        //FIELDS
        public string s;
        public SpriteFont font;
        private float fontSize;

        public Color color;

        public int orderInLayer = 0;

        //CONSTRUCTOR 
        public Text(string s = "new Text")
        {
            this.s = s;
            this.fontSize = 0.5f;

            this.color = Color.Black;

            if (Ressources.defaultFont != null)
                this.font = Ressources.defaultFont;
            else
                Console.WriteLine("ERROR - DEFAULT FONT NOT FOUND");
        }

        //METHODS
        public void SetFontSize(int x)
        {
            fontSize = (float)x / 80;
        }

        //DRAW
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (font != null && s != null)
                spriteBatch.DrawString(font, s, transform.position, color, transform.rotation, Microsoft.Xna.Framework.Vector2.Zero, transform.scale * fontSize, SpriteEffects.None,
                    (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000); 
        }
    }
}
