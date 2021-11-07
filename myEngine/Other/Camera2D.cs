using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Camera2D : GameObject
    {
        //FIELDS
        public Matrix transformMatrix { get; private set; }

        private Matrix offSet;

        private Vector2 centerPosition;

        //CONSTRUCTOR
        public Camera2D()
        {
            transform.scale = new Vector2(1, 1);

            offSet = Matrix.CreateTranslation(Settings.VIEWPORT_WIDTH, Settings.VIEWPORT_WIDTH, 0);

            this.LateUpdate();
        }

        //METHODS
        public override void LateUpdate()
        {
            transform.scale.X = MathHelper.Clamp(transform.scale.X, 0.3f, 10);
            transform.scale.Y = MathHelper.Clamp(transform.scale.X, 0.3f, 10);

            //Matrix.CreateTranslation(new Vector3(-mouseState.X - viewportWidth / 2, -mouseState.Y - viewportHeight / 2, 0)) * //Mouse Translation Matrix
            
            //Matrix center = Matrix.CreateTranslation(-centerPosition.X - (1280-300)/2, -centerPosition.Y - 720/2, 0);
            
            Matrix scale = Matrix.CreateScale(transform.scale.X, transform.scale.Y, 1);
            Matrix rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(transform.rotation));
            //Matrix position = Matrix.CreateTranslation(-Settings.GetScreenCenter().X - (int)transform.position.X, -Settings.GetScreenCenter().Y - (int)transform.position.Y, 0);
            //Matrix position = Matrix.CreateTranslation(new Vector3((1280-300) / 2, 720 / 2, 0));
            //Matrix position = Matrix.CreateTranslation(new Vector3(-transform.position.X - (1280 - 300) / 2, -transform.position.Y - 720 / 2, 0));
            Matrix position = Matrix.CreateTranslation(new Vector3(-transform.position.X, -transform.position.Y, 0));

            Matrix offSet = Matrix.CreateTranslation(Settings.VIEWPORT_WIDTH / 2, Settings.VIEWPORT_HEIGHT / 2, 0);

            //transformMatrix = center * scale * rotation * position * offSet;
            transformMatrix = position * rotation * scale * offSet;
        }

        public void ZoomAt(Vector2 pos, float amount)
        {
            //centerPosition = pos;
            centerPosition = Vector2.Zero;
            transform.scale += new Vector2(amount, amount);
        }

        public void ZoomOut(float amount)
        {
            transform.scale += new Vector2(amount, amount);
        }
    }
}
