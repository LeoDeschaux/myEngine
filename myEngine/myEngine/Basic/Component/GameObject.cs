using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class GameObject : Entity, IDisposable
    {
        //FIELDS
        public string name;
        public Transform transform;

        public List<Component> components;

        //public int orderInLayer = 0;
        //public bool dontDestroyOnLoad = false;

        //CONSTRUCTOR
        public GameObject()
        {
            transform = new Transform();
            components = new List<Component>();
        }

        public void AddComponent(Component c)
        {
            components.Add(c);
            c.SetGameObject(this);
        }

        public void AddComponent<T>()where T: Component, new()
        {
            Component c = new T();
            AddComponent(c);
        }

        public T GetComponent<T>()
        {
            var t = new Component();

            foreach (Component c in components)
            {
                if (c.GetType() == typeof(T))
                    t = c;
            }

            return (T)(object)t;
        }

        public virtual void OnCollision(Collider2D other) { }

        public override void Destroy()
        {
            base.Destroy();

            foreach (Component c in components)
            {
                c.Destroy();
            }
        }
    }
}
