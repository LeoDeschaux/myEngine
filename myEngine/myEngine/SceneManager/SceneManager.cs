using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public static class SceneManager
    {
        //FIELDS
        public static IScene currentScene;

        public static void ChangeScene(IScene scene)
        {
            ClearScene();
            Type t = Type.GetType(scene.ToString());
            currentScene = (IScene)Activator.CreateInstance(t);
        }

        public static void ChangeScene(Type scene)
        {
            ClearScene();
            currentScene = (IScene)Activator.CreateInstance(scene);
            //Type t = Type.GetType(scene.ToString());
            //currentScene = (IScene)Activator.CreateInstance(t);
        }

        public static void OnSceneChange()
        {

        }

        public static void ReloadScene()
        {
            ChangeScene(currentScene);
        }

        private static void ClearScene()
        {
            Engine.world.SkipUpdate();

            //Engine.world = new World();
            Engine.world.ClearWorld();
            //Engine.world.AddEntity();

            if(currentScene != null)
            {
                currentScene.Destroy();
            }
        }
    }
}