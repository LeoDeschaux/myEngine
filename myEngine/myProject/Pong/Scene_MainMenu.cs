﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using myEngine.myProject.Pong;

namespace myEngine
{
    public class Scene_MainMenu : IScene
    {
        //FIELDS
        public Input input;

        Button pvp;

        //CONSTRUCTOR
        public Scene_MainMenu()
        {
            input = new Input();

            Text text = new Text();
            text.s = "CRYSTAL PONG";
            text.color = Color.White;
            text.fontSize = 120;
            text.transform.position = new Vector2(Settings.SCREEN_WIDTH / 2, 150);
            text.alignment = Alignment.Center;

            //BUTTON PVP
            pvp = new Button();
            pvp.sprite.transform.position = new Vector2(Settings.Get_Screen_Center().X, 400);
            pvp.sprite.dimension = new Vector2(500, 80);

            pvp.text.transform.position = new Vector2(480, 355);
            //pvp.text.transform.position = pvp.sprite.transform.position;
            //pvp.text.alignment = Alignment.Center;
            
            pvp.text.color = Color.Black;
            pvp.text.fontSize = 80;
            pvp.text.s = "Play PVP";
            pvp.text.drawOrder = 9000;

            pvp.onButtonPressed += (object sender, EventArgs eventArgs) => LoadPVPScene();

            //BUTTON AI
            Button ai = new Button();
            ai.sprite.transform.position = new Vector2(Settings.Get_Screen_Center().X, 500);
            ai.sprite.dimension = new Vector2(500, 80);

            ai.text.transform.position = new Vector2(480, 455);
            ai.text.color = Color.Black;
            ai.text.fontSize = 80;
            ai.text.s = "Play vs AI";
            ai.text.drawOrder = 9000;

            ai.onButtonPressed += (object sender, EventArgs eventArgs) => LoadAIScene();

            //QUITTER
            Button exit = new Button();
            exit.sprite.transform.position = new Vector2(Settings.Get_Screen_Center().X, 655);
            exit.sprite.dimension = new Vector2(350, 50);

            exit.text.transform.position = new Vector2(595, 630);
            exit.text.color = Color.Black;
            exit.text.fontSize = 50;
            exit.text.s = "Exit";
            exit.text.drawOrder = 9000;

            exit.onButtonPressed += (object sender, EventArgs eventArgs) => ExitGame();
        }

        //METHODS
        private void LoadPVPScene()
        {
            Save_RunTime.data.Clear();
            Scene_Pong.gameMode = GameMode.PvP;
            Engine.sceneManager.ChangeScene(new Scene_Pong());
        }

        private void LoadAIScene()
        {
            Save_RunTime.data.Clear();
            Scene_Pong.gameMode = GameMode.PvAI;
            Engine.sceneManager.ChangeScene(new Scene_Pong());
        }

        private void ExitGame()
        {
            Engine.ExitGame();
        }

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            /*
            DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center(), Color.White);

            DrawSimpleShape.DrawRuller(pvp.transform.position+Vector2.One, Color.Red);
            DrawSimpleShape.DrawRuller(pvp.sprite.transform.position, Color.Blue);
            */
        }
    }
}
