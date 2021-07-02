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

        //CONSTRUCTOR

        //METHODS
        public override void Update()
        {
            var position = Matrix.CreateTranslation(-(int)transform.position.X, -(int)transform.position.Y, 0);

            var offSet = Matrix.CreateTranslation(Settings.SCREEN_WIDTH/2, Settings.SCREEN_HEIGHT/2, 0);

            transformMatrix = position * offSet;
        }
    }
}
