using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using myEngine;

namespace zzMathVisu
{
    public class Scene_Main : IScene
    {
        //FIELDS
        Text t;

        //CONSTRUCTOR
        public Scene_Main()
        {
            Settings.BACKGROUND_COLOR = Color.HotPink;

            /*
            Sprite s = new Sprite();
            s.texture = Ressources.Load<Texture2D>("myContent/2D/Utm-zones");

            s.dimension = new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            */

            this.camControl.isActive = true;

            //PopUp p = new PopUp("Hello");
            Button b = new Button();
            b.onButtonPressed = new Event(OnButtonPressed);

            Console.WriteLine(b.transform.position);

            t = new Text();
        }


        public override void Update()
        {
            t.s = "" + Util.ScreenToWorld(camera, Mouse.position.ToVector2());
        }

        //MEHTODS
        private void OnButtonPressed()
        {
            Console.WriteLine("TEST");
        }
        
    }
}
