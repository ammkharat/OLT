using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ISummaryLogService : INumericAndNonnumericCustomFieldEntryListService
    {
        [OperationContract]
        SummaryLog QueryById(long id);

        [OperationContract]
        List<NotifiedEvent> Insert(SummaryLog summaryLog);

        [OperationContract]
        List<NotifiedEvent> Update(SummaryLog summaryLog);

        [OperationContract]
        List<NotifiedEvent> Remove(SummaryLog summaryLog);

        [OperationContract]
        List<SummaryLogDTO> QuerySummaryLogDTOsByParentFloc(IFlocSet flocSet, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<SummaryLogDTO> QueryShiftSummaryDTOsByParentFlocAndDateRange(IFlocSet flocSet, Range<Date> range,
            List<long> readableVisibilityGroupIds);

        //Added to View based on rolepermission
        [OperationContract(Name = "QueryShiftSummaryDTOsByParentFlocAndDateRange1")]
        List<SummaryLogDTO> QueryShiftSummaryDTOsByParentFlocAndDateRange(IFlocSet flocSet, Range<Date> range, List<long> clientReadableVisibilityGroupIds, long? RoleId);

        [OperationContract]
        List<SummaryLog> QueryShiftSummaryLogsByFunctionalLocationDateRangeShiftAndWorkAssignment
            (DateTime @from, DateTime to, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId);
       
        // amit shukla flexi shift handover RITM0185797
        [OperationContract (Name = "Method1")]
        List<SummaryLog> QueryShiftSummaryLogsByFunctionalLocationDateRangeShiftAndWorkAssignment
            (DateTime @from, DateTime to, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId, bool isFlexible);

        [OperationContract]
        List<ItemReadBy> UsersThatMarkedLogAsRead(long summaryLogId);

        [OperationContract]
        void MarkAsRead(long summaryLogId, long userId, DateTime dateTime);

        [OperationContract]
        SummaryLog GetLatestSummaryLogForUser(long userId);

        [OperationContract]
        bool UserMarkedSummaryLogAsRead(long summaryLogId, long userId);

        [OperationContract]
        bool LogIsMarkedAsRead(long summaryLogId);
    }
}