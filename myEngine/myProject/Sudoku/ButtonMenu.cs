using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class ButtonMenu : GameObject
    {
        //FIELDS
        public Button b;
        public string number;

        //BUTTON PROPERTIES
        Vector2 dimension = new Vector2(70, 70);
        Vector2 startPos = new Vector2(50, 50);
        Color userInputColor = new Color(80, 80, 255);

        Sprite overlaySprite;

        //CONSTRUCTOR
        public ButtonMenu(int posX, int posY, string number)
        {
            b = new Button();

            this.number = number;

            Vector2 offSet = new Vector2(startPos.X, startPos.Y);
            Vector2 position = new Vector2(posX * (dimension.X + Grid.marginX), posY * (dimension.Y + Grid.marginY));
            b.transform.position = this.transform.position + offSet + position;
            b.sprite.transform = b.transform;
            b.text.transform = b.transform;

            b.sprite.dimension = dimension;
            b.drawOrder = this.drawOrder + 10;
            b.sprite.drawOrder = b.drawOrder + 11;
            b.text.drawOrder = b.drawOrder + 12;
            b.text.s = number;
            b.text.alignment = Alignment.Center;

            b.defaultColor = Color.White;
            b.isActive = false;

            b.onButtonPressed.SetFunction(OnClic);

            //LOCK SPRITE
            overlaySprite = new Sprite();
            overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/locked");
            overlaySprite.transform.position = this.b.sprite.transform.position;
            overlaySprite.dimension = this.b.sprite.dimension;
            overlaySprite.color = Color.Blue;
            overlaySprite.drawOrder = this.drawOrder + 200;
            overlaySprite.isVisible = true;
        }

        //METHODS
        public void SetCell(Cell cell)
        {
            b.onButtonPressed.SetFunction(OnClic);
            this.cell = cell;
        }

        public void RemoveCell()
        {
            this.cell = null;
        }

        public void SetButtonActive()
        {
            this.b.isActive = true;
            overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/border");
        }

        public void SetButtonInactive()
        {
            this.b.isActive = false;
            overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/locked");
        }

        Cell cell;
        private void OnClic()
        {
            if(cell != null)
            {
                cell.button.text.s = this.number;
                //cell.button.text.color = userInputColor;

                if (GridUtils.isCellValid(Game_Sudoku.board, cell))
                    cell.SetColor(Color.Green);
                else
                    cell.SetColor(Color.Red);
            }
        }

        public override void OnDestroy()
        {
            b.Destroy();
        }
    }
}
