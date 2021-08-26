using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class ParticleEngine : GameObject
    {
        //FIELDS
        private Random random;
        private List<Particle> particles;
        private int totalParticlesSpawned;

        //PARTICLE PROFILE
        private ParticleProfile profile;

        private float timer;
        public bool isActive;

        //CONSTRUCTOR
        public ParticleEngine(ParticleProfile profile, Vector2 position)
        {
            transform.position = position;
            this.particles = new List<Particle>();
            random = new Random();

            //SET PROFIL
            this.profile = profile;

            this.timer = profile.duration;
            isActive = profile.startAwake;
        }

        //METHODS
        private Particle GenerateNewParticle()
        {
            //PARTICLE SYSTEM BEHAVIOR 
            Texture2D texture = profile.particle.Texture;
            Vector2 position = transform.position;

            Vector2 velocity = new Vector2(
                    1f * (float)(random.NextDouble() * 2 - 1),
                    1f * (float)(random.NextDouble() * 2 - 1));

            float speed = profile.particle.Speed;

            float angle = profile.particle.Angle;

            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);

            Color color = profile.particle.Color;
            float size = 0.1f + profile.particle.Size * (float)random.NextDouble();

            float ttl = 0.1f + (float)random.NextDouble() * profile.particle.TTL;

            int orderInLayer = profile.particle.OrderInLayer;

            return new Particle(texture, position, velocity, speed, angle, angularVelocity, color, size, ttl, orderInLayer);
        }

        //UPDATE & DRAW
        public override void Update()
        {
            bool timeToDestroy = false;

            if (!profile.burstMode)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    if (!profile.loopMode)
                    {
                        isActive = false;
                        timeToDestroy = true;
                    }
                    else
                        timer = profile.duration;
                }
            }

            if (profile.burstMode && totalParticlesSpawned == profile.burstAmount)
            {
                isActive = false;
                timeToDestroy = true;
            }

            if (isActive)
            {
                if(profile.burstMode)
                {
                    for (int i = 0; i < profile.burstAmount; i++)
                    {
                        particles.Add(GenerateNewParticle());
                        totalParticlesSpawned++;
                    }
                }
                else
                {
                    for (int i = 0; i < 1 + (int)( (float)profile.emissionRate * (float)Time.deltaTime) + profile.emissionRate - particles.Count; i++)
                    {
                        if(particles.Count < profile.maxParticles)
                            particles.Add(GenerateNewParticle());
                    }
                }
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }

            if (particles.Count == 0 && timeToDestroy)
            {
                Destroy();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch, matrix);
            }
        }
    }
}
