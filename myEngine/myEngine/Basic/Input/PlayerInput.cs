using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace myEngine
{
    public sealed class PlayerInput : Entity
    {
        //FIELDS
        InputProfile profile;

        //PLAYER GAME PAD
        private GamePadState gamePadState;
        private GamePadState prevGamePadState;

        //CONSTRUCTOR
        public PlayerInput(InputProfile profile)
        {
            this.profile = profile;
        }

        /*
        public Input(PlayerIndex playerIndex = 0) //INPUT PROFILE
        {
            inputProfile = new InputProfile(playerIndex);
            mouse = new Mouse();
        }
        */

        //METHODS
        public override void Update()
        {
            if (profile.gamePadIndex != -1)
            {
                prevGamePadState = gamePadState;
                gamePadState = GamePad.GetState(profile.gamePadIndex);
            }
        }

        //BUTTONS / Action / Input
        public bool GetButton(myButtons button)
        {
            bool b = false;

            Buttons inputGamePadButton = new Buttons();
            Keys inputKey = new Keys();

            foreach (var kvp in profile.gamePad)
                if (kvp.Key == button)
                    inputGamePadButton = (Buttons)kvp.Value;

            foreach (var kvp in profile.keyboard)
                if (kvp.Key == button)
                    inputKey = (Keys)kvp.Value;

            if ((Input.GetKey(inputKey) && inputKey != 0) || (GetGamePad(inputGamePadButton) && inputGamePadButton != 0))
                b = true;

            return b;
        }

        public bool GetButtonDown(myButtons button)
        {
            bool b = false;

            Buttons inputGamePadButton = new Buttons();
            Keys inputKey = new Keys();

            foreach (var kvp in profile.gamePad)
                if (kvp.Key == button)
                    inputGamePadButton = (Buttons)kvp.Value;

            foreach (var kvp in profile.keyboard)
                if (kvp.Key == button)
                    inputKey = (Keys)kvp.Value;

            if ((Input.GetKeyDown(inputKey) && inputKey != 0) || (GetGamePadDown(inputGamePadButton) && inputGamePadButton != 0))
                b = true;

            return b;
        }


        private bool GetGamePad(Buttons button)
        {
            return gamePadState.IsButtonDown(button);
        }

        private bool GetGamePadDown(Buttons button)
        {
            return (gamePadState.IsButtonDown(button) && prevGamePadState.IsButtonUp(button));
        }
    }
}
