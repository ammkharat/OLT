using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Utility;
using System;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IReportingService
    {
        [OperationContract]
        DailyShiftLogReportDTO GetDailyShiftLogReportData(IFlocSet flocSet, List<UserShift> userShiftList,
            TagInfoGroup tagInfoGroup);

        //ayman action item reading
        [OperationContract]
        List<TrackerReport> GetReadingTrackers(long AidId, DateTime startdate, DateTime endDate);

        [OperationContract]
        List<DetailedLogReportDTO> GetDetailedLogReportData(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment);

        // used by streaming service
        List<TargetAlertExcelReportDTO> GetTargetAlertReportData(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<TargetAlertReportDetailDTO> GetDailyShiftAlertReportData(IFlocSet flocSet, List<UserShift> userShiftList);

        [OperationContract]
        OperatingEngineerLogReportDTO GetOperatingEngineerShiftLogReportData(Site site,
            IFlocSet flocSet,
            List<UserShift> userShifts,
            TagInfoGroup tagInfoGroup);

        [OperationContract]
        DailyShiftLogReportDTO GetOperatingEngineerShiftLogReportDataForDevEx(IFlocSet flocSet,
            List<UserShift> userShifts,
            TagInfoGroup tagInfoGroup);

        [OperationContract]
        List<ShiftGapReasonReportDTO> GetShiftGapReasonReportData(List<ShiftPattern> selectedShiftPatterns,
            IFlocSet flocSet,
            Date startDate,
            Date endDate);

        

        // this is used by streaming reporting service
        List<DeviationAlertReportDTO> GetRestrictionReportData(
            Date startDate, Date endDate, IFlocSet flocSet);

        // This doesn't pass from client-server. use the streaming reporting service
        MarkedAsReadReportDTO GetMarkedAsReadReportData(
            Site site, Date from, Date to, IFlocSet flocSet,
            bool includeLogs, bool includeSummaryogs, bool includeDirectiveLogs, bool includeShiftHandovers,
            bool includeDirectives, bool showFlexiShiftDataonly);

        //Added by ppanigrahi

        MarkedAsNotReadReportDTO GetMarkedAsNotReadReportData(
            Site site, Date from, Date to, IFlocSet flocSet,
            bool includeDirectiveLogs, bool includeShiftHandovers,
            bool includeDirectives);

        [OperationContract]
        List<ShiftHandoverQuestionnaire> GetDailyShiftHandoverReportData(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment);
      
        /* flexi shift and over RITM0185797 amit Shukla */ 
        [OperationContract (Name="Method1")]
        List<ShiftHandoverQuestionnaire> GetDailyShiftHandoverReportData(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment, bool showFlexibleShiftHandoverData);

        // This doesn't pass from client-server. use the streaming reporting service
        List<CustomFieldTrendReportDTO> GetCustomFieldTrendReportData(RootFlocSet rootFlocSet, UserShift startUserShift,
            UserShift endUserShift, List<WorkAssignment> workAssignments, bool includeNullWorkAssignment,
            bool includeLogs, bool includeSummaryLogs, bool includeDailyDirectives);

        [OperationContract]
        List<CSDMarkAsReadReportItem> GetFormOP14MarkedAsReadReport(Date fromDate, Date toDate, long siteId);

    }
}