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

        private bool isActive = false;

        //CONSTRUCTOR
        public TargetSpawner()
        {
            random = new Random(123456789);

            Vector2 position = Settings.Get_Screen_Center();
            Vector2 dimension = new Vector2(500, Settings.SCREEN_HEIGHT - 100);
            zoneRectangle = new Rectangle((int)(position.X - (dimension.X / 2)), (int)(position.Y - (dimension.Y / 2)), (int)dimension.X, (int)dimension.Y);

            //zoneRectangle = new Rectangle(Settings.Get_Screen_Center().ToPoint(), (Vector2.One * 200).ToPoint());
            //SpawnNewTarget();
        }

        Delay delay;
        public void SpawnNewTarget()
        {
            if(delay != null)
                delay.Destroy();

            delay = new Delay(2000, () =>
            {
                SpawnTarget();
            });
        }

        public void Start()
        {
            isActive = true;
            SpawnNewTarget();
        }

        //METHODS
        public void SpawnTarget()
        {
            if (!isActive)
                return;

            if (target == null)
                target = new Target();

            if (target.disposed)
            {
                target = new Target();
                target.transform.position = new Vector2(zoneRectangle.X + (zoneRectangle.Width * (float)random.NextDouble()),
                                                        zoneRectangle.Y + (zoneRectangle.Height * (float)random.NextDouble()));
                target.sprite.transform.position = target.transform.position;
                target.sprite.orderInLayer = 500;
            }
        }

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch sprite)
        {
            //DrawSimpleShape.DrawRectangle(zoneRectangle, 0, Color.Red);
        }
    }
}
