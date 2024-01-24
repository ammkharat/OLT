using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitMudsNettoyagePrintActions : PrintActions<WorkPermitMuds, WorkPermitMudsNettoyageReport, WorkPermitMudsNettoyageReportAdapter>
    {
        protected override WorkPermitMudsNettoyageReport CreateSpecificReport()
        {
            return new WorkPermitMudsNettoyageReport();
        }

        protected override List<WorkPermitMudsNettoyageReportAdapter> CreateReportAdapter(WorkPermitMuds workPermit)
        {
            WorkPermitMudsNettoyageReportAdapter adapter = new WorkPermitMudsNettoyageReportAdapter(workPermit);
            return new List<WorkPermitMudsNettoyageReportAdapter> { adapter };
        }

        public override string ReportTitle(WorkPermitMuds domainObject)
        {
            return string.Empty;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitMudsNettoyageReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}