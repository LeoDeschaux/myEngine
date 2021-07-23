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
        float speed = 200;

        //CONSTRUCTOR
        public Scene_Animation()
        {
            Settings.BACKGROUND_COLOR = Color.CornflowerBlue;

            AnimatedSprite animatedSprite = new AnimatedSprite(Ressources.Load<Texture2D>("TileMaps/myFile"), 2, 2);
            animatedSprite.transform.position = Settings.Get_Screen_Center();
            animatedSprite.speed = 4;
            animatedSprite.playAllFrame = true;

            //
            transformChar = new Transform();

            spritesheet = new AnimatedSprite(Ressources.Load<Texture2D>("TileMaps/spritesheet"), 4, 4);
            spritesheet.speed = 4;
            spritesheet.transform = transformChar;
            spritesheet.playAllFrame = false;
            spritesheet.animationIndex = 1;

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

            if (Input.GetKey(Keys.Right))
            {
                transformChar.position.X += speed * Time.deltaTime;
                state = myChar.right;
                spritesheet.animationIndex = 1;

            }
            else if (Input.GetKey(Keys.Left))
            {
                transformChar.position.X -= speed * Time.deltaTime;
                state = myChar.left;
                spritesheet.animationIndex = 3;
            }
            else if (Input.GetKey(Keys.Up))
            {
                transformChar.position.Y -= speed * Time.deltaTime;
                state = myChar.up;
                spritesheet.animationIndex = 2;
            }
            else if (Input.GetKey(Keys.Down))
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

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
        }
    }
}
