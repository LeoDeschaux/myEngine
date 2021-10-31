using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class NewTween
    {
        //FIELDS
        public unsafe static void BaseTween(ref float valueToModify, float endValue)
        {
            fixed (float* x = &valueToModify)
            {
                Tween t = new Tween(x, endValue);
            }
        }
    }
}
