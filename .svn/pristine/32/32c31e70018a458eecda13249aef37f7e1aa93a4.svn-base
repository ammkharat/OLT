using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN59ChecklistPrintActions : PrintActions<DomainObject, FormGN59ChecklistReport, FormGN59ChecklistReportAdapter>
    {
        protected override FormGN59ChecklistReport CreateSpecificReport()
        {
            return new FormGN59ChecklistReport();
        }

        protected override List<FormGN59ChecklistReportAdapter> CreateReportAdapter(DomainObject domainObject)
        {
            FormGN59ChecklistReportAdapter adapter = new FormGN59ChecklistReportAdapter();
            return new List<FormGN59ChecklistReportAdapter> { adapter };
        }

        public override string ReportTitle(DomainObject domainObject)
        {
            return string.Empty;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormGN59ChecklistReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}