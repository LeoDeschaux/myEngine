using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class myVector
    {
        public float X
        {
            get { Console.WriteLine(); return m_x; }
            set { Console.WriteLine("set - myVector, X:" + m_x); m_x = value; }
        }
        public float Y
        {
            get { Console.WriteLine(); return m_y; }
            set { Console.WriteLine("set - myVector, Y:" + m_y); m_y = value; }
        }

        private float m_x;
        private float m_y;

        public myVector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 ToVector(float x, float y)
        {
            return new Vector2(x, y);
        }

        public static myVector ToMyVector(float x, float y)
        {
            return new myVector(x, y);
        }
    }
}
