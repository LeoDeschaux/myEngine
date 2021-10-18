using System;
using System.Collections.Generic;
using System.Text;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using myEngine;

using ImGuiNET;

using zzMathVisu.myProject;

using zzMathVisu.myProject._02_EarthMap;

namespace zzMathVisu
{
    public class Scene_EarthMap : IScene
    {
        public static bool IsSceneActive = true;

        //FIELDS
        Text t;
        PopUpCoord c;

        //CONSTRUCTOR
        public Scene_EarthMap()
        {
            Settings.BACKGROUND_COLOR = Color.Pink; 

            Sprite s = new Sprite();
            //s.texture = Ressources.Load<Texture2D>("myContent/2D/Utm-zones");
            s.texture = Ressources.Load<Texture2D>("myContent/2D/Map");
            s.dimension = new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            s.transform.position = new Vector2(0, 0);
            s.isVisible = true;
            s.drawOrder = -1000;

            camControl.isActive = true;

            t = new Text();
            t.color = Color.White;
            c = new PopUpCoord();

            //Spawn Cities
            MVUtil.SpawnPinAtCoords("Paris", Coord.Paris);
            MVUtil.SpawnPinAtCoords("Tokyo", Coord.Tokyo);
            MVUtil.SpawnPinAtCoords("Le Cap", Coord.LeCap);
            MVUtil.SpawnPinAtCoords("Mexico", Coord.Mexico);
            MVUtil.SpawnPinAtCoords("Puntas Arenas", Coord.PuntasArenas);
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
    }
}