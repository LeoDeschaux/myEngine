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
        private KeyboardState prevKeyState;

        public MouseState ms;
        private MouseState prevMouseState;
        public Point mousePos;

        public GamePadState gamePadState;
        private GamePadState prevGamePadState;

        //INPUT PROFILE
        private InputProfile inputProfile;
        private int playerIndex;

        //CONSTRUCTOR
        public Input(PlayerIndex playerIndex = 0)
        {
            this.playerIndex = (int)playerIndex;
            inputProfile = new InputProfile(playerIndex);
        }

        //METHODS
        public override void Update()
        {
            prevMouseState = ms;
            ms = Microsoft.Xna.Framework.Input.Mouse.GetState();
            mousePos = new Point(ms.X, ms.Y);

            prevKeyState = keyState;
            keyState = Keyboard.GetState();

            prevGamePadState = gamePadState;
            gamePadState = GamePad.GetState(playerIndex);
        }

        //BUTTONS / Action / Input
        public bool GetButton(myButtons button)
        {
            bool b = false;

            Buttons inputGamePadButton = new Buttons();
            Keys inputKey = new Keys();

            foreach (var kvp in inputProfile.gamePad)
                if (kvp.Key == button)
                    inputGamePadButton = (Buttons)kvp.Value;

            foreach (var kvp in inputProfile.keyBoard)
                if (kvp.Key == button)
                    inputKey = (Keys)kvp.Value;


            if (GetGamePad(inputGamePadButton) || GetKey(inputKey))
                b = true;

            return b;
        }

        public bool GetButtonDown(myButtons button)
        {
            bool b = false;

            Buttons inputGamePadButton = new Buttons();
            Keys inputKey = new Keys();

            foreach (var kvp in inputProfile.gamePad)
                if (kvp.Key == button)
                    inputGamePadButton = (Buttons)kvp.Value;

            foreach (var kvp in inputProfile.keyBoard)
                if (kvp.Key == button)
                    inputKey = (Keys)kvp.Value;

            
            if (GetGamePadDown(inputGamePadButton) || GetKeyDown(inputKey))
                b = true;

            return b;
        }

        //GAMEPAD
        public bool GetGamePad(Buttons button)
        {
            return gamePadState.IsButtonDown(button);
        }

        public bool GetGamePadDown(Buttons button)
        {
            return (gamePadState.IsButtonDown(button) && prevGamePadState.IsButtonUp(button));
        }

        //KEYBOARD
        public bool GetKey(Keys key)
        {
            return (keyState.IsKeyDown(key));
        }

        public bool GetKeyDown(Keys key)
        {
            return (keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key));
        }

        //MOUSE
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