using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Player_Human : Player
    {
        //FIELDS

        private Input input;

        //CONSTRUCTOR
        public Player_Human(Vector2 startPos, PlayerIndex playerIndex)
        {
            input = new Input(playerIndex);
            this.playerIndex = playerIndex;

            raquette.transform.position = startPos;
            anchorPoint.position = new Vector2(raquette.transform.position.X + 20, raquette.transform.position.Y);
            
            name = "PLAYER";
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            anchorPoint.position = new Vector2(raquette.transform.position.X + 80, raquette.transform.position.Y);


            if (input.GetButton(myButtons.LeftAxisDown) && raquette.transform.position.Y < (Settings.SCREEN_HEIGHT - raquette.sprite.GetRectangle().Height / 2))
            {
                raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y + (speed * Time.deltaTime));
            }
            if (input.GetButton(myButtons.LeftAxisUp) && raquette.transform.position.Y > (0 + raquette.sprite.GetRectangle().Height / 2))
            {
                raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y - (speed * Time.deltaTime));
            }

            if(input.GetButtonDown(myButtons.ButtonA) && Scene_Pong.game.ball.ballState != Ball.BallState.moving && isHoldingTheBall)
            {
                Scene_Pong.game.ball.FireBall(0);
                Scene_Pong.game.targetSpawner.Start();
            }
        }
    }
}