using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class CircleCollider : Collider2D
    {
        //FIELDS
        Transform transform;
        float radius;

        //CONSTRUCTOR
        public CircleCollider(Transform transform, float radius)
        {
            Engine.physicEngine.AddCollider2D(this);

            this.transform = transform;
            this.radius = radius;
        }

        public override bool TypeIntersects(Collider2D other)
        {
            if (AreCircleIntersecting(this, (CircleCollider)other, out float depth, out Vector2 normal))
            {
                Vector2 mtv = depth * normal;

                this.transform.position += (-mtv / 2f);
                ((CircleCollider)other).transform.position += (mtv / 2f);

                return true;
            }

            return false;
        }

        private static bool AreCircleIntersecting(CircleCollider a, CircleCollider b)
        {
            float distance = Vector2.Distance(a.transform.position, b.transform.position);
            float r2 = a.radius + b.radius;

            if (distance >= r2)
            {
                return false;
            }

            return true;
        }

        private static bool AreCircleIntersecting(CircleCollider a, CircleCollider b, out float depth, out Vector2 normal)
        {
            depth = 0;
            normal = Vector2.Zero;

            Vector2 n = b.transform.position - a.transform.position;
            float distSq = n.LengthSquared();
            float r2 = a.radius + b.radius;
            float radiusSq = r2 * r2;

            if(distSq >= radiusSq)
            {
                return false;
            }

            float dist = MathF.Sqrt(distSq);

            if(dist != 0)
            {
                depth = r2 - dist;
                normal = n / dist;
            }
            else
            {
                depth = r2;
                normal = new Vector2(1f, 0f);
            }

            return true;

        }

        //METHODS
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //TODO: DRAW
        }
    }
}
