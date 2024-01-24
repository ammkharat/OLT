using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class DailyShiftLogReportPrintActions : PrintActions<DailyShiftLogReportDTO, DailyShiftLogReport, DailyShiftLogReportAdapter>
    {
        private readonly string labelTitle;

        public DailyShiftLogReportPrintActions(string labelTitle)
        {
            this.labelTitle = labelTitle;
        }

        protected override DailyShiftLogReport CreateSpecificReport()
        {
            return new DailyShiftLogReport();
        }

        protected override List<DailyShiftLogReportAdapter> CreateReportAdapter(DailyShiftLogReportDTO dto)
        {
            return new List<DailyShiftLogReportAdapter>{new DailyShiftLogReportAdapter(labelTitle, dto)};
        }

        public override string ReportTitle(DailyShiftLogReportDTO domainObject)
        {
            return StringResources.ReportLabel_Title_DailyShiftLog;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(DailyShiftLogReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}