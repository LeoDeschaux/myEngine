using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_2DCamera : IScene
    {
        //FIELDS
        public static Camera2D camera;
        private Input input;
        float speed = 500;

        //CONSTRUCTOR
        public Scene_2DCamera()
        {
            Sprite s = new Sprite(Settings.Get_Screen_Center(), (Vector2.One*150));
            
            camera = new Camera2D();

            Sprite center = new Sprite(Settings.Get_Screen_Center(), (Vector2.One * 50));
            center.color = Color.Red;
            center.transform = camera.transform;

            input = new Input();
        }

        //METHODS
        public override void Update()
        {
            //
            if (input.GetKey(Keys.Q))
            {
                camera.transform.position.X -= speed * Time.deltaTime;
            }

            if (input.GetKey(Keys.D))
            {
                camera.transform.position.X += speed * Time.deltaTime;
            }

            //
            if (input.GetKey(Keys.Z))
            {
                camera.transform.position.Y -= speed * Time.deltaTime;
            }

            if (input.GetKey(Keys.S))
            {
                camera.transform.position.Y += speed * Time.deltaTime;
            }
        }

    }
}
