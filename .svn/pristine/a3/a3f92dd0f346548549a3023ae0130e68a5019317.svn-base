using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting.Drawing;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class OnPremisePersonnelShiftReportPrintActions :
        PrintActions
            <OnPremisePersonnelShiftReportDTO, OnPremisePersonnelShiftReport, OnPremisePersonnelShiftReportAdapter>
    {
        protected override OnPremisePersonnelShiftReport CreateSpecificReport()
        {
            return new OnPremisePersonnelShiftReport();
        }

        protected override List<OnPremisePersonnelShiftReportAdapter> CreateReportAdapter(
            OnPremisePersonnelShiftReportDTO domainObject)
        {
            // todo
            return new List<OnPremisePersonnelShiftReportAdapter>
            {
                new OnPremisePersonnelShiftReportAdapter(domainObject)
            };
        }

        public override string ReportTitle(OnPremisePersonnelShiftReportDTO domainObject)
        {
            return StringResources.OnPremisePersonnelShiftReportTitle;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(OnPremisePersonnelShiftReport report,
            UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }
    }
}