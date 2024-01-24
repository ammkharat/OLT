using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Remote
{
    public class RemoteEventQueue
    {
        private readonly List<DomainEventArgs<DomainObject>> queue = new List<DomainEventArgs<DomainObject>>();
        private readonly object queueLockObject = new object();

        public void Clear()
        {
            lock (queueLockObject)
            {
                queue.Clear();
            }
        }

        public void Enqueue(DomainEventArgs<DomainObject> eventArgs)
        {
            lock (queueLockObject)
            {
                queue.Add(eventArgs);
            }
        }

        public DomainEventArgs<DomainObject> Dequeue()
        {
            if (Monitor.TryEnter(queueLockObject))
            {
                try
                {
                    if (queue.Count > 0)
                    {
                        var domainEventArgs = queue[0];
                        queue.RemoveAt(0);
                        return domainEventArgs;
                    }
                    else
                    {
                        return null;
                    }
                }
                finally
                {
                    Monitor.Exit(queueLockObject);
                }
            }
            return null;
        }
    }
}