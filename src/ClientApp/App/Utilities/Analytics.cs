using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Utilities
{
    // Note: This isn't threadsafe. Only call the public methods from the same thread across the app.
    public class Analytics
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<Analytics>();

        private static Analytics analytics;
        private IAnalyticsService analyticsService;

        private List<Event> events = new List<Event>();
        private const int NumberOfEventsToHoldBeforeFlushing = 10;

        private Analytics()
        {            
        }

        public static void Initialize(IAnalyticsService analyticsService)
        {
            GetInstance().InitializeInstance(analyticsService);
        }

        private void InitializeInstance(IAnalyticsService analyticsService)
        {
            this.analyticsService = analyticsService;
        }

        private static Analytics GetInstance()
        {
            return analytics ?? (analytics = new Analytics());
        }

        public static void Enable()
        {
            GetInstance().Enabled = true;
        }

        public static void Disable()
        {
            GetInstance().Enabled = false;
        }

        public static void Track(long userId, long? siteId, string eventName)
        {
            Track(userId, siteId, eventName, new List<Property>());
        }

        public static void Track(long userId, long? siteId, string eventName, List<Property> properties)
        {
            GetInstance().Track(new Event(null, userId, siteId, eventName, Clock.Now, properties));
        }

        public static void FlushSynchronously()
        {
            GetInstance().FlushEvents(false);
        }

        private void Track(Event @event)
        {
            if (!Enabled)
            {
                return;
            }

            events.Add(@event);

            if (events.Count >= NumberOfEventsToHoldBeforeFlushing)
            {
                FlushEvents(true);
            }
        }

        private void FlushEvents(bool sendAsynchronously)
        {
            List<Event> eventsToFlush = new List<Event>(events);
            events = new List<Event>();
            SendEvents(eventsToFlush, sendAsynchronously);
        }

        private void SendEvents(List<Event> events, bool sendAsynchronously)
        {
            BackgroundAnalyticsSender analyticsSender = new BackgroundAnalyticsSender(analyticsService);
            if (sendAsynchronously)
            {
                new BackgroundHelper<List<Event>, string>(new BackgroundWorker(), analyticsSender).Run(events);
            }
            else
            {
                analyticsSender.DoWork(events);
            }
        }

        private bool Enabled { get; set; }

        class BackgroundAnalyticsSender : IBackgroundingFriendly<List<Event>, string>
        {
            private readonly IAnalyticsService analyticsService;

            public BackgroundAnalyticsSender(IAnalyticsService analyticsService)
            {
                this.analyticsService = analyticsService;
            }

            public string DoWork(List<Event> events)
            {
                analyticsService.Insert(events);
                return null;
            }

            public void BeforeDoingWork()
            {
            }

            public void AfterDoingWork()
            {
            }

            public void WorkSuccessfullyCompleted(string result)
            {
            }

            public void OnError(Exception e)
            {
                logger.Error("An error occured while sending analytics.", e);
            }

            public void WorkCompletedOrCancelled()
            {
            }
        }
    }
}
