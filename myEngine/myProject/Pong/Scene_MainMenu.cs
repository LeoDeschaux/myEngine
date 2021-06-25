using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Scene_MainMenu : IScene
    {
        //FIELDS
        public Input input;

        //CONSTRUCTOR
        public Scene_MainMenu()
        {
            input = new Input();

            Text text = new Text();
            text.s = "PONG THE GAME";
            text.color = Color.White;
            text.fontSize = 120;
            text.transform.position = new Vector2(Settings.Get_Screen_Center().X - 450, 100);

            /*
            Text text2 = new Text();
            text2.s = "PRESS ENTER TO PLAY";
            text2.color = Color.White;
            text2.fontSize = 50;
            text2.transform.position = new Vector2(Settings.Get_Screen_Center().X - 250, Settings.Get_Screen_Center().Y + 200);
            */

            //BUTTON PVP
            Button pvp = new Button();
            pvp.sprite.transform.position = new Vector2(Settings.Get_Screen_Center().X, 400);
            pvp.sprite.dimension = new Vector2(500, 80);

            pvp.text.transform.position = new Vector2(480, 355);
            pvp.text.color = Color.Black;
            pvp.text.fontSize = 80;
            pvp.text.s = "Play PVP";
            pvp.text.orderInLayer = 9000;

            pvp.onButtonPressed += (object sender, EventArgs eventArgs) => LoadPVPScene();


            //BUTTON AI
            Button ai = new Button();
            ai.sprite.transform.position = new Vector2(Settings.Get_Screen_Center().X, 500);
            ai.sprite.dimension = new Vector2(500, 80);

            ai.text.transform.position = new Vector2(480, 455);
            ai.text.color = Color.Black;
            ai.text.fontSize = 80;
            ai.text.s = "Play vs AI";
            ai.text.orderInLayer = 9000;

            ai.onButtonPressed += (object sender, EventArgs eventArgs) => LoadAIScene();

            //QUITTER
            //BUTTON AI
            Button exit = new Button();
            exit.sprite.transform.position = new Vector2(Settings.Get_Screen_Center().X, 655);
            exit.sprite.dimension = new Vector2(350, 50);

            exit.text.transform.position = new Vector2(585, 630);
            exit.text.color = Color.Black;
            exit.text.fontSize = 50;
            exit.text.s = "Exit";
            exit.text.orderInLayer = 9000;

            exit.onButtonPressed += (object sender, EventArgs eventArgs) => ExitGame();
        }

        //METHODS
        private void LoadPVPScene()
        {
            Save_RunTime.data.Clear();
            Scene_Pong.gameMode = GameMode.PvP;
            Game1.sceneManager.ChangeScene(new Scene_Pong());
            Console.WriteLine("VOUS AVEZ CHOISI PVP");
        }

        private void LoadAIScene()
        {
            Save_RunTime.data.Clear();
            Scene_Pong.gameMode = GameMode.PvAI;
            Game1.sceneManager.ChangeScene(new Scene_Pong());
        }

        private void ExitGame()
        {
            Game1.ExitGame();
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
