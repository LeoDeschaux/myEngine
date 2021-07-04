using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_ParentTransform : IScene
    {
        //FIELDS
        Sprite p;
        Sprite c;

        float speed = 500f;

        //CONSTRUCTOR
        public Scene_ParentTransform()
        {
            p = new Sprite();
            p.transform.position = Settings.Get_Screen_Center();

            c = new Sprite();
            c.dimension = Vector2.One * 50;
            c.color = Color.Red;
            c.orderInLayer = 5000;
            
            c.transform.position += Vector2.One*100; // c.transform.position = c.transform.position + Vector2.One
            Console.WriteLine(c.transform.position);

            p.AddChild(c);
            Console.WriteLine(c.transform.position);

            c.transform.position += Vector2.One*100; // c.transform.position = c.transform.position + p.transform.position + Vector2.One
            Console.WriteLine(c.transform.position);
        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKey(Keys.Z))
                p.transform.position.Y -= speed * Time.deltaTime;
            if (Input.GetKey(Keys.S))
                p.transform.position.Y += speed * Time.deltaTime;
            if (Input.GetKey(Keys.Q))
                p.transform.position.X -= speed * Time.deltaTime;
            if (Input.GetKey(Keys.D))
                p.transform.position.X += speed * Time.deltaTime;


            if (Input.GetKey(Keys.A))
                p.transform.rotation -= speed * Time.deltaTime;

            if (Input.GetKey(Keys.E))
                p.transform.rotation += speed * Time.deltaTime;
        }

        public override void Draw(SpriteBatch sprite)
        {
        }
    }
}
