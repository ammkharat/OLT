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
    public class WorkPermitUSPipelinePrintActions_Pre_4_10 : PrintActions<WorkPermit, WorkPermitUSPipelineReport_Pre_4_10, WorkPermitUSPipelineReportAdapter>
    {
        private readonly IWorkPermitService workPermitService;
        private readonly IWorkPermitPage page;

        public WorkPermitUSPipelinePrintActions_Pre_4_10(IWorkPermitService workPermitService, IWorkPermitPage page)
        {
            this.workPermitService = workPermitService;
            this.page = page;
        }

        protected override WorkPermitUSPipelineReport_Pre_4_10 CreateSpecificReport()
        {
            return new WorkPermitUSPipelineReport_Pre_4_10();
        }

        protected override List<WorkPermitUSPipelineReportAdapter> CreateReportAdapter(WorkPermit workPermit)
        {
            WorkPermitUSPipelineReportAdapter fieldCopyAdapter = new WorkPermitUSPipelineReportAdapter(workPermit, false) { CopyBasedWatermarkText = "Field Copy" };
            WorkPermitUSPipelineReportAdapter controlRoomCopyAdapter = new WorkPermitUSPipelineReportAdapter(workPermit, false) { CopyBasedWatermarkText = "Control Room Copy" };

            return new List<WorkPermitUSPipelineReportAdapter> { fieldCopyAdapter, controlRoomCopyAdapter };
        }

        public override string ReportTitle(WorkPermit domainObject)
        {
            return StringResources.WorkPermitPrintFormTitle;
        }

        public override void ShowNotAbleToPrintError()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitUSPipelineReport_Pre_4_10 report, UserPrintPreference userPrintPreferences)
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