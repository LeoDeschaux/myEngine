using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows;

namespace myEngine
{
    public class Ca3D : GameObject
    {
        //FIELDS 
        Vector3 cameraTarget;
        Vector3 cameraDirection;
        Vector3 cameraUp;

        public Vector3 cameraPosition;
        public Vector3 cameraRotation;

        //MATRIX
        public Matrix worldMatrix;
        public Matrix projectionMatrix;
        public Matrix viewMatrix;

        //
        float speed = 50;
        float mouseSpeed = 3;
        MouseState prevMouseState;

        //CONSTRUCTOR
        public Ca3D()
        {
            Microsoft.Xna.Framework.Input.Mouse.SetPosition((int)Settings.GetScreenCenter().X, (int)Settings.GetScreenCenter().Y);
            //Microsoft.Xna.Framework.Input.Mouse.SetCursor(Microsoft.Xna.Framework.Input.MouseCursor.Crosshair);
            Engine.game.IsMouseVisible = false;

            //Setup Camera
            cameraPosition = new Vector3(0f, 2f, 10f);
            cameraRotation = new Vector3(0f, 0f, 0f);

            cameraTarget = new Vector3(0f, cameraPosition.Y, 0f);
            cameraDirection = cameraTarget - cameraPosition;
            cameraDirection.Normalize();

            cameraUp = Vector3.Up;

            //SETUP MATRIX
            worldMatrix = Matrix.CreateWorld(Vector3.Zero, Vector3.Forward, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Settings.ASPECT_RATIO, 1, 1000);
            viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraPosition + cameraDirection, cameraUp);


            //INIT
            Mouse.position = new Point((int)Settings.GetScreenCenter().X, (int)Settings.GetScreenCenter().Y);
            prevMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        Vector2 deltaMouse = Vector2.Zero;

        public override void Update()
        {
            /*
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
                cameraPosition += new Vector3(cameraDirection.X, 0f, cameraDirection.Z) * speed * Time.deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                cameraPosition -= new Vector3(cameraDirection.X, 0f, cameraDirection.Z) * speed * Time.deltaTime;
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                cameraPosition += Vector3.Cross(cameraUp, new Vector3(cameraDirection.X, 0f, cameraDirection.Z)) * speed * Time.deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                cameraPosition -= Vector3.Cross(cameraUp, new Vector3(cameraDirection.X, 0f, cameraDirection.Z)) * speed * Time.deltaTime;
            */

            //KEYBOARD MOVEMENT
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
                cameraPosition += cameraDirection * speed * Time.deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                cameraPosition -= cameraDirection * speed * Time.deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                cameraPosition += Vector3.Cross(cameraUp, cameraDirection) * speed * Time.deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                cameraPosition -= Vector3.Cross(cameraUp, cameraDirection) * speed * Time.deltaTime;

            // MOUSE CAM ROTATION
            /*
            cameraDirection = Vector3.Transform(
                cameraDirection, 
                Matrix.CreateFromAxisAngle(cameraUp, ((-MathHelper.PiOver4 / 1000) * mouseSpeed) * (Microsoft.Xna.Framework.Input.Mouse.GetState().X - prevMouseState.X)));

            cameraDirection = Vector3.Transform(
                cameraDirection, Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUp, cameraDirection), 
                ((MathHelper.PiOver4 / 1000) * mouseSpeed) * (Microsoft.Xna.Framework.Input.Mouse.GetState().Y - prevMouseState.Y)));
            
            cameraUp = Vector3.Transform(
                cameraUp, Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUp, cameraDirection), 
                ((MathHelper.PiOver4 / 1000) * mouseSpeed) * (Microsoft.Xna.Framework.Input.Mouse.GetState().Y - prevMouseState.Y)));

            */

            // Rotation in the world
            cameraDirection = Vector3.Transform(cameraDirection, Matrix.CreateFromAxisAngle(cameraUp, (-MathHelper.PiOver4 / 150) * (Microsoft.Xna.Framework.Input.Mouse.GetState().X - prevMouseState.X)));
            cameraDirection = Vector3.Transform(cameraDirection, Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUp, cameraDirection), (MathHelper.PiOver4 / 100) * (Microsoft.Xna.Framework.Input.Mouse.GetState().Y - prevMouseState.Y)));
            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(Vector3.Cross(cameraUp, cameraDirection), (MathHelper.PiOver4 / 100) * (Microsoft.Xna.Framework.Input.Mouse.GetState().Y - prevMouseState.Y)));

            Microsoft.Xna.Framework.Input.Mouse.SetPosition((int)Settings.GetScreenCenter().X, (int)Settings.GetScreenCenter().Y);
            prevMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            CreateLookAt();
        }

        private void CreateLookAt()
        {
            //viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraPosition, cameraUp);

            viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraPosition + cameraDirection, cameraUp);

            if (Input.GetKeyDown(Keys.Enter))
            {
                //Console.Clear();
                Util.DisplayMatrix(viewMatrix);
            }
        }

        //METHODS
        public void DrawModel(Model model, Vector3 position, Vector3 rotation)
        {
            worldMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(rotation.X)) *
                            Matrix.CreateRotationY(MathHelper.ToRadians(rotation.Y)) *
                            Matrix.CreateRotationZ(MathHelper.ToRadians(rotation.Z)) *
                            Matrix.CreateTranslation(position);

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldMatrix;
                    effect.View = viewMatrix;
                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }
        }

        //METHODS
        public void DrawModel(Object3D object3D)
        {
            worldMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(object3D.transform3D.rotation.X)) *
                            Matrix.CreateRotationY(MathHelper.ToRadians(object3D.transform3D.rotation.Y)) *
                            Matrix.CreateRotationZ(MathHelper.ToRadians(object3D.transform3D.rotation.Z)) *
                            Matrix.CreateTranslation(object3D.transform3D.position);

            foreach (ModelMesh mesh in object3D.model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldMatrix;
                    effect.View = viewMatrix;
                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }
        }
    }
}
