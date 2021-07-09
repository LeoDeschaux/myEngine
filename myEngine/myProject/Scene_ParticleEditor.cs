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
        Text text;

        //
        Particle p;

       

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

            //UI
            text = new Text("LEFT CLICK TO FIRE PARTICLES");
            //text.color = new Color(50, 50, 50);
            text.transform.position = new Vector2(0, 20);

            //GUI
            Settings.BACKGROUND_COLOR = Color.LightSlateGray;
            
        }

        //UPDATE & DRAW
        public override void Update()
        {
            Vector3 c = Game1.particleColor;
            p.Color = new Color(c.X, c.Y, c.Z);
            p.Size = Game1.particleSize;

            //
            if (Input.GetMouse(0))
            {
                particleEngine.EmitterLocation = Mouse.position.ToVector2();
            }
            else
            {
                particleEngine.EmitterLocation = Settings.Get_Screen_Center();
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
    }
}
