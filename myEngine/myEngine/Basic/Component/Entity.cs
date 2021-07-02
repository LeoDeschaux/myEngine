using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Entity : IDisposable
    {
        //FIELDS
        //public bool dontDestroyOnLoad = false;

        public bool disposed = false;

        //CONSTRUCTOR
        public Entity()
        {
            Engine.world.AddEntity(this);
        }

        //UPDATE & DRAW
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch sprite) { }

        //METHODS
        public virtual void Destroy()
        {
            OnDestroy();
            Dispose();
            Engine.world.RemoveEntity(this);
        }

        public virtual void OnDestroy() { }

        public void Dispose()
        {
            disposed = true;
        }
    }
}
