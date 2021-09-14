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

        //CONSTRUCTOR
        public Camera2D()
        {
            transform.position = Settings.GetScreenCenter();
            transform.scale = new Vector2(1, 1);

            offSet = Matrix.CreateTranslation(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT, 0);

            this.Update();
        }

        //METHODS
        public override void Update()
        {
            transform.scale.X = MathHelper.Clamp(transform.scale.X, 0.1f, 10);
            transform.scale.Y = MathHelper.Clamp(transform.scale.X, 0.1f, 10);

            Matrix scale = Matrix.CreateScale(transform.scale.X, transform.scale.Y, 1);
            Matrix rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(transform.rotation));
            Matrix position = Matrix.CreateTranslation(-(int)transform.position.X, -(int)transform.position.Y, 0);

            transformMatrix = scale * rotation * position * offSet;
        }
    }
}
