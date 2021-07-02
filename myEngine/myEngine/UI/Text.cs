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
    public enum Alignment
    {
        Left,
        Center,
        Right
    }

    public class Text : GameObject
    {
        //COMPONENTS
        private FontSystem fontSystem;
        public DynamicSpriteFont font;

        //FIELDS
        public string s;
        public int fontSize;

        public Color color;

        public int orderInLayer = 0;

        public bool isVisible = true;

        public Alignment alignment;

        //CONSTRUCTOR 
        public Text(string s = "new Text")
        {
            fontSystem = FontSystemFactory.CreateStroked(Engine.spriteBatch.GraphicsDevice, 1, Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            fontSystem.AddFont(File.ReadAllBytes(@"Content/myContent/UI/Fonts/arial.ttf"));

            this.s = s;
            this.fontSize = 32;

            this.color = Color.Black;
            this.alignment = Alignment.Left;
        }

        //METHODS
        private static Vector2 AlignmentOrigin(Alignment alignment, Vector2 dimensions)
        {
            switch (alignment)
            {
                case Alignment.Left:
                    return Vector2.Zero;
                case Alignment.Center:
                    return new Vector2(dimensions.X / 2, dimensions.Y / 2);
                case Alignment.Right:
                    return new Vector2(dimensions.X, 0);
                default:
                    return Vector2.Zero;
            }
        }

        //DRAW
        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteFontBase font = fontSystem.GetFont(fontSize);

            Vector2 dimensions = font.MeasureString(s);
            Vector2 origin = AlignmentOrigin(alignment, dimensions);

            if (font != null && s != null)
            {
                spriteBatch.DrawString(font, s, transform.position, color, transform.scale, transform.rotation, origin,
                    (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000);
            }
        }

        public Rectangle GetRectangle()
        {
            SpriteFontBase font = fontSystem.GetFont(fontSize);

            Vector2 dimensions = font.MeasureString(s);
            Vector2 origin = AlignmentOrigin(alignment, dimensions);

            Rectangle r = new Rectangle((int)(transform.position.X - origin.X), (int)(transform.position.Y - origin.Y), (int)dimensions.X, (int)dimensions.Y);
            return r;
        }
    }
}
