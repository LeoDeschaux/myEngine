using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Particle
    {
        //FIELDS 
        public Texture2D Texture { get; set; }        // The texture that will be drawn to represent the particle
        public Vector2 Position { get; set; }        // The current position of the particle        
        public Vector2 Velocity { get; set; }        // The speed of the particle at the current instance
        public float Angle { get; set; }            // The current angle of rotation of the particle
        public float AngularVelocity { get; set; }    // The speed that the angle is changing
        public Color Color { get; set; }            // The color of the particle
        public float Size { get; set; }                // The size of the particle
        public float TTL { get; set; }                // The 'time to live' of the particle
        public float Speed { get; set; }

        public int OrderInLayer = 0;

        //CONSTRUCTOR
        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, float speed,
            float angle, float angularVelocity, Color color, float size, float ttl, int orderInLayer)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngularVelocity = angularVelocity;
            Color = color;
            Size = size;
            TTL = ttl;
            Speed = speed;

            OrderInLayer = orderInLayer;
        }

        public Particle(Texture2D texture)
        {
            Texture = texture;
            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Angle = 0f;
            AngularVelocity = 0f;
            Color = Color.White;
            Size = 1f;
            TTL = 1;
            Speed = 1;
        }

        //UPDATE & DRAW
        public void Update()
        {
            TTL -= Time.deltaTime;
            Position += Velocity * Speed * Time.deltaTime * 60;
            Angle += AngularVelocity * Time.deltaTime * 60;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color,
                Angle, origin, Size, SpriteEffects.None, 
                (float)((Math.Clamp(OrderInLayer, -1000, 1000) + 1000)) / 2000);
        }
    }
}