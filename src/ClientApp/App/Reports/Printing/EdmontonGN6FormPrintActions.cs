using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN6FormPrintActions : EdmontonFormPrintActions<FormGN6, FormGN6Report, FormGN6ReportAdapter>
    {
        private readonly bool printedFromWorkPermit;

        public EdmontonGN6FormPrintActions(bool printedFromWorkPermit)
        {
            this.printedFromWorkPermit = printedFromWorkPermit;
        }

        protected override void AddPageSpecificWatermarks(FormGN6Report report, IEnumerable<FormGN6ReportAdapter> adapters)
        {
            if (printedFromWorkPermit)
            {
                AddPageSpecificWatermarksBasedOnDeletedAndStatus(report, adapters);
            }
            else
            {
                base.AddPageSpecificWatermarks(report, adapters);
            }
        }

        protected override FormGN6Report CreateSpecificReport()
        {
            return new FormGN6Report();
        }

        protected override List<FormGN6ReportAdapter> CreateReportAdapter(FormGN6 domainObject)
        {
            FormGN6ReportAdapter formReportAdapter = new FormGN6ReportAdapter(domainObject);
            return new List<FormGN6ReportAdapter> {formReportAdapter};
        }
    }
}