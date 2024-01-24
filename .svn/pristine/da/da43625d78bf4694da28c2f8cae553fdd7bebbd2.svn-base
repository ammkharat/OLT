using System.Collections.Generic;
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

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitMontrealPrintActions : PrintActions<WorkPermitMontreal, WorkPermitMontrealReport, WorkPermitMontrealReportAdapter>
    {
        private readonly IWorkPermitMontrealService workPermitMontrealService;
        private readonly IWorkPermitMontrealPage page;

        public WorkPermitMontrealPrintActions(IWorkPermitMontrealService workPermitMontrealService, IWorkPermitMontrealPage page)
        {
            this.workPermitMontrealService = workPermitMontrealService;
            this.page = page;
        }

        protected override WorkPermitMontrealReport CreateSpecificReport()
        {
            return new WorkPermitMontrealReport();
        }

        protected override List<WorkPermitMontrealReportAdapter> CreateReportAdapter(WorkPermitMontreal workPermit)
        {
            WorkPermitMontrealReportAdapter workPermitMontrealReportAdapter = new WorkPermitMontrealReportAdapter(workPermit);

            //DMND0010609-OLT - Edmonton Work permit Scan
            IApplicationService applicationService = ClientServiceRegistry.Instance.GetService<IApplicationService>();
            var buildEnvironment = applicationService.GetBuildConfiguration();
            workPermitMontrealReportAdapter.WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-WU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-W";
            //End
            
            return new List<WorkPermitMontrealReportAdapter> { workPermitMontrealReportAdapter };
        }

        public override string ReportTitle(WorkPermitMontreal domainObject)
        {
            return StringResources.WorkPermitPrintFormTitle;
        }

        public override bool BeforeFirstPrint(List<WorkPermitMontreal> workPermits)
        {
            List<WorkPermitMontreal> permitsWithDocumentLinks = workPermits.FindAll(permit => permit.DocumentLinks.Count > 0);

            bool userReadAtLeastOneDocumentLinkInEachPermit = workPermitMontrealService.HasUserReadAtLeastOneDocumentLinkInEachPermit(ClientSession.GetUserContext().User.IdValue, permitsWithDocumentLinks.ConvertAll(p => p.IdValue));
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

        public override void AfterPrintAction(WorkPermitMontreal domainObject)
        {
            if (domainObject.WorkPermitStatus.Equals(PermitRequestBasedWorkPermitStatus.Pending))
            {
                domainObject.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
                domainObject.LastModifiedBy = ClientSession.GetUserContext().User;
                domainObject.LastModifiedDateTime = Clock.Now;
                domainObject.IssuedDateTime = domainObject.LastModifiedDateTime;
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitMontrealService.Update, domainObject);
            }            
        }

        protected override void AddAssociatedReports(WorkPermitMontrealReport mainReport, WorkPermitMontreal domainObject)
        {
            if (domainObject.NettoyageTransfertHorsSite)
            {
                XtraReport nettoyageReport = new WorkPermitMontrealNettoyagePrintActions().CreateReport(domainObject);
                mainReport.Pages.AddRange(nettoyageReport.Pages);
            }
        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitMontrealReport report, UserPrintPreference userPrintPreferences)
        {
            // should print number of copies users have set value to, and force-single sided because AST on on the back-side of the page.
            return new ReportPrintPreference(report, userPrintPreferences.NumberOfCopies,false, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);
           
        }
    }
}