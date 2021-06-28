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

        public GamePadState gamePadState;
        private GamePadState prevGamePadState;

        //INPUT PROFILE
        private InputProfile inputProfile;

        //CONSTRUCTOR
        /*
        public Input(PlayerIndex playerIndex = 0) //INPUT PROFILE
        {
            inputProfile = new InputProfile(playerIndex);
            mouse = new Mouse();
        }
        */

        public Input()
        {
            inputProfile = new InputProfile();
        }

        public Input(InputProfile inputProfile)
        {
            this.inputProfile = inputProfile;
        }

        //METHODS
        public override void Update()
        {
            prevKeyState = keyState;
            keyState = Keyboard.GetState();

            if(inputProfile.gamePadIndex != -1)
            {
                prevGamePadState = gamePadState;
                gamePadState = GamePad.GetState(inputProfile.gamePadIndex);
            }
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

            foreach (var kvp in inputProfile.keyboard)
                if (kvp.Key == button)
                    inputKey = (Keys)kvp.Value;

            if ((GetKey(inputKey) && inputKey != 0) || (GetGamePad(inputGamePadButton) && inputGamePadButton != 0))
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

            foreach (var kvp in inputProfile.keyboard)
                if (kvp.Key == button)
                    inputKey = (Keys)kvp.Value;

            if ((GetKeyDown(inputKey) && inputKey != 0)  || (GetGamePadDown(inputGamePadButton) && inputGamePadButton != 0))
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


        /***********************************************************************************/

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
        public bool GetMouse(int i)
        {
            return Mouse.GetMouse(i);
        }
        public bool GetMouseDown(int i)
        {
            return Mouse.GetMouseDown(i);
        }
        public bool GetMouseUp(int i)
        {
            return Mouse.GetMouseUp(i);
        }
    }
}