using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Analytics;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IEventDao : IDao
    {
        void Insert(Event @event);
        void DeleteAnalyticsCreatedBeforeGivenDateTime(DateTime dateTime);
        List<string> QueryUniqueEventNames();
        List<Event> QueryByDateRangeAndEventNames(DateTime fromDateTime, DateTime toDateTime, List<string> eventNames);
    }
}
