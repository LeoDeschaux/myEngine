using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Image : Entity
    {
        // FIELDS 
        private Texture2D texture;
        public Transform transform;

        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle;

        private float rotation;
        private Vector2 origin;

        private Color color;
        private SpriteEffects effects;

        private int imageWidth, imageHeight;

        //SETTERS
        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetSize(int x, int y)
        {
            destinationRectangle.Width = x;
            destinationRectangle.Height = y;
        }

        public void SetImage(Texture2D texture)
        {
            this.texture = texture;
        }

        //GETTERS
        public Rectangle GetRectangle()
        {
            return new Rectangle();
        }

        //CONSTRUCTOR
        public Image(Texture2D img = null, int posX = 0, int posY = 0, int dimensionX = 0, int dimensionY = 0)
        {
            transform = new Transform();

            if (img == null)
                texture = DrawSimpleShape.GetTexture();
            else
                this.texture = img;

            this.imageWidth = this.texture.Width;
            this.imageHeight = this.texture.Height;

            if(dimensionX == 0 || dimensionY == 0)
                this.destinationRectangle = new Rectangle(posX, posY, imageWidth, imageHeight);
            else 
                this.destinationRectangle = new Rectangle(posX, posY, dimensionX, dimensionY);

            this.sourceRectangle = new Rectangle(0, 0, this.imageWidth, this.imageHeight);

            this.color = Color.White;
            this.rotation = 0f;
            this.origin = Vector2.Zero;
            this.effects = SpriteEffects.None;
        }

        //DRAW
        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            spriteBatch.Draw(this.texture, this.GetRectangle(), this.sourceRectangle, this.color, this.rotation, this.origin, this.effects, 0f);
        }
    }
}
