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
        public static Input input;
        public static Game_Pong game;
        public UI ui;

        //CONSTRUCTOR
        public Scene_MainMenu()
        {
            input = new Input();

            //Settings.BACKGROUND_COLOR = Color.PaleGoldenrod;

            Text text = new Text();
            text.s = "PONG THE GAME";
            text.color = Color.White;
            text.fontSize = 120;
            text.transform.position = new Vector2(Settings.Get_Screen_Center().X - 450, 200);


            Text text2 = new Text();
            text2.s = "PRESS ENTER TO PLAY";
            text2.color = Color.White;
            text2.fontSize = 50;
            text2.transform.position = new Vector2(Settings.Get_Screen_Center().X - 200, Settings.Get_Screen_Center().Y + 200);
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            if (input.GetKeyDown(Keys.Enter))
            {
                Game1.sceneManager.ChangeScene(new Scene_Pong());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
