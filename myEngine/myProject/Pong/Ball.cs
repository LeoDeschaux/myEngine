﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace myEngine
{
    public class Ball : GameObject
    {
        //FIELDS
        public static int sizeX = 30, sizeY = 30;
        public Sprite sprite;
        public Trail trail;

        private float speed = 12*60;

        public BallState ballState;
        private Vector2 direction;

        //COMPONENTS
        //private AudioSource audioSource;
        Collider2D collider;

        public enum BallState
        {
            idle,
            moving
        }

        //CONSTRCUTOR
        public Ball(Transform anchorPos)
        {
            this.transform = anchorPos;

            ballState = BallState.idle;

            sprite = new Sprite(new Vector2(transform.position.X/2, transform.position.Y), new Vector2(sizeX, sizeY));
            sprite.color = Color.Yellow;
            sprite.transform = this.transform;

            trail = new Trail(sprite.transform);
            trail.maxPoints = 3;

            AddComponent(new Collider2D(sprite));
            //collider = new Collider2D(sprite);
        }

        //METHODS
        public void FireBall(int direction = 0)
        {
            if(direction == 0 && ballState == BallState.idle)
            {
                Vector2 currentPos = transform.position;
                transform = new Transform();
                transform.position = currentPos;
                sprite.transform = this.transform;

                this.direction.X = 1;
                this.direction.Y = 0;

                ballState = BallState.moving;

                trail.transform = this.transform;
                GetComponent<Collider2D>().transformTarget = this.transform;
                OnBallChangeDirection(false);
            }

            ballState = BallState.moving;
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (ballState == BallState.moving)
            {
                if (transform.position.X > Settings.SCREEN_WIDTH - sprite.GetRectangle().Width/2)
                {
                    direction.X = -1;
                    OnBallChangeDirection(true);
                }

                if (transform.position.X < 0 + sprite.GetRectangle().Width/2)
                {
                    direction.X = 1;
                    OnBallChangeDirection(true);
                }

                if (transform.position.Y > Settings.SCREEN_HEIGHT - sprite.GetRectangle().Height/2)
                {
                    direction.Y = -1;
                    OnBallChangeDirection(true);
                }

                if (transform.position.Y < 0 + sprite.GetRectangle().Height/2)
                {
                    direction.Y = 1;
                    OnBallChangeDirection(true);
                }

                transform.position += direction * speed * Time.deltaTime;
            }

            /*
            if (direction.X == 1)
                sprite.color = Color.Blue;
            else if (direction.X == -1)
                sprite.color = Color.Red;
            */
        }
        
        public override void OnCollision(Collider2D other)
        {
            if(other.gameObject is Player)
            {
                //REBOND HORIZONTAL
                if (transform.position.X > ((Player)other.gameObject).raquette.transform.position.X)
                    direction.X = 1;
                if (transform.position.X < ((Player)other.gameObject).raquette.transform.position.X)
                    direction.X = -1;

                //VERTICAL
                float raquettePosY = ((Player)other.gameObject).raquette.transform.position.Y;
                float raquetteDimY = ((Player)other.gameObject).raquette.sprite.GetRectangle().Height;

                if (transform.position.Y < (raquettePosY - (raquetteDimY / 2)) + raquetteDimY / 3)
                    direction.Y = -1;
                else if ((transform.position.Y > (raquettePosY - (raquetteDimY / 2)) + raquetteDimY / 3) &&
                        transform.position.Y < (raquettePosY - (raquetteDimY / 2)) + (raquetteDimY / 3) * 2)
                    direction.Y = 0;
                else if (transform.position.Y > (raquettePosY - (raquetteDimY / 2)) + (raquetteDimY / 3) * 2)
                    direction.Y = 1;

                OnBallChangeDirection(false);
            }
            else
            {
                other.gameObject.Destroy();

                if (direction.X == 1)
                    Scene_Pong.game.player1.OnPlayerScorePoint();
                else if (direction.X == -1)
                    Scene_Pong.game.player2.OnPlayerScorePoint();
            }
        }

        private void OnBallChangeDirection(bool isAWall)
        {
            trail.AddPoints();

            ParticleProfile pp = new ParticleProfile();
            pp.burstMode = true;
            pp.duration = 0.1f;

            ParticleEngine p = new ParticleEngine(pp, transform.position);

            if (isAWall)
                AudioSource.PlaySoundEffect(Ressources.ball_hit_wall);
            else
                AudioSource.PlaySoundEffect(Ressources.ball_hit_raquette);
        }
    }
}
