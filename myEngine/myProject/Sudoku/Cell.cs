using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Cell : GameObject
    {
        //FIELDS
        Button button;

        //CONSTRUCTOR
        public Cell(Vector2 position, Vector2 dimension)
        {
            transform.position = position;

            button = new Button();
            button.transform = this.transform;
            button.sprite.transform = this.transform;
            button.text.transform = this.transform;

            button.sprite.color = Color.White;
            button.sprite.dimension = new Vector2(dimension.X, dimension.Y);

            button.text.s = "";
            button.text.alignment = Alignment.Center;

            button.onButtonPressed.PlayFunction(OnClic);
            button.onButtonRelease.PlayFunction(OnClicRelease);
        }

        public override void Update()
        {
        }

        //METHODS
        Button b;
        public void OnClic()
        {
            //SHOW CHOICE
            b = new Button();
            b.transform.position = this.transform.position + new Vector2(this.button.sprite.dimension.X + 10, 0);
            b.sprite.transform = b.transform;
            b.text.transform = b.transform;

            b.sprite.dimension = button.sprite.dimension;
            b.drawOrder = button.drawOrder + 10;
            b.sprite.drawOrder = b.drawOrder + 11;
            b.text.drawOrder = b.drawOrder + 12;
            b.text.s = "1";
            b.text.alignment = Alignment.Center;

            b.defaultColor = Color.Red;
        }

        public void OnClicRelease()
        {
            b.Destroy();
        }
        
        public override void OnDestroy()
        {
            button.sprite.Destroy();
        }
    }
}
