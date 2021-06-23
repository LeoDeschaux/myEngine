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
            scorePlayer.orderInLayer = -1000;

            //SET AI SCORE
            scoreAI = new Text();
            scoreAI.color = c;
            scoreAI.s = Scene_Pong.game.player_Human.score.ToString();
            scoreAI.fontSize = 300;
            scoreAI.transform.position = new Vector2(800, Settings.SCREEN_HEIGHT / 2 - 200);
            scoreAI.orderInLayer = -1000;

            //SET PLAYER LIVES
            livesPlayer = new Sprite[3];
            for (int i = 0; i < 3; i++)
            {
                livesPlayer[i] = new Sprite(new Vector2((int)((150) + 30*1.2*i), 650), new Vector2(30, 30));
                livesPlayer[i].color = Color.White;
                livesPlayer[i].orderInLayer = 450;

                Sprite s = new Sprite(livesPlayer[i].transform.position, livesPlayer[i].dimension*0.8f);
                s.orderInLayer = 500;
                s.color = Color.HotPink;
            }

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


        //PAUSE MENU
        Sprite pauseMenu_BG;
        Text pause;
        Button mainMenu;

        public void OnPauseMenuCalled()
        {
            bool b = true;

            if (pauseMenu_BG != null && pause != null)
                if (pauseMenu_BG.disposed && pause.disposed)
                    b = true;
                else
                    b = false;

            if (b)
            {
                pauseMenu_BG = new Sprite(Settings.Get_Screen_Center(), new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT));
                pauseMenu_BG.color = new Color(0, 0, 0, 200);
                pauseMenu_BG.orderInLayer = 600;

                pause = new Text();
                pause.s = "=";
                pause.fontSize = 500;
                pause.color = Color.White;
                pause.orderInLayer = 700;
                pause.transform.position = new Vector2(900, 200);
                pause.transform.rotation = MathHelper.ToRadians(90);

                //BUTTON
                mainMenu = new Button();
                mainMenu.isVisible = true;

                mainMenu.sprite.transform.position = new Vector2(650, 600);
                mainMenu.sprite.dimension = new Vector2(500, 100);
                mainMenu.sprite.orderInLayer = 700;

                mainMenu.text.s = "Quitter la partie";
                mainMenu.text.orderInLayer = 800;
                mainMenu.text.color = Color.Black;
                mainMenu.text.transform.position = new Vector2(500, 580);
                mainMenu.text.fontSize = 50;

                mainMenu.onButtonPressed += QuitGame;

                Settings.GAME_SPEED = 0;
            }
            else
            {
                pauseMenu_BG.Destroy();
                pause.Destroy();
                mainMenu.Destroy();

                Settings.GAME_SPEED = 1;
            }
        }

        private void QuitGame(object sender, EventArgs eventArgs)
        {
            Game1.sceneManager.ChangeScene(new Scene_MainMenu());
        }
    }
}
