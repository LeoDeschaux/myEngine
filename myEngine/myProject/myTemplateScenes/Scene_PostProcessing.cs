using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public class Scene_PostProcessing : IScene
    {
        //FIELDS

        //CONSTRUCTOR
        public Scene_PostProcessing()
        {
            Settings.BACKGROUND_COLOR = Color.Khaki;

            Sprite s = new Sprite(Ressources.Load<Texture2D>("myContent/2D/character"));
        }

        //METHODS
        public override void Draw(SpriteBatch sprite)
        {
        }
    }
}
