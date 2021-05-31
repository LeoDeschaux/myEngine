using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class AudioSource
    {
        //FIELDS
        private static Random random;

        //CONSTRUCTOR
        public AudioSource()
        {
            
        }

        //METHODS
        public static void PlaySoundEffect(SoundEffect soundEffect)
        {
            random = new Random();

            //float volume = 1f + ((float)random.NextDouble()*1.5f) - 1.5f/2;

            float maxVolume = 0.1f;
            float volume = 0.8f + (((maxVolume * 2) * (float)random.NextDouble()) - maxVolume);

            float maxPitch = 0.1f;
            float pitch = 0f + (((maxPitch * 2) * (float)random.NextDouble()) - maxPitch);

            float pan = 0.0f;

            soundEffect.Play(volume, pitch, pan);
        }
    }
}
