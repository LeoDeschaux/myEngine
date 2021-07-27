using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class GridMenu : Entity
    {
        //FIELDS
        ButtonMenu[] buttons;

        //CONSTRUCTOR
        public GridMenu(Cell cell)
        {
            buttons = new ButtonMenu[9];

            //SHOW CHOICE
            buttons[0] = new ButtonMenu(cell, 0, 0, "1");
            buttons[1] = new ButtonMenu(cell, 1, 0, "2");
            buttons[2] = new ButtonMenu(cell, 2, 0, "3");

            buttons[3] = new ButtonMenu(cell, 0, 1, "4");
            buttons[4] = new ButtonMenu(cell, 1, 1, "5");
            buttons[5] = new ButtonMenu(cell, 2, 1, "6");

            buttons[6] = new ButtonMenu(cell, 0, 2, "7");
            buttons[7] = new ButtonMenu(cell, 1, 2, "8");
            buttons[8] = new ButtonMenu(cell, 2, 2, "9");


            //b.onButtonRelease.PlayFunction(OnSubButtonClic);
        }

        //METHODS
        public override void OnDestroy()
        {
            for (int i = 0; i < 9; i++)
                buttons[i].Destroy();
        }
    }
}
