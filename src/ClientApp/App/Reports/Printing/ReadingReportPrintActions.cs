using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ReadingReportPrintActions : PrintActions<TrackerReport, ReadingReport, ReadingReportAdapter>
    {
        private readonly string labelTitle;

        public ReadingReportPrintActions(string labelTitle)
        {
            this.labelTitle = labelTitle;
        }

        protected override ReadingReport CreateSpecificReport()
        {
            return new ReadingReport();
        }

        protected override List<ReadingReportAdapter> CreateReportAdapter(TrackerReport dto)
        {
            return new List<ReadingReportAdapter>{new ReadingReportAdapter(labelTitle, dto)};
        }

        public override string ReportTitle(TrackerReport domainObject)
        {
            return StringResources.ReportLabel_Title_DailyShiftLog;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(ReadingReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}