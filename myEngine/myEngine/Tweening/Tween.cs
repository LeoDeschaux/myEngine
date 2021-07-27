using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Tween : Entity
    {
        //FIELDS
        private unsafe float* valueToModify;

        private float startValue;
        private float endValue;

        //CONSTRUCTOR
        public unsafe Tween(float* valueToModify, float endValue)
        {
            this.valueToModify = valueToModify;

            this.startValue = *valueToModify;
            this.endValue = endValue;
        }

        //METHODS
        public unsafe override void Update()
        {
            if (valueToModify == null)
                return;

            float difference = endValue - startValue;

            if (Math.Abs((endValue - *valueToModify)) > 10)
                *valueToModify += difference * Time.deltaTime;
            else
                Destroy();
        }
    }
}