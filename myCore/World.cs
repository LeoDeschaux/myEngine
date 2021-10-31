using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class World
    {
        //FIELDS
        //List<GameObject> gameObjects;
        public static List<EmptyObject> entities;
        public static List<Component> components;

        //CONSTRUCTOR
        public World()
        {
            //gameObjects = new List<GameObject>();
            entities = new List<EmptyObject>();
            components = new List<Component>();

        }

        public static void GetWorldStats()
        {
            Console.WriteLine("Entities: " + entities.Count);
            Console.WriteLine("Components: " + components.Count);
        }

        //UPDATE & DRAW
        private bool runUpdate;
        public void SkipUpdate()
        {
            runUpdate = false;
        }

        public void Update()
        {
            runUpdate = true;

            for (int i = 0; i < entities.Count; i++)
            {
                EmptyObject e = entities[i];
                e.Update();

                if (!runUpdate)
                    return;
            }

            for (int i = 0; i < components.Count; i++)
            {
                Component c = components[i];
                c.Update();
            }
        }

        public void LateUpdate()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                EmptyObject e = entities[i];
                e.LateUpdate();
            }

            for (int i = 0; i < components.Count; i++)
            {
                Component c = components[i];
                c.LateUpdate();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            //SORT BY DRAW ORDER
            entities.Sort((x, y) => x.drawOrder.CompareTo(y.drawOrder));

            for (int i = 0; i < entities.Count; i++)
            {
                EmptyObject e = entities[i];
                e.Draw(spriteBatch, matrix);
            }

            for (int i = 0; i < components.Count; i++)
            {
                Component c = components[i];
                c.Draw(spriteBatch);
            }
        }

        public void AddEntity(EmptyObject e)
        {
            entities.Add(e);
        }

        public void RemoveEntity(EmptyObject e)
        {
            entities.Remove(e);
        }

        public void AddComponent(Component c)
        {
            components.Add(c);
        }

        public void RemoveComponent(Component c)
        {
            components.Remove(c);
        }

        public void ClearWorld()
        {
            //gameObjects = new List<GameObject>();
            components = new List<Component>();

            List<EmptyObject> dontDestroy = new List<EmptyObject>();
            for (int i = 0; i < entities.Count; i++)
            {
                EmptyObject e = entities[i];
                if (e.dontDestroyOnLoad)
                    dontDestroy.Add(e);
            }

            entities = new List<EmptyObject>();

            for (int i = 0; i < dontDestroy.Count; i++)
            {
                EmptyObject e = dontDestroy[i];
                entities.Add(e);
            }

            Engine.physicEngine = new PhysicEngine();
            //Engine.debug = new Debug();

            /*
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject g = gameObjects[i];
                if (g.dontDestroyOnLoad)
                    Console.WriteLine(g);
                else
                    g.Destroy();
            }

            for (int i = 0; i < entities.Count; i++)
            {
                Entity e = entities[i];
                if (e.dontDestroyOnLoad)
                    Console.WriteLine(e);
                else
                    e.Destroy();
            }
            */

            //gameObjects = null;
            //entities = null;
        }
    }
}
