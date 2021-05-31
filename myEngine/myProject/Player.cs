using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public abstract class Player : GameObject
    {
        //FIELDS
        public Raquette raquette;
        public float speed = 500;

        public Transform anchorPoint;

        //CONSTRUCTOR 
        public Player()
        {
            raquette = new Raquette();
            anchorPoint = new Transform();
        }

        //METHODS

        //UPDATE & DRAW
        public abstract override void Update();

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}