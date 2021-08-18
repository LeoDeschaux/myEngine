using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class CameraMouseController : Entity
    {
        //FIELDS
        float speed = 500;
        Vector2 deltaMouse;
        float speedMouse = 1;

        public bool isActive;

        //REF
        Camera2D camera;

        //CONSTRUCTOR
        public CameraMouseController(Camera2D camera)
        {
            this.camera = camera;
            isActive = false;
        }

        //METHODS
        public override void Update()
        {
            if (!isActive)
                return;

            //MOUSE CAM CONTROLE
            if (Input.GetMouseDown(MouseButtons.Middle))
            {
                deltaMouse = Mouse.position.ToVector2();
            }

            if (Input.GetMouse(MouseButtons.Middle))
            {
                camera.transform.position += ((deltaMouse - Mouse.position.ToVector2()) * speedMouse);
                deltaMouse = Mouse.position.ToVector2();
            }

            //KEYBOARD CAM CONTROLE
            if (Input.GetKey(Keys.K))
            {
                camera.transform.position.X -= speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.M))
            {
                camera.transform.position.X += speed * Time.deltaTime;
            }

            //
            if (Input.GetKey(Keys.O))
            {
                camera.transform.position.Y -= speed * Time.deltaTime;
            }

            if (Input.GetKey(Keys.L))
            {
                camera.transform.position.Y += speed * Time.deltaTime;
            }

            //ZOOM
            if(Input.GetKey(Keys.B))
            {
                camera.transform.scale.X += 0.001f;
                camera.transform.scale.Y += 0.001f;
            }

            //DEZOOM
            if (Input.GetKey(Keys.N))
            {
                camera.transform.scale.X -= 0.001f;
                camera.transform.scale.Y -= 0.001f;
            }

            if (Input.GetKey(Keys.I))
            {
                camera.transform.rotation += 0.1f;
            }

            if (Input.GetKey(Keys.P))
            {
                camera.transform.rotation -= 0.1f;
            }
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawSimpleShape.DrawRullerFree(new Vector2(0,0), matrix);
        }
    }
}
