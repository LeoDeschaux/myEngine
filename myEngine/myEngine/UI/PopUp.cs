using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class PopUp : GameObject
    {
        //FIELDS
        public Sprite background;
        public Button button;
        public Text text;

        //CONSTRUCTOR
        public PopUp(string msg)
        {
            transform.position = Settings.Get_Screen_Center();

            background = new Sprite();
            background.color = Color.Black;
            background.dimension = new Vector2(500, 300);
            background.transform = this.transform;

            text = new Text();
            text.drawOrder = 1000;
            text.s = msg;
            text.transform.position = new Vector2(background.transform.position.X,
                                                   background.transform.position.Y - (background.dimension.Y/2) + (text.GetRectangle().Height*2));
            text.color = Color.White;
            text.alignment = Alignment.Center;

            button = new Button();
            button.sprite.dimension = new Vector2(200, 80);
            button.transform.position = new Vector2(background.transform.position.X,
                                                   background.transform.position.Y + (background.dimension.Y/2) - (button.sprite.dimension.Y/1.2f));

            button.defaultColor = Color.White;
            button.hoverColor = Color.Yellow;
            button.onClicColor = Color.Red;

            button.text.s = "Continue";
            button.text.alignment = Alignment.Center;

            button.text.transform = button.transform;
            button.sprite.transform = button.transform;

            background.drawOrder = 1000;
            button.sprite.drawOrder = 1001;
            button.text.drawOrder = 1002;

        }

        //METHODS
    }
}
