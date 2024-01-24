using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ILogDTODao : IDao
    {
        List<LogDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateRange range, List<long> clientReadableVisibilityGroupIds);
        List<LogDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateTime? startOfRange, DateTime? endOfRange, WorkAssignment assignment, List<long> clientReadableVisibilityGroupIds);

        List<LogDTO> QueryOpEngineerLogsByFunctionalLocation(IFlocSet flocSet, DateTime? startOfRange, List<long> clientReadableVisibilityGroupIds);

        List<LogReportDTO> QueryForLogReportDTO(IFlocSet flocSet, UserShift shift, bool onlyReturnLogsFlaggedAsOperatingEngineerLog);

        List<LogDTO> QueryById(List<long> logIds);
        List<LogDTO> QueryOpEngLogsByFunctionalLocations(IFlocSet flocSet, DateTime? startOfRange, DateTime? endOfRange, List<long> clientReadableVisibilityGroupIds);

        List<LogDTO> GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(IFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds);

        List<MarkedAsReadReportLogDTO> QueryDTOByParentFlocListAndMarkedAsRead(DateTime start, DateTime end, IList<FunctionalLocation> parentFlocs);
        List<LogDTO> QueryByActionItem(long actionItemId);
        List<LogDTO> QueryByActionItemDefinition(long actionItemDefinitionId);
        List<LogDTO> QueryByWorkPermitEdmonton(long workPermitEdmontonId);
        List<LogDTO> QueryByWorkPermitLubes(long workPermitLubesId);

        List<HasCommentsDTO> QueryByParentFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId);
        List<HasCommentsDTO> QueryByParentFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId, bool isFlexible);

        List<LogDTO> QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(LogType logType, DateTime? startOfRange, DateTime? endOfRange, IFlocSet flocSet, User readByUser, List<long> clientReadableVisibilityGroupIds);
        List<LogDTO> QueryByTargetAlert(long targetAlertId);
        List<HasCommentsDTO> QueryByShiftHandoverQuestionnaire(long shiftHandoverQuestionnaireId, long siteId);
        List<LogDTO> QueryByWorkPermitMontreal(long workPermitMontrealId);
        List<HasCommentsDTO> QueryByShiftHandoverQuestionnaireLogItem(long shiftHandoverQuestionnaireId);//RITM0164968-  mangesh
        List<LogDTO> QueryByWorkPermitMuds(long workPermitMudsId); //RITM0301321 mangesh

        //Added for view based on role permisiion

        List<LogDTO> QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(
          LogType logType, DateTime? startOfRange, DateTime? endOfRange, IFlocSet flocSet, User readByUser, List<long> clientReadableVisibilityGroupIds, long? RoleId);

        List<LogDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateRange range, List<long> clientReadableVisibilityGroupIds,long ? RoleId);

         //Mukesh-for Operator Round Messgae
        List<ShiftLogMessage> QueryShiftLogMessage(IFlocSet Floc, long siteId);
    }
}