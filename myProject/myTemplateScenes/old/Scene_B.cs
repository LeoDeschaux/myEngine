using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public class Scene_B : IScene
    {
        //FIELDS

        //CONSTRUCTOR
        public Scene_B()
        {
            Settings.BACKGROUND_COLOR = Color.LightPink;

            Button button = new Button();
            button.transform.position = new Vector2(0,0);
            button.text.s = "GO TO SCENE A";
            button.text.transform.position = button.transform.position;
            button.text.useScreenCoord = false;
            button.onButtonPressed.SetFunction(ChangeScene);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                ChangeScene();
        }

        //METHODS
        public void ChangeScene()
        {
            SceneManager.ChangeScene(typeof(Scene_A));
        }
    }
}
