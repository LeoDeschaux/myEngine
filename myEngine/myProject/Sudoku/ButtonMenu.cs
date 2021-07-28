using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class ButtonMenu : GameObject
    {
        //FIELDS
        Button b;

        Cell cell;
        string number;

        //CONSTRUCTOR
        public ButtonMenu(Cell cell, int posX, int posY, string number)
        {
            b = new Button();

            this.cell = cell;
            Button button = cell.button;

            this.number = number;

            //this.b.transform.position = button.transform.position;

            Vector2 offSet = new Vector2(-1 * (button.sprite.dimension.X + Grid.marginX), -1 * (button.sprite.dimension.Y + Grid.marginY));
            Vector2 position = new Vector2(posX * (button.sprite.dimension.X + Grid.marginX), posY * (button.sprite.dimension.Y + Grid.marginY));
            b.transform.position = button.transform.position + offSet + position;
            b.sprite.transform = b.transform;
            b.text.transform = b.transform;

            b.sprite.dimension = button.sprite.dimension;
            b.drawOrder = button.drawOrder + 10;
            b.sprite.drawOrder = b.drawOrder + 11;
            b.text.drawOrder = b.drawOrder + 12;
            b.text.s = number;
            b.text.alignment = Alignment.Center;

            b.defaultColor = Color.Red;

            b.onButtonPressed.SetFunction(OnClic);
        }

        //METHODS
        private void OnClic()
        {
            cell.button.text.s = this.number;
            cell.OnSubButtonClic();
        }

        public override void OnDestroy()
        {
            b.Destroy();
        }
    }
}
