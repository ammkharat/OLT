using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Analytics;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPropertyDao : IDao
    {
        List<Property> QueryByEventId(long eventId);
    }
}
