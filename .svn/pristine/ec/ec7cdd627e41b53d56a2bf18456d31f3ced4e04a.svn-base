using System.Collections.Generic;
using Com.Suncor.Olt.Remote.Utilities;

namespace Com.Suncor.Olt.Remote.Services
{
    public class EventQueueTestWrapper
    {
        public EventQueueTestWrapper()
        {
            Cleanup();
            Utilities.EventQueue.InitializeEventQueue();
        }

        public void Cleanup()
        {
            Utilities.EventQueue.CleanUpEventQueue();
        }

        public List<EventQueueItem> EventQueue
        {
            get { return Utilities.EventQueue.GetQueue(); }
        }

    }
}
