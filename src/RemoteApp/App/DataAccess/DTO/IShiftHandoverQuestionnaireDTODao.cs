using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IShiftHandoverQuestionnaireDTODao : IDao
    {
        List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocation(IFlocSet flocSet, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds);

        List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocationAndAssignment(IFlocSet flocSet, long? workAssignmentId, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds);

        //Added for View shifthandover based on rolepermission
        List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocation(IFlocSet flocSet, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds,long? RoleId);

        List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocationAndAssignment(IFlocSet flocSet, long? workAssignmentId, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds,long? RoleId);
        //end

        List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> QueryByParentFlocListAndMarkedAsRead(
            Site site, DateTime from, DateTime to, IFlocSet flocSet, bool showFlexiShiftDataonly);

        List<ShiftHandoverQuestionnaireDTO> QueryOnesWithYesAnswersByFunctionalLocationAndShift(RootFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds);

        List<ShiftHandoverQuestionnaireDTO> QueryOnesWithYesAnswersByFunctionalLocationAndDateRange(RootFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds);
        //Added by ppanigrahi
        List<MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> QueryByParentFlocListAndMarkedAsNotRead(
            Site site, DateTime from, DateTime to, IFlocSet flocSet);
    }
}