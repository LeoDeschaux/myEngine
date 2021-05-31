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
        }
    }
}
