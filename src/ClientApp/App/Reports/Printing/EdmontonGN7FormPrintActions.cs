using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN7FormPrintActions : EdmontonFormPrintActions<FormGN7, FormReport, FormReportAdapter>
    {
        protected override FormReport CreateSpecificReport()
        {
            return new FormReport();
        }

        protected override List<FormReportAdapter> CreateReportAdapter(FormGN7 domainObject)
        {
            GN7FormReportAdapter formReportAdapter = new GN7FormReportAdapter(domainObject);
            return new List<FormReportAdapter> { formReportAdapter };
        }
    }
}