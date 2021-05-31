using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Raquette : GameObject
    {
        //FIELDS
        public Sprite sprite;

        //CONSTRUCTOR
        public Raquette()
        {
            sprite = new Sprite(new Vector2(0, 0), new Vector2(40, 150));
            sprite.transform = this.transform;
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}