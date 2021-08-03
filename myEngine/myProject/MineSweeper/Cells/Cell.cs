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

        public bool revealed = false;
        private bool isMarked = false;

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
        public override void Update()
        {
            if (Mouse.GetMouseDown(MouseButton.Right) && button.sprite.GetRectangle().Contains(Mouse.position))
                OnLeftClic();
        }
        public abstract void OnClic();

        public virtual void OnLeftClic()
        {
            if (!isMarked)
            {
                isMarked = true;
                button.sprite.texture = Ressources.Load<Texture2D>("myContent/2D/Crossed");
            }
            else
            {
                isMarked = false;
                button.sprite.texture = Ressources.Load<Texture2D>("myContent/2D/Cell");
            }
        }

        public virtual void ShowCell()
        {
            revealed = true;

            Game_MineSweeper.grid.OnShowCell(this);

            button.isActive = false;
            button.disabledColor = Color.White;
        }

        public override void OnDestroy()
        {
            button.Destroy();
        }
    }
}
