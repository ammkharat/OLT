using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IEventDao eventDao;

        public AnalyticsService() : this(DaoRegistry.GetDao<IEventDao>())
        {
        }

        public AnalyticsService(IEventDao eventDao)
        {
            this.eventDao = eventDao;
        }

        public void Insert(List<Event> events)
        {
            foreach (Event @event in events)
            {
                eventDao.Insert(@event);
            }
        }

        public void DeleteAnalyticsCreatedBeforeGivenDateTime(DateTime dateTime)
        {
            eventDao.DeleteAnalyticsCreatedBeforeGivenDateTime(dateTime);
        }

        public List<string> QueryUniqueEventNames()
        {
            return eventDao.QueryUniqueEventNames();
        }
    }
}
