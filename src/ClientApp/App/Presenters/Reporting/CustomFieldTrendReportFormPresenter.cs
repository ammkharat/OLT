using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Forms.Reporting;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using ExcelExporter = Com.Suncor.Olt.Client.Excel.ExcelExporter;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class CustomFieldTrendReportFormPresenter
    {
        private readonly BackgroundWorker backgroundWorker = new ClientBackgroundWorker();
        private readonly IDateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaFormView view;
        private readonly IStreamingReportingService reportingService;
        private readonly IWorkAssignmentService workAssignmentService;
        private readonly IShiftPatternService shiftPatternService;

        public CustomFieldTrendReportFormPresenter()
        {
            view = new DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm()
                       { Title = StringResources.CustomFieldTrendReportFormTitle };

            view.FormLoad += HandleFormLoad;
            view.RunReportButtonClick += HandleRunReportButtonClick;
            view.CancelButtonClick += HandleCancelButtonClick;
            view.FormClose += HandleFormClose;

            reportingService = ClientServiceRegistry.Instance.GetService<IStreamingReportingService>();
            workAssignmentService = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();

            backgroundWorker.DoWork += GenerateReportInBackground;
            backgroundWorker.RunWorkerCompleted += GenerateReportInBackgroundComplete;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        public void Run(IMainForm form)
        {
            view.ShowDialog(form);
            view.Dispose();
        }

        public void HandleFormLoad()
        {
            DateTime now = Clock.Now;
            view.StartDate = now.ToDate();
            view.EndDate = now.ToDate();

            LoadAssignments();

            List<FunctionalLocation> flocList = ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations;
            view.UserSelectedFunctionalLocations = flocList;

            List<ShiftPattern> availableShiftPatterns = GetPossibleShifts(flocList[0].Site);
            view.AvailableShiftPatterns = availableShiftPatterns;

            view.IncludeLogs = true;
            view.IncludeSummaryLogs = true;
            view.IncludeDailyDirectives = true;


            IAuthorized authorized = new Authorized();
            UserRoleElements userRoleElements = ClientSession.GetUserContext().UserRoleElements;

            if (!authorized.ToViewLogs(userRoleElements))
            {
                view.DisableIncludeLogsCapability();
            }

            if (!authorized.ToViewSummaryLogs(userRoleElements))
            {
                view.DisableIncludeSummaryLogsCapability();
            }

            if (!authorized.ToViewDirectiveLogs(userRoleElements) || !ClientSession.GetUserContext().SiteConfiguration.UseLogBasedDirectives)
            {
                view.DisableIncludeDailyDirectivesCapability();
            }
        }

        private void HandleFormClose()
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        protected List<ShiftPattern> GetPossibleShifts(Site site)
        {
            return shiftPatternService.QueryBySite(site);
        }

        public void HandleRunReportButtonClick()
        {
            if (Validate())
            {
                view.RunReportButtonEnabled = false;

                UserShift startUserShift = CreateCorrectUserShift(view.StartShiftPattern, view.StartDate);
                UserShift endUserShift = CreateCorrectUserShift(view.EndShiftPattern, view.EndDate);

                RootFlocSet flocSet = new RootFlocSet(new List<FunctionalLocation>(view.UserSelectedFunctionalLocations));

                BackgroundJobArgs backgroundJobArgs = new BackgroundJobArgs(startUserShift, endUserShift, flocSet, view.SelectedAssignments, view.IncludeLogs, view.IncludeDailyDirectives, view.IncludeSummaryLogs);
                backgroundWorker.RunWorkerAsync(backgroundJobArgs);
            }
        }

        private Stream GetCustomFieldTrendReportData(BackgroundJobArgs backgroundJobArgs)
        {
            return reportingService.GetCustomFieldTrendReportData(
                    backgroundJobArgs.FlocSet,
                    backgroundJobArgs.StartUserShift, backgroundJobArgs.EndUserShift, backgroundJobArgs.Assignments, false, backgroundJobArgs.IncludeLogs, backgroundJobArgs.IncludeDailyDirectives, backgroundJobArgs.IncludeSummaryLogs);
        }

        protected static UserShift CreateCorrectUserShift(ShiftPattern pattern, Date selectedDay)
        {
            return new UserShift(pattern, CreateCorrectDateTimeForShiftPattern(selectedDay, pattern));
        }

        private static DateTime CreateCorrectDateTimeForShiftPattern(Date day, ShiftPattern pattern)
        {
            const int shiftPaddingAsMinutes = 10;
            return new DateTime(day.Year,
                                day.Month,
                                day.Day,
                                pattern.StartTime.Hour,
                                pattern.StartTime.Minute + shiftPaddingAsMinutes,
                                pattern.StartTime.Second);
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
                view.SetErrorForFunctionalLocationSelectionRequired();
                isValid = false;
            }

            if (view.SelectedAssignments.Count == 0)
            {
                view.SetErrorForWorkAssignmentSelectionRequired();
                isValid = false;
            }
            
            if (view.SelectedAssignments.Count > 1)
            {
                view.SetErrorForMoreThanOneWorkAssignmentSelection();
                isValid = false;
            }

            if (view.IncludeLogs == false && view.IncludeSummaryLogs == false && view.IncludeDailyDirectives == false)
            {
                view.SetSelectReportError();
                isValid = false;
            }

            return isValid;
        }

        public void HandleCancelButtonClick()
        {
            view.CloseForm();
        }

        private void LoadAssignments()
        {
            List<WorkAssignment> assignments = workAssignmentService.QueryBySite(ClientSession.GetUserContext().Site);

            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> adapters =
                assignments.ConvertAll(a => new WorkAssignmentMultiSelectGridRenderer.DisplayAdapter(a));

            view.Assignments = adapters;
        }

        private void GenerateReportInBackground(object sender, DoWorkEventArgs e)
        {
            e.Result = GetCustomFieldTrendReportData((BackgroundJobArgs) e.Argument);

            BackgroundWorker bgWorker = (BackgroundWorker)sender;
            if (bgWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void GenerateReportInBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            view.RunReportButtonEnabled = true;

            if (e.Error != null)
            {
                throw e.Error;
            }

            using (Stream stream = (Stream) e.Result)
            {
                ExcelExporter excelExporter = new ExcelExporter();
                excelExporter.Export(stream);
            }

            view.CloseForm();
        }

        private class BackgroundJobArgs
        {
            public UserShift StartUserShift { get; private set; }
            public UserShift EndUserShift { get; private set; }
            public RootFlocSet FlocSet { get; private set; }
            public List<WorkAssignment> Assignments { get; private set; }
            public bool IncludeLogs { get; private set; }
            public bool IncludeDailyDirectives { get; private set; }
            public bool IncludeSummaryLogs { get; private set; }

            public BackgroundJobArgs(UserShift startUserShift, UserShift endUserShift, RootFlocSet flocSet, List<WorkAssignment> assignments, bool includeLogs, bool includeDailyDirectives,
                         bool includeSummaryLogs)
            {
                StartUserShift = startUserShift;
                EndUserShift = endUserShift;
                FlocSet = flocSet;
                Assignments = assignments;
                IncludeLogs = includeLogs;
                IncludeDailyDirectives = includeDailyDirectives;
                IncludeSummaryLogs = includeSummaryLogs;
            }
        }

    }
}
