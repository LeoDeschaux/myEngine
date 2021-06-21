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
            Sprite s = new Sprite(new Vector2(Settings.Get_Screen_Center().X, Settings.Get_Screen_Center().Y), new Vector2(50, 150));
            s.orderInLayer = -1000;
            s.transform.rotation = 45f;
            s.AddComponent(new Collider2D(s));

            //TEST ZONE
            //Console.WriteLine(s.GetRec().X + ", " + s.GetRec().Y + ", " + s.GetRec().Width + ", " + s.GetRec().Height);
        }

        //METHODS

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch sprite)
        {
        }

    }
}
