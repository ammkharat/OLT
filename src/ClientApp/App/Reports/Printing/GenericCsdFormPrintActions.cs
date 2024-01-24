using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class GenericCsdFormPrintActions :
        EdmontonFormPrintActions<GenericCsd, FormGenericCsdReport, FormGenericCsdReportAdapter>
    {
        protected override FormGenericCsdReport CreateSpecificReport()
        {
            return new FormGenericCsdReport();
        }

        protected override List<FormGenericCsdReportAdapter> CreateReportAdapter(GenericCsd domainObject)
        {
            var formReportAdapter = new FormGenericCsdReportAdapter(domainObject);
            return new List<FormGenericCsdReportAdapter> {formReportAdapter};
        }
    }
}