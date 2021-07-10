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
        private static  ContentManager content;

        public static void Init(ContentManager content)
        {
            Ressources.content = content;
        }

        public static T Load<T>(string path)
        {
            return content.Load<T>(path);
        }
    }
}