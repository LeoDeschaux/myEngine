using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Cell : GameObject
    {
        //FIELDS
        public Button button;

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
        }

        public override void Update()
        {
        }

        //METHODS
        GridMenu menu;
        public void OnClic()
        {
            menu = new GridMenu(this);
        }

        public void OnSubButtonClic()
        {
            menu.Destroy();
        }
        
        public override void OnDestroy()
        {
            button.sprite.Destroy();
        }
    }
}
