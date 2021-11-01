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
            Settings.BACKGROUND_COLOR = Color.AliceBlue;

            Text t = new Text();
            t.s = "Press Enter to launch event";
            t.transform.position = Settings.GetScreenCenter();
            t.alignment = Alignment.Center;

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
