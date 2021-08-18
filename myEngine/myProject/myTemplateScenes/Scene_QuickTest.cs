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

        Vector2 localPos;
        Vector2 localScale;
        float localRotation;

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
            child.transform.position = new Vector2(100, 100);
            child.dimension = new Vector2(30, 30);
            child.transform.rotation = 45;

            localPos = child.transform.position;
            localScale = child.transform.scale;
            localRotation = child.transform.rotation;

            camControl.isActive = true;
        }

        //METHODS
        public override void Update()
        {
            //PARENT
            Matrix p_scale = Matrix.CreateScale(parent.transform.scale.X, parent.transform.scale.Y, 1);
            Matrix p_rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(-parent.transform.rotation));
            Matrix p_position = Matrix.CreateTranslation((int)parent.transform.position.X, (int)parent.transform.position.Y, 0);
            Matrix p_transform = p_scale * p_rotation * p_position;

            //CHILD
            Matrix c_scale = Matrix.CreateScale(localScale.X, localScale.Y, 1);
            Matrix c_rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(-localRotation));
            Matrix c_position = Matrix.CreateTranslation((int)localPos.X, (int)localPos.Y, 0);
            Matrix c_transform = c_scale * c_rotation * c_position;

            Matrix newTransform = c_transform * p_transform;

            Util.DecomposeMatrix(ref newTransform, out child.transform.position, out child.transform.rotation, out child.transform.scale);

            UpdateInputs();
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawSimpleShape.DrawLine(parent.transform.position, child.transform.position, Color.Green, thickness: 10, matrix: matrix);
        }

        private void UpdateInputs()
        {
            if(Input.GetKey(Keys.Left))
                localPos.X -= speed * Time.deltaTime;
            if (Input.GetKey(Keys.Right))
                localPos.X += speed * Time.deltaTime;
            if (Input.GetKey(Keys.Up))
                localPos.Y += speed * Time.deltaTime;
            if (Input.GetKey(Keys.Down))
                localPos.Y -= speed * Time.deltaTime;

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
