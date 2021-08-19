using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Scene_QuickTest : IScene
    {
        //FIELDS
        Sprite parent;
        Sprite child;

        float speed = 500;

        //CONSTRUCTOR
        public Scene_QuickTest()
        {
            Settings.BACKGROUND_COLOR = Color.LightYellow;

            Text t = new Text("SCENE_QUICKTEST");

            parent = new Sprite();
            parent.color = Color.Red;
            parent.transform.position = new Vector2(0, 0);
            parent.dimension = new Vector2(100, 100);
            parent.transform.rotation = 45;

            child = new Sprite();
            child.color = Color.Black;
            child.transform.position = new Vector2(150, 100);
            child.dimension = new Vector2(30, 30);
            child.transform.rotation = 45;

            child.SetParent(parent);

            camControl.isActive = true;

            //child.transform.position += new Vector2(123, 0);

            //child.transform = new Transform();
        }

        //METHODS
        public override void Update()
        {
            UpdateInputs();
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawSimpleShape.DrawLine(parent.transform.position, child.transform.position, Color.Green, thickness: 10, matrix: matrix);
        }

        private void UpdateInputs()
        {
            if(Input.GetKey(Keys.Left))
            {
                child.transform.position.X -= speed * Time.deltaTime;
                //Console.WriteLine(child.transform.position.X);
                //Console.WriteLine("TEST");
            }
            if (Input.GetKey(Keys.Right))
                child.transform.position.X += speed * Time.deltaTime;
            if (Input.GetKey(Keys.Up))
                child.transform.position.Y += speed * Time.deltaTime;
            if (Input.GetKey(Keys.Down))
                child.transform.position.Y -= speed * Time.deltaTime;

            if (Input.GetKey(Keys.Q))
            {
                parent.transform.position.X -= speed * Time.deltaTime;

                //parent.transform.position += new Vector2(-speed * Time.deltaTime, 0);
            }

            if (Input.GetKey(Keys.D))
            {
                parent.transform.position.X += speed * Time.deltaTime;
            }

            //
            if (Input.GetKey(Keys.Z))
            {
                parent.transform.position.Y += speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.S))
            {
                parent.transform.position.Y -= speed * Time.deltaTime;
            }

            //ZOOM
            if (Input.GetKey(Keys.C))
            {
                parent.transform.scale.X += speed * 0.01f * Time.deltaTime;
                parent.transform.scale.Y += speed * 0.01f * Time.deltaTime;
            }

            //DEZOOM
            if (Input.GetKey(Keys.W))
            {
                parent.transform.scale.X -= speed * 0.01f * Time.deltaTime;
                parent.transform.scale.Y -= speed * 0.01f * Time.deltaTime;
            }

            //ROTATION
            if (Input.GetKey(Keys.A))
            {
                parent.transform.rotation -= speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.E))
            {
                parent.transform.rotation += speed * Time.deltaTime;
            }
        }
    }
}
