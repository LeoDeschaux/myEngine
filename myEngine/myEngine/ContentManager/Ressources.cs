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
        public static SoundEffect target_hit_small_v1, target_hit_small_v2;
        public static SoundEffect target_hit_medium, target_hit_big;

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

            target_hit_small_v1 = content.Load<SoundEffect>("myContent/Audio/TargetHit_Small");
            target_hit_small_v2 = content.Load<SoundEffect>("myContent/Audio/TargetHit_SmallV2");

            target_hit_medium = content.Load<SoundEffect>("myContent/Audio/TargetHit_Medium");
            target_hit_big = content.Load<SoundEffect>("myContent/Audio/TargetHit_Big");
        }
    }
}
