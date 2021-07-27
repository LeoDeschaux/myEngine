using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Event
    {
        public delegate void Function();
        Function function;

        //CONSTRUCTOR
        public Event(Function function = null)
        {
            this.function = function;
        }

        public void PlayFunction(Function function)
        {
            this.function = function;
        }

        public void Invoke()
        {
            function?.Invoke();
        }
    }

    public class Event<T>
    {
        //FIELDS
        public delegate void myEvent(T value);
        myEvent e;

        //CONSTRUCTOR
        public Event(myEvent e = null)
        {
            this.e = e;
        }

        public void AddListener(myEvent e)
        {
            this.e = e;
        }

        public void Invoke(T value)
        {
            e?.Invoke(value);
        }

        //METHODS
        //public static Event operator +(Event a) => a;
    }
}
