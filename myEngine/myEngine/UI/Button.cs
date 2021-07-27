using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Button : Entity
    {
        //COMPONENTS
        public Transform transform;

        //public Image image;
        public Text text;
        public Sprite sprite;

        public event EventHandler onButtonPressed;
        private bool isActive;
        public bool isVisible = true;

        //----- COLORS -----
        public Color defaultColor;
        public Color hoverColor;
        public Color onClicColor;
        //unaviable

        // SETTERS
        public void SetActive(bool b)
        {
            //Color c = b ? Color.White : Color.Gray;
            //image.SetColor(c);

            isActive = b;
        }

        //CONSTRUCTOR
        public Button(Texture2D img = null)
        {
            transform = new Transform();

            sprite = new Sprite(Vector2.Zero, Vector2.One * 50);
            sprite.color = Color.White;

            defaultColor = Color.White;
            hoverColor = Color.LightGray;
            onClicColor = Color.DarkGray;

            text = new Text();

            //image = new Image(img);

            //image.transform.SetParent(this.transform);
            //text.transform.SetParent(this.transform);
            
            isActive = true;
        }

        bool isPressed = false;

        //UPDATE & DRAW
        public override void Update()
        {

            if (!isActive || !isVisible)
                return;

            if (sprite.GetRectangle().Contains(Mouse.mouseState.Position))
            {
                if(!isPressed)
                    sprite.color = hoverColor;

                if (Mouse.GetMouseDown(0))
                {
                    sprite.color = onClicColor;

                    isPressed = true;

                    if(onButtonPressed != null)
                        onButtonPressed(this, EventArgs.Empty);
                }
            }
            else
                sprite.color = defaultColor;


            if (Mouse.GetMouseUp(0))
            {
                sprite.color = defaultColor;
                isPressed = false;
            }

        }

        public override void OnDestroy()
        {
            sprite.Destroy();
            text.Destroy();
        }
    }
}