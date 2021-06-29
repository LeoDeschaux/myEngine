using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class AudioMixer
    {
        //FIELDS
        private float _volume = 0.3f;
        public float volume
        {
            get { return _volume; }
            set { _volume = Math.Clamp(value, 0, 1); }
        }

        //CONSTRUCTOR
        public AudioMixer()
        {

        }

        //METHODS
    }
}