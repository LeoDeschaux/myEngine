﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Input : Entity
    {
        //STATIC KEYBOARD 
        private static KeyboardState keyState;
        private static KeyboardState prevKeyState;

        //PLAYER GAME PAD
        private GamePadState gamePadState;
        private GamePadState prevGamePadState;

        //INPUT PROFILE
        private InputProfile inputProfile;

        private static bool recordInput = true;

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
            if(inputProfile.gamePadIndex != -1)
            {
                prevGamePadState = gamePadState;
                gamePadState = GamePad.GetState(inputProfile.gamePadIndex);
            }
        }

        public static void StaticUpdate()
        {
            if (recordInput == false)
                return;

            prevKeyState = keyState;
            keyState = Keyboard.GetState();

            Mouse.Update();
        }

        public override void LateUpdate()
        {
            Mouse.LateUpdate();
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
        public static bool GetKey(Keys key)
        {
            return (keyState.IsKeyDown(key));
        }

        public static bool GetKeyDown(Keys key)
        {
            return (keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key));
        }

        //MOUSE
        public static bool GetMouse(MouseButton mouseButton)
        {
            return Mouse.GetMouse(mouseButton);
        }
        public static bool GetMouseDown(MouseButton mouseButton)
        {
            return Mouse.GetMouseDown(mouseButton);
        }
        public static bool GetMouseUp(MouseButton mouseButton)
        {
            return Mouse.GetMouseUp(mouseButton);
        }
    }
}