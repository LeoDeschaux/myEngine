using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class SimpleTween : Entity
    {
        //FIELDS
        public float startValue { get; private set; }
        public float endValue { get; private set; }
        public float difference { get; private set; }

        private float duration;
        private float timer;

        public bool isPlaying { get; private set; }
        public bool asEnded { get; private set; }
        private bool playOnlyOnce;

        public float value { get; private set; }

        //handle delay
        private bool start;
        private float delay;
        private float timerDelay;

        public float speed = 1000f;

        //CONSTRUCTOR
        public SimpleTween(float startValue, float endValue, float duration, float delay = 0, bool playOnlyOnce = true)
        {
            this.startValue = startValue;
            this.endValue = endValue;
            this.duration = duration * 1000;
            this.delay = delay * 1000;
            this.playOnlyOnce = playOnlyOnce;

            difference = endValue - startValue;
            timer = 0;
            value = startValue;

            start = false;
            isPlaying = false;
            asEnded = false;

            //Game1.updateables.Add(this);
        }
        
        public override void Update()
        {

            value += 200 * Time.deltaTime;
            if (start)
            {
                timerDelay += speed * (float)Time.deltaTime;
                if (timerDelay > delay)
                    isPlaying = true;
            }

            if (isPlaying)
            {
                timer += speed * (float)Time.deltaTime;
                if (timer < duration)
                {
                    //value = LinearTween(startValue, endValue, timer, duration);
                    value = CubiqTween(startValue, endValue, timer, duration);
                }
                else
                {
                    value = endValue;
                    //isPlaying = false;
                    asEnded = true;
                }
            }
        }

        public void Start()
        {
            start = true;
            asEnded = false;
            isPlaying = false;

            timer = 0;
            timerDelay = 0;
            
            difference = endValue - startValue;
            value = startValue;
        }

        /*
        public void Destroy()
        {
            //Game1.Remove(this);
        }
        */

        //METHODS
        public float LinearTween(float startPos, float endPos, float startTime, float duration)
        {
            float difference = endPos - startPos;

            return (((difference) * (startTime / duration)) + startPos);
        }

        public float CubiqTween(float startPos, float endPos, float startTime, float duration)
        {
            float t = startTime / duration;
            float difference = endPos - startPos;

            float x = 
                (MathF.Pow((1 - t), 3f)) * startPos + 
                3 * (MathF.Pow((1-t), 2f)) * t * (startPos + (difference * 0.5f)) +
                3 * (1-t) * (MathF.Pow(t, 2f)) * (startPos) +
                (MathF.Pow(t, 3f)) * endPos; 

            return x;
        }
    }
}