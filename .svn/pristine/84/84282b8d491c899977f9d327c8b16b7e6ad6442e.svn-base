using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class DailyShiftTargetAlertReportPrintActions : PrintActions<TargetAlertReportDetailDTO, DailyShiftTargetAlertReport, DailyShiftTargetAlertReportAdapter>
    {
        protected override DailyShiftTargetAlertReport CreateSpecificReport()
        {
            return new DailyShiftTargetAlertReport();
        }

        protected override List<DailyShiftTargetAlertReportAdapter> CreateReportAdapter(TargetAlertReportDetailDTO domainObject)
        {
            return new List<DailyShiftTargetAlertReportAdapter>{new DailyShiftTargetAlertReportAdapter(domainObject)};
        }

        public override string ReportTitle(TargetAlertReportDetailDTO domainObject)
        {
            return StringResources.ReportLabel_Title_TargetAlert;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(DailyShiftTargetAlertReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}