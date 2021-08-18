using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public sealed class Camera 
    {
        private const float minZ = 1f;
        private const float maxZ = 2048;

        private Vector2 position;
        private float baseZ;
        public float z;

        private float aspectRatio;
        private float fieldOfView;

        private Matrix view;
        private Matrix proj;

        public Matrix View { get { return view; } }
        public Matrix Projection { get { return proj; } }

        public Camera()
        {
            position = Vector2.Zero;
            view = Matrix.Identity;
            proj = Matrix.Identity;

            aspectRatio = (float)Settings.SCREEN_WIDTH / Settings.SCREEN_HEIGHT;
            fieldOfView = MathHelper.PiOver2;

            baseZ = GetZFromHeight(Settings.SCREEN_HEIGHT);
            z = baseZ;

            UpdateMatrices();
        }

        public void UpdateMatrices()
        {
            //view = Matrix.CreateLookAt(new Vector3(0, 0, (float)z), Vector3.Zero, Vector3.Up);
            //proj = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, Camera.minZ, Camera.maxZ);

            view = Matrix.Identity;
            proj = Matrix.Identity;

            proj[0] = 0.001f * (z*0.01f);

            proj[5] = -0.002f * (z * 0.01f);

            proj[11] = 0; 
            proj[12] = -1; 
            proj[13] = 1; 
            proj[14] = -0;
            proj[15] = 1;

            proj *= Matrix.CreateTranslation(new Vector3(1, -1, 0));
        }

        private float GetZFromHeight(float height)
        {
            return (0.5f * height) / MathF.Tan(0.5f * fieldOfView);
        }

        public void MoveZ(float amount)
        {
            z += amount;
            z = MathHelper.Clamp(z, Camera.minZ, Camera.maxZ);

            UpdateMatrices();
        }
    }
}
