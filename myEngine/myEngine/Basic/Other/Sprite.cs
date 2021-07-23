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
        public Color color;

        public bool isVisible = true;

        public SpriteEffects spriteEffect;
        public Effect effect;

        //CONSTRUCTOR
        public Sprite()
        {
            transform = new Transform();
            this.texture = DrawSimpleShape.GetTexture();
            transform.position = Vector2.Zero;
            this.dimension = Vector2.One * 150;
            color = Color.White;
            spriteEffect = SpriteEffects.None;
        }

        public Sprite(Texture2D texture2D)
        {
            transform = new Transform();

            this.texture = texture2D;

            this.dimension = new Vector2(texture2D.Width, texture2D.Height);
            color = Color.White;
            spriteEffect = SpriteEffects.None;
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

            spriteEffect = SpriteEffects.None;
        }

        //METHODS
        public Rectangle GetRectangle()
        {
            return new Rectangle(
                (int)transform.position.X-(int)((dimension.X * transform.scale.X) / 2),
                (int)transform.position.Y-(int)((dimension.Y * transform.scale.Y) / 2),
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

        private Vector2 GetOrigin()
        {
            return new Vector2(texture.Width/2, texture.Height/2);
        }

        //DRAW
        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            if (!isVisible)
                return;


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, effect, matrix);
            //spriteBatch.Begin(SpriteSortMode.Immediate);

            //effect?.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Draw(this.texture, GetRec(), null, this.color, MathHelper.ToRadians(transform.rotation), GetOrigin(), spriteEffect, 
                (float)( (Math.Clamp(drawOrder, -1000, 1000)+1000)) / 2000);

            spriteBatch.End();
        }
    }
}
