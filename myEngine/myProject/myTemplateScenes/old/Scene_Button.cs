using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_Button : IScene
    {
        //FIELDS
        Button b1;
        Button b2;

        //CONSTRUCTOR
        public Scene_Button()
        {
            Settings.BACKGROUND_COLOR = Color.LightBlue;

            b1 = new Button();
            b1.transform.position = Settings.Get_Screen_Center();
            b1.sprite.dimension = new Vector2(120, 120);
            b1.drawOrder = 0;
            b1.sprite.drawOrder = 1;
            b1.text.drawOrder = 2;

            b1.text.s = "B1";
            b1.text.alignment = Alignment.Center;

            b2 = new Button();
            b2.transform.position = new Vector2(b1.transform.position.X + 50, b1.transform.position.Y);
            b2.sprite.dimension = b1.sprite.dimension;
            b2.drawOrder = 100;
            b2.sprite.drawOrder = 101;
            b2.text.drawOrder = 102;

            b2.text.s = "B2";
            b2.text.alignment = Alignment.Center;
        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.P))
            {
                Console.WriteLine(Button.buttonsSelected.Count);
            }
        }
    }
}
