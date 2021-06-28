using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace myEngine
{
    public class AnimatedSprite : GameObject
    {
        //FIELDS
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public float speed = 1;

        //CONSTRUCTOR
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        private float time = 0;
        private float frequence = 1;

        //METHODS
        public override void Update()
        {
            time += Time.deltaTime * speed;
            if (time >= frequence)
            {
                time = 0;

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)transform.position.X, (int)transform.position.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
