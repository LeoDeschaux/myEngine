using Microsoft.Xna.Framework;
using Microsoft.Xna;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Debug_UI : EmptyObject
    {
        //FIELDS
        Text debugMode;
        Text releaseMode;
        Text mousePosition;
        Text entities;
        Text components;
        Text frameRate;
        Text timeSpeed;

        bool isVisible;
        Color textColor;
        int textSize;
        int orderInLayer;

        List<Text> texts;

        //CONSTRUCTOR
        public Debug_UI()
        {
            this.dontDestroyOnLoad = true;

            isVisible = true;
            orderInLayer = 999;
            textColor = Color.White;
            textSize = 40;

            texts = new List<Text>();

            debugMode = new Text();
            releaseMode = new Text();
            mousePosition = new Text();
            entities = new Text();
            components = new Text();
            frameRate = new Text();
            timeSpeed = new Text();

            texts.Add(debugMode);
            texts.Add(releaseMode);
            texts.Add(mousePosition);
            texts.Add(entities);
            texts.Add(components);
            texts.Add(frameRate);
            texts.Add(timeSpeed);

            foreach(Text t in texts)
            {
                t.isVisible = isVisible;
                t.drawOrder = orderInLayer;
                t.color = textColor;
                t.fontSize = textSize;
                t.dontDestroyOnLoad = true;
            }
        }

        //METHODS
        public override void Update()
        {
            if (!isVisible)
                return;

            debugMode.s = "Debug Mode: " + Settings.DEBUG_MODE;
            releaseMode.s = "\nRelease Mode: " + Settings.RELEASE_MODE;
            mousePosition.s = "\n\nMouse Position: " + Mouse.position.ToVector2().ToString();
            entities.s = "\n\n\nNumber of entities: " + World.entities.Count;
            components.s = "\n\n\n\nNumber of components: " + World.components.Count;
            frameRate.s = "\n\n\n\n\nFrameRate: " + ((int)(1 / (float)Time.gameTime.ElapsedGameTime.TotalSeconds)).ToString();
            timeSpeed.s = "\n\n\n\n\n\nTime Speed: " + Settings.GAME_SPEED;
        }

        public string ReturnText()
        {
            return "";
        }

        public void SetVisible(bool b)
        {
            isVisible = b;

            foreach (Text t in texts)
            {
                t.isVisible = isVisible;
            }
        }

        public override void OnDestroy()
        {
            foreach (Text t in texts)
            {
                t.Destroy();
            }
        }
    }
}
