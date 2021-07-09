using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using System;

using ImGuiNET;
using ImGuiNET.SampleProgram.XNA;
using Num = System.Numerics;

namespace myEngine
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphicDevice;

        //GUI
        private ImGuiRenderer _imGuiRenderer;

        private Texture2D _xnaTexture;
        private IntPtr _imGuiTexture;

        //VALUE
        public static Vector3 particleColor;
        public static float particleSize = 1;

        public Game1()
        {
            graphicDevice = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            Engine.Initialize(this);

            _imGuiRenderer = new ImGuiRenderer(Engine.game);
            _imGuiRenderer.RebuildFontAtlas();

            _xnaTexture = CreateTexture(GraphicsDevice, 300, 150, pixel =>
            {
                var red = (pixel % 300) / 2;
                return new Color(red, 1, 1);
            });

            _imGuiTexture = _imGuiRenderer.BindTexture(_xnaTexture);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            Engine.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Engine.Draw();

            _imGuiRenderer.BeforeLayout(Time.gameTime);

            ImGuiLayout();

            _imGuiRenderer.AfterLayout();


            base.Draw(gameTime);
        }

        //GUI
        private float f = 0.0f;

        private byte[] _textBuffer = new byte[100];

        protected virtual void ImGuiLayout()
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

        public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint)
        {
            //initialize a texture
            var texture = new Texture2D(device, width, height);

            //the array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            for (var pixel = 0; pixel < data.Length; pixel++)
            {
                //the function applies the color according to the specified pixel
                data[pixel] = paint(pixel);
            }

            //set the color
            texture.SetData(data);

            return texture;
        }
    }
}