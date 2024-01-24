using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class SummaryLogPrintActions : PrintActions<SummaryLog, RtfGenericSingleLogReport, GenericSingleLogReportAdapter>
    {
        private readonly ISummaryLogService summaryLogService;
        private readonly IEditHistoryService editHistoryService;

        public SummaryLogPrintActions(ISummaryLogService summaryLogService, IEditHistoryService editHistoryService)
        {
            this.summaryLogService = summaryLogService;
            this.editHistoryService = editHistoryService;
        }

        protected override RtfGenericSingleLogReport CreateSpecificReport()
        {
            return new RtfGenericSingleLogReport();
        }

        protected override List<GenericSingleLogReportAdapter> CreateReportAdapter(SummaryLog summaryLog)
        {
            List<DomainObjectChangeSet> changeSets = editHistoryService.GetRecentEditHistoryForSummaryLog(summaryLog.IdValue);
            List<ItemReadBy> itemReadBys = summaryLogService.UsersThatMarkedLogAsRead(summaryLog.IdValue);

            GenericSingleLogReportAdapter adapter = new GenericSingleLogReportAdapter(
                summaryLog,
                summaryLog.FunctionalLocations,
                CustomFieldEntry.PadEntriesWithBlanks(summaryLog.CustomFields, summaryLog.CustomFieldEntries),
                summaryLog.DocumentLinks,
                changeSets,
                itemReadBys,
                StringResources.ReportLabel_Title_ShiftSummaryLog,
                summaryLog.LastModifiedBy,
                summaryLog.LogDateTime,
                summaryLog.ShiftDisplayName,
                summaryLog.WorkAssignment,
                false,
                summaryLog.RtfComments,
                summaryLog.DorComments,
                summaryLog.EnvironmentalHealthSafetyFollowUp,
                summaryLog.ProcessControlFollowUp,
                summaryLog.OperationsFollowUp,
                summaryLog.InspectionFollowUp,
                summaryLog.SupervisionFollowUp,
                summaryLog.OtherFollowUp,
                false);
            //Mukesh for Log Image
            adapter.Images = summaryLog.Imagelist;

            adapter.getSite = ClientSession.GetUserContext().Site;//Aarti

            return new List<GenericSingleLogReportAdapter> {adapter};
        }

        public override string ReportTitle(SummaryLog domainObject)
        {
            return StringResources.SummaryLogPrintFormTitle;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(RtfGenericSingleLogReport report, UserPrintPreference userPrintPreference)
        {
            // Print duplex by default.
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);   
        }
    }
}