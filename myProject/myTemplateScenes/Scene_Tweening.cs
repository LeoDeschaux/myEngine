using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_Tweening : IScene
    {
        //FIELDS
        public Sprite[] mySprites;

        // MY ANIMATE VARS
        public SimpleTween[] myTweens;
        public SimpleTween[] myTweensR;
        public SimpleTween[] myTweensS;

        Random random;

        bool init;

        Text text;

        //CONSTRUCTOR
        public Scene_Tweening()
        {
            Settings.BACKGROUND_COLOR = Color.DarkOrchid;
            camControl.isActive = true;

            camera.transform.position += new Vector2(560, -Settings.SCREEN_HEIGHT/2);

            mySprites = new Sprite[20];

            random = new Random();

            text = new Text("PRESS ENTER TO FIRE ANIMATION");
            text.color = new Color(50, 50, 50);

            //INIT GRID
            int i = 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Vector2 offSet = new Vector2(350, 450);
                    mySprites[i] = new Sprite(new Vector2(x * 125, y*55) + offSet, new Vector2(120, 50));
                    i++;
                }
            }

            //INIT TWEENS
            myTweens = new SimpleTween[mySprites.Length];
            for (int x = 0; x < mySprites.Length; x++)
            {
                myTweens[x] = new SimpleTween(mySprites[x].transform.position.Y, mySprites[x].transform.position.Y-300, 0.5f, x*0.1f);
            }

            myTweensR = new SimpleTween[mySprites.Length];
            for (int x = 0; x < mySprites.Length; x++)
            {
                myTweensR[x] = new SimpleTween(MathHelper.WrapAngle(90), 0, 0.5f, x * 0.1f);
            }

            myTweensS = new SimpleTween[mySprites.Length];
            for (int x = 0; x < mySprites.Length; x++)
            {
                myTweensS[x] = new SimpleTween(0.1f, 1, 0.5f, x * 0.1f);
            }

            //OVERRIDE tween[0]
            //myTweens[0] = new SimpleTween(mySprites[0].transform.GetPosition().Y, mySprites[0].transform.GetPosition().Y - 400, 0.5f, 0 * 0.1f);
        }

        private void InitGrid()
        {
            for (int x = 0; x < mySprites.Length; x++)
            {
                if (myTweens[x].isPlaying)
                {
                    float myValue = myTweens[x].value;
                    mySprites[x].transform.position = new Vector2(mySprites[x].transform.position.X, myValue);
                }

                if (myTweensR[x].isPlaying)
                {
                    float myValueR = myTweensR[x].value;
                    mySprites[x].transform.rotation = myValueR;
                }

                if (myTweensS[x].isPlaying)
                {
                    float myValueS = myTweensS[x].value;
                    mySprites[x].transform.scale.X = myValueS;
                    mySprites[x].transform.scale.Y = myValueS;
                }
            }
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Enter))
            {
                for (int x = 0; x < mySprites.Length; x++)
                {
                    myTweens[x].Start();
                    myTweensR[x].Start();
                    myTweensS[x].Start();
                }

                init = true;
            }

            if(init)
                InitGrid();

            //float myValue = myTweens[0].value;
            //mySprites[0].transform.SetPosition(mySprites[0].transform.GetPosition().X, myValue);
        }

        public override void Draw(SpriteBatch spriteBatch, Matrix matrix)
        {
        }
    }
}