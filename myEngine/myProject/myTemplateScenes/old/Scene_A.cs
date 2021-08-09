using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_A : IScene
    {
        //FIELDS

        //CONSTRUCTOR 
        public Scene_A()
        {
            Settings.BACKGROUND_COLOR = Color.LightGreen;

            Button button = new Button();
            button.transform.position = Settings.Get_Screen_Center();
            button.text.s = "GO TO SCENE B";
            button.onButtonPressed.SetFunction(ChangeScene);
        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                ChangeScene();
        }

        public void ChangeScene()
        {
            SceneManager.ChangeScene(typeof(Scene_B));
            //Engine.sceneManager.ChangeScene(new Scene_B());
        }
    }
}
