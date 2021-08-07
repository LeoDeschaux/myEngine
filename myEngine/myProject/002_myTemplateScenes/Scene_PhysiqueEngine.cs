using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Scene_PhysiqueEngine : IScene
    {
        //FIELDS

        //CONSTRUCTOR
        public Scene_PhysiqueEngine()
        {
            Text t = new Text();
            t.s = "PHYSIQUE ENGINE";
            t.color = Color.White;
        }

        //METHODS

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
        }

    }
}
