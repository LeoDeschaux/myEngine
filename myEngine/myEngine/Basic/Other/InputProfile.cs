using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class InputProfile
    {
        //FIELDS
        public IDictionary<myButtons, Buttons> gamePad;
        public IDictionary<myButtons, Keys> keyBoard;

        //CONSTRUCTOR
        public InputProfile(PlayerIndex playerIndex)
        {
            gamePad = new Dictionary<myButtons, Buttons>();
            keyBoard = new Dictionary<myButtons, Keys>();

            InitDefaultProfile(playerIndex);
        }

        //METHODS
        public void InitDefaultProfile(PlayerIndex playerIndex)
        {
            if(playerIndex == PlayerIndex.One)
                InitKeyBoard();
            
            InitGamePad();
        }

        public void InitKeyBoard()
        {
            keyBoard = new Dictionary<myButtons, Keys>();

            //SET KEYBOARD
            keyBoard = new Dictionary<myButtons, Keys>();
            keyBoard.Add(myButtons.ButtonA, Keys.Space);

            keyBoard.Add(myButtons.DPadUp, Keys.Up);
            keyBoard.Add(myButtons.DPadRight, Keys.Right);
            keyBoard.Add(myButtons.DPadDown, Keys.Down);
            keyBoard.Add(myButtons.DPadLeft, Keys.Left);

            keyBoard.Add(myButtons.LeftAxisUp, Keys.Up);
            keyBoard.Add(myButtons.LeftAxisRight, Keys.Right);
            keyBoard.Add(myButtons.LeftAxisDown, Keys.Down);
            keyBoard.Add(myButtons.LeftAxisLeft, Keys.Left);
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