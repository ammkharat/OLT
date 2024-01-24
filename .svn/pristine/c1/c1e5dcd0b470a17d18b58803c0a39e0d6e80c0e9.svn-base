using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonOP14FormPrintActions : EdmontonFormPrintActions<FormOP14, FormOP14Report, FormOP14ReportAdapter>
    {
        protected override FormOP14Report CreateSpecificReport()
        {
            return new FormOP14Report();
        }

        protected override List<FormOP14ReportAdapter> CreateReportAdapter(FormOP14 domainObject)
        {
            FormOP14ReportAdapter formReportAdapter = new FormOP14ReportAdapter(domainObject);
            return new List<FormOP14ReportAdapter> { formReportAdapter };
        }       
    }
}