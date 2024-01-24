using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ILogService : INumericAndNonnumericCustomFieldEntryListService
    {
        [OperationContract]
        Log QueryById(long id);

        [OperationContract]
        List<LogDTO> QueryDTOById(List<long> ids);

        [OperationContract]
        List<LogDTO> GetLogsForDisplay(IFlocSet flocSet, DateRange range, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogDTO> GetCrossShiftLogsForDisplay(IFlocSet flocSet, WorkAssignment assignment, DateRange dateRange,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogDTO> GetDailyDirectivesForDisplayByUserRootFlocs(Site site, IFlocSet flocSet, User readByUser,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogDTO> GetDailyDirectivesForDisplayByUserRootFlocsAndDateRange(IFlocSet flocSet, Range<Date> dateRange,
            User readByUser, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogDTO> GetOperatingEngineerLogsForDisplay(Site site, IFlocSet flocSet,
            List<long> readableVisibilityGroupIds);

        [OperationContract ]
        List<HasCommentsDTO> QueryLogsByParentFunctionalLocationDateRangeShiftAndWorkAssignmentAndCurrentShift(
            DateTime @from, DateTime to, IFlocSet flocSet, long shiftPatternId, long? workAssignmentId, long userId);
        // amit shukla flexi shift handover RITM0185797
        [OperationContract (Name = "Method1")]
        List<HasCommentsDTO> QueryLogsByParentFunctionalLocationDateRangeShiftAndWorkAssignmentAndCurrentShift(
            DateTime @from, DateTime to, IFlocSet flocSet, long shiftPatternId, long? workAssignmentId, long userId,bool isFlexible);

        [OperationContract]
        List<LogDTO> QueryOperatingEngineerDTOsByFunctionalLocationsAndDateRange(IFlocSet flocSet, Range<Date> range,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogDTO> QueryStandardLogsByFlocAndCurrentShift(IFlocSet flocSet, UserShift userShift,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<LogPriorityPageDTO> QueryDirectivesForPriorityPageDTOs(IFlocSet flocSet, Range<Date> dateRange, User user,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<NotifiedEvent> Remove(Log log);

        [OperationContract]
        List<NotifiedEvent> Update(Log log);

        [OperationContract]
        List<NotifiedEvent> Insert(Log log);

        [OperationContract]
        List<NotifiedEvent> InsertForActionItem(Log log, ActionItem associatedActionItem);

        [OperationContract]
        List<NotifiedEvent> InsertActionItemDefinition(Log log, ActionItemDefinition associatedActionItemDefinition);

        [OperationContract]
        List<NotifiedEvent> InsertForTargetAlert(Log log, TargetAlert associatedTargetAlert);

        [OperationContract]
        LogRead MarkAsRead(long logId, long userId, DateTime readDateTime);

        [OperationContract]
        List<ItemReadBy> UsersThatMarkedLogAsRead(long logId);

        [OperationContract]
        bool LogIsMarkedAsRead(long logId);

        [OperationContract]
        bool UserMarkedLogAsRead(long logId, long userId);

        [OperationContract]
        bool HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(LogDefinition logDefinition,
            DateTime dateTimeToCheck, ExactFlocSet flocSet);

        [OperationContract]
        List<LogDTO> QueryDTOsByActionItem(long actionItemId);

        [OperationContract]
        int CountOfLogsAssociatedToActionItem(long actionItemId);

        [OperationContract]
        List<LogDTO> QueryDTOsByActionItemDefinition(long actionItemDefinitionId);

        [OperationContract]
        int CountOfLogsAssociatedToActionItemDefinition(long actionItemDefinitionId);

        [OperationContract]
        void SaveLogGuideline(string guidelineText, FunctionalLocation functionalLocation);

        [OperationContract]
        LogGuideline QueryLogGuidelineByDivision(FunctionalLocation functionalLocation);

        [OperationContract]
        List<LogGuideline> QueryLogGuidelinesByDivisions(List<string> divisions, long siteId);

        [OperationContract]
        List<NotifiedEvent> InsertForWorkPermitEdmonton(Log log, WorkPermitEdmonton associatedWorkPermit);

        [OperationContract]
        List<NotifiedEvent> InsertForWorkPermitLubes(Log log, WorkPermitLubes associatedWorkPermit);

        [OperationContract]
        List<LogDTO> QueryDTOsByWorkPermitEdmonton(long id);

        [OperationContract]
        int CountOfLogsAssociatedToWorkPermitEdmonton(long id);

        [OperationContract]
        List<LogDTO> QueryDTOsByTargetAlert(long targetAlertId);

        [OperationContract]
        int CountOfLogsAssociatedToTargetAlert(long idValue);

        [OperationContract]
        List<LogDTO> QueryDTOsByWorkPermitLubes(long id);

        [OperationContract]
        int CountOfLogsAssociatedToWorkPermitLubes(long workPermitLubesId);

        [OperationContract]
        List<NotifiedEvent> InsertForWorkPermitMontreal(Log log, WorkPermitMontreal associatedWorkPermit);

        [OperationContract]
        List<LogDTO> QueryDTOsByWorkPermitMontreal(long workPermitMontrealId);

        [OperationContract]
        int CountOfLogsAssociatedToWorkPermitMontreal(long idValue);

        //RITM0301321 mangesh - start
        [OperationContract]
        List<LogDTO> QueryDTOsByWorkPermitMuds(long workPermitMudsId);

        [OperationContract]
        int CountOfLogsAssociatedToWorkPermitMuds(long idValue);

        [OperationContract]
        List<NotifiedEvent> InsertForWorkPermitMuds(Log log, WorkPermitMuds associatedWorkPermit);
        //RITM0301321 end

        [OperationContract(Name = "GetLogsForDisplay1")]
        List<LogDTO> GetLogsForDisplay(IFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds, long? RoleId);
    }
}