﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Component : Entity
    {
        //FIELDS
        public GameObject gameObject;

        //CONSTRUCTOR
        public Component()
        {
            Game1.world.AddComponent(this);
            this.gameObject = null;
        }

        public void SetGameObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        //METHODS
        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        //METHODS
        public void Destroy()
        {
            OnDestroy();
            Game1.world.RemoveComponent(this);
        }

        public virtual void OnDestroy() { }
    }
}
