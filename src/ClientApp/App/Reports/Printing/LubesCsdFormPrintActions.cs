using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class LubesCsdFormPrintActions : EdmontonFormPrintActions<LubesCsdForm, FormLubesCsdReport, FormLubesCsdReportAdapter>
    {
        protected override FormLubesCsdReport CreateSpecificReport()
        {
            return new FormLubesCsdReport();
        }

        protected override List<FormLubesCsdReportAdapter> CreateReportAdapter(LubesCsdForm domainObject)
        {
            var formReportAdapter = new FormLubesCsdReportAdapter(domainObject);
            return new List<FormLubesCsdReportAdapter> {formReportAdapter};
        }
    }
}