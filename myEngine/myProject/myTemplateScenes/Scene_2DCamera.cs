using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_2DCamera : IScene
    {
        //FIELDS
        float speed = 500;

        //CONSTRUCTOR
        public Scene_2DCamera()
        {
            Sprite s = new Sprite(Settings.Get_Screen_Center(), (Vector2.One*150));
            
            Sprite center = new Sprite(Settings.Get_Screen_Center(), (Vector2.One * 50));
            center.color = Color.Red;
            center.transform = camera.transform;
        }

        //METHODS
        public override void Update()
        {
            //
            if (Input.GetKey(Keys.Q))
            {
                camera.transform.position.X -= speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.D))
            {
                camera.transform.position.X += speed * Time.deltaTime;
            }

            //
            if (Input.GetKey(Keys.Z))
            {
                camera.transform.position.Y -= speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.S))
            {
                camera.transform.position.Y += speed * Time.deltaTime;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
            DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center());
        }

    }
}
