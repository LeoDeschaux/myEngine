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
        private Camera camera;
        private Object3D myObject;
        private Object3D myObject2;

        private Input input;
        private float speed = 15f;

        //CONSTRUCTOR
        public Scene_3D()
        {
            Console.WriteLine("SCENE 3D");
            camera = new Camera();
            myObject = new Object3D(camera);
            myObject.transform3D.position = new Vector3(-4, 0, 0);

            myObject2 = new Object3D(camera);
            myObject2.transform3D.position = new Vector3(4, 0, 0);

            input = new Input();
        }

        public override void Update()
        {
            myObject.transform3D.rotation.X++;
            myObject.transform3D.rotation.Y++;

            //myObject.transform3D.position.X += 1 * Time.deltaTime;
            
            //
            if(input.GetKey(Keys.Q))
            {
                camera.camPosition.X += speed * Time.deltaTime;
            }

            if (input.GetKey(Keys.D))
            {
                camera.camPosition.X -= speed * Time.deltaTime;
            }

            //
            if (input.GetKey(Keys.Z))
            {
                camera.camPosition.Z += speed * Time.deltaTime;
            }

            if (input.GetKey(Keys.S))
            {
                camera.camPosition.Z -= speed * Time.deltaTime;
            }

            //
            if (input.GetKey(Keys.A))
            {
                camera.camRotation.Y -= speed * 10 * Time.deltaTime;
            }

            if (input.GetKey(Keys.E))
            {
                camera.camRotation.Y += speed * 10 * Time.deltaTime;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
        }
    }
}
