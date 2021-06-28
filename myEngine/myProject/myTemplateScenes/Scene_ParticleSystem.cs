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
        Input input;

        //CONSTRUCTOR
        public Scene_ParticleSystem()
        {
            Particle p = new Particle(Ressources.Images["diamond"]);
            
            ParticleProfile pp = new ParticleProfile(p);
            pp.maxParticles = 1000;
            pp.burstMode = false;
            pp.loopMode = true;
            pp.duration = 5;

            particleEngine = new ParticleEngine(pp, Vector2.Zero);
            particleEngine.isActive = false;
            
            //UI
            text = new Text("LEFT CLICK TO FIRE PARTICLES");
            text.color = new Color(50, 50, 50);

            input = new Input();
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (Mouse.GetMouse(0))
            {
                particleEngine.isActive = true;
                particleEngine.EmitterLocation = new Vector2(Mouse.position.X, Mouse.position.Y);
            }
            else
                particleEngine.isActive = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}