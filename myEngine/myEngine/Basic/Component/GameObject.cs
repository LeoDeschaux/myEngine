using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public class GameObject : Entity, IDisposable
    {
        //FIELDS
        public string name;

        public GameObject parent { get; private set; }
        private bool hasParent;

        public Transform transform;

        /*
        {
            get { return t_transform.GetTransform(this.parent); }
            set { Console.WriteLine("test"); t_transform = value; } 
            //set { t_transform.SetTransform(value); }
        }
        */

        private Transform t_transform;

        public List<Component> components;
        private List<GameObject> childs;

        //public bool dontDestroyOnLoad = false;

        //CONSTRUCTOR
        public GameObject()
        {
            transform = new Transform(Vector2.Zero, 0f, Vector2.One);
            //transform = new Transform();

            components = new List<Component>();
            childs = new List<GameObject>();

            parent = null;
            hasParent = false;
        }

        public void SetParent(GameObject parent)
        {
            this.parent = parent;
            this.hasParent = true;
        }

        public void AddChild(GameObject child)
        {
            childs.Add(child);
            //child.parent = this;
            //child.relativeTransform.position = child.transform.position;
            //child.transform.position += this.transform.position;
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
