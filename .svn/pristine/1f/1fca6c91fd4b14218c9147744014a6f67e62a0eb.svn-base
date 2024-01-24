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
    public class WorkPermitDenverPrintActions_Pre_4_10 : PrintActions<WorkPermit, WorkPermitDenverReport_Pre_4_10, WorkPermitDenverReportAdapter>
    {
        private readonly IWorkPermitService workPermitService;
        private readonly IWorkPermitPage page;

        public WorkPermitDenverPrintActions_Pre_4_10(IWorkPermitService workPermitService, IWorkPermitPage page)
        {
            this.workPermitService = workPermitService;
            this.page = page;
        }

        protected override WorkPermitDenverReport_Pre_4_10 CreateSpecificReport()
        {
            return new WorkPermitDenverReport_Pre_4_10();
        }

        protected override List<WorkPermitDenverReportAdapter> CreateReportAdapter(WorkPermit workPermit)
        {
            WorkPermitDenverReportAdapter fieldCopyAdapter = new WorkPermitDenverReportAdapter(workPermit, false) { CopyBasedWatermarkText = "Field Copy" };
            WorkPermitDenverReportAdapter controlRoomCopyAdapter = new WorkPermitDenverReportAdapter(workPermit, false) { CopyBasedWatermarkText = "Control Room Copy" };

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

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitDenverReport_Pre_4_10 report, UserPrintPreference userPrintPreferences)
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