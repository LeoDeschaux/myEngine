using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_NewTween : IScene
    {
        //FIELDS
        Sprite s;

        //CONSTRUCTOR
        public Scene_NewTween()
        {
            Text t = new Text();
            t.s = "Press F5 to restart scene";
            t.transform.position = new Vector2(Settings.SCREEN_WIDTH / 2, 600);
            t.alignment = Alignment.Center;

            Settings.BACKGROUND_COLOR = Color.AliceBlue;

            s = new Sprite();
            s.color = Color.Black;
            s.transform.position = new Vector2(-400, 0);

            NewTween.BaseTween(ref s.transform.position.X, 400);

            //EXEMPLE DE FONCTIONS A CREER
            //NewTween.BaseTween(ref valueToModify, endValue, speed);
            //NewTween.BaseTween(ref valueToModify, endValue, startAfterDelay);
            //NewTween.BaseTween(ref valueToModify, endValue, timeToComplete);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Enter))
            {
                s.Destroy();
            }
        }
    }
}
