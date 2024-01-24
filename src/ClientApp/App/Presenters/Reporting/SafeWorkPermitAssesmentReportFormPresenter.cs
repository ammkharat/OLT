using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Excel;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Forms.Reporting;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class SafeWorkPermitAssessmentReportFormPresenter
    {
        private readonly IDateRangeAndFlocReportCriteriaFormView view;
        private readonly IStreamingReportingService reportingService;

        public SafeWorkPermitAssessmentReportFormPresenter()
        {
            view = new DateRangeAndFlocReportCriteriaForm();
            view.FormLoad += HandleFormLoad;
            view.RunReportButtonClick += HandleRunReportButtonClick;
            view.CancelButtonClick += HandleCancelButtonClick;

            reportingService = ClientServiceRegistry.Instance.GetService<IStreamingReportingService>();
        }

        public void HandleFormLoad()
        {
            view.Title = StringResources.SafeWorkPermitAssessmentReport_Excel_Report_Title;
            DateTime now = Clock.Now.TruncateToDay();
            view.StartDate = now.ToDate();
            view.EndDate = now.ToDate();
        }

        public void HandleRunReportButtonClick()
        {
            if (Validate())
            {
                Stream stream =
                    reportingService.GetSafeWorkPermitAssessmentReportData(new RootFlocSet(new List<FunctionalLocation>(view.UserSelectedFunctionalLocations)),
                    new DateRange(view.StartDate, view.EndDate));

                ExcelExporter excelExporter = new ExcelExporter();
                excelExporter.Export(stream);

                view.CloseForm();
            }
        }

        public void HandleCancelButtonClick()
        {
            view.CloseForm();
        }

        private bool Validate()
        {
            view.ClearErrors();

            bool isValid = true;

            if (view.StartDate > view.EndDate)
            {
                view.SetErrorForStartDate(StringResources.FromDateBeforeToDate);
                view.SetErrorForEndDate(StringResources.FromDateBeforeToDate);
                isValid = false;
            }

            if (view.UserSelectedFunctionalLocations.Count == 0)
            {
                view.LaunchFunctionalLocationSelectionRequiredMessage();
                isValid = false;
            }

            return isValid;
        }

        public void Run(IMainForm form)
        {
            view.ShowDialog(form);
        }
    }
}