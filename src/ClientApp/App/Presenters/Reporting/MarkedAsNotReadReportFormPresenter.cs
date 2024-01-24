using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Excel;
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
       
    class MarkedAsNotReadReportFormPresenter
    {
        private readonly IMarkedAsNotReadReportFormView view;
        private readonly IStreamingReportingService streamingReportingService;
        public MarkedAsNotReadReportFormPresenter
           (
            IMarkedAsNotReadReportFormView view, 
            bool includeHandoversByDefault,
            bool includeDirectivesByDefault)
            {
                 this.view = view;
                 streamingReportingService = ClientServiceRegistry.Instance.GetService<IStreamingReportingService>();
                 view.DirectivesChecked = includeDirectivesByDefault;
                 view.ShiftHandoverChecked = includeHandoversByDefault;
            }
        public void Form_Load(object sender, EventArgs e)
        {
            DateTime now = Clock.Now.TruncateToDay();
            view.StartDate = now.ToDate();
            view.EndDate = now.ToDate();
        }

        public void RunReportButton_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                bool usingLogBasedDirectives = ClientSession.GetUserContext().SiteConfiguration.UseLogBasedDirectives;

                Stream stream = streamingReportingService.GetMarkedAsNotReadReportData(
                    ClientSession.GetUserContext().Site,
                    view.StartDate,
                    view.EndDate,
                    new RootFlocSet(new List<FunctionalLocation>(view.UserSelectedFunctionalLocations)),
                    //view.LogsChecked,
                    // view.SummaryLogsChecked,
                    view.DirectivesChecked && usingLogBasedDirectives,
                    view.ShiftHandoverChecked, view.DirectivesChecked);
                    //  view.DirectivesChecked && !usingLogBasedDirectives,view.FlexiShiftHandoverChecked); //Aarti:INC0538563:"Mark As Read" issue.Both Directive and Directive logs should come in report.
                  //Aarti:INC0538563:"Mark As Read" issue.Both Directive and Directive logs should come in report.

                ExcelExporter excelExporter = new ExcelExporter();
                 excelExporter.Export(stream);

                view.CloseForm();
            }

        }
        public void CancelButton_Click(object sender, EventArgs e)
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

            if (!view.DirectivesChecked &&!view.ShiftHandoverChecked)
               
            {
                view.SetSelectReportError(StringResources.ReportSelectionError);
                isValid = false;
            }

            if (view.UserSelectedFunctionalLocations.Count == 0)
            {
                view.LaunchFunctionalLocationSelectionRequiredMessage();
                isValid = false;
            }

            return isValid;
        }


    }
}
