using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Sprite : GameObject
    {
        //FIELDS
        public Texture2D texture;
        public Vector2 dimension;
        private Vector2 origin;
        public Color color;

        private Rectangle sourceRectangle;

        public bool isVisible = true;
        public int orderInLayer = 0;

        //CONSTRUCTOR
        public Sprite()
        {
            transform = new Transform();
            this.texture = DrawSimpleShape.GetTexture();
            transform.position = Vector2.Zero;
            this.dimension = Vector2.One * 150;
            color = Color.White;
            sourceRectangle = new Rectangle(0, 0, (int)dimension.X, (int)dimension.Y);
            origin = new Vector2(dimension.X / 2, dimension.Y / 2);
        }

        public Sprite(Vector2 position, Vector2 dimension, Texture2D texture2D = null)
        {
            transform = new Transform();

            if (texture2D != null)
                this.texture = texture2D;
            else
                this.texture = DrawSimpleShape.GetTexture();

            transform.position = position;
            this.dimension = dimension;

            color = Color.White;
            sourceRectangle = new Rectangle(0, 0, (int)dimension.X, (int)dimension.Y);

            //origin = new Vector2((float)(GetRectangle().X), (float)(GetRectangle().Y));
            //origin = Vector2.Zero;
            origin = new Vector2(dimension.X / 2, dimension.Y / 2);
        }

        //METHODS
        public Rectangle GetRectangle()
        {
            return new Rectangle(
                (int)transform.position.X-(int)(dimension.X/2),
                (int)transform.position.Y-(int)(dimension.Y/2),
                (int)(dimension.X * transform.scale.X),
                (int)(dimension.Y * transform.scale.Y));
        }

        public Rectangle GetRec()
        {
            return new Rectangle(
                (int)transform.position.X,
                (int)transform.position.Y,
                (int)(dimension.X * transform.scale.X),
                (int)(dimension.Y * transform.scale.Y));
        }

        private Vector2 GetCenter()
        {
            return new Vector2(transform.position.X + (dimension.X / 2), transform.position.Y + (dimension.Y / 2));
        }

        //DRAW
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(isVisible)
            spriteBatch.Draw(this.texture, GetRec(), this.sourceRectangle, this.color, MathHelper.ToRadians(transform.rotation), origin, SpriteEffects.None, 
                (float)( (Math.Clamp(orderInLayer, -1000, 1000)+1000)) / 2000);
        }
    }
}
