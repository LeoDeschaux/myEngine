using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public abstract class Collider2D : Component
    {
        //FIELDS
        public Transform transformTarget;

        public bool Intersects(Collider2D other)
        {
            if(this.GetType() == other.GetType())
            {
                return TypeIntersects(other);
            }

            return false;
        }

        public abstract bool TypeIntersects(Collider2D other);
        
        //UPDATE & DRAW
        public abstract override void Draw(SpriteBatch spriteBatch);

        public override void OnDestroy()
        {
            Engine.physicEngine.RemoveCollider2D(this);
        }
    }
}
