using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IDeviationAlertResponseReasonCodeAssignmentDao : IDao
    {
        List<DeviationAlertResponseReasonCodeAssignment> QueryByDeviationAlertResponseId(long responseId);
        DeviationAlertResponseReasonCodeAssignment Insert(
                DeviationAlertResponseReasonCodeAssignment assignment, long deviationAlertResponseId);
    }
}
