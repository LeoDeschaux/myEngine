using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myEngine.myProject.Arkanoid
{
    public class Game_Arkanoid : Entity
    {
        //FIELDS
        public static Grid grid;
        public static Paddle paddle;
        public static Ball ball;

        //CONSTRUCTOR
        public Game_Arkanoid()
        {
            Settings.BACKGROUND_COLOR = Color.White;

            paddle = new Paddle();
            grid = new Grid();

            ball = new Ball(paddle);
            paddle.isServing = true;
        }

        //METHODS
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            drawOrder = 500;
            DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center(), Color.Red, matrix);
        }
    }
}
