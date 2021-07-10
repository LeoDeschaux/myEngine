using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

using ImGuiNET;
using ImGuiNET.SampleProgram.XNA;
using Num = System.Numerics;

namespace myEngine
{
    public class Scene_ParticleEditor : IScene
    {
        //FIELDS
        ParticleEngine particleEngine;
        ParticleEngine pe_followMouse;
        Text text;

        //
        Particle p;

        //GUI
        private ImGuiRenderer _imGuiRenderer;

        //VALUE
        public static Vector3 particleColor;
        public static float particleSize = 1;


        //CONSTRUCTOR
        public Scene_ParticleEditor()
        {
            p = new Particle(DrawSimpleShape.GetTexture(10, 10));

            ParticleProfile pp = new ParticleProfile(p);
            pp.maxParticles = 1000;
            pp.burstMode = false;
            pp.loopMode = true;
            pp.duration = 5;

            particleEngine = new ParticleEngine(pp, Vector2.Zero);
            particleEngine.isActive = true;

            particleEngine.EmitterLocation = Settings.Get_Screen_Center();

            //FOLLOW MOUSE
            pe_followMouse = new ParticleEngine(pp, Settings.Get_Screen_Center());
            pe_followMouse.isActive = false;

            //UI
            text = new Text("LEFT CLICK TO FIRE PARTICLES");
            //text.color = new Color(50, 50, 50);
            text.transform.position = new Vector2(0, 20);

            //GUI
            Settings.BACKGROUND_COLOR = Color.LightSlateGray;

            _imGuiRenderer = new ImGuiRenderer(Engine.game);
            _imGuiRenderer.RebuildFontAtlas();

        }

        //UPDATE & DRAW
        public override void Update()
        {
            Vector3 c = particleColor;
            p.Color = new Color(c.X, c.Y, c.Z);
            p.Size = particleSize;

            //
            if (Input.GetMouse(0))
            {
                pe_followMouse.isActive = true;
                pe_followMouse.EmitterLocation = Mouse.position.ToVector2();
            }
            else
            {
                pe_followMouse.isActive = false;
                pe_followMouse.EmitterLocation = Settings.Get_Screen_Center();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int x = 16;
            int y = 9;

            Color c = new Color(100, 100, 100);

            for(int i = 0; i < x; i++)
            {
                DrawSimpleShape.DrawRuller(new Vector2(Settings.SCREEN_WIDTH/(x+1) + (Settings.SCREEN_WIDTH/(x+1) * i), 
                    Settings.SCREEN_HEIGHT / (y + 1) + (Settings.SCREEN_HEIGHT / (y + 1) * i)), c, -1000);
            }
        }

        public override void DrawGUI()
        {
            _imGuiRenderer.BeforeLayout(Time.gameTime);
            ImGuiLayout();
            _imGuiRenderer.AfterLayout();
        }

        //GUI
        protected void ImGuiLayout()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New"))
                    {
                        Console.WriteLine("NEW MENU");
                    }
                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("do thing"))
                    {
                        Console.WriteLine("edit - do thing");
                    }
                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }

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
