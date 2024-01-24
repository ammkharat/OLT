using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN75RosterPrintActions<TDomainObject> 
        : PrintActions<TDomainObject, FormGN75RosterReport, FormGN75RosterReportAdapter> where TDomainObject : DomainObject, IEdmontonForm
    {
        protected override FormGN75RosterReport CreateSpecificReport()
        {
            return new FormGN75RosterReport();
        }

        protected override List<FormGN75RosterReportAdapter> CreateReportAdapter(TDomainObject domainObject)
        {
            FormGN75RosterReportAdapter formReportAdapter = new FormGN75RosterReportAdapter(domainObject);
            return new List<FormGN75RosterReportAdapter> { formReportAdapter };
        }

        public override string ReportTitle(TDomainObject domainObject)
        {
            return domainObject.FormType.GetName();
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormGN75RosterReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, false, false, string.Empty, true);
        }
    }
}