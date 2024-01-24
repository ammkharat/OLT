using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class MontrealCsdFormPrintActions :
        EdmontonFormPrintActions<MontrealCsd, FormMontrealCsdReport, FormMontrealCsdReportAdapter>
    {
        protected override FormMontrealCsdReport CreateSpecificReport()
        {
            return new FormMontrealCsdReport();
        }

        protected override List<FormMontrealCsdReportAdapter> CreateReportAdapter(MontrealCsd domainObject)
        {
            var formReportAdapter = new FormMontrealCsdReportAdapter(domainObject);
            return new List<FormMontrealCsdReportAdapter> {formReportAdapter};
        }
    }
}