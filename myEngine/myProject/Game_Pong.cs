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
        private Player player_AI;
        private Player player_Human;

        public Ball ball;

        public int scoreTable = 0;

        float i = 0;

        //CONSTRUCTOR
        public Game_Pong()
        {
            player_AI = new Player_AI();
            player_Human = new Player_Human();

            ball = new Ball(player_Human.anchorPoint);

            //
            player_AI.AddComponent(new Collider2D(player_AI.raquette.sprite));
            player_Human.AddComponent(new Collider2D(player_Human.raquette.sprite));

            //UI
            Text text = new Text();
            text.color = Color.White;
            text.s = scoreTable.ToString();
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (Scene_Pong.input.GetKey(Keys.Delete))
                ball.Destroy();

            i += Time.deltaTime;
            //if (i < 60)
                //Console.WriteLine("i: " + i + ", time: " + Time.gameTime.TotalGameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}