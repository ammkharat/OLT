using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class FormGenericTemplateFormPrintActions : EdmontonFormPrintActions<FormGenericTemplate, FormGenericTemplateReport, FormGenericTemplateReportAdapter>
    {
        protected override FormGenericTemplateReport CreateSpecificReport()
        {
            return new FormGenericTemplateReport();
        }

        protected override List<FormGenericTemplateReportAdapter> CreateReportAdapter(FormGenericTemplate domainObject)
        {
            FormGenericTemplateReportAdapter formReportAdapter = new FormGenericTemplateReportAdapter(domainObject);
            return new List<FormGenericTemplateReportAdapter> { formReportAdapter };
        }       
    }
}