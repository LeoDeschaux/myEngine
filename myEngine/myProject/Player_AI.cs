﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Player_AI : Player
    {
        //FIELDS
        private bool moveUp = true;
        private bool inRange = false;

        //CONSTRUCTOR
        public Player_AI()
        {
            raquette.transform.position = new Vector2(1080, Settings.SCREEN_HEIGHT / 2);
            name = "AI";
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            Vector2 ballPos = Scene_Pong.game.ball.transform.position;
            Vector2 raqPos = raquette.transform.position;

            if ((raqPos.X - ballPos.X) > Settings.SCREEN_WIDTH / 3)
                inRange = false;
            else
                inRange = true;


            if (inRange)
            {
                if(ballPos.X < raqPos.X)
                {
                    if (raqPos.Y > ballPos.Y && Math.Abs(raqPos.Y-ballPos.Y) > 10)
                    {
                        if (raqPos.Y > 0 + raquette.sprite.GetRectangle().Height / 2)
                            raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y - (speed * Time.deltaTime));
                    }
                    else if (raqPos.Y < ballPos.Y && Math.Abs(raqPos.Y - ballPos.Y) > 10)
                    {
                        if (raqPos.Y < (Settings.SCREEN_HEIGHT) - raquette.sprite.GetRectangle().Height / 2)
                            raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y + (speed * Time.deltaTime));
                    }
                }
                else
                {
                    BackAndForce();
                }
            }
            else
            {
                //RETURN MIDDLE
                if(Math.Abs(raqPos.Y - Settings.SCREEN_HEIGHT/2) > 10)
                {
                    if (raqPos.Y < (Settings.SCREEN_HEIGHT / 2))
                        raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y + (speed * Time.deltaTime));

                    if (raqPos.Y > (Settings.SCREEN_HEIGHT / 2))
                        raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y - (speed * Time.deltaTime));
                }
            }
        }

        private void BackAndForce()
        {
            if (moveUp)
                raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y + (speed * Time.deltaTime));
            else
                raquette.transform.position = new Vector2(raquette.transform.position.X, raquette.transform.position.Y - (speed * Time.deltaTime));

            if (raquette.transform.position.Y < 0 + raquette.sprite.GetRectangle().Height / 2)
                moveUp = true;

            if (raquette.transform.position.Y > (Settings.SCREEN_HEIGHT) - raquette.sprite.GetRectangle().Height / 2)
                moveUp = false;
        }
    }
}