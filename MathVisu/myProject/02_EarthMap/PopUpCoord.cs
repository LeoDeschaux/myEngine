using System;
using System.Collections.Generic;
using System.Text;

using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using myEngine;

using Num = System.Numerics;

namespace zzMathVisu
{
    public class PopUpCoord : GameObject
    {
        //FIELDS
        ImGuiRenderer renderer;

        //UI VALUES
        public static Vector3 particleColor;
        public static float particleSize = 1;

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
        protected void DrawPopUp()
        {
            ImGui.SetNextWindowSize(new Num.Vector2(300, 300));
            ImGui.SetNextWindowPos(new Num.Vector2(Settings.SCREEN_WIDTH/2 - 150, Settings.SCREEN_HEIGHT/2 - 150));

            ImGui.GetStyle().WindowRounding = 0.0f;
            ImGui.GetStyle().ChildRounding = 0.0f;
            ImGui.GetStyle().FrameRounding = 0.0f;
            ImGui.GetStyle().GrabRounding = 0.0f;
            ImGui.GetStyle().PopupRounding = 0.0f;
            ImGui.GetStyle().ScrollbarRounding = 0.0f;

            ImGuiWindowFlags window_flags = 0;

            window_flags |= ImGuiWindowFlags.NoResize;
            window_flags |= ImGuiWindowFlags.NoCollapse;
            window_flags |= ImGuiWindowFlags.NoMove;

            ImGui.Begin("WINDOW", window_flags);
            ImGui.Text("Hello, world!");
            ImGui.SliderFloat("float", ref particleSize, 0.0f, 10.0f, string.Empty);

            Num.Vector3 v = new Num.Vector3(particleColor.X, particleColor.Y, particleColor.Z);

            ImGui.ColorEdit3("clear color", ref v);

            particleColor = new Vector3(v.X, v.Y, v.Z);

            ImGui.Button("Set Marker");

            ImGui.End();
        }

        //GUI
        protected void DrawGUI()
        {
            ImGui.SetNextWindowSize(new Num.Vector2(300, Settings.SCREEN_HEIGHT));
            ImGui.SetNextWindowPos(new Num.Vector2((Settings.SCREEN_WIDTH - 300), 0));

            ImGui.GetStyle().WindowRounding = 0.0f;
            ImGui.GetStyle().ChildRounding = 0.0f;
            ImGui.GetStyle().FrameRounding = 0.0f;
            ImGui.GetStyle().GrabRounding = 0.0f;
            ImGui.GetStyle().PopupRounding = 0.0f;
            ImGui.GetStyle().ScrollbarRounding = 0.0f;

            ImGuiWindowFlags window_flags = 0;

            window_flags |= ImGuiWindowFlags.NoResize;
            window_flags |= ImGuiWindowFlags.NoCollapse;
            window_flags |= ImGuiWindowFlags.NoMove;

            ImGui.Begin("WINDOW", window_flags);
            ImGui.Text("Hello, world!");
            ImGui.SliderFloat("float", ref particleSize, 0.0f, 10.0f, string.Empty);

            Num.Vector3 v = new Num.Vector3(particleColor.X, particleColor.Y, particleColor.Z);

            ImGui.ColorEdit3("clear color", ref v);

            particleColor = new Vector3(v.X, v.Y, v.Z);
            ImGui.End();
        }
    }
}
