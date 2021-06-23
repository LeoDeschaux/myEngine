using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public abstract class IScene : Entity
    {
        //FIELDS

        //CONSTRUCTOR
        public IScene()
        {
            Settings.BACKGROUND_COLOR = Color.Black;
            Settings.GAME_SPEED = 1;
        }

        //UPDATE & DRAW
        public abstract override void Update();
        public abstract override void Draw(SpriteBatch sprite);
    }
}
