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
        private static Type nextScene;

        public static void ChangeSceneOld(IScene scene)
        {
            ClearScene();
            //Type t = Type.GetType(scene.ToString());
            Type t = scene.GetType();
            currentScene = (IScene)Activator.CreateInstance(t);
        }

        public static void ChangeScene(Type scene)
        {
            nextScene = scene;

            if (currentScene == null)
            {
                ChangeSceneNow();
            }
            else
                Engine.lateEventSystem.AddEvent(new Event(ChangeSceneNow));
        }

        private static void ChangeSceneNow()
        {
            if (currentScene != null)
                ClearScene();

            currentScene = (IScene)Activator.CreateInstance(nextScene);

            //currentScene.Start();
        }

        public static void OnSceneChange()
        {

        }

        public static void ReloadScene()
        {
            ChangeScene(currentScene.GetType());
        }

        private static void ClearScene()
        {
            Engine.world.SkipUpdate();
            Engine.renderingEngine.SkipGUI();
            
            //Engine.world = new World();
            Engine.world.ClearWorld();
            //Engine.world.AddEntity(this);
            //Engine.world.AddEntity(input);

            if(currentScene != null)
            {
                currentScene.Destroy();
            }

        }
    }
}