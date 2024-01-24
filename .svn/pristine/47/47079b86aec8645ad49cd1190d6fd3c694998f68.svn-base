using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class MudsTemporaryInstallationFormPrintActions :
        EdmontonFormPrintActions<TemporaryInstallationsMUDS, FormMudsTemporaryInstallationReport, FormMudsTemporaryInstallationsReportAdapter>
    {
        protected override FormMudsTemporaryInstallationReport CreateSpecificReport()
        {
            return new FormMudsTemporaryInstallationReport();
        }

        protected override List<FormMudsTemporaryInstallationsReportAdapter> CreateReportAdapter(TemporaryInstallationsMUDS domainObject)
        {
            var formReportAdapter = new FormMudsTemporaryInstallationsReportAdapter(domainObject);
            return new List<FormMudsTemporaryInstallationsReportAdapter> { formReportAdapter };
        }
    }
}