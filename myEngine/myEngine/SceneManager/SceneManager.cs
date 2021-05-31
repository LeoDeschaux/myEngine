﻿using System;
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
            currentScene = new Scene_Pong();
            input = new Input();
        }

        //UPDATE & DRAW
        public override void Update()
        {
            CheckInput_ChangeScene();
        }

        private void CheckInput_ChangeScene()
        {
            if (input.GetKeyDown(Keys.F1))
            {
                ClearScene();
                currentScene = new Scene_Pong();
            }

            if (input.GetKeyDown(Keys.F2))
            {
                ClearScene();
                currentScene = new Scene_DrawSimpleShape();
            }

            if (input.GetKeyDown(Keys.F3))
            {
                ClearScene();
                currentScene = new Scene_Animation();
            }

            if (input.GetKeyDown(Keys.F4))
            {
                ClearScene();
                currentScene = new Scene_ParticleSystem();
            }
        }

        private void ClearScene()
        {
            //Game1.world = new World();
            Game1.world.ClearWorld();
            Game1.world.AddEntity(this);
            Game1.world.AddEntity(input);

            if(currentScene != null)
                currentScene.Destroy();
        }
    }
}