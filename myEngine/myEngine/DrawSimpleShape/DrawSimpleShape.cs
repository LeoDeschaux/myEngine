using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace myEngine
{
    public static class DrawSimpleShape
    {
        //FIELDS

        //METHODS
        public static Texture2D GetTexture(int x = 2, int y = 2) //2 make it divisible, making it avoid glitching (i guess ?????)
        {
            Texture2D texture = new Texture2D(RendererEngine.spriteBatch.GraphicsDevice, x, y, false, SurfaceFormat.Color);

            Color[] data = new Color[x * y];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            texture.SetData(data);

            return texture;
        }

        //##### DRAW LINE #####
        public static void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness = 1f, int orderInLayer = 0)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

            DrawLine(point1, distance, angle, color, thickness, orderInLayer);
        }

        public static void DrawLine(Vector2 point1, Vector2 point2, Color color, Matrix? matrix, float thickness = 1f, int orderInLayer = 0)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

            DrawLine(point1, distance, angle, color, matrix, thickness, orderInLayer);
        }

        public static void DrawLine(Vector2 point, float length, float angle, Color color, float thickness = 1f, int orderInLayer = 0)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length * 0.5f, thickness * 0.5f);

            RendererEngine.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            RendererEngine.spriteBatch.Draw(GetTexture(), point, null, color, angle, origin, scale, SpriteEffects.None,
                (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000);
            RendererEngine.spriteBatch.End();
        }

        public static void DrawLine(Vector2 point, float length, float angle, Color color, Matrix? matrix, float thickness = 1f, int orderInLayer = 0)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length * 0.5f, thickness * 0.5f);

            RendererEngine.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, transformMatrix: matrix);
            RendererEngine.spriteBatch.Draw(GetTexture(), point, null, color, angle, origin, scale, SpriteEffects.None,
                (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000);
            RendererEngine.spriteBatch.End();
        }

        //##### DRAW RECTANGLE #####
        public static void DrawRectangle(Vector2 position, Vector2 dimension, float rotation, Color color, float thickness = 1f, int orderInLayer = 0)
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

        public static void DrawRectangle(Vector2 position, Vector2 dimension, float rotation, Color color, Matrix? matrix, float thickness = 1f, int orderInLayer = 0)
        {
            Vector2 point1 = position;
            Vector2 point2 = position + dimension;

            //DIAGONAL
            DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point2.X, point2.Y), color, matrix, thickness, orderInLayer);

            //LINES
            DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point2.X, point1.Y), color, matrix, thickness, orderInLayer);
            DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point1.X, point2.Y), color, matrix, thickness, orderInLayer);

            DrawLine(new Vector2(point2.X, point2.Y), new Vector2(point1.X, point2.Y), color, matrix, thickness, orderInLayer);
            DrawLine(new Vector2(point2.X, point2.Y), new Vector2(point2.X, point1.Y), color, matrix, thickness, orderInLayer);
        }

        public static void DrawRectangle(Rectangle rectangle, float rotation, Color color, Matrix? matrix, float thickness = 1f, int orderInLayer = 0)
        {
            float angle = MathHelper.ToRadians(rotation);

            Vector2 center = new Vector2(rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2));
            Vector2 point1 = new Vector2(rectangle.X, rectangle.Y);
            Vector2 point2 = new Vector2(rectangle.X + rectangle.Width, rectangle.Y);
            Vector2 point3 = new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);
            Vector2 point4 = new Vector2(rectangle.X, rectangle.Y + rectangle.Height);

            Vector2 initPoint1 = point1;

            //POINT1
            float x = center.X + (rectangle.Width/2 * (float)Math.Cos((double)angle) - rectangle.Height / 2 * (float)Math.Sin((double)angle));
            float y = center.Y + (rectangle.Width / 2 * (float)Math.Sin((double)angle) + rectangle.Height/2 * (float)Math.Cos((double)angle));
            point1 = new Vector2(x, y);

            //POINT2
            angle += (float)Math.PI / 2;
            x = center.X + (rectangle.Height / 2 * (float)Math.Cos((double)angle) - rectangle.Width / 2 * (float)Math.Sin((double)angle));
            y = center.Y + (rectangle.Height / 2 * (float)Math.Sin((double)angle) + rectangle.Width / 2 * (float)Math.Cos((double)angle));
            point2 = new Vector2(x, y);

            //POINT3
            angle += (float)Math.PI / 2;
            x = center.X + (rectangle.Width/2 * (float)Math.Cos((double)angle) - rectangle.Height / 2 * (float)Math.Sin((double)angle));
            y = center.Y + (rectangle.Width / 2 * (float)Math.Sin((double)angle) + rectangle.Height/2 * (float)Math.Cos((double)angle));
            point3 = new Vector2(x, y);

            //POINT4
            angle += (float)Math.PI / 2;
            x = center.X + (rectangle.Height / 2 * (float)Math.Cos((double)angle) - rectangle.Width / 2 * (float)Math.Sin((double)angle));
            y = center.Y + (rectangle.Height / 2 * (float)Math.Sin((double)angle) + rectangle.Width / 2 * (float)Math.Cos((double)angle));
            point4 = new Vector2(x, y);

            //NEW RECTANGLE
            DrawLine(point1, point2, color, matrix, thickness: thickness);
            DrawLine(point2, point3, color, matrix, thickness: thickness);
            DrawLine(point3, point4, color, matrix, thickness: thickness);
            DrawLine(point4, point1, color, matrix, thickness: thickness);

            //DIAGO
            //DrawLine(point1, point3, color, matrix, thickness: thickness);
        }

        public static void DrawRectangle(Rectangle rectangle, float rotation, Color color, float thickness = 1f, int orderInLayer = 0)
        {
            DrawRectangle(rectangle, rotation, color, null, thickness, orderInLayer);
        }

        public static void DrawRectangleFull(Vector2 position, Vector2 dimension, Color color, Matrix? matrix, int orderInLayer = 0)
        {
            Vector2 point1 = position;
            Vector2 point2 = position + dimension;

            var r = new Rectangle(
            Math.Min((int)point1.X, (int)point2.X),
            Math.Min((int)point1.Y, (int)point2.Y),
            Math.Abs((int)point2.X - (int)point1.X),
            Math.Abs((int)point2.Y - (int)point1.Y));

            //Rectangle sourceRectangle = new Rectangle(0, 0, (int)dimension.X, (int)dimension.Y);

            RendererEngine.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp, transformMatrix: matrix);
            RendererEngine.spriteBatch.Draw(GetTexture(), r, null, color, 0, Vector2.Zero, SpriteEffects.None,
                (float)((Math.Clamp(orderInLayer, -1000, 1000) + 1000)) / 2000);
            RendererEngine.spriteBatch.End();
        }

        public static void DrawRuller(Vector2 position)
        {
            DrawSimpleShape.DrawLine(new Vector2(position.X, 0), Settings.SCREEN_HEIGHT, MathHelper.ToRadians(90), Color.Red);
            DrawSimpleShape.DrawLine(new Vector2(0, position.Y), Settings.SCREEN_WIDTH, 0, Color.Red);
        }

        public static void DrawRuller(Vector2 position, Matrix? matrix)
        {
            DrawSimpleShape.DrawLine(new Vector2(position.X, 0), Settings.SCREEN_HEIGHT, MathHelper.ToRadians(90), Color.Red, matrix);
            DrawSimpleShape.DrawLine(new Vector2(0, position.Y), Settings.SCREEN_WIDTH, 0, Color.Red, matrix);
        }

        public static void DrawRuller(Vector2 position, Color color)
        {
            //VERTICAL
            DrawSimpleShape.DrawLine(new Vector2(position.X, 0), Settings.SCREEN_HEIGHT, MathHelper.ToRadians(90), color);
            
            //HORIZONTAL
            DrawSimpleShape.DrawLine(new Vector2(0, position.Y), Settings.SCREEN_WIDTH, 0, color);
        }

        public static void DrawRuller(Vector2 position, Color color, Matrix? matrix)
        {
            //VERTICAL
            DrawSimpleShape.DrawLine(new Vector2(position.X, 0), Settings.SCREEN_HEIGHT, MathHelper.ToRadians(90), color, matrix);

            //HORIZONTAL
            DrawSimpleShape.DrawLine(new Vector2(0, position.Y), Settings.SCREEN_WIDTH, 0, color, matrix);
        }

        public static void DrawRuller(Vector2 position, Color color, int orderInLayer = 0)
        {
            //VERTICAL
            DrawSimpleShape.DrawLine(new Vector2(position.X, 0), Settings.SCREEN_HEIGHT, MathHelper.ToRadians(90), color, orderInLayer: orderInLayer);

            //HORIZONTAL
            DrawSimpleShape.DrawLine(new Vector2(0, position.Y), Settings.SCREEN_WIDTH, 0, color, orderInLayer: orderInLayer);
        }

        public static void DrawRuller(Vector2 position, Color color, Matrix? matrix, int orderInLayer = 0)
        {
            //VERTICAL
            DrawSimpleShape.DrawLine(new Vector2(position.X, 0), Settings.SCREEN_HEIGHT, MathHelper.ToRadians(90), color, matrix, orderInLayer: orderInLayer);

            //HORIZONTAL
            DrawSimpleShape.DrawLine(new Vector2(0, position.Y), Settings.SCREEN_WIDTH, 0, color, matrix, orderInLayer: orderInLayer);
        }
    }
}