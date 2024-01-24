using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Analytics;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IAnalyticsService
    {
        [OperationContract(IsOneWay = true)]
        void Insert(List<Event> events);

        [OperationContract]
        void DeleteAnalyticsCreatedBeforeGivenDateTime(DateTime dateTime);

        [OperationContract]
        List<string> QueryUniqueEventNames();
    }
}