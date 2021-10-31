using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public enum InputMode
    {
        defaultKeyboard,
        defaultGamePad
    }

    //POSSIBLE EXTENSION : 
    /*
        public IDictionary<myButtons, List<Keys>> keyboard;
        keyboard.Add(myButtons.ButtonB, new List<Keys> { Keys.Space, Keys.LeftControl });

        foreach (var kvp in inputProfile.gamePad)
            {
                if (kvp.Key == button)
                {
                    foreach (var v in kvp.Value)
                    {
                        inputGamePadButton = (Buttons) v;
                        if (GetGamePad(inputGamePadButton) && inputGamePadButton != 0)
                            b = true;
                    }
                }
            }
        */


    public class InputProfile
    {
        private List<Button> l;

        //FIELDS
        public IDictionary<myButtons, Buttons> gamePad;
        public IDictionary<myButtons, Keys> keyboard;

        public PlayerIndex playerIndex;
        public int gamePadIndex = -1;

        private InputMode inputMode;

        //CONSTRUCTOR
        /*
        public InputProfile(PlayerIndex playerIndex)
        {
            gamePad = new Dictionary<myButtons, Buttons>();
            keyBoard = new Dictionary<myButtons, Keys>();

            this.playerIndex = playerIndex;

            InitDefaultProfile();
        }
        */

        public InputProfile()
        {
            gamePad = new Dictionary<myButtons, Buttons>();
            keyboard = new Dictionary<myButtons, Keys>();

            this.playerIndex = PlayerIndex.One;
        }

        public InputProfile(PlayerIndex playerIndex, InputMode inputMode)
        {
            gamePad = new Dictionary<myButtons, Buttons>();
            keyboard = new Dictionary<myButtons, Keys>();

            this.playerIndex = playerIndex;
            this.inputMode = inputMode;

            InitDefaultProfile();
        }

        public InputProfile(PlayerIndex playerIndex, InputMode inputMode, int gamePadNumber)
        {
            gamePad = new Dictionary<myButtons, Buttons>();
            keyboard = new Dictionary<myButtons, Keys>();

            this.playerIndex = playerIndex;
            this.inputMode = inputMode;
            this.gamePadIndex = (gamePadNumber-1);

            InitDefaultProfile();
        }

        //METHODS
        public void InitDefaultProfile()
        {
            if (inputMode == InputMode.defaultKeyboard)
                InitKeyboard();
            if (inputMode == InputMode.defaultGamePad)
                InitGamePad();
        }

        public void InitKeyboard()
        {
            keyboard = new Dictionary<myButtons, Keys>();

            //SET KEYBOARD
            keyboard.Add(myButtons.ButtonA, Keys.Space);
            keyboard.Add(myButtons.ButtonB, Keys.LeftControl);

            keyboard.Add(myButtons.LeftAxisUp, Keys.Up);
            keyboard.Add(myButtons.LeftAxisRight, Keys.Right);
            keyboard.Add(myButtons.LeftAxisDown, Keys.Down);
            keyboard.Add(myButtons.LeftAxisLeft, Keys.Left);
        }

        public void InitGamePad()
        {
            gamePad = new Dictionary<myButtons, Buttons>();

            //SET GAMEPAD
            gamePad.Add(myButtons.ButtonA, Buttons.A);
            gamePad.Add(myButtons.ButtonB, Buttons.B);

            gamePad.Add(myButtons.DPadUp, Buttons.DPadUp);
            gamePad.Add(myButtons.DPadRight, Buttons.DPadRight);
            gamePad.Add(myButtons.DPadDown, Buttons.DPadDown);
            gamePad.Add(myButtons.DPadLeft, Buttons.DPadLeft);

            gamePad.Add(myButtons.LeftAxisUp, Buttons.LeftThumbstickUp);
            gamePad.Add(myButtons.LeftAxisRight, Buttons.LeftThumbstickRight);
            gamePad.Add(myButtons.LeftAxisDown, Buttons.LeftThumbstickDown);
            gamePad.Add(myButtons.LeftAxisLeft, Buttons.LeftThumbstickLeft);
        }
    }
}