using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class LogPrintActions : PrintActions<Log, RtfGenericSingleLogReport, GenericSingleLogReportAdapter>
    {
        private readonly ILogService logService;
        private readonly IEditHistoryService editHistoryService;

        public LogPrintActions(ILogService logService, IEditHistoryService editHistoryService)
        {
            this.logService = logService;
            this.editHistoryService = editHistoryService;
        }

        protected override RtfGenericSingleLogReport CreateSpecificReport()
        {
            return new RtfGenericSingleLogReport();
        }

        protected override List<GenericSingleLogReportAdapter> CreateReportAdapter(Log log)
        {
            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;

            List<DomainObjectChangeSet> changeSets = editHistoryService.GetRecentEditHistoryForLog(log.IdValue);
            List<ItemReadBy> itemReadBys = logService.UsersThatMarkedLogAsRead(log.IdValue);

            GenericSingleLogReportAdapter adapter = new GenericSingleLogReportAdapter(
                log,
                log.FunctionalLocations,
                CustomFieldEntry.PadEntriesWithBlanks(log.CustomFields, log.CustomFieldEntries),
                log.DocumentLinks,
                changeSets,
                itemReadBys,
                GetReportTitleText(log, siteConfiguration.OperatingEngineerLogDisplayName),
                log.LastModifiedBy,
                log.LogDateTime,
                log.ShiftDisplayName,
                log.WorkAssignment,
                log.RecommendForShiftSummary,
                log.RtfComments,
                null,
                log.EnvironmentalHealthSafetyFollowUp,
                log.ProcessControlFollowUp,
                log.OperationsFollowUp,
                log.InspectionFollowUp,
                log.SupervisionFollowUp,
                log.OtherFollowUp,
                log.LogType == LogType.Standard && log.RecommendForShiftSummary);

            //Mukesh for Log Image
            adapter.Images = log.Imagelist;
            adapter.getSite = ClientSession.GetUserContext().Site;//Aarti

            return new List<GenericSingleLogReportAdapter> {adapter};
        }

        private static string GetReportTitleText(Log log, string operatingEngineerName)
        {
            if (log.LogType == LogType.DailyDirective)
            {
                return StringResources.ReportLabel_Title_Directive;
            }
            return log.IsOperatingEngineerLog ? operatingEngineerName : StringResources.ReportLabel_Title_ShiftLog;
        }

        public override string ReportTitle(Log domainObject)
        {
            return StringResources.LogPrintFormTitle;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(RtfGenericSingleLogReport report, UserPrintPreference userPrintPreference)
        {
            // Print duplex by default.
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}