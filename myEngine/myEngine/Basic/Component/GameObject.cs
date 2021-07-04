using System;
using System.Collections.Generic;

namespace myEngine
{
    public class GameObject : Entity, IDisposable
    {
        //FIELDS
        public string name;

        public GameObject parent { get; private set; }
        public Transform relativeTransform;

        private Transform m_transform;
        public Transform transform
        {
            get
            {
                foreach (GameObject child in childs)
                {
                    child.transform.position.X = (this.m_transform.position.X + child.relativeTransform.position.X);
                    child.transform.position.Y = (this.m_transform.position.Y + child.relativeTransform.position.Y);
                }

                return m_transform;
            }
            set
            {
                m_transform = value;
            }
        }

        public List<Component> components;

        private List<GameObject> childs;

        //public int orderInLayer = 0;
        //public bool dontDestroyOnLoad = false;

        //CONSTRUCTOR
        public GameObject()
        {
            relativeTransform = new Transform();
            m_transform = new Transform();
            transform = new Transform();
            components = new List<Component>();

            childs = new List<GameObject>();
        }

        public void AddChild(GameObject child)
        {
            childs.Add(child);
            child.parent = this;
            child.relativeTransform.position = child.transform.position;
            child.transform.position += this.transform.position;
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
