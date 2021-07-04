using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_3D : IScene
    {
        //FIELDS 
        private Camera3D camera;
        private Object3D myObject;
        private Object3D myObject2;

        private float speed = 15f;

        //CONSTRUCTOR
        public Scene_3D()
        {
            Console.WriteLine("SCENE 3D");
            camera = new Camera3D();
            myObject = new Object3D(camera);
            myObject.transform3D.position = new Vector3(-4, 0, 0);

            myObject2 = new Object3D(camera);
            myObject2.transform3D.position = new Vector3(4, 0, 0);
        }

        public override void Update()
        {
            myObject.transform3D.rotation.X++;
            myObject.transform3D.rotation.Y++;

            //
            if(Input.GetKey(Keys.Q))
            {
                camera.camPosition.X += speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.D))
            {
                camera.camPosition.X -= speed * Time.deltaTime;
            }

            //
            if (Input.GetKey(Keys.Z))
            {
                camera.camPosition.Z += speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.S))
            {
                camera.camPosition.Z -= speed * Time.deltaTime;
            }

            //
            if (Input.GetKey(Keys.A))
            {
                camera.camRotation.Y -= speed * 10 * Time.deltaTime;
            }

            if (Input.GetKey(Keys.E))
            {
                camera.camRotation.Y += speed * 10 * Time.deltaTime;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
        }
    }
}
