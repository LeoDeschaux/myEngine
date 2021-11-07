using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class CameraMouseController : EmptyObject
    {
        //FIELDS
        float speed = 500;
        Vector2 deltaMouse;
        float speedMouse = 1;

        public bool isActive;

        public Rectangle boundingBox;

        //REF
        Camera2D camera;

        //CONSTRUCTOR
        public CameraMouseController(Camera2D camera)
        {
            this.camera = camera;
            isActive = false;
            boundingBox = new Rectangle(0, 0, 0, 0);

            oldCamMatrix = camera.transformMatrix;
        }

        //METHODS
        Matrix oldCamMatrix;
        bool hasBeenPressed = false;

        //SCROLL WHEEL
        float previousScrollValue;
        MouseState currentMouseState;

        public override void Update()
        {
            if (!isActive)
                return;

            //////////////// NOTE ////////////
            ///to do the shaking bug, replace oldCamMatrix with camera.transformMatrix
            //////////////////////////////////
            if (Mouse.position.X < Settings.VIEWPORT_WIDTH)
            {
                //MOUSE CAM CONTROLE
                if (Input.GetMouseDown(MouseButtons.Left))
                {
                    oldCamMatrix = camera.transformMatrix;
                    deltaMouse = Util.ScreenToWorld(oldCamMatrix, Mouse.position.ToVector2());
                    hasBeenPressed = true;
                }

                if (Input.GetMouse(MouseButtons.Left) && hasBeenPressed)
                {
                    Vector2 nextPos = camera.transform.position + ((deltaMouse - Util.ScreenToWorld(oldCamMatrix, Mouse.position.ToVector2()) * speedMouse));

                    if(boundingBox != new Rectangle(0,0,0,0))
                    {
                        if (nextPos.X > boundingBox.X && nextPos.X < boundingBox.Width)
                            camera.transform.position.X = nextPos.X;
                        if (nextPos.Y > boundingBox.Y && nextPos.Y < boundingBox.Height)
                            camera.transform.position.Y = nextPos.Y;
                    }
                    else
                    {
                        camera.transform.position = nextPos;
                    }
                
                    deltaMouse = Util.ScreenToWorld(oldCamMatrix, Mouse.position.ToVector2());
                }

                if(Input.GetMouseUp(MouseButtons.Left))
                {
                    hasBeenPressed = false;
                }
            }


            //WHEEL ZOOM
            currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            
            if(Engine.renderingEngine.viewPort.Bounds.Contains(Mouse.position))
            {
                if (currentMouseState.ScrollWheelValue < previousScrollValue)
                {
                    camera.ZoomAt(Util.ScreenToWorld(camera.transformMatrix, new Vector2((1280 - 300) / 2, 720 / 2)), -0.5f);
                }
                else if (currentMouseState.ScrollWheelValue > previousScrollValue)
                {
                    camera.ZoomAt(Util.ScreenToWorld(camera.transformMatrix, new Vector2((1280 - 300) / 2, 720 / 2)), 0.5f);
                }
            }
            
            previousScrollValue = currentMouseState.ScrollWheelValue;
        }
    }
}
