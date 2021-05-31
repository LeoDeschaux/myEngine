using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Trail : Entity
    {
        //FIELDS
        public Transform transform;
        private List<Vector2> positions;
        public bool isVisible = true;

        public int maxPoints;

        //CONSTRUCTOR
        public Trail(Transform transform)
        {
            this.transform = transform;
            positions = new List<Vector2>();
        }

        //METHODS
        public void AddPoints()
        {
            positions.Add(transform.position);

            if (positions.Count > maxPoints)
                positions.RemoveAt(0);
        }

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                float f = ( (float)i+1 / (float)positions.Count ) * 255;

                if (i + 1 < positions.Count)
                    DrawSimpleShape.DrawLine(positions[i], positions[i + 1], new Color(255, 0, 0, (int)f));
            }

            if(positions.Count > 0)
                DrawSimpleShape.DrawLine(positions[positions.Count - 1], transform.position, Color.Red);
        }
    }
}