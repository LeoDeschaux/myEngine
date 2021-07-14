using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Snake
{
    public struct IntVec2
    {
        public int X;
        public int Y;

        public IntVec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "{" + X + "," + Y + "}";
        }

        public static IntVec2 operator +(IntVec2 a) => a;

        public static IntVec2 operator +(IntVec2 a, IntVec2 b)
        => new IntVec2(a.X + b.X, a.Y + b.Y);
    }
}
