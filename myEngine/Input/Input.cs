using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public static class Input
    {
        private static MouseState mouseState;
        private static MouseState prevMouseState;

        private static KeyboardState keyState;
        private static KeyboardState prevKeyState;

        private static GamePadState gamePadState;
        private static GamePadState prevGamePadState;

        public static void Update()
        {
            prevMouseState = mouseState;
            mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            prevKeyState = keyState;
            keyState = Keyboard.GetState();

            prevGamePadState = gamePadState;
            gamePadState = GamePad.GetState(PlayerIndex.One);
        }

        //GAMEPAD
        public static bool GetGamePad(Buttons button)
        {
            return (gamePadState.IsButtonDown(button));
        }
        public static bool GetGamePadDown(Buttons button)
        {
            return (gamePadState.IsButtonDown(button) && prevGamePadState.IsButtonUp(button));
        }
        public static bool GetGamePadUp(Buttons button)
        {
            return (gamePadState.IsButtonUp(button) && prevGamePadState.IsButtonDown(button));
        }

        //KEYBOARD
        public static bool GetKey(Keys key)
        {
            return (keyState.IsKeyDown(key));
        }
        public static bool GetKeyDown(Keys key)
        {
            return (keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key));
        }
        public static bool GetKeyUp(Keys key)
        {
            return (keyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key));
        }

        //MOUSE
        public static bool GetMouse(MouseButtons mouseButton)
        {
            if (mouseButton == MouseButtons.Left)
                return (mouseState.LeftButton == ButtonState.Pressed);

            if (mouseButton == MouseButtons.Right)
                return (mouseState.RightButton == ButtonState.Pressed);

            if (mouseButton == MouseButtons.Middle)
                return (mouseState.MiddleButton == ButtonState.Pressed);

            return false;
        }

        public static bool GetMouseDown(MouseButtons mouseButton)
        {
            if (mouseButton == MouseButtons.Left)
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                    return true;

            if (mouseButton == MouseButtons.Right)
                if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
                    return true;

            if (mouseButton == MouseButtons.Middle)
                if (mouseState.MiddleButton == ButtonState.Pressed && prevMouseState.MiddleButton == ButtonState.Released)
                    return true;

            return false;
        }

        public static bool GetMouseUp(MouseButtons mouseButton)
        {
            if (mouseButton == MouseButtons.Left)
                if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                    return true;

            if (mouseButton == MouseButtons.Right)
                if (mouseState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed)
                    return true;

            if (mouseButton == MouseButtons.Middle)
                if (mouseState.MiddleButton == ButtonState.Released && prevMouseState.MiddleButton == ButtonState.Pressed)
                    return true;

            return false;
        }
    }
}