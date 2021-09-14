﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows;

namespace myEngine
{
    public class Camera3D : GameObject
    {
        public Matrix worldMatrix
        {
            get;
            set;
        }
        public Matrix projectionMatrix
        {
            get;
            protected set;
        }
        public Matrix viewMatrix
        {
            get
            {
                return Matrix.CreateLookAt(cameraPosition, cameraLookAt, Vector3.Up);
            }
        }

        private Vector3 cameraPosition;
        private Vector3 cameraRotation;
        private float cameraSpeed;
        private Vector3 cameraLookAt;

        private Vector3 mouseRotationBuffer;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        private Game game;

        public Vector3 Position
        {
            get { return cameraPosition; }
            set
            {
                cameraPosition = value;
                UpdateLookAt();
            }
        }

        public Vector3 Rotation
        {
            get { return cameraRotation; }
            set
            {
                cameraRotation = value;
                UpdateLookAt();
            }
        }

        public Camera3D(Game game, Vector3 position, Vector3 rotation, float speed)
        {
            this.game = game;

            this.cameraSpeed = speed;

            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                game.GraphicsDevice.Viewport.AspectRatio,
                1f,
                1000f);

            //this.Rotation = rotation;

            MoveTo(position, rotation);

            previousMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        private void MoveTo(Vector3 pos, Vector3 rot)
        {
            Position = pos;
            Rotation = rot;
        }

        private void UpdateLookAt()
        {
            Matrix rotationMatrix = Matrix.CreateRotationX(cameraRotation.X) *
                                    Matrix.CreateRotationY(cameraRotation.Y);

            Vector3 lookAtOffSet = Vector3.Transform(Vector3.UnitZ, rotationMatrix);

            cameraLookAt = cameraPosition + lookAtOffSet;
        }

        private Vector3 PreviewMove(Vector3 amount)
        {
            Matrix rotate = Matrix.CreateRotationY(cameraRotation.Y);
            Vector3 movement = new Vector3(amount.X, amount.Y, amount.Z);
            movement = Vector3.Transform(movement, rotate);

            return cameraPosition + movement;
        }

        private void Move(Vector3 scale)
        {
            MoveTo(PreviewMove(scale), Rotation);
        }

        public override void Update()
        {
            currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            Vector3 moveVector = Vector3.Zero;

            if (Input.GetKey(Keys.Z))
                moveVector.Z = 1;
            if (Input.GetKey(Keys.S))
                moveVector.Z = -1;
            if (Input.GetKey(Keys.Q))
                moveVector.X = 1;
            if (Input.GetKey(Keys.D))
                moveVector.X = -1;

            if (Input.GetKey(Keys.E))
                moveVector.Y = 1;
            if (Input.GetKey(Keys.A))
                moveVector.Y = -1;

            if (moveVector != Vector3.Zero)
            {
                moveVector.Normalize();
                moveVector *= Time.deltaTime * cameraSpeed;

                Move(moveVector);
            }

            float deltaX;
            float deltaY;

            if(currentMouseState != previousMouseState)
            {
                deltaX = currentMouseState.X - (game.GraphicsDevice.Viewport.Width / 2);
                deltaY = currentMouseState.Y - (game.GraphicsDevice.Viewport.Height / 2);

                mouseRotationBuffer.X -= 2f * deltaX * Time.deltaTime;
                mouseRotationBuffer.Y -= 2f * deltaY * Time.deltaTime;

                if (mouseRotationBuffer.Y < MathHelper.ToRadians(-75f))
                    mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(-75f));
                if (mouseRotationBuffer.Y > MathHelper.ToRadians(75f))
                    mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(75f));

                Rotation = new Vector3(-MathHelper.Clamp(mouseRotationBuffer.Y, MathHelper.ToRadians(-75f), MathHelper.ToRadians(75f)),
                    MathHelper.WrapAngle(mouseRotationBuffer.X), 0);

                deltaX = 0;
                deltaY = 0;
            }

            Microsoft.Xna.Framework.Input.Mouse.SetPosition(game.GraphicsDevice.Viewport.Width/2, game.GraphicsDevice.Viewport.Height / 2);

            previousMouseState = currentMouseState;
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
