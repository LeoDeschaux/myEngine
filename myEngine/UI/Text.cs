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

        public bool isVisible;

        public Alignment alignment;

        public bool useScreenCoord;

        //CONSTRUCTOR 
        public Text(string s = "new Text")
        {
            fontSystem = FontSystemFactory.CreateStroked(RenderingEngine.spriteBatch.GraphicsDevice, 1, Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            fontSystem.AddFont(File.ReadAllBytes(@"Content/myContent/UI/Fonts/arial.ttf"));

            this.s = s;
            this.fontSize = 32;

            this.color = Color.Black;
            this.alignment = Alignment.Left;

            isVisible = true;
            useScreenCoord = true;
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
        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            if (s == null || isVisible == false)
                return;

            SpriteFontBase font = fontSystem.GetFont(fontSize);

            Vector2 dimensions = font.MeasureString(s);
            Vector2 origin = AlignmentOrigin(alignment, dimensions);

            if (font != null && s != null)
            {
                if (useScreenCoord)
                {
                    matrix = Matrix.Identity;

                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, transformMatrix: matrix);

                    spriteBatch.DrawString(font, s, transform.position, color, transform.scale, transform.rotation, origin,
                        (float)((Math.Clamp(drawOrder, -1000, 1000) + 1000)) / 2000);

                    spriteBatch.End();
                }
                else
                {
                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, transformMatrix: matrix);

                    spriteBatch.DrawString(font, s, new Vector2(transform.position.X, transform.position.Y * -1), color, transform.scale, transform.rotation, origin,
                        (float)((Math.Clamp(drawOrder, -1000, 1000) + 1000)) / 2000);

                    spriteBatch.End();
                }
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
