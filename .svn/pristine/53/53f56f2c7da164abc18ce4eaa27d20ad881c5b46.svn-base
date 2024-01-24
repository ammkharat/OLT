using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{    
    public class ImportPermitRequestEdmontonFormPresenter : BaseFormPresenter<IImportPermitRequestEdmontonFormView>
    {
        private readonly IPermitRequestEdmontonService importService;

        private readonly BackgroundWorker backgroundWorker = new ClientBackgroundWorker();
        private readonly ImportPermitRequestMultiDayProgressForm progressForm;

        private readonly List<PermitRequestImportResult> importResults = new List<PermitRequestImportResult>();
        private readonly List<NotifiedEvent> notifiedEventsFromFinalizeStep = new List<NotifiedEvent>();
        private int numberOfTurnaroundPermitRequestsProcessedInFinalizeStep;


        public ImportPermitRequestEdmontonFormPresenter(IPermitRequestEdmontonService importService) : base(new ImportPermitRequestEdmontonForm())
        {
            this.importService = importService;
           
            view.Load += HandleFormLoad;
            view.ImportButtonClicked += HandleImportButtonClicked;
            view.CancelButtonClicked += CancelButton_Click;
            view.FormClosing += HandleFormClosing;

            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorkerDoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorkerWorkCompleted;
                 
            progressForm = new ImportPermitRequestMultiDayProgressForm();      
            
            importResults.Clear();
            notifiedEventsFromFinalizeStep.Clear();
        }
       
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {                                               
            BackgroundWorkerArguments args = (BackgroundWorkerArguments) e.Argument;                        
            List<Date> importDates = args.GetImportDates();

            int progressCounter = 0;

            long batchId = importService.GetNewBatchId();

            foreach (Date importDate in importDates)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                List<IHasPermitKey> resultsImportedThusFar = importResults.GetPermitKeyDataFromPermitRequests();
                PermitRequestImportResult result = importService.Import(args.User, importDate, args.Flocs, resultsImportedThusFar, batchId);
                importResults.Add(result);

                // if we get an Error for any dates, then let's stop processing, and throw up an error with no inserts/updates/deletes for any records.
                if (result.HasError)
                    break;

                progressCounter++;
                if (progressForm.InvokeRequired)
                {
                    Action<int> setProgressBarValue = progressForm.SetProgressBarValue;
                    progressForm.Invoke(setProgressBarValue, progressCounter);
                }
                else
                {
                    progressForm.SetProgressBarValue(progressCounter);
                }
            }
            
            List<IHasPermitKey> importRequestDataList = importResults.GetProcessedWorkOrderData();
            List<IHasPermitKey> rejections = importResults.GetKeysForRejectedPermitRequests();

            bool severeError = importResults.Exists(r => r.HasError);

            if (!severeError)
            {
                EdmontonPermitRequestPostFinalizeResult finalizeResult = importService.FinalizeImport(args.StartDate, args.EndDate, importRequestDataList, rejections, batchId, args.User);
                notifiedEventsFromFinalizeStep.AddRange(finalizeResult.NotifiedEvents);
                numberOfTurnaroundPermitRequestsProcessedInFinalizeStep = finalizeResult.NumberOfTurnaroundPermitsHandled;
            }
            
            // Don't use the e.Result property here. It will be null if a cancellation happens, and we need to know what had happened up to that point for later code.
            // e.Result = backgroundWorkResults;
        }
       
        private int GetNumberOfDaysToImport(Date start, Date end)
        {
            return (end - start).Days;    
        }
      
        private void BackgroundWorkerWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            progressForm.IsWorkDone = true;
            progressForm.WaitABit();
            progressForm.Close();
                                 
            if (importResults.HasErrors() || importResults.HasRejections())
            {
                ImportPermitRequestEdmontonErrorFormPresenter presenter = new ImportPermitRequestEdmontonErrorFormPresenter(importResults, numberOfTurnaroundPermitRequestsProcessedInFinalizeStep);
                presenter.Run(view);
            }
            else
            {
                string message;

                if (importResults.HasResults() || numberOfTurnaroundPermitRequestsProcessedInFinalizeStep > 0)
                {
                    int count = importResults.GetResultCount() + numberOfTurnaroundPermitRequestsProcessedInFinalizeStep;
                    message = String.Format(StringResources.PermitRequestImportSuccess_ResultsReturned, count);
                }
                else
                {
                    message = StringResources.PermitRequestImportSuccess_NothingReturnedForMultipleDates;
                }

                view.ShowSuccessMessageBox(message);
            }

            ServiceEventDispatcher.DispatchEvents(importResults.GetNotifiedEvents());
            ServiceEventDispatcher.DispatchEvents(notifiedEventsFromFinalizeStep);                           
            
            view.DialogResult = DialogResult.OK;
            view.Close();
        }

        private void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                e.Cancel = true;                
            }                         
        }
       
        private void HandleFormLoad(object sender, EventArgs e)
        {
            Date defaultStartDate = GetDefaultStartDate();
            view.StartDate = defaultStartDate;
            view.EndDate = GetDefaultEndDate(defaultStartDate);

            view.LastImportDate = GetLastImportDateTimeText();
            view.FromDateLabel = StringResources.PermitRequestImportFromDateLabel;            
        }

        private string GetLastImportDateTimeText()
        {
            DateTime? lastImportDateTime = importService.GetLastImportDateTime();
            if (!lastImportDateTime.HasValue)
            {
                return StringResources.None;
            }
            
            return lastImportDateTime.Value.ToShortDateAndTimeString();            
        }

        private static Date GetDefaultStartDate()
        {
            DateTime now = Clock.Now.TruncateToDay();
            return now.ToDate().NextNonWeekendDate;           
        }

        private Date GetDefaultEndDate(Date defaultStartDate)
        {
            return defaultStartDate.AddDays(6);
        }

        private void HandleImportButtonClicked(object sender, EventArgs e)
        {
            int days = GetNumberOfDaysToImport(view.StartDate, view.EndDate);

            bool wasSuccessful = Validate(days, view.StartDate, view.EndDate);

            if (!wasSuccessful)
            {
                return;
            }
                                 
            view.DisableControlsForImport();

            progressForm.StartPosition = FormStartPosition.Manual;
            progressForm.Location = view.GetCenterParentLocation(progressForm);
            progressForm.Show(view);
            
            progressForm.Maximum = days + 1;            

            BackgroundWorkerArguments args = new BackgroundWorkerArguments(
                view.StartDate, view.EndDate, ClientSession.GetUserContext().User, ClientSession.GetUserContext().DivisionsForSelectedFunctionalLocations);
          
            backgroundWorker.RunWorkerAsync(args);            
        }

        private bool Validate(int days, Date start, Date end)
        {
            if (days > 7)
            {
                view.SetErrorForTooManyDaysSelected();
                return false;
            }

            if (end < start)
            {
                view.SetErrorForEndDateBeforeStartDate();
                return false;
            }

            return true;
        }

        private class BackgroundWorkerArguments
        {
            public BackgroundWorkerArguments(Date startDate, Date endDate, User user, List<FunctionalLocation> flocs)
            {
                StartDate = startDate;
                EndDate = endDate;
                User = user;
                Flocs = flocs;            
            }

            public Date StartDate { get; private set; }
            public Date EndDate { get; private set; }            
            public User User { get; private set; }
            public List<FunctionalLocation> Flocs { get; private set; }

            public List<Date> GetImportDates()
            {
                List<Date> list = new List<Date>();
                Date current = StartDate;

                while (current <= EndDate)
                {
                    list.Add(current);
                    current = current.AddDays(1);
                }

                return list;
            }
        }
    }
}