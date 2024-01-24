using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ITargetAlertService
    {
        /// <summary>
        ///     Updates target definition with latest tag reading, then if required, either raises a new
        ///     target alert, or updates an existing non-closed alert with the latest reading.
        /// </summary>
        [OperationContract]
        void EvaluateTarget(TargetDefinition targetDefinition);

        [OperationContract]
        void EvaluateTargets(List<TargetDefinition> targetDefinitions);

        [OperationContract]
        List<NotifiedEvent> CreateTargetAlertResponse(TargetAlertResponse response, bool createLog,
            bool isLogOperationalEngineerLog, User currentUser, ShiftPattern shiftPattern, Role currentUserRole,
            WorkAssignment workAssignment);

        [OperationContract]
        List<NotifiedEvent> UpdateTargetAlert(TargetAlert targetAlert);

        [OperationContract]
        void ClearAllTargetAlertsAtOrBelowFlocs(List<FunctionalLocation> functionalLocations);

        [OperationContract]
        TargetAlert QueryById(long id);

        [OperationContract]
        TargetAlert QueryTargetAlertNeedingAttentionByTargetDefinition(TargetDefinition targetDefinition);

        [OperationContract]
        List<TargetAlertDTO> QueryDTOsNeedingAttention(IFlocSet flocSet, Range<Date> dateRange);

        [OperationContract]
        List<TargetAlertDTO> QueryByFunctionalLocationsAndStatuses(IFlocSet flocSet,
            List<TargetAlertStatus> targetAlertStatuses);
    }
}