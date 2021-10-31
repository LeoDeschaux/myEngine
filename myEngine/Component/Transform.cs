using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;

        private GameObject parent;
        private bool hasParent;

        //CONSTRUCTOR
        public Transform()
        {
            //INIT
            this.position = Vector2.Zero;
            this.rotation = 0f;
            this.scale = Vector2.One;

            parent = null;
            hasParent = false;
        }

        public void SetParent(GameObject parent)
        {
            this.parent = parent;
            hasParent = true;
        }

        public void UnSetParent()
        {
            this.parent = null;
            hasParent = false;
        }

        public Matrix GetMatrix()
        {
            Matrix c_scale = Matrix.CreateScale(scale.X, scale.Y, 1);
            Matrix c_rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(rotation));
            Matrix c_position = Matrix.CreateTranslation((int)position.X, (int)position.Y, 0);
            Matrix c_transform = c_scale * c_rotation * c_position;

            return c_transform;
        }

        /*
        public Transform GetTransform(GameObject? parent)
        {
            if (hasParent)
            {
                if (parent == null)
                    throw new ArgumentException("no parent");

                //PARENT
                Matrix p_scale = Matrix.CreateScale(parent.transform.scale.X, parent.transform.scale.Y, 1);
                Matrix p_rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(-parent.transform.rotation));
                Matrix p_position = Matrix.CreateTranslation((int)parent.transform.position.X, (int)parent.transform.position.Y, 0);
                Matrix p_transform = p_scale * p_rotation * p_position;

                //CHILD
                Matrix c_scale = Matrix.CreateScale(scale.X, scale.Y, 1);
                Matrix c_rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(-rotation));
                Matrix c_position = Matrix.CreateTranslation((int)position.X, (int)position.Y, 0);
                Matrix c_transform = c_scale * c_rotation * c_position;

                Matrix newTransform = c_transform * p_transform;

                Vector2 tmp_Pos = position;
                Vector2 tmp_Scale = scale;
                float tmp_Rot = rotation;

                Util.DecomposeMatrix(ref newTransform, out tmp_Pos, out tmp_Rot, out tmp_Scale);

                Transform result = new Transform();
                result.position = tmp_Pos;
                result.scale = tmp_Scale;
                result.rotation = tmp_Rot;

                return result;
            }
            else
            {
                return this;
            }
        }
        */
    }
}
