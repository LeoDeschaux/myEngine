using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Cell : GameObject
    {
        //FIELDS
        public int posX, posY;
        public Button button;

        bool isCellSelected = false;
        bool finishedSpawned = false;

        Sprite overlaySprite;

        //CONSTRUCTOR
        public Cell(Vector2 position, Vector2 dimension, int posX, int posY)
        {
            transform.position = position;
            this.posX = posX;
            this.posY = posY;

            button = new Button();
            button.transform = this.transform;
            button.sprite.transform = this.transform;
            button.text.transform = this.transform;

            button.sprite.color = Color.White;
            button.sprite.dimension = new Vector2(dimension.X, dimension.Y);

            button.text.s = "";
            button.text.alignment = Alignment.Center;

            button.onButtonPressed.SetFunction(OnClic);
            //button.onButtonRelease.PlayFunction(SetIsReady);
            //button.onButtonPressedOutside.SetFunction(ClicOutside);
            button.onHoverEnter.SetFunction(OnHoverEnter);
            button.onHoverExit.SetFunction(OnHoverExit);

            //CURSOR
            overlaySprite = new Sprite();
            overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/cursor");
            overlaySprite.transform.position = this.transform.position;
            overlaySprite.dimension = this.button.sprite.dimension;
            overlaySprite.color = Color.Blue;
            overlaySprite.drawOrder = this.drawOrder + 20;
            overlaySprite.isVisible = false;
        }

        public override void Update()
        {
        }
        
        //METHODS
        public void OnHoverEnter()
        {
            if(isCellSelected == false)
            {
                overlaySprite.isVisible = true;
                overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/cursor");
            }
        }

        public void OnHoverExit()
        {
            if (isCellSelected == false)
            {
                overlaySprite.isVisible = false;
            }
        }

        public void OnClic()
        {
            Game_Sudoku.menu.SubscribeCell(this);
        }

        public void SetCellActive()
        {
            isCellSelected = true;
            button.defaultColor = Color.LightBlue;
            button.hoverColor = Color.LightBlue;
            
            overlaySprite.isVisible = true;
            overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/border");
        }

        public void SetCellToDefault()
        {
            isCellSelected = false;
            button.defaultColor = Color.White;
            button.hoverColor = Color.Gray;

            overlaySprite.isVisible = false;
        }

        public override void OnDestroy()
        {
            button.sprite.Destroy();
        }
    }
}
