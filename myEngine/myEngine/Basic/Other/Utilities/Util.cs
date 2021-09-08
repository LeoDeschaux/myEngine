using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class Util
    {
        public static Vector2 ScreenToWorld(Camera2D cam, Vector2 position)
        {
            Transform t = new Transform();
            t.position = position;

            t = t.GetTransform(cam);

            return t.position;
        }

        public static Vector2 WorldToScreen()
        {
            return Vector2.Zero;
        }

        public static float RandomBetween(float min, float max)
        {
            if (min > max)
                throw new ArgumentException("min > max");

            Random random = new Random();

            //Random random = new Random();
            float result = min + ((float)random.NextDouble() * (max - min));
            return result;
        }

        public static float RandomBetween(Random random, float min, float max)
        {
            if (min > max)
                throw new ArgumentException("min > max");

            //Random random = new Random();
            float result = min + ((float)random.NextDouble() * (max - min));
            return result;
        }

        public static void DisplayMatrix(Matrix m)
        {
            int i = 0;
            for (int rows = 0; rows < 4; rows++)
            {
                for (int collumns = 0; collumns < 4; collumns++)
                {
                    Console.Write(m[i] + ", ");
                    i++;

                }
                Console.WriteLine("");
            }

            Console.WriteLine("---------------------------");
        }

        public static void DecomposeMatrix(ref Matrix matrix, out Vector2 position, out float rotation, out Vector2 scale)
        {
            Vector3 position3, scale3;
            Quaternion rotationQ;

            matrix.Decompose(out scale3, out rotationQ, out position3);

            Vector2 direction = Vector2.Transform(Vector2.UnitX, rotationQ);
            rotation = -1 * MathHelper.ToDegrees((float)Math.Atan2((double)(direction.Y), (double)(direction.X)));
            position = new Vector2(position3.X, position3.Y);
            scale = new Vector2(scale3.X, scale3.Y);
        }

        public static void DecomposeMatrix(Matrix matrix, Transform transform)
        {
            Vector3 position3, scale3;
            Quaternion rotationQ;

            matrix.Decompose(out scale3, out rotationQ, out position3);

            Vector2 direction = Vector2.Transform(Vector2.UnitX, rotationQ);
            transform.rotation = -1 * MathHelper.ToDegrees((float)Math.Atan2((double)(direction.Y), (double)(direction.X)));
            transform.position = new Vector2(position3.X, position3.Y);
            transform.scale = new Vector2(scale3.X, scale3.Y);
        }

        public static float FindPolygonArea(Vector2[] vertices)
        {
            float totalArea = 0f;

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector2 a = vertices[i];
                Vector2 b = vertices[(i + 1) % vertices.Length];

                float dy = (a.Y + b.Y) / 2f;
                float dx = b.X - a.X;

                float area = dy * dx;
                totalArea += area;
            }

            return MathF.Abs(totalArea);
        }

        public static float FindCollisionRadius(Vector2[] vertices)
        {
            float polygonArea = Util.FindPolygonArea(vertices);
            float circleRadius = MathF.Sqrt(polygonArea / MathHelper.Pi);

            return circleRadius;
        }

        public static Vector2[] ConvertVerticesTransform(Vector2[] vertices, Matrix transformMatrix)
        {
            Vector2[] newVertices = new Vector2[vertices.Length];
            vertices.CopyTo(newVertices, 0);

            Transform t = new Transform();
            Util.DecomposeMatrix(transformMatrix, t);
            Matrix m = Matrix.CreateScale((float)Math.Sqrt((double)t.scale.X)) * Matrix.CreateRotationZ(MathHelper.ToRadians(t.rotation)) * Matrix.CreateTranslation(0f, 0f, 0f);
            //Console.WriteLine(t.scale.X);

            for (int i = 0; i < newVertices.Length; i++)
            {
                Vector2 a = newVertices[i];
                Vector2 b = newVertices[(i + 1) % newVertices.Length];

                a = Vector2.Transform(a, m) * new Vector2(1, -1);
                b = Vector2.Transform(b, m) * new Vector2(1, -1);

                newVertices[i] = a;
                newVertices[(i + 1) % newVertices.Length] = b;
            }

            return newVertices;
        }
    }
}
