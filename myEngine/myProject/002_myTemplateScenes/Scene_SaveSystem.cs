using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Scene_SaveSystem : IScene
    {
        //FIELDS
        private int playerHealth;

        //CONSTRUCTOR
        public Scene_SaveSystem()
        {
            Settings.BACKGROUND_COLOR = Color.LightSalmon;

            //READ SAVE
            playerHealth = 0;

            //SAVE

        }

        //METHODS
    }
}