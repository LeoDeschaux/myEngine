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
            if (!AudioEngine.audioDeviceConnected)
                return;

            if (soundEffect == null)
                return;

            random = new Random(); 

            float maxVolume = AudioEngine.MasterMixer.volume;
            float volume = 0.8f + ( ((float)random.NextDouble()) / 5f );
            volume = volume * maxVolume;

            float maxPitch = 0.1f;
            float pitch = 0f + ( ((float)random.NextDouble()) /  (1f/maxPitch) );

            float pan = 0.0f;

            volume = Math.Clamp(volume, 0, 1);
            pitch = Math.Clamp(pitch, 0, 1);
            pan = Math.Clamp(pan, 0, 1);

            soundEffect.Play(volume, pitch, pan);
        }
    }
}
