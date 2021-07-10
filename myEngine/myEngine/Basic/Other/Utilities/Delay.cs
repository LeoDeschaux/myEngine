using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Delay : Entity
    {
        public double Timer = 0.0;
        public double DelayTime = 0.0;

        Action action;

        public Delay(double DelayTime, Action action)
        {
            this.DelayTime = DelayTime;
            Timer = Time.gameTime.TotalGameTime.TotalMilliseconds + DelayTime;

            this.action = action;
        }

        public void Wait(GameTime gt, Action Action)
        {
            if (this.Timer <= gt.TotalGameTime.TotalMilliseconds)
            {
                Timer = gt.TotalGameTime.TotalMilliseconds + DelayTime;
                Action.Invoke();
            }
        }

        public override void Update()
        {
            if (this.Timer <= Time.gameTime.TotalGameTime.TotalMilliseconds)
            {
                Timer = Time.gameTime.TotalGameTime.TotalMilliseconds + DelayTime;

                if (action != null)
                {
                    action.Invoke();
                }
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