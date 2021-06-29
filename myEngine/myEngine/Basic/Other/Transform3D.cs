using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Transform3D
    {
        //FIELDS
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        //CONSTRUCTOR
        public Transform3D()
        {
            position = Vector3.Zero;
            rotation = Vector3.Zero;
            scale = Vector3.One;
        }

    }
}
