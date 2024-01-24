using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class DailyShiftTargetAlertGapReasonReportPrintActions : PrintActions<ShiftGapReasonReportDTO, DailyShiftTargetAlertGapReasonReport, DailyShiftTargetAlertGapReasonReportAdapter>
    {
        protected override DailyShiftTargetAlertGapReasonReport CreateSpecificReport()
        {
            return new DailyShiftTargetAlertGapReasonReport();
        }

        protected override List<DailyShiftTargetAlertGapReasonReportAdapter> CreateReportAdapter(ShiftGapReasonReportDTO domainObject)
        {
            return new List<DailyShiftTargetAlertGapReasonReportAdapter>{new DailyShiftTargetAlertGapReasonReportAdapter(domainObject)};
        }

        public override string ReportTitle(ShiftGapReasonReportDTO domainObject)
        {
            return StringResources.ReportLabel_Title_DailyShiftLog;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(DailyShiftTargetAlertGapReasonReport report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}