using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public class Scene_DrawTest : IScene
    {
        //FIELDS
        Vector2[] positions;
        Color[] colors;
        int amountOfShapes = 50;
        int amountOfPositions;

        Stopwatch watch;
        
        Shapes shapes;

        //CONSTRUCTOR
        public Scene_DrawTest()
        {
            Settings.BACKGROUND_COLOR = Color.CornflowerBlue;


            shapes = new Shapes(Engine.game);
            Random random = new Random(0);
            watch = new Stopwatch();

            amountOfPositions = amountOfShapes * 2;
            positions = new Vector2[amountOfPositions];

            colors = new Color[amountOfShapes];

            for (int i = 0; i < amountOfPositions; i++)
                positions[i] = new Vector2((float)random.NextDouble() * Settings.SCREEN_WIDTH, (float)random.NextDouble() * Settings.SCREEN_HEIGHT);

            for(int i = 0; i < amountOfShapes; i++)
                colors[i] = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

            Util.DisplayMatrix(Matrix.CreateOrthographicOffCenter(0, 1280, 720, 0, 0, 1));
        }


        //METHODS
        public override void Update()
        {
            if(Input.GetKeyDown(Keys.P))
            {
                Console.WriteLine(watch.Elapsed.TotalMilliseconds);
            }

            if (Input.GetKeyDown(Keys.Subtract))
            {
                pointsCircle--;
            }

            if (Input.GetKeyDown(Keys.Add))
            {
                pointsCircle++;
            }
        }

        int pointsCircle = 3;

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            watch.Restart();

            shapes.Begin(camera);

            //shapes.DrawLine(new Vector2(100, 100), Mouse.position.ToVector2(), 50, Color.Red);
            for (int i = 0; i < amountOfPositions; i += 2)
            {
                //shapes.DrawCircle(new Vector2(120, 120), 50, 3, 3, Color.Green);
                //shapes.DrawRectangle(50, 50, 200, 500, 3, Color.Black);
                //shapes.DrawLine(Vector2.Zero, new Vector2(100, 100), 5, Color.Red);

                //shapes.DrawLine(positions[i], positions[i + 1], 3, colors[i/2]);
                //shapes.DrawRectangle(positions[i].X, positions[i].Y, positions[i + 1].X, positions[i + 1].Y, 3, colors[i / 2]);
                //shapes.DrawCircle(positions[i], 50, 12, 4, colors[i / 2]);
                
                
                shapes.DrawCircleFill(Settings.GetScreenCenter(), 40, pointsCircle, Color.Red);

                //DrawSimpleShape.DrawRectangleFull(positions[i], positions[i + 1], Color.Yellow, null);
            }

            shapes.End();

            shapes.Begin(camera);


            //shapes.DrawCircle(Settings.GetScreenCenter(), 40, 3, 12, Color.Red);

            shapes.DrawCircleFill(Vector2.Zero, 150, 3, Color.Red);



            //shapes.DrawLine(new Vector2(100, 100), Mouse.position.ToVector2(), 50, Color.Red);
            shapes.End();

            watch.Stop();
        }
    }
}
