using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class FormOP14FormPrintActions : EdmontonFormPrintActions<FormOP14, FormOP14Report, FormOP14ReportAdapter>
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

        public override string ReportTitle(FormOP14 domainobject)
        {
            return domainobject.FormType.GetName();
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormOP14Report report, UserPrintPreference userPrintPreference)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}
