using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitMontrealNettoyagePrintActions : PrintActions<WorkPermitMontreal, WorkPermitMontrealNettoyageReport, WorkPermitMontrealNettoyageReportAdapter>
    {
        protected override WorkPermitMontrealNettoyageReport CreateSpecificReport()
        {
            return new WorkPermitMontrealNettoyageReport();
        }

        protected override List<WorkPermitMontrealNettoyageReportAdapter> CreateReportAdapter(WorkPermitMontreal workPermit)
        {
            WorkPermitMontrealNettoyageReportAdapter adapter = new WorkPermitMontrealNettoyageReportAdapter(workPermit);
            return new List<WorkPermitMontrealNettoyageReportAdapter> { adapter };
        }

        public override string ReportTitle(WorkPermitMontreal domainObject)
        {
            return string.Empty;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitMontrealNettoyageReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}