using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using myEngine;
using System;
using Num = System.Numerics;

namespace zzMathVisu
{
    public class PopUpCoord : GameObject
    {
        //FIELDS
        ImGuiRenderer renderer;

        //UI VALUES
        private static Num.Vector2 coords;

        //CONSTRUCTOR
        public PopUpCoord()
        {
            renderer = new ImGuiRenderer(Engine.game);
            renderer.RebuildFontAtlas();
        }

        //METHODS

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            renderer.BeforeLayout(Time.gameTime);

            DrawPopUp();

            renderer.AfterLayout();
        }

        public void DrawPopUp()
        {
            /*
            ImGui.SetNextWindowSize(new Num.Vector2(300, 300));
            ImGui.SetNextWindowPos(new Num.Vector2(Settings.SCREEN_WIDTH/2 - 150, Settings.SCREEN_HEIGHT/2 - 150));

            ImGui.GetStyle().WindowRounding = 0.0f;
            ImGui.GetStyle().ChildRounding = 0.0f;
            ImGui.GetStyle().FrameRounding = 0.0f;
            ImGui.GetStyle().GrabRounding = 0.0f;
            ImGui.GetStyle().PopupRounding = 0.0f;
            ImGui.GetStyle().ScrollbarRounding = 0.0f;

            ImGuiWindowFlags window_flags = 0;

            //window_flags |= ImGuiWindowFlags.NoResize;
            //window_flags |= ImGuiWindowFlags.NoCollapse;
            //window_flags |= ImGuiWindowFlags.NoMove;
            ImGui.Begin("WINDOW", window_flags);
            */

            ImGui.Begin("NAME");

            ImGui.Text("Choose your marker position : ");

            ImGui.SliderFloat("Longitude", ref coords.Y, -180f, 180f);
            ImGui.SliderFloat("Latitude", ref coords.X, -90f, 90f);

            if (ImGui.Button("Set Marker"))
            {
                Console.WriteLine("PRESSED");
                Sprite s = new Sprite();

                s.transform.position = Scene_EarthMap.convert(coords.X, coords.Y);
                //s.transform.position = new Vector2(positionUI.X, positionUI.Y);
                s.dimension = new Vector2(2, 2);
                s.color = Color.Red;
                s.drawOrder = 100;
            }

            ImGui.End();
        }
    }
}
