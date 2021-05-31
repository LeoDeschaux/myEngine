using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Input : Entity
    {
        //FIELDS
        public KeyboardState keyState;
        public KeyboardState prevKeyState;
        public MouseState ms;
        public MouseState prevMouseState;
        public Point mousePos;

        //CONSTRUCTOR

        //METHODS
        public override void Update()
        {
            prevMouseState = ms;
            ms = Microsoft.Xna.Framework.Input.Mouse.GetState();
            mousePos = new Point(ms.X, ms.Y);

            prevKeyState = keyState;
            keyState = Keyboard.GetState();
        }

        public bool GetKey(Keys key)
        {
            return (keyState.IsKeyDown(key));
        }

        public bool GetKeyDown(Keys key)
        {
            return (keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key));
        }

        public bool GetMouseDown(int i)
        {
            if(i == 0)
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