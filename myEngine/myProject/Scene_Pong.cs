using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_Pong : IScene
    {
        //FIELDS
        public static Input input;
        public static Game_Pong game;
        public UI ui;

        Sprite s;

        //CONSTRUCTOR
        public Scene_Pong()
        {
            input = new Input();
            game = new Game_Pong();
            ui = new UI_Pong();

            s = new Sprite(new Vector2(Settings.Get_Screen_Center().X, Settings.Get_Screen_Center().Y), new Vector2(50, 50));
            s.color = Color.HotPink;
            s.orderInLayer = -1000;
            s.transform.rotation = 45f;
            s.AddComponent(new Collider2D(s));
            s.GetComponent<Collider2D>().scale = 2;
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
            if(input.GetKeyDown(Keys.Tab))
            {
                s = new Sprite(new Vector2(Settings.Get_Screen_Center().X, Settings.Get_Screen_Center().Y), new Vector2(50, 50));
                s.color = Color.HotPink;
                s.orderInLayer = -1000;
                s.transform.rotation = 45f;
                s.AddComponent(new Collider2D(s));
                s.GetComponent<Collider2D>().scale = 2;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
