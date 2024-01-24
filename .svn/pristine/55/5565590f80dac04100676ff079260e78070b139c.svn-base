using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ConfinedSpaceMontrealPrintActions : PrintActions<ConfinedSpace, ConfinedSpaceMontrealReport, ConfinedSpaceMontrealReportAdapter>
    {
        private readonly IConfinedSpacePage page;
        private readonly IConfinedSpaceService service;

        public ConfinedSpaceMontrealPrintActions(IConfinedSpacePage page, IConfinedSpaceService service)
        {
            this.page = page;
            this.service = service;
        }

        protected override ConfinedSpaceMontrealReport CreateSpecificReport()
        {
            return new ConfinedSpaceMontrealReport();
        }

        protected override List<ConfinedSpaceMontrealReportAdapter> CreateReportAdapter(ConfinedSpace domainObject)
        {
            ConfinedSpaceMontrealReportAdapter adapter = new ConfinedSpaceMontrealReportAdapter(domainObject);
            return new List<ConfinedSpaceMontrealReportAdapter> {adapter};
        }

        public override string ReportTitle(ConfinedSpace domainObject)
        {
            return StringResources.ConfinedSpacePrintFormTitle;
        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(ConfinedSpaceMontrealReport report, UserPrintPreference userPrintPreferences)
        {
            // should print two copies of the Confined Space document, and force-single sided because AST on on the back-side of the page.
            return new ReportPrintPreference(report, 2, false, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);
        }

        public override void AfterPrintAction(ConfinedSpace confinedSpace)
        {
            if (confinedSpace.ConfinedSpaceStatus.Id != ConfinedSpaceStatus.Issued.Id)
            {
                confinedSpace.ConfinedSpaceStatus = ConfinedSpaceStatus.Issued;
                confinedSpace.LastModifiedBy = ClientSession.GetUserContext().User;
                confinedSpace.LastModifiedDateTime = Clock.Now;
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, confinedSpace);
            }
        }
    }
}