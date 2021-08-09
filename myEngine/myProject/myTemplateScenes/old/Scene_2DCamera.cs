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
            Sprite s = new Sprite(Settings.GetScreenCenter(), (Vector2.One*150));
            s.dimension = new Vector2(300, 150);

            Text t = new Text();
            t.transform.position = Settings.GetScreenCenter();
            t.s = "Ceci est le centre";
            t.alignment = Alignment.Center;
            t.color = Color.Red;

            Sprite center = new Sprite(Settings.GetScreenCenter(), (Vector2.One * 10));
            center.color = Color.Red;
            center.transform = camera.transform;
        }

        Vector2 deltaMouse;
        float speedMouse = 1;

        //METHODS
        public override void Update()
        {
            //MOUSE CAM CONTROLE
            if (Input.GetMouseDown(MouseButton.Middle))
            {
                deltaMouse = Mouse.position.ToVector2();
            }

            if (Input.GetMouse(MouseButton.Middle))
            {
                camera.transform.position += ((deltaMouse - Mouse.position.ToVector2()) * speedMouse);
                deltaMouse = Mouse.position.ToVector2();
            }

            //KEYBOARD CAM CONTROLE
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

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawSimpleShape.DrawRuller(Settings.GetScreenCenter(), matrix);
        }
    }
}
