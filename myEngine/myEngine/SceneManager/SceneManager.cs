using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class SceneManager : Entity
    {
        //FIELDS
        public IScene currentScene;
        private Input input;

        //CONSTRUCTOR
        public SceneManager()
        {
            //currentScene = new Scene_ParentTransform();
            currentScene = new Scene_PostProcessing();
            input = new Input();
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if(!Settings.RELEASE_MODE)
                CheckInput_ChangeScene();
        }

        private void CheckInput_ChangeScene()
        {
            if (Input.GetKeyDown(Keys.F1))
                ChangeScene(new Scene_Pong());
            if (Input.GetKeyDown(Keys.F2))
                ChangeScene(new Scene_DrawSimpleShape());
            if (Input.GetKeyDown(Keys.F3))
                ChangeScene(new Scene_Tweening());
            if (Input.GetKeyDown(Keys.F4))
                ChangeScene(new Scene_ParticleSystem());
            if (Input.GetKeyDown(Keys.F5))
                ChangeScene(new Scene_PhysiqueEngine());
            if (Input.GetKeyDown(Keys.F6))
                ChangeScene(new Scene_3D());
            if (Input.GetKeyDown(Keys.F7))
                ChangeScene(new Scene_Animation());
            if (Input.GetKeyDown(Keys.F8))
                ChangeScene(new Scene_2DCamera());
            if (Input.GetKeyDown(Keys.F9))
                ChangeScene(new Scene_ParentTransform());
            if (Input.GetKeyDown(Keys.F10))
                ChangeScene(new Scene_PerlinNoise());
            if (Input.GetKeyDown(Keys.F11))
                ChangeScene(new Scene_TextUI());
            /*
            if (Input.GetKeyDown(Keys.F12))
                ChangeScene(new Scene_WindowSizes());
            */

            if (Input.GetKeyDown(Keys.F12))
                ChangeScene(new Scene_ParticleEditor());
        }

        public void ChangeScene(IScene scene)
        {
            ClearScene();
            Type t = Type.GetType(scene.ToString());
            currentScene = (IScene)Activator.CreateInstance(t);
        }

        public void ReloadScene()
        {
            ChangeScene(currentScene);
        }

        private void ClearScene()
        {
            Engine.world = new World();
            Engine.world.ClearWorld();
            Engine.world.AddEntity(this);
            Engine.world.AddEntity(input);

            if(currentScene != null)
            {
                currentScene.Destroy();
            }
        }
    }
}