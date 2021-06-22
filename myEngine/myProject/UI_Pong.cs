using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class UI_Pong : UI
    {
        //FIELDS
        Text scorePlayer;
        Text scoreAI;

        Sprite[] livesPlayer;
        Sprite[] livesAI;

        //CONCSTRUCTOR
        public UI_Pong()
        {
            Color c = new Color(30, 30, 30);

            //SET PLAYER SCORE
            scorePlayer = new Text();
            scorePlayer.color = c;
            scorePlayer.s = Scene_Pong.game.player_Human.score.ToString();
            scorePlayer.fontSize = 300;
            scorePlayer.transform.position = new Vector2(200, Settings.SCREEN_HEIGHT / 2 - 200);

            //SET AI SCORE
            scoreAI = new Text();
            scoreAI.color = c;
            scoreAI.s = Scene_Pong.game.player_Human.score.ToString();
            scoreAI.fontSize = 300;
            scoreAI.transform.position = new Vector2(800, Settings.SCREEN_HEIGHT / 2 - 200);

            //SET PLAYER LIVES
            livesPlayer = new Sprite[3];
            for (int i = 0; i < 3; i++)
            {
                livesPlayer[i] = new Sprite(new Vector2((int)((150) + 30*1.2*i), 650), new Vector2(30, 30));
                livesPlayer[i].color = Color.White;
                livesPlayer[i].orderInLayer = 900;

                Sprite s = new Sprite(livesPlayer[i].transform.position, livesPlayer[i].dimension*0.8f);
                s.orderInLayer = 1000;
                s.color = Color.Red;
            }

            livesPlayer[0].AddComponent(new Collider2D(livesPlayer[0]));
            livesPlayer[0].GetComponent<Collider2D>().scale *= 2;

            //SET AI LIVES
            livesAI = new Sprite[3];

        }

        public override void Update()
        {
            scorePlayer.s = Scene_Pong.game.player_Human.score.ToString();
            scoreAI.s = Scene_Pong.game.player_AI.score.ToString();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
