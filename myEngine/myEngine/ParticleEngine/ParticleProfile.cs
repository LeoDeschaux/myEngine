using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public class ParticleProfile
    {
        //FIELDS
        public bool burstMode = false; // != looping
        public bool startAwake = true;
        public float duration = 5f;

        //NUMBERS
        public int burstAmount = 10;
        public int emissionRate = 100;
        public int maxParticles = 1000;


        //PARTICLE
        public Particle particle;

        //CONSTRUCTOR
        public ParticleProfile(Particle p = null)
        {
            //CREATE PARTICLE
            if(p != null)
            {
                this.particle = p;
            }
            else
            {
                this.particle = new Particle(
                    DrawSimpleShape.GetTexture(10, 10),
                    Vector2.Zero,
                    Vector2.Zero,
                    0f,
                    0f,
                    Color.White,
                    1,
                    1
                );
            }
        }
    }
}
