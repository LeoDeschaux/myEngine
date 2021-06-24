using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Game_Pong : Entity
    {
        //FIELDS
        public Player player_AI;
        public Player player_Human;
        public Ball ball;

        public TargetSpawner targetSpawner;

        //CONSTRUCTOR
        public Game_Pong()
        {
            player_AI = new Player_AI();
            player_Human = new Player_Human();

            ball = new Ball(player_Human.anchorPoint);

            targetSpawner = new TargetSpawner();
        }

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}