using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.MineSweeper
{
    public class Cell_Bomb : Cell
    {
        //FIELDS

        //CONSTRUCTOR

        public Cell_Bomb(Vector2 position, Vector2 dimension, int x, int y) : base(position, dimension, x, y)
        {
            button.defaultColor = Color.Pink;
            button.hoverColor = Color.Red;

            button.onButtonPressed.SetFunction(OnClic);
        }

        //METHODS
        public void OnClic()
        {
            ShowCell();
        }

        public override void ShowCell()
        {
            Console.WriteLine("BOMB, YOU LOOSE");

            button.sprite.texture = Ressources.Load<Texture2D>("myContent/2D/Mine");
            button.isActive = false;
            button.disabledColor = Color.White;
        }
    }
}
