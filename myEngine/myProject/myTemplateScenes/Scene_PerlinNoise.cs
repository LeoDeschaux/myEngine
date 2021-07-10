using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImGuiNET;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Scene_PerlinNoise : IScene
    {
        //FIELDS
        Sprite sprite;

        Perlin p;

        //GUI

        //CONSTRUCTOR
        public Scene_PerlinNoise()
        {
            Settings.BACKGROUND_COLOR = Color.BurlyWood;

            //
            p = new Perlin();

            sprite = new Sprite();
            sprite.transform.position = Settings.Get_Screen_Center();
            sprite.dimension = new Vector2(256, 256);

            sprite.texture = GetTexture((int)sprite.dimension.X, (int)sprite.dimension.Y);
        }

        //METOHDS
        public override void Update()
        {
            sprite.texture = GetTexture((int)sprite.dimension.X, (int)sprite.dimension.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public Texture2D GetTexture(int x = 1, int y = 1)
        {
            Texture2D texture = new Texture2D(Engine.spriteBatch.GraphicsDevice, x, y, false, SurfaceFormat.Color);

            Color[] data = new Color[x * y];
            for (int i = 0; i < data.Length; ++i)
            {
                int xCord = i % (int)sprite.dimension.X;
                int yCord = i / (int)sprite.dimension.Y;

                data[i] = CalculateColor(xCord, yCord);
            }

            texture.SetData(data);

            return texture;
        }

        public float scale = 20;
        public float offSetX = 0;
        public float offSetY = 0;
        public float threshold = 100;

        public Color CalculateColor(int x, int y)
        {
            double xCoord = (double)x / sprite.dimension.X * scale + offSetX;
            double yCoord = (double)y / sprite.dimension.Y * scale + offSetY;

            Double d = p.perlin(xCoord, yCoord, 0);

            int sample = (int)(d * 255);

            if (sample <= threshold)
                sample = 0;
            else
                sample = 255;

            Color c = new Color(sample, sample, sample);

            return c;
        }

        public override void DrawGUI()
        {
            ImGui.Begin("Perlin Noise");
            ImGui.SetWindowSize(new System.Numerics.Vector2(300, 200));
            ImGui.SetWindowPos(new System.Numerics.Vector2(50, 50));

            ImGui.Text("Params");
            ImGui.SliderFloat("Scale", ref scale, 1f, 50f, string.Empty);
            ImGui.SliderFloat("OffSetX", ref offSetX, 0f, 10f, string.Empty);
            ImGui.SliderFloat("OffSetY", ref offSetY, 0f, 10f, string.Empty);
            ImGui.SliderFloat("ThreshHold", ref threshold, 0f, 255f, string.Empty);

            ImGui.End();
        }
    }
}
