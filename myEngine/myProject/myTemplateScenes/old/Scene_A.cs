using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_A : IScene
    {
        //FIELDS
        Text t;

        //CONSTRUCTOR 
        public Scene_A()
        {
            Settings.BACKGROUND_COLOR = Color.LightGreen;

            Button button = new Button();
            button.transform.position = new Vector2(0, 0);
            button.text.s = "GO TO SCENE B";
            button.text.transform.position = button.transform.position;
            button.text.useScreenCoord = false;

            button.onButtonPressed.SetFunction(ChangeScene);

            this.camControl.isActive = true;

            Point p = new Point(0,0);

            t = new Text();
        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                ChangeScene();

            Vector2 mousePosition = Util.ScreenToWorld(SceneManager.currentScene.camera.transformMatrix, Mouse.position.ToVector2());
            t.s = "" + mousePosition;
        }

        public void ChangeScene()
        {
            //SceneManager.ChangeScene(typeof(Scene_B));

            Console.WriteLine("CLICKED");

            //Engine.sceneManager.ChangeScene(new Scene_B());
        }
    }
}
