using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_TwoBitCoding : IScene
    {
        //FIELDS
        Sprite s;

        //CONSTRUCTOR
        public Scene_TwoBitCoding()
        {
            Settings.BACKGROUND_COLOR = Color.CornflowerBlue;

            Text t = new Text("TWO BIT TUTORIAL");
            t.color = Color.White;
            t.alignment = Alignment.Center;
             
            s = new Sprite();
            s.texture = Ressources.Load<Texture2D>("myContent/2D/Character");
            s.transform.position = new Vector2(0, 0);

            Sprite center = new Sprite();
            center.transform.position = new Vector2(0, 0);
            center.color = Color.HotPink;

            this.drawOrder = 5000000;
        }

        //METHODS
        public override void Start()
        {
        }

        public override void Update()
        {
            float speed = 550;

            if(Input.GetKey(Microsoft.Xna.Framework.Input.Keys.Up))
                s.transform.position += new Vector2(0, speed) * Time.deltaTime;

            if (Input.GetKey(Microsoft.Xna.Framework.Input.Keys.Down))
                s.transform.position += new Vector2(0, -speed) * Time.deltaTime;

            if (Input.GetKey(Microsoft.Xna.Framework.Input.Keys.Left))
                s.transform.position += new Vector2(-speed, 0) * Time.deltaTime;

            if (Input.GetKey(Microsoft.Xna.Framework.Input.Keys.Right))
                s.transform.position += new Vector2(speed, 0) * Time.deltaTime;
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawSimpleShape.DrawLine(new Vector2(0, 0), new Vector2(150, 150), Color.Red, matrix, thickness: 5);
        }
    }
}
