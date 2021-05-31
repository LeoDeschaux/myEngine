using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public abstract class IScene : Entity
    {
        //FIELDS

        //CONSTRUCTOR
        public IScene()
        {
            Game1.world.AddEntity(this);
        }

        //UPDATE & DRAW
        public abstract override void Update();
        public abstract override void Draw(SpriteBatch sprite);
    }
}
