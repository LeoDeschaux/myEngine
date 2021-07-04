using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Transform // : Entity //Transform2D 
    {
        //FIELDS
        public Vector2 position;
        public float rotation;
        public Vector2 scale;

        private Transform parent;

        /*
        private List<Transform> children = new List<Transform>();

        private Matrix absolute, invertAbsolute, local;
        private float localRotation, absoluteRotation;
        private Vector2 localScale, absoluteScale, localPosition, absolutePosition;
        private bool needsAbsoluteUpdate = true, needsLocalUpdate = true;
        */

        //CONSTRUCTOR
        public Transform()
        {
            position = Vector2.Zero;
            rotation = 0f;
            scale = Vector2.One;
        }

        //ACCESOR
        /*
        public void SetPosition(Vector2 p)
        {
            position = p;
        }

        public void SetPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public Vector2 GetPosition()
        {
            if (parent != null)
                return position + parent.GetWorldPosition();
            else
                return position;
        }

        private Vector2 GetWorldPosition()
        {
            return position;
        }

        public void SetParent(Transform parent)
        {
            this.parent = parent;

            //SetPosition(parent.GetPosition().X, parent.GetPosition().Y);
        }

        public Transform GetParent()
        {
            return this.parent;
        }

        public static Transform Zero()
        {
            return new Transform();
        }
        */
    }
}
