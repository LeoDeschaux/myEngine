using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_WorldAndScreen : IScene
    {
        Sprite sprite;

        public Scene_WorldAndScreen()
        {
            Settings.BACKGROUND_COLOR = Color.AliceBlue;
            sprite = new Sprite();
            sprite.color = Color.Black;

            camControl.isActive = true;
        }

        public override void Update()
        {
            sprite.transform.position = Util.WorldToScreen(camera.transformMatrix, Settings.GetScreenCenter());
        }
    }
}