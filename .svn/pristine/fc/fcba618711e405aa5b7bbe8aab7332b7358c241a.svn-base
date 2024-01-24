using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class ConfinedSpaceMudsPrintActions : PrintActions<ConfinedSpaceMuds, ConfinedSpaceMudsReport, ConfinedSpaceMudsReportAdapter>
    {
        private readonly IConfinedSpaceMudsPage page;
        private readonly IConfinedSpaceMudsService service;

        public ConfinedSpaceMudsPrintActions(IConfinedSpaceMudsPage page, IConfinedSpaceMudsService service)
        {
            this.page = page;
            this.service = service;
        }

        protected override ConfinedSpaceMudsReport CreateSpecificReport()
        {
            return new ConfinedSpaceMudsReport();
        }

        protected override List<ConfinedSpaceMudsReportAdapter> CreateReportAdapter(ConfinedSpaceMuds domainObject)
        {
            ConfinedSpaceMudsReportAdapter adapter = new ConfinedSpaceMudsReportAdapter(domainObject);
            //Added Workpermit Sign
            WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
            ConfinedSpaceMudSign objConfinedSpaceMudSign = WPSign.GetConfinedMudSign(domainObject.ConfinedSpaceNumber.ToString());
            if (objConfinedSpaceMudSign != null)
            {
                adapter.Verifier_NAME = Convert.ToString(objConfinedSpaceMudSign.Verifier_FNAME) + " " +
                                                            Convert.ToString(objConfinedSpaceMudSign.Verifier_LNAME);
                adapter.Verifier_BADGENUMBER = objConfinedSpaceMudSign.Verifier_BADGENUMBER;
                adapter.Verifier_BADGETYPE = objConfinedSpaceMudSign.Verifier_BADGETYPE;
                adapter.Verifier_SOURCE = objConfinedSpaceMudSign.Verifier_SOURCE == null ||
                                                              objConfinedSpaceMudSign.Verifier_SOURCE == "" ||
                                                              objConfinedSpaceMudSign.Verifier_SOURCE == "Manual"
                    ? ""
                    : " (" + objConfinedSpaceMudSign.Verifier_SOURCE + ")";
                adapter.Verifier_NAME = adapter.Verifier_NAME +
                                                            adapter.Verifier_SOURCE;

                adapter.DETENTEUR_NAME = Convert.ToString(objConfinedSpaceMudSign.DETENTEUR_FNAME) +
                                                             " " +
                                                             Convert.ToString(objConfinedSpaceMudSign.DETENTEUR_LNAME);
                adapter.DETENTEUR_BADGENUMBER = objConfinedSpaceMudSign.DETENTEUR_BADGENUMBER;
                adapter.DETENTEUR_BADGETYPE = objConfinedSpaceMudSign.DETENTEUR_BADGETYPE;
                adapter.DETENTEUR_SOURCE = objConfinedSpaceMudSign.DETENTEUR_SOURCE == null ||
                                                               objConfinedSpaceMudSign.DETENTEUR_SOURCE == "" ||
                                                               objConfinedSpaceMudSign.DETENTEUR_SOURCE == "Manual"
                    ? ""
                    : "(" + objConfinedSpaceMudSign.DETENTEUR_SOURCE + ")";
                ;
                adapter.DETENTEUR_NAME = adapter.DETENTEUR_NAME +
                                                             adapter.DETENTEUR_SOURCE;

                adapter.EMETTEUR_NAME = Convert.ToString(objConfinedSpaceMudSign.EMETTEUR_FNAME) + " " +
                                                            Convert.ToString(objConfinedSpaceMudSign.EMETTEUR_LNAME);
                adapter.EMETTEUR_BADGENUMBER = objConfinedSpaceMudSign.EMETTEUR_BADGENUMBER;
                adapter.EMETTEUR_BADGETYPE = objConfinedSpaceMudSign.EMETTEUR_BADGETYPE;
                adapter.EMETTEUR_SOURCE = objConfinedSpaceMudSign.EMETTEUR_SOURCE == null ||
                                                              objConfinedSpaceMudSign.EMETTEUR_SOURCE == "" ||
                                                              objConfinedSpaceMudSign.EMETTEUR_SOURCE == "Manual"
                    ? ""
                    : " (" + objConfinedSpaceMudSign.EMETTEUR_SOURCE + ")";
                adapter.EMETTEUR_NAME = adapter.EMETTEUR_NAME +
                                                            adapter.EMETTEUR_SOURCE;
                if (objConfinedSpaceMudSign.FirstNameFirstResult != null && objConfinedSpaceMudSign.FirstNameFirstResult != "" && objConfinedSpaceMudSign.LasttNameFirstResult != null && objConfinedSpaceMudSign.LasttNameFirstResult != "")
                {
                    adapter.FirstGastestInitial = objConfinedSpaceMudSign.FirstNameFirstResult.Substring(0, 1) + objConfinedSpaceMudSign.LasttNameFirstResult.Substring(0, 1);
                }
            }
            return new List<ConfinedSpaceMudsReportAdapter> {adapter};
        }

        public override string ReportTitle(ConfinedSpaceMuds domainObject)
        {
            return StringResources.ConfinedSpacePrintFormTitle;
        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(ConfinedSpaceMudsReport report, UserPrintPreference userPrintPreferences)
        {
            // should print two copies of the Confined Space document, and force-single sided because AST on on the back-side of the page.
            return new ReportPrintPreference(report, 2, false, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);
        }

        public override void AfterPrintAction(ConfinedSpaceMuds confinedSpace)
        {
            if (confinedSpace.ConfinedSpaceStatus.Id != ConfinedSpaceStatusMuds.Issued.Id)
            {
                confinedSpace.ConfinedSpaceStatus = ConfinedSpaceStatusMuds.Issued;
                confinedSpace.LastModifiedBy = ClientSession.GetUserContext().User;
                confinedSpace.LastModifiedDateTime = Clock.Now;
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, confinedSpace);
            }
        }
    }
}