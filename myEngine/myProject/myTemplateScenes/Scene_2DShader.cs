﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using ImGuiNET;

namespace myEngine
{
    public class Scene_2DShader : IScene
    {
        //FIELDS 
        Sprite sprite;
        Effect effect;

        float x = 0;

        //CONSTRUCTOR
        public Scene_2DShader()
        {
            Settings.BACKGROUND_COLOR = Color.Gray;

            //RenderTarget2D
            Texture2D character = Ressources.Load<Texture2D>("myContent/2D/character");
            Texture2D mountain = Ressources.Load<Texture2D>("myContent/2D/mountain");

            sprite = new Sprite(mountain);

            sprite.transform.position = Settings.Get_Screen_Center();
            sprite.dimension = new Vector2(Settings.SCREEN_WIDTH * 0.95f, Settings.SCREEN_HEIGHT * 0.95f);

            //EFFECT
            effect = Ressources.Load<Effect>("myContent/Shader/testShader");

            Texture2D textureMask = Ressources.Load<Texture2D>("myContent/2D/texture");
            effect.Parameters["customTexture"]?.SetValue(textureMask);

            sprite.effect = effect;

            //SPRITE
            Sprite s = new Sprite(mountain);
            s.transform.position = new Vector2(80*2, 45*2);
            s.dimension = new Vector2(160*2, 90*2);
        }

        //METHODS

        public override void Update()
        {
            effect.Parameters["param1"]?.SetValue(x);
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
        }

        public override void DrawGUI()
        {
            ImGui.Begin("Shader Params");
            ImGui.SetWindowSize(new System.Numerics.Vector2(300, 200));

            ImGui.Text("Tint");

            //float x = effect.Parameters["param1"].GetValueSingle();

            ImGui.SliderFloat("Red", ref x, 0f, 2f, string.Empty);
            //ImGui.SliderFloat("OffSetX", ref offSetX, 0f, 10f, string.Empty);
            //ImGui.SliderFloat("OffSetY", ref offSetY, 0f, 10f, string.Empty);
            //ImGui.SliderFloat("ThreshHold", ref threshold, 0f, 255f, string.Empty);

            ImGui.End();
        }
    }
}
