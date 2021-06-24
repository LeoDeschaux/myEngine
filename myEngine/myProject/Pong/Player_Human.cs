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

        //CONSTRUCTOR
        public Player_Human()
        {
            raquette.transform.position = new Vector2(160, Settings.SCREEN_HEIGHT/2);
            anchorPoint.position = new Vector2(raquette.transform.position.X + 20, raquette.transform.position.Y);
            
            name = "PLAYER";
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            anchorPoint.position = new Vector2(raquette.transform.position.X + 80, raquette.transform.position.Y);

            if (Scene_Pong.input.GetKey(Keys.Up) && raquette.transform.position.Y > 0 + raquette.sprite.GetRectangle().Height/2)
            {
                raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y - (speed * Time.deltaTime));
            }
            if(Scene_Pong.input.GetKey(Keys.Down) && raquette.transform.position.Y < (Settings.SCREEN_HEIGHT - raquette.sprite.GetRectangle().Height/2))
            {
                raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y + (speed * Time.deltaTime));
            }

            if (Scene_Pong.input.GetKeyDown(Keys.Space) && Scene_Pong.game.ball.ballState != Ball.BallState.moving)
            {
                Scene_Pong.game.ball.FireBall(0);
                Console.WriteLine("FIRE");
                Scene_Pong.game.targetSpawner.Start();
            }
        }
    }
}