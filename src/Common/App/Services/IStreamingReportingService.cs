﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IStreamingReportingService
    {
        [OperationContract]
        Stream GetCustomFieldTrendReportData(RootFlocSet rootFlocSet, UserShift startUserShift, UserShift endUserShift,
            List<WorkAssignment> workAssignments, bool includeNullWorkAssignment, bool includeLogs,
            bool includeSummaryLogs, bool includeDailyDirectives);

        [OperationContract]
        Stream GetFormOilsandsTrainingReportData(RootFlocSet rootFlocSet, UserShift startUserShift,
            UserShift endUserShift, List<WorkAssignment> workAssignments);

        [OperationContract]
        Stream GetMarkedAsReadReportData(
            Site site, Date fromDate, Date toDate, IFlocSet flocSet,
            bool includeLogs, bool includeSummaryLogs, bool includeDirectiveLogs, bool includeShiftHandovers,
            bool includeDirectives, bool showFlexiShiftDataonly);

        [OperationContract]
        Stream GetRestrictionReportData(
            Date startDate, Date endDate, IFlocSet flocSet);

        [OperationContract]
        Stream GetTargetAlertReportData(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        Stream GetSafeWorkPermitAssessmentReportData(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        Stream GetAnalyticsExcelExportData(DateTime fromDateTime, DateTime toDateTime, List<string> eventNames);

        [OperationContract]
        Stream GetMarkedAsNotReadReportData(Site site, Date fromDate, Date toDate, IFlocSet flocSet, bool includeDirectiveLogs, bool includeShiftHandovers, bool includeDirectives);

    }
}