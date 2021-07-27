using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Cell : GameObject
    {
        //FIELDS
        Sprite sprite;

        //CONSTRUCTOR
        public Cell(Vector2 position, Vector2 dimension)
        {
            transform.position = position;

            sprite = new Sprite();
            sprite.transform = this.transform;
            sprite.color = Color.White;
            sprite.dimension = new Vector2(dimension.X, dimension.Y);
        }

        public override void Update()
        {
            if (sprite.GetRectangle().Contains(Mouse.mouseState.Position))
            {
                sprite.color = new Color(255, 0, 0, 10);
            }
            else
                sprite.color = Color.White;
        }

        //METHODS
        public override void OnDestroy()
        {
            sprite.Destroy();
        }
    }
}
