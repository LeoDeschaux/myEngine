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

        //CONCSTRUCTOR
        public UI_Pong()
        {
            Color c = new Color(30, 30, 30);

            scorePlayer = new Text();
            scorePlayer.color = c;
            scorePlayer.s = Scene_Pong.game.player_Human.score.ToString();
            scorePlayer.fontSize = 300;
            scorePlayer.transform.position = new Vector2(200, Settings.SCREEN_HEIGHT / 2 - 200);


            scoreAI = new Text();
            scoreAI.color = c;
            scoreAI.s = Scene_Pong.game.player_Human.score.ToString();
            scoreAI.fontSize = 300;
            scoreAI.transform.position = new Vector2(800, Settings.SCREEN_HEIGHT / 2 - 200);
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
