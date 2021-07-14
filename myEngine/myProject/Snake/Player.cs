using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using myEngine.myProject.Snake;

namespace myEngine.myProject.Snake
{
    public class Player : GameObject
    {
        //FIELDS
        public IntVec2 gridPosition;
        public IntVec2 direction;

        //
        public Sprite head;

        public Sprite s;

        //CONSTRUCTOR
        public Player()
        {
            gridPosition = new IntVec2(0,0);
            direction = new IntVec2(1,0);

            head = new Sprite();
            head.transform.position = new Vector2(1130, 500);
            head.dimension = new Vector2(50, 50);
            head.texture = Ressources.Load<Texture2D>("myContent/2D/Snake_Head");
        }

        public override void Draw(SpriteBatch sprite)
        {
            //DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center(), Color.Red);
            DrawSimpleShape.DrawRuller(head.transform.position, Color.Red);
        }

        float speed = 50;

        //METHODS
        public override void Update()
        {
            //head.transform.rotation += speed * Time.deltaTime;

            if (Input.GetKeyDown(Keys.Up))
            {
                direction = new IntVec2(0,-1);
                head.transform.rotation = 270;
            }

            if (Input.GetKeyDown(Keys.Down))
            {
                direction = new IntVec2(0,1);
                head.transform.rotation = 90;
            }

            if (Input.GetKeyDown(Keys.Left))
            {
                direction = new IntVec2(-1,0);
                head.transform.rotation = 180;
            }

            if (Input.GetKeyDown(Keys.Right))
            {
                direction = new IntVec2(1,0);
                head.transform.rotation = 0;
            }
        }
    }
}
