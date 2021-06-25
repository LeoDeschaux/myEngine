using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Mouse : Entity
    {
        //FIELDS
        public MouseState ms;
        public MouseState prevMouseState;
        public Point position;

        public Vector2 sensitivity;

        //CONSTRUCTOR
        public Mouse()
        {

        }

        public override void Update()
        {
            prevMouseState = ms;
            ms = Microsoft.Xna.Framework.Input.Mouse.GetState();
            position = new Point(ms.X, ms.Y);
        }

        //METHODS
        public bool GetMouseDown(int i)
        {
            if (i == 0)
                return (ms.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released);

            if (i == 1)
                return (ms.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released);

            if (i == 2)
                return (ms.MiddleButton == ButtonState.Pressed && prevMouseState.MiddleButton == ButtonState.Released);

            return false;
        }

        public bool GetMouseUp(int i)
        {
            if (i == 0)
                return (ms.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed);

            if (i == 1)
                return (ms.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed);

            if (i == 2)
                return (ms.MiddleButton == ButtonState.Released && prevMouseState.MiddleButton == ButtonState.Pressed);

            return false;
        }
    }
}
