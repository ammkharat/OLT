using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN59FormPrintActions : EdmontonFormPrintActions<FormGN59, FormReport, FormReportAdapter>
    {
        private readonly bool printedFromWorkPermit;

        public EdmontonGN59FormPrintActions(bool printedFromWorkPermit)
        {
            this.printedFromWorkPermit = printedFromWorkPermit;
        }

        protected override FormReport CreateSpecificReport()
        {
            return new FormReport();
        }

        protected override void AddPageSpecificWatermarks(FormReport report, IEnumerable<FormReportAdapter> adapters)
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

        protected override List<FormReportAdapter> CreateReportAdapter(FormGN59 domainObject)
        {
            GN59FormReportAdapter formReportAdapter = new GN59FormReportAdapter(domainObject);
            return new List<FormReportAdapter> { formReportAdapter };
        }
    }
}