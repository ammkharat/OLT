using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Client.Services;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitDenverPrintActions : PrintActions<WorkPermit, WorkPermitDenverReport, WorkPermitDenverReportAdapter>
    {
        private readonly IWorkPermitService workPermitService;
        private readonly IWorkPermitPage page;

        public WorkPermitDenverPrintActions(IWorkPermitService workPermitService, IWorkPermitPage page)
        {
            this.workPermitService = workPermitService;
            this.page = page;
        }

        protected override WorkPermitDenverReport CreateSpecificReport()
        {
            return new WorkPermitDenverReport();
        }

        protected override List<WorkPermitDenverReportAdapter> CreateReportAdapter(WorkPermit workPermit)
        {
            IApplicationService applicationService = ClientServiceRegistry.Instance.GetService<IApplicationService>();
            var buildEnvironment = applicationService.GetBuildConfiguration();

            WorkPermitDenverReport report = new WorkPermitDenverReport(); // temp for doing some calculations
            bool precautionsTooLong = !report.StringWillFitIntoSpecialPrecautionsOrConsiderationsField(workPermit.SpecialPrecautionsOrConsiderations);

            WorkPermitDenverReportAdapter fieldCopyAdapter = new WorkPermitDenverReportAdapter(workPermit, precautionsTooLong, "Field Copy") { CopyBasedWatermarkText = "Field Copy" };
           fieldCopyAdapter.WorkpermitScanText= buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-FU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-F";
           
            WorkPermitDenverReportAdapter controlRoomCopyAdapter = new WorkPermitDenverReportAdapter(workPermit, precautionsTooLong, "Control Room Copy") { CopyBasedWatermarkText = "Control Room Copy" };
            controlRoomCopyAdapter.WorkpermitScanText = buildEnvironment != "Release-PRD" ? ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-CU" : ClientSession.GetUserContext().SiteId.ToString() + "-" + workPermit.PermitNumber + "-C";
            return new List<WorkPermitDenverReportAdapter> { fieldCopyAdapter, controlRoomCopyAdapter };
        }

       

        public override string ReportTitle(WorkPermit domainObject)
        {
            return StringResources.WorkPermitPrintFormTitle;
        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitDenverReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report,
                                 1,
                                 true,
                                 true,
                                 userPrintPreferences.PrinterName,
                                 userPrintPreferences.ShowPrintDialog);
        }

        public override void AfterPrintAction(WorkPermit permit)
        {
            if (permit.IsNot(WorkPermitStatus.Issued))
            {
                User issuer = ClientSession.GetUserContext().User;
                permit.ChangeToIssuedPermit(issuer, Clock.Now);
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, permit);
            }
        }
    }
}