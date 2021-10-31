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
            background = new Sprite();
            background.color = Color.Black;
            background.dimension = new Vector2(500, 300);
            //background.transform = this.transform;

            text = new Text();
            text.drawOrder = 2010;
            text.s = msg;
            text.transform.position = new Vector2(background.transform.position.X,
                                                   background.transform.position.Y - (background.dimension.Y/2) + (text.GetRectangle().Height*2));
            text.color = Color.White;
            text.alignment = Alignment.Center;
            text.useScreenCoord = false;

            button = new Button();
            button.sprite.dimension = new Vector2(200, 80);
            //button.sprite.transform.position = new Vector2(0, -150);

            button.transform.position = new Vector2(background.transform.position.X,
                                                   (background.transform.position.Y + (background.dimension.Y/2) - (button.sprite.dimension.Y/1.2f)));
            button.defaultColor = Color.White;
            button.hoverColor = Color.Yellow;
            button.onClicColor = Color.Red;

            button.text.s = "Continue";
            button.text.alignment = Alignment.Center;
            button.text.useScreenCoord = false;

            //button.text.transform = button.transform;
            //button.sprite.transform = button.transform;
            button.sprite.transform.position = new Vector2(button.transform.position.X, button.transform.position.Y);

            background.drawOrder = 2000;
            button.drawOrder = 2001;
            button.sprite.drawOrder = 2002;
            button.text.drawOrder = 2003;

        }

        //METHODS
    }
}
