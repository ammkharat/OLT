using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraReports.UI;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Presenters;
using System;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitMudsPrintActions : PrintActions<WorkPermitMuds, WorkPermitMudsReport, WorkPermitMudsReportAdapter>
    {
        private readonly IWorkPermitMudsService workPermitMudsService;
        private readonly IWorkPermitMudsPage page;

        public WorkPermitMudsPrintActions(IWorkPermitMudsService workPermitMudsService, IWorkPermitMudsPage page)
        {
            this.workPermitMudsService = workPermitMudsService;
            this.page = page;
        }

        protected override WorkPermitMudsReport CreateSpecificReport()
        {
            return new WorkPermitMudsReport();
        }

        protected override List<WorkPermitMudsReportAdapter> CreateReportAdapter(WorkPermitMuds workPermit)
        {
            //SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            //var numberOfCopies = siteConfiguration.DefaultNumberOfCopiesForWorkPermits;

            //var adapters = new List<WorkPermitMudsReportAdapter>();
            //var permitIssuer = new WorkPermitMudsReportAdapter(workPermit)
            //{
            //    WaterMarkText = "Permit Issuer"

            //};
            //var permitAcceptor = new WorkPermitMudsReportAdapter(workPermit)
            //{
            //    WaterMarkText = "Permit Acceptor"
            //};
            //var workerVerifier = new WorkPermitMudsReportAdapter(workPermit)
            // {
            //     WaterMarkText = "Worker/Verifier"
            // };

            //adapters.Add(permitIssuer);
            //if (numberOfCopies == 2)
            //{
            //    adapters.Add(permitAcceptor);
            //}
            //if (numberOfCopies == 3)
            //{
            //    adapters.Add(permitAcceptor);
            //    adapters.Add(workerVerifier);
            //}

            //return adapters;

            WorkPermitMudsReportAdapter workPermitMudsReportAdapter = new WorkPermitMudsReportAdapter(workPermit);

            //DMND0010609-OLT - Edmonton Work permit Scan
            IApplicationService applicationService = ClientServiceRegistry.Instance.GetService<IApplicationService>();
            var buildEnvironment = applicationService.GetBuildConfiguration();
            workPermitMudsReportAdapter.WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-WU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-W";

            //Added Workpermit Sign
            WorkPermitSarniaSignFormPresenter WPSign = new WorkPermitSarniaSignFormPresenter();
            WorkPermitMudSign objWorkPermitMudSign = WPSign.GetMudSign(workPermitMudsReportAdapter.PermitNumber);
            if (objWorkPermitMudSign!=null)
            {
                workPermitMudsReportAdapter.Verifier_NAME = Convert.ToString(objWorkPermitMudSign.Verifier_FNAME) + " " + Convert.ToString(objWorkPermitMudSign.Verifier_LNAME);
                workPermitMudsReportAdapter.Verifier_BADGENUMBER = objWorkPermitMudSign.Verifier_BADGENUMBER;
                workPermitMudsReportAdapter.Verifier_BADGETYPE = objWorkPermitMudSign.Verifier_BADGETYPE;
                workPermitMudsReportAdapter.Verifier_SOURCE = objWorkPermitMudSign.Verifier_SOURCE == null || objWorkPermitMudSign.Verifier_SOURCE == "" || objWorkPermitMudSign.Verifier_SOURCE == "Manual" ? "" : " (" + objWorkPermitMudSign.Verifier_SOURCE + ")" ;
                workPermitMudsReportAdapter.Verifier_NAME = workPermitMudsReportAdapter.Verifier_NAME + workPermitMudsReportAdapter.Verifier_SOURCE;

                workPermitMudsReportAdapter.DETENTEUR_NAME = Convert.ToString(objWorkPermitMudSign.DETENTEUR_FNAME) + " " + Convert.ToString(objWorkPermitMudSign.DETENTEUR_LNAME);
                workPermitMudsReportAdapter.DETENTEUR_BADGENUMBER = objWorkPermitMudSign.DETENTEUR_BADGENUMBER;
                workPermitMudsReportAdapter.DETENTEUR_BADGETYPE = objWorkPermitMudSign.DETENTEUR_BADGETYPE;
                workPermitMudsReportAdapter.DETENTEUR_SOURCE = objWorkPermitMudSign.DETENTEUR_SOURCE == null || objWorkPermitMudSign.DETENTEUR_SOURCE == "" || objWorkPermitMudSign.DETENTEUR_SOURCE == "Manual" ? "" : "(" + objWorkPermitMudSign.DETENTEUR_SOURCE + ")"; ;
                workPermitMudsReportAdapter.DETENTEUR_NAME = workPermitMudsReportAdapter.DETENTEUR_NAME + workPermitMudsReportAdapter.DETENTEUR_SOURCE;

                workPermitMudsReportAdapter.EMETTEUR_NAME = Convert.ToString(objWorkPermitMudSign.EMETTEUR_FNAME) + " " + Convert.ToString(objWorkPermitMudSign.EMETTEUR_LNAME);
                workPermitMudsReportAdapter.EMETTEUR_BADGENUMBER = objWorkPermitMudSign.EMETTEUR_BADGENUMBER;
                workPermitMudsReportAdapter.EMETTEUR_BADGETYPE = objWorkPermitMudSign.EMETTEUR_BADGETYPE;
                workPermitMudsReportAdapter.EMETTEUR_SOURCE = objWorkPermitMudSign.EMETTEUR_SOURCE == null || objWorkPermitMudSign.EMETTEUR_SOURCE == "" || objWorkPermitMudSign.EMETTEUR_SOURCE == "Manual" ? "" : " (" + objWorkPermitMudSign.EMETTEUR_SOURCE+")";
                workPermitMudsReportAdapter.EMETTEUR_NAME = workPermitMudsReportAdapter.EMETTEUR_NAME + workPermitMudsReportAdapter.EMETTEUR_SOURCE;

           if(objWorkPermitMudSign.FirstNameFirstResult!=null && objWorkPermitMudSign.FirstNameFirstResult!=""&& objWorkPermitMudSign.LasttNameFirstResult!=null && objWorkPermitMudSign.LasttNameFirstResult!="")
           {
               workPermitMudsReportAdapter.FirstGastestInitial=objWorkPermitMudSign.FirstNameFirstResult.Substring(0,1)+objWorkPermitMudSign.LasttNameFirstResult.Substring(0,1);
           }
            
            if(objWorkPermitMudSign.FirstNameSecondResult!=null && objWorkPermitMudSign.FirstNameSecondResult!=""&& objWorkPermitMudSign.LasttNameSecondResult!=null && objWorkPermitMudSign.LasttNameSecondResult!="")
           {
               workPermitMudsReportAdapter.SecondGastestInitial=objWorkPermitMudSign.FirstNameSecondResult.Substring(0,1)+objWorkPermitMudSign.LasttNameSecondResult.Substring(0,1);
           }

           if(objWorkPermitMudSign.FirstNameThirdResult!=null && objWorkPermitMudSign.FirstNameThirdResult!=""&& objWorkPermitMudSign.LasttNameThirdResult!=null && objWorkPermitMudSign.LasttNameThirdResult!="")
           {
               workPermitMudsReportAdapter.ThirdGastestInitial = objWorkPermitMudSign.FirstNameThirdResult.Substring(0, 1) + objWorkPermitMudSign.LasttNameThirdResult.Substring(0, 1);
           }


           if (objWorkPermitMudSign.FirstNameFourthResult != null && objWorkPermitMudSign.FirstNameFourthResult != "" && objWorkPermitMudSign.LasttNameFourthResult != null && objWorkPermitMudSign.LasttNameFourthResult != "")
           {
               workPermitMudsReportAdapter.FourthGastestInitial = objWorkPermitMudSign.FirstNameFourthResult.Substring(0, 1) + objWorkPermitMudSign.LasttNameFourthResult.Substring(0, 1);
           }
            
            
            
            }


            return new List<WorkPermitMudsReportAdapter> { workPermitMudsReportAdapter };
        }

       

        public override string ReportTitle(WorkPermitMuds domainObject)
        {
            return StringResources.WorkPermitPrintFormTitle;
        }

        protected override void AddPageSpecificWatermarks(WorkPermitMudsReport report,
           IEnumerable<WorkPermitMudsReportAdapter> adapters)
        {
            //var index = 0;
            ////SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            ////var numberOfCopies = siteConfiguration.DefaultNumberOfCopiesForWorkPermits;

            //foreach (var adapter in adapters)
            //{
            //    report.Pages[index].AssignWatermark(CreateTextWatermark(adapter.WaterMarkText));
            //    index++;
            //    //if (index == numberOfCopies) return;
            //}
        }

        public override bool BeforeFirstPrint(List<WorkPermitMuds> workPermits)
        {
            List<WorkPermitMuds> permitsWithDocumentLinks = workPermits.FindAll(permit => permit.DocumentLinks.Count > 0);

            bool userReadAtLeastOneDocumentLinkInEachPermit = workPermitMudsService.HasUserReadAtLeastOneDocumentLinkInEachPermit(ClientSession.GetUserContext().User.IdValue, permitsWithDocumentLinks.ConvertAll(p => p.IdValue));
            if (!userReadAtLeastOneDocumentLinkInEachPermit)
            {
                DialogResult result = page.ShowUserHasNotReadDocumentLinksMessage();
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        public override void AfterPrintAction(WorkPermitMuds domainObject)
        {
                if (domainObject.WorkPermitStatus.Equals(PermitRequestBasedWorkPermitStatus.Pending))
                {
                    domainObject.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
                    domainObject.LastModifiedBy = ClientSession.GetUserContext().User;
                    domainObject.LastModifiedDateTime = Clock.Now;
                    domainObject.IssuedDateTime = domainObject.LastModifiedDateTime;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMudsService.Update, domainObject);
                } 
        }

        protected override void AddAssociatedReports(WorkPermitMudsReport mainReport, WorkPermitMuds domainObject)
        {
            //if (domainObject.RemplirLeFormulaireDeCondition.StateAsBool)
            //{
                //XtraReport nettoyageReport = new WorkPermitMudsNettoyagePrintActions().CreateReport(domainObject);
                //mainReport.Pages.AddRange(nettoyageReport.Pages);

            //    if (domainObject.ConfinedSpace == null) return;
            //    XtraReport csdReport = new ConfinedSpaceMudsPrintActions(null, null).CreateReport(domainObject.ConfinedSpace);
            //    mainReport.Pages.AddRange(csdReport.Pages);
            //}

        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitMudsReport report, UserPrintPreference userPrintPreferences)
        {
            // should print number of copies users have set value to, and force-single sided because AST on on the back-side of the page.
            //return new ReportPrintPreference(report, userPrintPreferences.NumberOfCopies, false, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);

            SiteConfiguration siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;
            var numberOfCopies = siteConfiguration.DefaultNumberOfCopiesForWorkPermits;

            return new ReportPrintPreference(report, numberOfCopies, true, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);
        }
    }
}