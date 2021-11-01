using Microsoft.Xna.Framework;
using Microsoft.Xna;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public class PostProcessingProfile
    {
        //FIELDS
        public Effect effect;
        public Color color;

        //CONSTRUCTOR
        public PostProcessingProfile()
        {
            color = Color.Transparent;
            effect = Ressources.Load<Effect>("myContent/Shader/postProcessing");
            Texture2D textureMask = Ressources.Load<Texture2D>("myContent/2D/texture");
            
            //POST PROCESSING
            effect.Parameters["customTexture"]?.SetValue(textureMask);
            effect.Parameters["param1"]?.SetValue((0f));

            /*
            float speed = 2f;
            float time = (float)Math.Sin((double)Time.gameTime.TotalGameTime.TotalSeconds * speed);
            float intensity = 0.2f;

            //effect.Parameters["param1"]?.SetValue((1+time) * intensity);
            */
        }

        //METHODS

    }
}