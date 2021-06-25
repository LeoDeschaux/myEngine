using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public enum GameMode
    {
        PvP,
        PvAI
    }

    public class Game_Pong : Entity
    {
        //FIELDS
        public Player player1;
        public Player player2;
        public Ball ball;

        public TargetSpawner targetSpawner;


        //CONSTRUCTOR
        public Game_Pong(GameMode gameMode)
        {
            if(gameMode == GameMode.PvP)
            {
                player1 = new Player_Human(new Vector2(160, Settings.SCREEN_HEIGHT / 2), PlayerIndex.One);
                player2 = new Player_Human(new Vector2(1080, Settings.SCREEN_HEIGHT / 2), PlayerIndex.Two);
            }
            else
            {
                player1 = new Player_Human(new Vector2(160, Settings.SCREEN_HEIGHT / 2), PlayerIndex.One);
                player2 = new Player_AI(PlayerIndex.Two);
            }

            ball = new Ball(player1.anchorPoint);
            player1.isHoldingTheBall = true;

            targetSpawner = new TargetSpawner();
        }

        public void OnGameOver(PlayerIndex looser)
        {
            Player player = Scene_Pong.game.player1;
            if (looser == player.playerIndex)
                player = Scene_Pong.game.player2;

            player.score++;

            SaveScore();
            ReloadScene();
        }

        private void SaveScore()
        {
            player1.SaveScore();
            player2.SaveScore();
        }

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        static Delay delay;
        public static void ReloadScene()
        {
            delay = new Delay(2000, () =>
            {
                Game1.sceneManager.ReloadScene();
            });
        }
    }
}