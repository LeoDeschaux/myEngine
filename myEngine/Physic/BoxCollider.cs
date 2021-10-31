using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class BoxCollider : Collider2D
    {
        //FIELDS
        public Rectangle rectangle;
        private Sprite sprite;
        private float scale = 1f;

        //CONSTRUCTOR
        public BoxCollider(Sprite sprite)
        {
            transformTarget = new Transform();
            rectangle = new Rectangle();

            Engine.physicEngine.AddCollider2D(this);

            if (sprite != null)
            {
                this.sprite = sprite;
                transformTarget = sprite.transform;
                rectangle = sprite.GetRec();
            }
        }

        public override bool TypeIntersects(Collider2D other)
        {
            //throw new NotImplementedException();
            return this.rectangle.Intersects(((BoxCollider)other).rectangle);
        }

        //METHODS
        public override void Update()
        {
            rectangle = calculateRectangle();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //you cannot rotate a rectangle, but 0 correspond to the rotation just in case..
            if (Settings.DEBUG_MODE)
                DrawSimpleShape.DrawRectangle(rectangle, 0, Color.Green, thickness: 3, orderInLayer: 700);
        }

        private Rectangle calculateRectangle()
        {
            rectangle = sprite.GetRec();
            Vector2 dimension = new Vector2(sprite.GetRec().Width, sprite.GetRec().Height);
            Rectangle newRectangle = new Rectangle((int)(rectangle.X - (dimension.X * scale / 2)), (int)(rectangle.Y - (dimension.Y * scale / 2)), (int)(dimension.X * scale), (int)(dimension.Y * scale));
            return newRectangle;
        }
    }
}
