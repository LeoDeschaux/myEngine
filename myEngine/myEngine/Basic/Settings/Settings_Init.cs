﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace myEngine
{
    public class Settings_Init
    {
        public static void InitSettingsFromFile(Settings settings)
        {
            /*
            var iniFile = new IniFile("options.ini");

            //string s = iniFile.GetInteger("Section", "variable", "defaultValue");
            //int i = iniFile.GetInteger("Section", "variable", "defaultValue");
            //bool b = iniFile.GetBoolean("Section", "variable", "defaultValue");

            bool b = iniFile.GetBoolean("Options", "FullScreen", false);
            Engine.graphics.IsFullScreen = b;

            int x = iniFile.GetInteger("Options", "Screen_Width", 1280);
            int y = iniFile.GetInteger("Options", "Screen_Height", 720);

            Engine.graphics.PreferredBackBufferWidth = x;
            Engine.graphics.PreferredBackBufferHeight = y;

            Settings.SCREEN_WIDTH = x;
            Settings.SCREEN_HEIGHT = y;

            Engine.game.graphics.SynchronizeWithVerticalRetrace = false;
            Engine.game.IsFixedTimeStep = false;

            Engine.graphics.ApplyChanges();
            */
        }
    }
}
