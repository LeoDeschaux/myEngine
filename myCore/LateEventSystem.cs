using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class LateEventSystem
    {
        List<Event> events;

        public LateEventSystem()
        {
            events = new List<Event>();
        }

        public void AddEvent(Event e)
        {
            events.Add(e);
        }

        public void Update()
        {
            for (int i = 0; i < events.Count; i++)
            {
                events[i].Invoke();
                events.Remove(events[i]);
            }
        }
    }
}
