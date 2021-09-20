using System;
using System.Collections.Generic;
using System.Text;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using myEngine;

using ImGuiNET;

namespace zzMathVisu
{
    public class Scene_EarthMap : IScene
    {
        //FIELDS
        Text t;
        PopUpCoord c;


        //CONSTRUCTOR
        public Scene_EarthMap()
        {
            Settings.BACKGROUND_COLOR = Color.Pink; 

            Sprite s = new Sprite();
            s.texture = Ressources.Load<Texture2D>("myContent/2D/Utm-zones");
            s.dimension = new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            s.transform.position = new Vector2(0, 0);
            s.isVisible = true;

            camControl.isActive = true;

            t = new Text();
            t.color = Color.White;
            c = new PopUpCoord();
        }

        //METHODS
        public override void Update()
        {
            Vector2 pos = new Vector2(myEngine.Mouse.position.X, myEngine.Mouse.position.Y);

            pos = Util.ScreenToWorld(camera.transformMatrix, pos);
            t.s = "" + pos;
        }

        public override void DrawGUI()
        {
            c.DrawPopUp();
        }

        public static Vector2 convert(float longitude, float latitude)
        {
            //lambda: longitude
            //phi: latitude
            //x = cos(phi0)*(lambda - lambda0)
            //y = (phi - phi0)

            latitude = MathHelper.ToRadians(latitude * 2);
            longitude = MathHelper.ToRadians(longitude);

            float longCenter = 0; //Settings.SCREEN_WIDTH/2;
            float latCenter = 0; //Settings.SCREEN_HEIGHT/2;
            float R = 0; //6.371km;

            Vector2 result = Vector2.Zero;

            result.X = (longitude - longCenter) * (float)Math.Cos(latCenter);
            result.Y = (latitude - latCenter);

            result.X = (result.X / MathHelper.Pi) * Settings.SCREEN_WIDTH / 2;
            result.Y = (result.Y / MathHelper.Pi) * Settings.SCREEN_HEIGHT / 2;

            return result;
        }
    }
}
