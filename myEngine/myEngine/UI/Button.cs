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
        private static List<Button> instance = null;
        public static List<Button> buttonsSelected
        {
            get
            {
                if (instance == null)
                {
                    instance = new List<Button>();
                }
                return instance;
            }
        }

        public Transform transform;

        //public Image image;
        public Text text;
        public Sprite sprite;

        public Event onButtonPressed;
        public Event onButtonRelease;

        public Event onButtonPressedOutside;
        public Event onButtonReleaseOutside;

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
            sprite.transform = this.transform;
            sprite.color = Color.White;
            sprite.drawOrder = this.drawOrder + 1;

            defaultColor = Color.White;
            hoverColor = Color.LightGray;
            onClicColor = Color.DarkGray;

            text = new Text();
            text.transform = this.transform;
            text.drawOrder = this.drawOrder + 2;

            //image = new Image(img);

            //image.transform.SetParent(this.transform);
            //text.transform.SetParent(this.transform);
            
            isActive = true;

            onButtonPressed = new Event();
            onButtonRelease = new Event();
            onButtonPressedOutside = new Event();
            onButtonReleaseOutside = new Event();
        }

        public enum ButtonState
        {
            unselected,
            hover,
            clicked
        }

        //UPDATE & DRAW
        private bool IsOnTop()
        {
            bool isOnTop = false;
            if (Button.buttonsSelected.Count > 0)
            {
                int maxDrawOrder = buttonsSelected[0].drawOrder;
                foreach (Button b in buttonsSelected)
                {
                    if (b.drawOrder >= maxDrawOrder)
                        maxDrawOrder = b.drawOrder;
                }

                if (this.drawOrder == maxDrawOrder)
                {
                    isOnTop = true;
                }
            }
            else
                isOnTop = true;

            return isOnTop;
        }

        private void OnHoverEnter()
        {
            Button.buttonsSelected.Add(this);
        }

        private void OnHoverExit()
        {
            isSelected = false;
            buttonState = ButtonState.unselected;
            Button.buttonsSelected.Remove(this);
        }

        private void OnButtonSelected()
        {
            isSelected = true;
            buttonState = ButtonState.hover;
        }

        ButtonState buttonState;
        bool hoverState = false;
        bool previousHoverState = false;
        bool isSelected = false;
        bool isPressed = false;

        bool mouseDown = false;
        bool previousMouseDown = false;

        public override void Update()
        {
            if (!isActive || !isVisible)
                return;

            buttonState = ButtonState.unselected;

            previousMouseDown = mouseDown;
            mouseDown = Mouse.GetMouse(MouseButton.Left);

            previousHoverState = hoverState;
            if (sprite.GetRectangle().Contains(Mouse.position))
                hoverState = true;
            else
            {
                hoverState = false;

                if (mouseDown && !previousMouseDown)
                    OnButtonPressedOutside();
            }

            if (hoverState == true && previousHoverState == false)
                OnHoverEnter();

            if (hoverState && IsOnTop())
            {
                OnButtonSelected();

                //CHECK INPUT
                if (Mouse.GetMouseDown(MouseButton.Left))
                {
                    buttonState = ButtonState.clicked;
                    isPressed = true;

                    OnButtonPressed();
                }
            }
            else
            {
                if (isSelected)
                    OnHoverExit();
                else if (hoverState == false && previousHoverState == true)
                    OnHoverExit();
            }

            //CHECK INPUT
            if (Mouse.GetMouseUp(0) && isPressed)
            {
                if (buttonState == ButtonState.hover)
                {
                    OnRelease();
                }
                else
                    OnReleaseOutSide();

                isPressed = false;
            }

            //SET COLORS 
            if (buttonState == ButtonState.unselected)
                sprite.color = defaultColor;
            else if (buttonState == ButtonState.hover)
                sprite.color = hoverColor;
            else if (buttonState == ButtonState.clicked)
                sprite.color = onClicColor;

            if (isPressed)
                sprite.color = onClicColor;
        }

        //public void OnHoverEnter() { }
        //public void OnHoverExit() { }

        public void OnRelease() { onButtonRelease?.Invoke(); }
        public void OnReleaseOutSide() { onButtonReleaseOutside?.Invoke(); }

        public void OnButtonPressed() { onButtonPressed?.Invoke(); }
        public void OnButtonPressedOutside() { onButtonPressedOutside?.Invoke(); }

        public override void OnDestroy()
        {
            Button.buttonsSelected.Remove(this);

            sprite.Destroy();
            text.Destroy();
        }
    }
}