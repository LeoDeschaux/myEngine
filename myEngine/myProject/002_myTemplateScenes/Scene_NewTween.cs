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
            Settings.BACKGROUND_COLOR = Color.AliceBlue;

            s = new Sprite();
            s.color = Color.Black;
            s.transform.position = new Vector2(100, Settings.Get_Screen_Center().Y);

            NewTween.BaseTween(ref s.transform.position.X, 1000);

            //EXEMPLE DE FONCTIONS A CREER
            //NewTween.BaseTween(ref valueToModify, endValue, speed);
            //NewTween.BaseTween(ref valueToModify, endValue, startAfterDelay);
            //NewTween.BaseTween(ref valueToModify, endValue, timeToComplete);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Enter))
                s.Destroy();
        }
    }
}
