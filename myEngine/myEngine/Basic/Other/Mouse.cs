using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class Mouse
    {
        //FIELDS
        public static MouseState mouseState;
        public static MouseState prevMouseState;
        public static Point position;

        public static Vector2 sensitivity;

        private static bool asBeenReleased = true;

        //CONSTRUCTOR
        public static void Update()
        {
            prevMouseState = mouseState;
            mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            position = new Point(mouseState.X, mouseState.Y);

            asBeenReleased = true;
        }

        //METHODS
        public static bool GetMouseDown(int i)
        {
            if (!asBeenReleased)
                return false;

            if (i == 0)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    asBeenReleased = false;
                    return true;
                }
            }

            if (i == 1)
            {
                if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released);
                {
                    asBeenReleased = false;
                    return true;
                }
            }

            if (i == 2)
            {
                if (mouseState.MiddleButton == ButtonState.Pressed && prevMouseState.MiddleButton == ButtonState.Released);
                {
                    asBeenReleased = false;
                    return true;
                }
            }

            return false;
        }

        public static bool GetMouseUp(int i)
        {
            if (i == 0)
                return (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed);

            if (i == 1)
                return (mouseState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed);

            if (i == 2)
                return (mouseState.MiddleButton == ButtonState.Released && prevMouseState.MiddleButton == ButtonState.Pressed);

            return false;
        }
    }
}
