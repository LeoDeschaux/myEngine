using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using myEngine.myProject.Pong;

namespace myEngine
{
    public class Scene_Pong : IScene
    {
        //FIELDS
        public static Game_Pong game;
        public static UI ui;

        public static GameMode gameMode = GameMode.PvAI;

        //CONSTRUCTOR
        public Scene_Pong()
        {
            game = new Game_Pong(Scene_Pong.gameMode);
            ui = new UI_Pong();
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Escape))
            {
                ((UI_Pong) ui).OnPauseMenuCalled();
            }


            if (Settings.RELEASE_MODE)
                return;

            if (Input.GetKeyDown(Keys.Tab))
            {
                game.player1.OnPlayerGetRemovedStock();
            }

            if (Input.GetKeyDown(Keys.CapsLock))
            {
                game.player2.OnPlayerGetRemovedStock();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
        }
    }
}
