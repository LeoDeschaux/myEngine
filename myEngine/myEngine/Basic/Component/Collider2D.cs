using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Collider2D : Component
    {
        //FIELDS
        public Transform transformTarget;
        public Rectangle rectangle;

        private Sprite sprite;

        public float scale = 1;

        //CONSTRUCTOR

        public Collider2D(Sprite sprite)
        {
            transformTarget = new Transform();
            rectangle = new Rectangle();

            Game1.physicEngine.AddCollider2D(this);

            if (sprite != null)
            {
                this.sprite = sprite;
                transformTarget = sprite.transform;
                rectangle = sprite.GetRec();
            }
        }

        //UPDATE & DRAW
        public override void Update()
        {
            rectangle = calculateRectangle();
        }

        private Rectangle calculateRectangle()
        {
            rectangle = sprite.GetRec();
            Vector2 dimension = new Vector2(sprite.GetRec().Width, sprite.GetRec().Height);
            Rectangle newRectangle = new Rectangle((int)(rectangle.X-(dimension.X*scale/2)), (int)(rectangle.Y-(dimension.Y*scale/2)), (int)(dimension.X*scale), (int)(dimension.Y*scale));
            return newRectangle;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //you cannot rotate the rectangle, but 0 correspond to the rotation just in case..
            //DrawSimpleShape.DrawRectangle(rectangle, 0, Color.Green, 2, 1000);
        }
    }
}
