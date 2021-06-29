using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace myEngine
{
    public class AudioEngine
    {
        //FIELDS
        public static AudioMixer MasterMixer;

        public static bool audioDeviceConnected = false;

        //CONSTRUCTOR
        public AudioEngine()
        {
            MasterMixer = new AudioMixer();
            MasterMixer.volume = 0.2f;

            try
            {
                SoundEffect.Initialize();
                AudioEngine.audioDeviceConnected = true;
            }
            catch (NoAudioHardwareException ex)
            {
                AudioEngine.audioDeviceConnected = false;
            }
        }

        //METHODS
    }
}
