
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class WorkPermitLubesPrintActions_Pre_4_18: PrintActions<WorkPermitLubes, WorkPermitLubesReport_Pre_4_18, WorkPermitLubesReportAdapter>
    {
        private readonly IWorkPermitLubesService workPermitService;
        private readonly bool printEmptyForm;

        public WorkPermitLubesPrintActions_Pre_4_18(IWorkPermitLubesService workPermitService) : this(workPermitService, false)
        {           
        }

        public WorkPermitLubesPrintActions_Pre_4_18(IWorkPermitLubesService workPermitService, bool printEmptyForm)
        {
            this.workPermitService = workPermitService;
            this.printEmptyForm = printEmptyForm;
        }

        protected override WorkPermitLubesReport_Pre_4_18 CreateSpecificReport()
        {
            return new WorkPermitLubesReport_Pre_4_18();
        }

        protected override List<WorkPermitLubesReportAdapter> CreateReportAdapter(WorkPermitLubes workPermit)
        {
            WorkPermitLubesReport_Pre_4_18 report = new WorkPermitLubesReport_Pre_4_18(); // temp for doing some calculations
            bool descriptionTooLong = !report.StringWillFitIntoTaskDescriptionField(workPermit.TaskDescription);
            bool hazardsTooLong = !report.StringWillFitIntoHazardsField(workPermit.OtherHazardsAndOrRequirements);

            List<WorkPermitLubesReportAdapter> adapters = new List<WorkPermitLubesReportAdapter>();

            if (printEmptyForm)
            {
                WorkPermitLubesReportAdapter emptyAdapter = new WorkPermitLubesReportAdapter(new WorkPermitLubes(Clock.Now, null), true) {WaterMarkText = string.Empty};
                adapters.Add(emptyAdapter);
            }
            else
            {
                WorkPermitLubesReportAdapter permitAcceptor = new WorkPermitLubesReportAdapter(workPermit, descriptionTooLong, hazardsTooLong) { WaterMarkText = "Permit Acceptor", IsPermitAcceptorCopy = true };
                WorkPermitLubesReportAdapter permitIssuer = new WorkPermitLubesReportAdapter(workPermit, descriptionTooLong, hazardsTooLong) { WaterMarkText = "Permit Issuer", IsPermitIssuerCopy = true };                

                adapters.Add(permitAcceptor);
                adapters.Add(permitIssuer);                
            }

            return adapters;
        }

        protected override void AddPageSpecificWatermarks(WorkPermitLubesReport_Pre_4_18 report, IEnumerable<WorkPermitLubesReportAdapter> adapters)
        {
            int index = 0;
            foreach (WorkPermitLubesReportAdapter adapter in adapters)
            {
                // skip Field Level Risk Assessment page.  don't add a watermark to it.
                int pageNumberIndex = index*2;
                //int pageNumberIndex = index;
                report.Pages[pageNumberIndex].AssignWatermark(CreateTextWatermark(adapter.WaterMarkText));    
                index++;
            }
        }

        protected override ReportPrintPreference CreateReportPrintPreference(WorkPermitLubesReport_Pre_4_18 report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, true, userPrintPreferences.PrinterName, userPrintPreferences.ShowPrintDialog);
        }

        public override void AfterPrintAction(WorkPermitLubes workPermit)
        {
            if (!printEmptyForm && workPermit.WorkPermitStatus.Equals(PermitRequestBasedWorkPermitStatus.Pending))
            {
                workPermit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;

                workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
                workPermit.LastModifiedDateTime = Clock.Now;
                workPermit.IssuedDateTime = workPermit.LastModifiedDateTime;
                workPermit.IssuedBy = workPermit.LastModifiedBy;

                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, workPermit);
            }
        }

        public override string ReportTitle(WorkPermitLubes domainObject)
        {
            return string.Empty;
        }
    }
}