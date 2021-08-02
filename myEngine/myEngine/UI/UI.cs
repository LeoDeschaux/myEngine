using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public abstract class UI : Entity
    {
        //FIELDS

        //CONSTRUCTOR

        //METHODS

        //UPDATE & DRAW
        public abstract override void Update();
        public abstract override void Draw(SpriteBatch spriteBatch, Matrix matrix);
    }
}