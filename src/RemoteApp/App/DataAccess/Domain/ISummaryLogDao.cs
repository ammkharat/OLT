using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISummaryLogDao : IDao
    {
        //[CachedQueryById]
        SummaryLog QueryById(long id);

        [CachedInsertOrUpdate(false, false)]
        SummaryLog Insert(SummaryLog log);

        [CachedRemove(false, false)]
        void Remove(SummaryLog log);

        [CachedInsertOrUpdate(false, false)]
        void Update(SummaryLog log);

        SummaryLog QueryLatestSummaryLogForUser(long userId);

        List<SummaryLog> QueryByFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId);
        List<SummaryLog> QueryByFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId, bool isFlexible);

        bool HasChildren(SummaryLog summaryLog);

        List<SummaryLog> QueryByShiftHandover(long shiftHandoverId);
    }
}