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
            this.texture = DrawSimpleShape.GetTexture();
            this.dimension = Vector2.One * 150;
            color = Color.White;
            spriteEffect = SpriteEffects.None;
        }

        public Sprite(Texture2D texture2D)
        {
            this.texture = texture2D;
            this.dimension = new Vector2(texture2D.Width, texture2D.Height);
            color = Color.White;
            spriteEffect = SpriteEffects.None;
        }

        public Sprite(Vector2 position, Vector2 dimension, Texture2D texture2D = null)
        {
            //transform = new Transform();

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
                (int)-transform.position.Y,
                (int)(dimension.X * transform.scale.X),
                (int)(dimension.Y * transform.scale.Y));
        }

        public Rectangle GetRec2()
        {
            return new Rectangle(
                (int)Math.Round(transform.position.X, MidpointRounding.AwayFromZero),
                (int)Math.Round(-transform.position.Y, MidpointRounding.AwayFromZero),
                (int)Math.Round((dimension.X * transform.scale.X), MidpointRounding.AwayFromZero),
                (int)Math.Round((dimension.Y * transform.scale.Y), MidpointRounding.AwayFromZero));
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


            //BlendState.NonPremultiplied
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, effect, matrix);
            //spriteBatch.Begin(SpriteSortMode.Immediate);

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, effect, matrix);

            //effect?.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Draw(this.texture, GetRec(), null, this.color, MathHelper.ToRadians(transform.rotation), GetOrigin(), spriteEffect, 
                (float)( (Math.Clamp(drawOrder, -1000, 1000)+1000)) / 2000);

            spriteBatch.End();
        }
    }
}
