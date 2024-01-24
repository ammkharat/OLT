using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IEventSinkDao : IDao
    {
        void DeleteByClientUri(string clientUri);
        void Insert(EventSink eventSink);
        List<EventSink> QueryAll();
    }
}