using System;
using System.Collections.Generic;
using System.Text;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using myEngine;

namespace zzMathVisu
{
    public class Scene_EarthMap : IScene
    {
        //FIELDS
        Text t;

        //CONSTRUCTOR
        public Scene_EarthMap()
        {
            Settings.BACKGROUND_COLOR = Color.Pink; 

            Sprite s = new Sprite();
            s.texture = Ressources.Load<Texture2D>("myContent/2D/Utm-zones");
            s.dimension = new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            s.transform.position = new Vector2(0, 0);
            s.isVisible = false;


            Sprite ss = new Sprite();
            ss.texture = Ressources.Load<Texture2D>("myContent/2D/Utm-zones");
            ss.dimension = new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            ss.color = Color.Blue;
            ss.transform.position = new Vector2(s.dimension.X, 0);
            ss.isVisible = false;

            camControl.isActive = true;

            t = new Text();
        }

        //METHODS
        public override void Update()
        {
            Vector2 pos = new Vector2(myEngine.Mouse.position.X, myEngine.Mouse.position.Y);

            pos = Util.ScreenToWorld(camera.transformMatrix, pos);
            t.s = "" + pos;

            if (Input.GetMouseDown(MouseButtons.Left))
            {
                /*
                Sprite s = new Sprite();
                s.color = Color.Red;
                s.dimension = new Vector2(50, 50);

                s.transform.position = new Vector2(pos.X, -pos.Y);
                s.drawOrder = 500;
                */
            }

            if(Input.GetKeyDown(Keys.Enter))
            {
                //PopUp p = new PopUp("Hello");
                PopUpCoord c = new PopUpCoord();
                //p.button.onButtonPressed = new Event(OnButtonPressed);
            }


        }
    }
}
