using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class DrawSimpleShape
    {
        //FIELDS

        //METHODS
        public static Texture2D GetTexture(int x = 1, int y = 1)
        {
            Texture2D texture = new Texture2D(Game1.spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);

            if (x == 1 && y == 1)
            {
                texture.SetData(new[] { Color.White });
            }
            else
            {
                texture = new Texture2D(Game1.spriteBatch.GraphicsDevice, x, y, false, SurfaceFormat.Color);

                Color[] data = new Color[x * y];
                for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
                texture.SetData(data);
            }

            return texture;
        }

        //##### DRAW LINE #####
        public static void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness = 1f, int orderInLayer = 0)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(point1, distance, angle, color, thickness, orderInLayer);
        }

        public static void DrawLine(Vector2 point, float length, float angle, Color color, float thickness = 1f, int orderInLayer = 0)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            Game1.spriteBatch.Draw(GetTexture(), point, null, color, angle, origin, scale, SpriteEffects.None,
                (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000);
        }

        //##### DRAW RECTANGLE #####
        public static void DrawRectangle(Vector2 position, Vector2 dimension, Color color, float thickness = 1f, int orderInLayer = 0)
        {
            Vector2 point1 = position;
            Vector2 point2 = position + dimension;

            //DIAGONAL
            DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point2.X, point2.Y), color, thickness, orderInLayer);

            //LINES
            DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point2.X, point1.Y), color, thickness, orderInLayer);
            DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point1.X, point2.Y), color, thickness, orderInLayer);

            DrawLine(new Vector2(point2.X, point2.Y), new Vector2(point1.X, point2.Y), color, thickness, orderInLayer);
            DrawLine(new Vector2(point2.X, point2.Y), new Vector2(point2.X, point1.Y), color, thickness, orderInLayer);
        }

        public static void DrawRectangleFull(Vector2 position, Vector2 dimension, Color color, int orderInLayer = 0)
        {
            Vector2 point1 = position;
            Vector2 point2 = position + dimension;

            var r = new Rectangle(
            Math.Min((int)point1.X, (int)point2.X),
            Math.Min((int)point1.Y, (int)point2.Y),
            Math.Abs((int)point2.X - (int)point1.X),
            Math.Abs((int)point2.Y - (int)point1.Y));

            //Rectangle sourceRectangle = new Rectangle(0, 0, (int)dimension.X, (int)dimension.Y);

            Game1.spriteBatch.Draw(GetTexture(), r, null, color, 0, Vector2.Zero, SpriteEffects.None,
                (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000);
        }
    }
}