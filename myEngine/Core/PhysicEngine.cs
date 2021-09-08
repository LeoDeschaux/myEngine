using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class PhysicEngine
    {
        //FIELDS
        List<Collider2D> collider2Ds;

        //CONSTRUCTOR
        public PhysicEngine()
        {
            collider2Ds = new List<Collider2D>();
        }

        //METHODS
        public void AddCollider2D(Collider2D collider)
        {
            collider2Ds.Add(collider);
        }

        public void RemoveCollider2D(Collider2D collider)
        {
            collider2Ds.Remove(collider);
        }

        //UPDATE 
        public void Update()
        {
            for (int i = 0; i < collider2Ds.Count - 1; i++)
            {
                Collider2D other = collider2Ds[i];

                for (int j = i+1; j < collider2Ds.Count; j++)
                {
                    Collider2D c = collider2Ds[j];

                    if (c.Intersects(other))
                    {
                        c.gameObject.OnCollision(other);
                        other.gameObject.OnCollision(c);
                    }
                }
            }
        }
    }
}
