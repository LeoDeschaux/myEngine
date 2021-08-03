using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.MineSweeper
{
    public abstract class Cell : Entity
    {
        //FIELDS
        public Button button;
        public int x;
        public int y;

        //CONSTRUCTOR
        public Cell(Vector2 position, Vector2 dimension, int x, int y)
        {
            this.x = x;
            this.y = y;

            button = new Button();
            button.transform.position = position;
            button.sprite.dimension = dimension;
            button.sprite.transform = button.transform;
            button.text.transform = button.transform;

            button.text.s = "";
            button.text.drawOrder = button.sprite.drawOrder + 100000;

            button.sprite.texture = Ressources.Load<Texture2D>("myContent/2D/Cell");
        }

        //METHODS
        public abstract void ShowCell();

        public override void OnDestroy()
        {
            button.Destroy();
        }
    }
}
