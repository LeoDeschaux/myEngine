using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.MineSweeper
{
    public class Cell_Empty : Cell
    {
        //FIELDS

        //CONSTRUCTOR
        public Cell_Empty(Vector2 position, Vector2 dimension, int x, int y) : base(position,dimension, x, y)
        {
            button.onButtonPressed.SetFunction(OnClic);
        }

        //METHODS
        public void GetNumberOfBombAround()
        {
            button.text.s = GridUtils.GetNumberOfBombAround(Game_MineSweeper.grid, this).ToString();
        }

        public void OnClic()
        {
            GetNumberOfBombAround();
            ShowCell();
        }

        public override void ShowCell()
        {
            button.sprite.texture = Ressources.Load<Texture2D>("myContent/2D/CellRevealed");
            button.isActive = false;
            button.disabledColor = Color.White;
        }
    }
}