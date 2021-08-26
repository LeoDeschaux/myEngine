using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class EmptyObject : IDisposable
    {
        //FIELDS
        public bool dontDestroyOnLoad = false;
        public int drawOrder = 0;

        public bool disposed = false;

        //CONSTRUCTOR
        public EmptyObject()
        {
            Engine.world.AddEntity(this);
        }

        //UPDATE & DRAW
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void Draw(SpriteBatch sprite, Matrix matrix) { }

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
