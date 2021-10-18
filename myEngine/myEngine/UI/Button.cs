using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Button : EmptyObject
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

        public Event onHoverEnter;
        public Event onHoverExit;
        public Event onButtonPressed;
        public Event onButtonRelease;
        public Event onButtonPressedOutside;
        public Event onButtonReleaseOutside;

        public bool isActive = true;
        public bool isVisible = true;

        //----- COLORS -----
        public Color defaultColor;
        public Color hoverColor;
        public Color onClicColor;
        public Color disabledColor;

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

            sprite = new Sprite(Vector2.Zero, new Vector2(250, 50));
            sprite.color = Color.White;
            sprite.drawOrder = this.drawOrder + 1;

            defaultColor = Color.White;
            hoverColor = Color.LightGray;
            onClicColor = Color.DarkGray;
            disabledColor = Color.DarkGray;

            text = new Text();
            text.drawOrder = this.drawOrder + 2;

            text.alignment = Alignment.Center;

            //image = new Image(img);

            //image.transform.SetParent(this.transform);
            //text.transform.SetParent(this.transform);
            
            isActive = true;

            onHoverEnter = new Event();
            onHoverExit = new Event();
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

        private void HoverEnter()
        {
            Button.buttonsSelected.Add(this);
        }

        private void HoverExit()
        {
            isSelected = false;
            buttonState = ButtonState.unselected;
            Button.buttonsSelected.Remove(this);
        }

        private void ButtonSelected()
        {
            isSelected = true;
            buttonState = ButtonState.hover;
        }

        ButtonState buttonState;
        ButtonState previousState;

        bool hoverState = false;
        bool previousHoverState = false;
        bool isSelected = false;
        bool isPressed = false;

        bool mouseDown = false;
        bool previousMouseDown = false;


        public override void Update()
        {
            if (!isActive || !isVisible)
            {
                sprite.color = disabledColor;
                return;
            }

            previousState = buttonState;
            buttonState = ButtonState.unselected;

            previousMouseDown = mouseDown;
            mouseDown = Input.GetMouse(MouseButtons.Left);

            Vector2 mousePosition = Util.ScreenToWorld(SceneManager.currentScene.camera.transformMatrix, Mouse.position.ToVector2());
            mousePosition = new Vector2(mousePosition.X, -mousePosition.Y);

            previousHoverState = hoverState;
            if (sprite.GetRectangle().Contains(mousePosition))
                hoverState = true;
            else
            {
                hoverState = false;

                if (mouseDown && !previousMouseDown)
                    OnButtonPressedOutside();
            }

            if (hoverState == true && previousHoverState == false)
                HoverEnter();

            if (hoverState && IsOnTop())
            {
                ButtonSelected();

                //CHECK INPUT
                if (Input.GetMouseDown(MouseButtons.Left))
                {
                    buttonState = ButtonState.clicked;
                    isPressed = true;

                    OnButtonPressed();
                }
            }
            else
            {
                if (isSelected)
                    HoverExit();
                else if (hoverState == false && previousHoverState == true)
                    HoverExit();
            }

            //CHECK INPUT
            if (Input.GetMouseUp(0) && isPressed)
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

            if (buttonState == ButtonState.hover && previousState != ButtonState.hover)
                OnHoverEnter();
            if (buttonState != ButtonState.hover && previousState == ButtonState.hover)
                OnHoverExit();

            if (isPressed)
                sprite.color = onClicColor;
        }

        public void OnHoverEnter() { onHoverEnter?.Invoke(); }
        public void OnHoverExit() { onHoverExit?.Invoke(); }

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