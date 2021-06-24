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
        public Collider2D collider;

        //SCORE
        public int score = 0;
        public int lives = 3;

        //BALL


        //CONSTRUCTOR 
        public Player()
        {
            raquette = new Raquette();
            anchorPoint = new Transform();

            AddComponent(new Collider2D(raquette.sprite));
        }

        //METHODS

        //UPDATE & DRAW
        public abstract override void Update();

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void OnCollision(Collider2D other)
        {
        }
    }
}