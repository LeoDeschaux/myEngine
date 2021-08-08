using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_ParticleSystem : IScene
    {
        //FIELDS
        ParticleEngine particleEngine;
        Text text;

        //
        Particle p;

        //CONSTRUCTOR
        public Scene_ParticleSystem()
        {
            //p = new Particle(Ressources.Images["diamond"]);

            p = new Particle(DrawSimpleShape.GetTexture(10, 10));

            p.Speed = 20;
            
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
            text.color = new Color(50, 50, 50);
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Add))
            {
                Console.Write("PLUS : ");
                Console.WriteLine(p.Size);
                p.Size += 1;
            }

            if (Input.GetKeyDown(Keys.Subtract))
            {
                Console.Write("MINUS : ");
                Console.WriteLine(p.Size);
                p.Size -= 1;
            }

            /*
            if (Mouse.GetMouse(0))
            {
                particleEngine.isActive = true;
                particleEngine.EmitterLocation = new Vector2(Mouse.position.X, Mouse.position.Y);
            }
            else
                particleEngine.isActive = false;
            */
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
        }
    }
}