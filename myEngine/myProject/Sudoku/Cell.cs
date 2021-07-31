﻿using Microsoft.Xna.Framework;
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

        public bool isSealled = false;

        Sprite overlaySprite;

        public Color color = Color.White;

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

            button.sprite.color = color;
            button.sprite.dimension = new Vector2(dimension.X, dimension.Y);

            button.text.s = "";
            button.text.alignment = Alignment.Center;

            button.onButtonPressed.SetFunction(OnClic);
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

        //METHODS
        public void SetSelled(bool b)
        {
            isSealled = b;

            if (isSealled)
                button.isActive = false;
            else
                button.isActive = true;
        }

        public void SetColor(Color color)
        {
            this.color = color;

            button.defaultColor = color;
            button.hoverColor = color;
        }

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
            SetColor(Color.LightBlue);
            
            overlaySprite.isVisible = true;
            overlaySprite.texture = Ressources.Load<Texture2D>("myContent/2D/border");
        }

        public void SetCellToDefault()
        {
            isCellSelected = false;
            SetColor(color);

            overlaySprite.isVisible = false;
        }
    }
}
