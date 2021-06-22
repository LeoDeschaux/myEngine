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
            for (int i = 0; i < collider2Ds.Count; i++)
            {
                Collider2D c = collider2Ds[i];

                for (int j = 0; j < collider2Ds.Count; j++)
                {
                    Collider2D other = collider2Ds[j];

                    if (c.rectangle.Intersects(other.rectangle) && j != i)
                        c.gameObject.OnCollision(other);
                }
                
            }
        }
    }
}
