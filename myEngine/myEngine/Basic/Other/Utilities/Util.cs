using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class Util
    {
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
            float result = min + ((float)random.NextDouble() * (max-min));
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
    }
}
