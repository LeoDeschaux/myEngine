using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Entity
    {
        //FIELDS
        //public bool dontDestroyOnLoad = false;

        //CONSTRUCTOR
        public Entity()
        {
            Game1.world.AddEntity(this);
        }

        //UPDATE & DRAW
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch sprite) { }

        //METHODS
        public void Destroy()
        {
            Game1.world.RemoveEntity(this);
        }
    }
}
