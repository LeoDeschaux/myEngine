using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public enum MouseButton
    {
        Left,
        Middle,
        Right
    }

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
            //position = new Point(mouseState.X, mouseState.Y);

            float ratioX = (float)Engine.game.Window.ClientBounds.Width / (float)Settings.SCREEN_WIDTH;
            float ratioY = (float)Engine.game.Window.ClientBounds.Height / (float)Settings.SCREEN_HEIGHT;

            position = new Point((int)(mouseState.X / ratioX), (int)(mouseState.Y / ratioY));

        }

        public static void LateUpdate()
        {
            asBeenReleased = true;
        }

        //METHODS
        public static bool GetMouse(MouseButton mouseButton)
        {
            if (mouseButton == MouseButton.Left)
                return (mouseState.LeftButton == ButtonState.Pressed);

            if (mouseButton == MouseButton.Right)
                return (mouseState.RightButton == ButtonState.Pressed);

            if (mouseButton == MouseButton.Middle)
                return (mouseState.MiddleButton == ButtonState.Pressed);
            
            return false;
        }

        public static bool GetMouseDown(MouseButton mouseButton)
        {
            if (!asBeenReleased)
                return false;

            if (mouseButton == MouseButton.Left)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    asBeenReleased = false;
                    return true;
                }
            }

            if (mouseButton == MouseButton.Right)
            {
                if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
                {
                    asBeenReleased = false;
                    return true;
                }
            }

            if (mouseButton == MouseButton.Middle)
            {
                if (mouseState.MiddleButton == ButtonState.Pressed && prevMouseState.MiddleButton == ButtonState.Released)
                {
                    asBeenReleased = false;
                    return true;
                }
            }

            return false;
        }

        public static bool GetMouseUp(MouseButton mouseButton)
        {
            if (mouseButton == MouseButton.Left)
            {
                if(mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                {
                    asBeenReleased = true;
                    return true;
                }
            }

            if (mouseButton == MouseButton.Right)
            {
                if (mouseState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed)
                {
                    asBeenReleased = true;
                    return true;
                }
            }

            if (mouseButton == MouseButton.Middle)
            {
                if (mouseState.MiddleButton == ButtonState.Released && prevMouseState.MiddleButton == ButtonState.Pressed)
                {
                    asBeenReleased = true;
                    return true;
                }
            }

            return false;
        }
    }
}
