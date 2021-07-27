using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class ColorObject
    {
        Color c;

        public ColorObject()
        {
            c = Color.Red;
        }

        public Color myColor()
        {
            return c;
        }

        public void Great()
        {
            Console.WriteLine("JE SUIS COULEUR");
        }
    }
    public class Scene_Event : IScene
    {
        //FIELDS
        ColorObject r;
        Event e;

        //CONSTRUCTOR
        public Scene_Event()
        {
            r = new ColorObject();

            e = new Event(r.Great);
        }

        //METHODS
        public override void Update()
        {
            if(Input.GetKeyDown(Keys.Enter))
                e?.Invoke();
        }
    }
}
