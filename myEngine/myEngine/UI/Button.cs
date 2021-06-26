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

        public Image image;
        public Text text;
        public Sprite sprite;

        public event EventHandler onButtonPressed;
        private bool isActive;
        public bool isVisible = true;

        //----- COLORS -----
        //default
        //hover
        //onClic
        //unaviable

        // SETTERS
        public void SetActive(bool b)
        {
            Color c = b ? Color.White : Color.Gray;
            image.SetColor(c);

            isActive = b;
        }

        //CONSTRUCTOR
        public Button(Texture2D img = null)
        {
            transform = new Transform();

            sprite = new Sprite(Vector2.Zero, Vector2.One * 50);
            sprite.color = Color.Red;

            text = new Text();

            //image = new Image(img);

            //image.transform.SetParent(this.transform);
            //text.transform.SetParent(this.transform);
            
            isActive = true;
        }

        //UPDATE & DRAW
        public override void Update()
        {

            if (!isActive || !isVisible)
                return;

            if (sprite.GetRectangle().Contains(Mouse.mouseState.Position))
            {
                sprite.color = Color.LightGray;

                if (Mouse.GetMouseDown(0))
                {
                    sprite.color = Color.Black;

                    if(onButtonPressed != null)
                        onButtonPressed(this, EventArgs.Empty);
                }
            }
            else
            {
                sprite.color = Color.White;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!isVisible)
                return;
        }

        public override void OnDestroy()
        {
            sprite.Destroy();
            text.Destroy();
        }
    }
}