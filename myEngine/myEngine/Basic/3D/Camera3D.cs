using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Camera3D : GameObject
    {
        //FIELDS 
        Vector3 camTarget;
        Vector3 camDirection;
        Vector3 camUp;

        public Vector3 camPosition;
        public Vector3 camRotation;

        //MATRIX
        public Matrix worldMatrix;
        public Matrix viewMatrix;
        public Matrix projectionMatrix;

        //CONSTRUCTOR
        public Camera3D()
        {
            //Setup Camera
            camPosition = new Vector3(0f, 0f, -10f);
            camRotation = new Vector3(0f, 0f, 0f);

            camTarget = new Vector3(0f, 0f, 0f);

            camDirection = camTarget - camPosition;

            camDirection.Normalize();
            camUp = Vector3.Up;

            //SETUP MATRIX
            worldMatrix = Matrix.CreateWorld(Vector3.Zero, Vector3.Forward, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Settings.ASPECT_RATIO, 1, 100);
            viewMatrix = Matrix.CreateLookAt(camPosition, camPosition + camDirection, camUp);
        }

        public override void Update()
        {
            //camDirection = camTarget - camPosition;
            //camDirection.Normalize();
            //viewMatrix = Matrix.CreateLookAt(camPosition, camPosition + camDirection, Vector3.Up);

            /*
            viewMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(camRotation.X)) *
                            Matrix.CreateRotationY(MathHelper.ToRadians(camRotation.Y)) *
                            Matrix.CreateRotationZ(MathHelper.ToRadians(camRotation.Z)) *
                            Matrix.CreateTranslation(camPosition);
            */

            //viewMatrix = Matrix.CreateLookAt(camPosition, camPosition * camRotation, Vector3.Up);

            viewMatrix = Matrix.CreateTranslation(camPosition) *
                        Matrix.CreateFromAxisAngle(Vector3.Up, MathHelper.ToRadians(camRotation.Y));
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
