using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace myEngine
{
    

    public class Scene_Animation : IScene
    {
        //FIELDS 

        //CONSTRUCTOR
        public Scene_Animation()
        {
            Text text = new Text();
            text.s = "Scene_Animation";
            text.color = Color.White;

            //Frame
            //Sequence (plusieurs frame)
            //AnimationPlayer
            //Animation

            Settings.BACKGROUND_COLOR = Color.White;

            AnimatedSprite animatedSprite = new AnimatedSprite(Ressources.animatedSprite, 2, 2);
            animatedSprite.transform.position = Settings.Get_Screen_Center();
            animatedSprite.speed = 4;

            //


        }

        private enum myChar
        {
            idle,
            up,
            right,
            down,
            left
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
