using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class LubesAlarmDisableFormPrintActions : EdmontonFormPrintActions<LubesAlarmDisableForm, FormLubesAlarmDisableReport, FormLubesAlarmDisableReportAdapter>
    {
        protected override FormLubesAlarmDisableReport CreateSpecificReport()
        {
            return new FormLubesAlarmDisableReport();
        }

        protected override List<FormLubesAlarmDisableReportAdapter> CreateReportAdapter(LubesAlarmDisableForm domainObject)
        {
            var formReportAdapter = new FormLubesAlarmDisableReportAdapter(domainObject);
            return new List<FormLubesAlarmDisableReportAdapter> { formReportAdapter };
        }
    }
}