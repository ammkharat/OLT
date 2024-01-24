using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class OnPremisePersonnelShiftReportPresenter :
        AbstractReportPagePresenter
            <IDateRangeReportParametersControl, OnPremisePersonnelShiftReportDTO, OnPremisePersonnelShiftReport, OnPremisePersonnelShiftReportAdapter>
    {
        private readonly IFormEdmontonService formService;
        private readonly OnPremisePersonnelShiftReportPrintActions printActions;

        public OnPremisePersonnelShiftReportPresenter()
            : base(StringResources.OnPremisePersonnelShiftReportTitle, new RtfReportsPage(), false)
        {
            formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            printActions = new OnPremisePersonnelShiftReportPrintActions();
        }

        protected override PrintActions<OnPremisePersonnelShiftReportDTO, OnPremisePersonnelShiftReport, OnPremisePersonnelShiftReportAdapter> PrintActions
        {
            get { return printActions; }
        }

        protected override IDateRangeReportParametersControl CreateParametersControl()
        {
            return new DateRangeReportParametersControl();
        }

        protected override void Page_RunReportClicked(object sender, EventArgs e)
        {
            if (parameters.IsValid)
            {
                var reportDataSource = CreateDataSource();
                if (null == reportDataSource || reportDataSource.Count == 0 || reportDataSource.First().OnPremisePersonnelShiftReportDetailDTOs.Count == 0)
                {
                    Page.DisplayErrorMessage(StringResources.ReportsPage_NoResultsFound);
                }
                else
                {
                    XtraReport xtraReport = PrintActions.CreateReport(reportDataSource);
                    Page.Report = xtraReport;
                }
            }
            else
            {
                Page.DisplayErrorMessage(parameters.ErrorMessage);
            }
        }

        protected override void InitializeParameters()
        {
            parameters.SelectedStartDate = Clock.Now.ToDate();
            parameters.SelectedEndDate = Clock.Now.AddDays(5).ToDate();
        }

        protected override List<OnPremisePersonnelShiftReportDTO> CreateDataSource()
        {
            var queryOnPremisePersonnelShiftReport =
                formService.QueryOnPremisePersonnelShiftReport(
                    new Range<DateTime>(parameters.SelectedStartDate.ToDateTimeAtStartOfDay(),
                        parameters.SelectedEndDate.ToDateTimeAtEndOfDay()));
            return
                queryOnPremisePersonnelShiftReport.ToList();
        }
    }
}