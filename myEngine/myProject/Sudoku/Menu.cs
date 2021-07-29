using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Menu : Entity
    {
        //FIELDS
        ButtonMenu[] buttons;
        private Cell cellRef;

        //CONSTRUCTOR
        public Menu()
        {
            buttons = new ButtonMenu[9];

            //SHOW CHOICE
            buttons[0] = new ButtonMenu(0, 0, "1");
            buttons[1] = new ButtonMenu(0, 1, "2");
            buttons[2] = new ButtonMenu(0, 2, "3");

            buttons[3] = new ButtonMenu(0, 3, "4");
            buttons[4] = new ButtonMenu(0, 4, "5");
            buttons[5] = new ButtonMenu(0, 5, "6");

            buttons[6] = new ButtonMenu(0, 6, "7");
            buttons[7] = new ButtonMenu(0, 7, "8");
            buttons[8] = new ButtonMenu(0, 8, "9");


            laDouille = new Button();
            laDouille.sprite.dimension = new Vector2(Settings.SCREEN_WIDTH, Settings.SCREEN_HEIGHT);
            laDouille.sprite.transform.position = Settings.Get_Screen_Center();
            laDouille.defaultColor = Color.Transparent;

            laDouille.drawOrder = -999;
            laDouille.sprite.drawOrder = -999;

            laDouille.text.s = "";

            laDouille.onButtonPressed.SetFunction(OnClicOutSide);
        }

        Button laDouille;

        //METHODS
        public void OnClicOutSide()
        {
            UnSubscribePreviousCell();
        }

        public void SubscribeCell(Cell cell)
        {
            UnSubscribePreviousCell();

            cellRef = cell;
            cellRef.SetCellActive();
            SetMenuActive();
        }

        public void UnSubscribePreviousCell()
        {
            cellRef?.SetCellToDefault();
            SetMenuInactive();
        }

        private void SetMenuActive()
        {
            for (int i = 0; i < 9; i++)
            {
                buttons[i].SetCell(cellRef);
                buttons[i].SetButtonActive();
            }
        }

        private void SetMenuInactive()
        {
            for (int i = 0; i < 9; i++)
            {
                buttons[i].RemoveCell();
                buttons[i].SetButtonInactive();
            }
        }

        public override void OnDestroy()
        {
            for (int i = 0; i < 9; i++)
                buttons[i].Destroy();
        }
    }
}
