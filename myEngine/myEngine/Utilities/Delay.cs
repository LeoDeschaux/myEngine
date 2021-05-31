using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Delay
    {
        public double Timer = 0.0;
        public double DelayTime = 0.0;

        public Delay(double DelayTime)
        {
            this.DelayTime = DelayTime;
        }

        public void Wait(GameTime gt, Action Action)
        {
            if (this.Timer <= gt.TotalGameTime.TotalMilliseconds)
            {
                Timer = gt.TotalGameTime.TotalMilliseconds + DelayTime;
                Action.Invoke();
            }
        }

        /*           ///// TIMER /////
        if (this.timer <= gameTime.TotalGameTime.TotalMilliseconds && !asSpawned)
            {
            timer = gameTime.TotalGameTime.TotalMilliseconds + delayTime;
        }

        delay.Wait(gameTime, () =>
            {
            });
        */
    }
}