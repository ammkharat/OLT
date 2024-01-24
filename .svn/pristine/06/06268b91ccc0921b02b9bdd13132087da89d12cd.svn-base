using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Reports.Adapters;
using Com.Suncor.Olt.Reports.Printing;
using Com.Suncor.Olt.Reports.SubReports.OilsandsTraining;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Reports
{
    public partial class FormOilsandsTrainingReport : XtraReport, IOltReport<FormOilsandsTrainingReportAdapter>
    {
        public FormOilsandsTrainingReport()
        {
            InitializeComponent();
            trainingBlockSubreport.BeforePrint += HandleTrainingBlockSubreportBeforePrint;
            approvalsSubreport.BeforePrint += HandleApprovalsSubreportBeforePrint;
            flocSubreport.BeforePrint += HandleFlocSubreportBeforePrint;
        }

        public void SetMasterAndSubReportDataSource(List<FormOilsandsTrainingReportAdapter> adapters,
            DateTime currentTimeInSite)
        {
            if (adapters == null || adapters.Count < 1)
            {
                return;
            }

            DataSource = adapters;

            var functionalLocationReportAdapters = new List<FunctionalLocationReportAdapter>();
            adapters.ForEach(a => functionalLocationReportAdapters.AddRange(a.FunctionalLocationReportAdapters));
            flocSubreport.ReportSource.DataSource = functionalLocationReportAdapters;

            var approvalReportAdapters = new List<ApprovalReportAdapter>();
            adapters.ForEach(a => approvalReportAdapters.AddRange(a.ApprovalReportAdapters));
            approvalsSubreport.ReportSource.DataSource = approvalReportAdapters;

            var trainingBlockReportAdapters = new List<TrainingBlockReportAdapter>();
            adapters.ForEach(a => trainingBlockReportAdapters.AddRange(a.TrainingBlockReportAdapters));
            trainingBlockSubreport.ReportSource.DataSource = trainingBlockReportAdapters;

            printDateTime.Value = currentTimeInSite.ToLongDateAndTimeString();
        }

        private void HandleTrainingBlockSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var trainingFormId = GetCurrentColumnValue<long>("FormId");
            var subReport = (TrainingBlockSubReport) trainingBlockSubreport.ReportSource;
            subReport.parentIdParam.Value = trainingFormId;
        }

        private void HandleApprovalsSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var trainingFormId = GetCurrentColumnValue<long>("FormId");
            var subReport = (ApprovalReport) approvalsSubreport.ReportSource;
            subReport.ParentIdParam.Value = trainingFormId;
        }

        private void HandleFlocSubreportBeforePrint(object sender, PrintEventArgs e)
        {
            var trainingFormId = GetCurrentColumnValue<long>("FormId");
            var subReport = (FunctionalLocationSubReport) flocSubreport.ReportSource;
            subReport.parentIdParam.Value = trainingFormId;
        }
    }
}