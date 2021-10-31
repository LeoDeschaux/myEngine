using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_3D : IScene
    {
        //FIELDS 
        private Camera3D camera;
        private Object3D myObject;
        private Object3D myObject2;

        private float speed = 15f;

        private Floor floor;

        private Shapes3D ss;

        //CONSTRUCTOR
        public Scene_3D()
        {
            Settings.BACKGROUND_COLOR = Color.Gray;

            camera = new Camera3D(Engine.game, new Vector3(0, 1.5f, -10), new Vector3(0,0,0), 15f);

            myObject = new Object3D(camera);
            myObject.transform3D.position = new Vector3(0, 0, 0);
            myObject.drawOrder = 0;
            myObject.isVisible = true;

            myObject2 = new Object3D(camera);
            myObject2.transform3D.position = new Vector3(20, 0, -20);
            myObject2.drawOrder = 1;
            myObject2.isVisible = false;

            this.drawOrder = 10000;

            floor = new Floor(Engine.game.GraphicsDevice, camera, 12, 12, 1);
            ss = new Shapes3D(Engine.game.GraphicsDevice, camera);

            Engine.game.IsMouseVisible = false;
        }

        public override void Update()
        {
            myObject.transform3D.rotation.X += speed * Time.deltaTime;
            myObject.transform3D.rotation.Y += speed * Time.deltaTime;
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            Shapes s = new Shapes(Engine.game);

            s.Begin(null);
            s.DrawCircleFill(new Vector2(Settings.SCREEN_WIDTH/4, -Settings.SCREEN_HEIGHT/4), 8, 12, Color.White);
            s.End();

            Vector3 a = new Vector3(0, 0, 0);
            ss.DrawTriangle(a, 3f, Color.Red);
        }
    }
}