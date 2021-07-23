using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine
{
    public class Scene_PostProcessing : IScene
    {
        //CONSTRUCTOR
        public Scene_PostProcessing()
        {
            Settings.BACKGROUND_COLOR = Color.Khaki;

            Sprite s = new Sprite(Ressources.Load<Texture2D>("myContent/2D/mountain"));
            s.transform.position = Settings.Get_Screen_Center();
            s.dimension = new Vector2(Settings.SCREEN_WIDTH * 0.9f, Settings.SCREEN_HEIGHT * 0.9f);

            Text t = new Text("mon text");
            t.fontSize = 50;

            postProcessingProfile.effect.Parameters["param1"]?.SetValue((1f));
        }

        //METHODS
        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center(), Color.Red, orderInLayer: 1000);
        }
    }
}