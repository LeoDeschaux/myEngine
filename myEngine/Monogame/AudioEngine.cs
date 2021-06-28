using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace myEngine
{
    public class AudioEngine
    {
        //FIELDS
        public static bool audioDeviceConnected = false;

        //CONSTRUCTOR
        public AudioEngine()
        {
            try
            {
                SoundEffect.Initialize();
            }
            catch (NoAudioHardwareException ex)
            {
                AudioEngine.audioDeviceConnected = false;
            }

        }

        //METHODS
    }
}
