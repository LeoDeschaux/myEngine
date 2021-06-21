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
                rectangle = sprite.GetRectangle();
            }
        }

        //UPDATE & DRAW
        public override void Update()
        {
            //rectangle = new Rectangle((int)transformTarget.position.X, (int)transformTarget.position.Y, rectangle.Width, rectangle.Height);
            rectangle = sprite.GetRectangle();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //DrawSimpleShape.DrawRectangle(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.Width, rectangle.Height), Color.Green, 1, 1000);
        }
    }
}
