using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN24FormPrintActions : EdmontonFormPrintActions<FormGN24, FormGN24Report, FormGN24ReportAdapter>
    {
        private readonly bool printedFromWorkPermit;

        public EdmontonGN24FormPrintActions(bool printedFromWorkPermit)
        {
            this.printedFromWorkPermit = printedFromWorkPermit;
        }

        protected override void AddPageSpecificWatermarks(FormGN24Report report, IEnumerable<FormGN24ReportAdapter> adapters)
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

        protected override FormGN24Report CreateSpecificReport()
        {
            return new FormGN24Report();
        }

        protected override List<FormGN24ReportAdapter> CreateReportAdapter(FormGN24 domainObject)
        {
            FormGN24ReportAdapter formReportAdapter = new FormGN24ReportAdapter(domainObject);
            return new List<FormGN24ReportAdapter> { formReportAdapter };
        }
    }
}