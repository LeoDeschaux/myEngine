using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Ressources
    {
        // STATIC FIELDS 
        public static Dictionary<string, Texture2D> Images;

        public static SpriteFont defaultFont;
        public static SoundEffect ball_hit_raquette, ball_hit_wall;
        public static SoundEffect[] target_hit_sounds;

        //RANDOM
        static Random random;

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            List<string> imagesName = new List<string>()
            {
                "circle",
                "diamond",
                "star"
            };

            foreach (string img in imagesName)
            {
                Images.Add(img, content.Load<Texture2D>("myContent/ParticleSystem/" + img));
            }
        }

        public static void LoadFont(ContentManager content)
        {
            defaultFont = content.Load<SpriteFont>("myContent/UI/defaultFont");
        }

        public static void LoadRessources(ContentManager content)
        {
            ball_hit_raquette = content.Load<SoundEffect>("myContent/Audio/BallHit_V1");
            ball_hit_wall = content.Load<SoundEffect>("myContent/Audio/BallHit_V2");

            target_hit_sounds = new SoundEffect[4];
            target_hit_sounds[0] = content.Load<SoundEffect>("myContent/Audio/TargetHit_Small");
            target_hit_sounds[1] = content.Load<SoundEffect>("myContent/Audio/TargetHit_SmallV2");
            target_hit_sounds[2] = content.Load<SoundEffect>("myContent/Audio/TargetHit_Medium");
            target_hit_sounds[3] = content.Load<SoundEffect>("myContent/Audio/TargetHit_Big");
        }

        public static SoundEffect GetSound(SoundEffect[] sounds)
        {
            random = new Random();
            SoundEffect s = sounds[random.Next(0, sounds.Length)];
            return s;
        }
    }
}