using System;
using System.Collections.Generic;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Remote.Wcf;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class EventQueue
    {
        private const string DATA_STORE_SLOT_NAME = "delegate";
        private const string QUEUE_DOES_NOT_EXIST = "An event is being pushed without an event queue.";

        private static readonly ILog logger = GenericLogManager.GetLogger<EventQueue>();

        public static void InitializeEventQueue()
        {
            LocalDataStoreSlot dataStore = Thread.GetNamedDataSlot(DATA_STORE_SLOT_NAME);
            Thread.SetData(dataStore, new List<EventQueueItem>());
        }

        public static void CleanUpEventQueue()
        {
            LocalDataStoreSlot dataStore = Thread.GetNamedDataSlot(DATA_STORE_SLOT_NAME);
            Thread.SetData(dataStore, null);
        }

        public static void FlushAllEventsRegistered()
        {
            List<EventQueueItem> queue = GetQueue();
            if (queue == null || queue.Count == 0)
            {
                return;
            }


            string eventServiceUrl = WcfConfiguration.Instance.BaseAddress;

            try
            {
                GenericServiceRegistry genericServiceRegistry = GenericServiceRegistry.Instance;
                IEventService eventService = genericServiceRegistry.GetService<IEventService>();

                foreach (EventQueueItem item in queue)
                {
                    eventService.PublishEvent(new DomainEventArgs<DomainObject>(item.DomainObject, item.ApplicationEvent), item.InitiatingEventSink);
                }
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Cannot call event service at {0}.", eventServiceUrl), e);
            }

            queue.Clear();
        }

        public static List<EventQueueItem> GetQueue()
        {
            LocalDataStoreSlot dataStore = Thread.GetNamedDataSlot(DATA_STORE_SLOT_NAME);
            return Thread.GetData(dataStore) as List<EventQueueItem>;
        }

        public static NotifiedEvent PushEventIntoQueue(ApplicationEvent applicationEvent, DomainObject domainObject)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot("ClientUri");
            string clientUri = Thread.GetData(slot) as string;
            return PushEventIntoQueue(clientUri == null ? null : new InitiatingEventSink(clientUri), applicationEvent, domainObject);
        }

        private static NotifiedEvent PushEventIntoQueue(InitiatingEventSink initiatingEventSinkUri, ApplicationEvent applicationEvent, DomainObject domainObject)
        {
            List<EventQueueItem> eventQueue = GetQueue();
            if (eventQueue == null)
            {
                logger.Error(QUEUE_DOES_NOT_EXIST);
             throw new ApplicationException(QUEUE_DOES_NOT_EXIST);
            }


            if (domainObject != null)
            {
                logger.DebugFormat("Pushing event into queue: [Method:{0}] [DomainObject:{1}] [Id:{2}] [Initiating Event Sink Uri:{3}]",
                    applicationEvent, domainObject.GetType().Name, domainObject.Id,
                    initiatingEventSinkUri != null ? initiatingEventSinkUri.ClientUri : "<null initiating event sink>");
            }
            else
            {
                logger.DebugFormat("Pushing event into queue with null object so refresh All");
            }

            EventQueueItem item = new EventQueueItem(applicationEvent, domainObject, initiatingEventSinkUri);
            eventQueue.Add(item);

            return new NotifiedEvent(applicationEvent, domainObject);
        }
    }
}
