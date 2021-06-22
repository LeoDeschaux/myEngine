using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class TargetSpawner : Entity
    {
        //FIELDS
        Rectangle zoneRectangle;

        public Target target;

        private Random random;

        //CONSTRUCTOR
        public TargetSpawner()
        {
            random = new Random();

            Vector2 position = Settings.Get_Screen_Center();
            Vector2 dimension = new Vector2(500, Settings.SCREEN_HEIGHT - 100);
            zoneRectangle = new Rectangle((int)(position.X - (dimension.X / 2)), (int)(position.Y - (dimension.Y / 2)), (int)dimension.X, (int)dimension.Y);

            //zoneRectangle = new Rectangle(Settings.Get_Screen_Center().ToPoint(), (Vector2.One * 200).ToPoint());
            SpawnNewTarget();
        }

        //METHODS
        public void SpawnNewTarget()
        {
            if (target == null)
                target = new Target();
        }

        //UPDATE & DRAW
        public override void Update()
        {
            if (target.disposed)
            {
                target = new Target();
                target.transform.position = new Vector2(zoneRectangle.X + (zoneRectangle.Width * (float)random.NextDouble()), 
                                                        zoneRectangle.Y + (zoneRectangle.Height * (float)random.NextDouble()));
                target.sprite.transform.position = target.transform.position;
                target.sprite.orderInLayer = 500;
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
            //DrawSimpleShape.DrawRectangle(zoneRectangle, 0, Color.Red);
        }
    }
}
