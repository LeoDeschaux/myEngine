using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    

    public class Scene_Animation : IScene
    {
        //FIELDS 
        Transform transformChar;
        myChar state;
        AnimatedSprite spritesheet;

        Input input;

        float speed = 200;

        //CONSTRUCTOR
        public Scene_Animation()
        {
            //Frame
            //Sequence (plusieurs frame)
            //AnimationPlayer
            //Animation

            Settings.BACKGROUND_COLOR = Color.CornflowerBlue;

            AnimatedSprite animatedSprite = new AnimatedSprite(Ressources.animatedSprite, 2, 2);
            animatedSprite.transform.position = Settings.Get_Screen_Center();
            animatedSprite.speed = 4;
            animatedSprite.playAllFrame = true;

            //
            transformChar = new Transform();

            spritesheet = new AnimatedSprite(Ressources.spriteSheet, 4, 4);
            spritesheet.speed = 4;
            spritesheet.transform = transformChar;
            spritesheet.playAllFrame = false;
            spritesheet.animationIndex = 1;

            input = new Input();
            state = myChar.idle;
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
            if (state != myChar.idle)
                spritesheet.play = true;

            if (input.GetKey(Keys.Right))
            {
                transformChar.position.X += speed * Time.deltaTime;
                state = myChar.right;
                spritesheet.animationIndex = 1;

            }
            else if (input.GetKey(Keys.Left))
            {
                transformChar.position.X -= speed * Time.deltaTime;
                state = myChar.left;
                spritesheet.animationIndex = 3;
            }
            else if (input.GetKey(Keys.Up))
            {
                transformChar.position.Y -= speed * Time.deltaTime;
                state = myChar.up;
                spritesheet.animationIndex = 2;
            }
            else if (input.GetKey(Keys.Down))
            {
                transformChar.position.Y += speed * Time.deltaTime;
                state = myChar.down;
                spritesheet.animationIndex = 0;
            }
            else
            {
                state = myChar.idle;
                spritesheet.play = false;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
        }
    }
}
