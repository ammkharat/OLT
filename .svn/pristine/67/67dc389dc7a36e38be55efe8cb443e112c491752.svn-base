using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitFilterSelectorPresenter : IWorkPermitFilterSelectorPresenter
    {        
        private readonly IWorkPermitFilterSelectorFormView view;
        private Range<Date> dateRange;
        private List<WorkPermitStatus> previousStatuses;
        private Duration previousSelectedDuration;

        public WorkPermitFilterSelectorPresenter(IWorkPermitFilterSelectorFormView view)
        {
            this.view = view;
            this.view.Presenter = this;
            previousStatuses = new List<WorkPermitStatus>(WorkPermitPagePresenter.DefaultStatuses);
            previousSelectedDuration = Duration.OneMonth;
        }

        public void HandleSelectButtonClick(object sender, EventArgs e)
        {
            if (view.CustomRangeChecked)
            {
                SetCustomDateRange();
            }
            else
            {
                SetDateRangeBackFromToday();
            }

            if (view.CustomRangeChecked && DateRangeIsWiderThanOneYear())
            {
                view.DisplayErrorDialog(StringResources.WorkPermitFilterSelectorDateRangeTooWideError);
            }
            else if (HasNoStatusSelected)
            {
                view.DisplayErrorDialog(StringResources.WorkPermitFilterSelectorStatusNotSelectedError);
            }
            else
            {
                if (DateRangeIsWiderThanThirtyOneDays())
                {
                    DialogResult dialogResult = view.DisplayWarningDialog(StringResources.DateRangeSelectorDataMayTakeALongTimeToBeReturnedMessageBoxText);
                    if (!dialogResult.Equals(DialogResult.Yes))
                    {
                        return;
                    }
                }

                previousStatuses = SelectedStatuses;
                previousSelectedDuration = view.SelectedFixedRangeDuration;
                view.CloseForm(DialogResult.OK);
            }
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.AddFixedRangeDuration(new[]
                                           {
                                               Duration.OneMonth, 
                                               Duration.ThreeMonths, 
                                               Duration.SixMonths,
                                               Duration.OneYear
                                           });

            view.SelectedFixedRangeDuration = previousSelectedDuration;
            view.CustomRangeChecked = true;
            
            InitializeStatusCheckBoxes();
        }

        private bool HasNoStatusSelected
        {
            get { return SelectedStatuses.Count == 0; }
        }

        private bool DateRangeIsWiderThanOneYear()
        {
            return new DateRange(dateRange.LowerBound, dateRange.UpperBound).DateRangeIsWiderThanOneYear;
        }

        public void SetCustomDateRange()
        {
            Date startDate = view.StartDate;
            Date endDate = view.EndDate;
            dateRange = startDate > endDate ?
                            new Range<Date>(endDate, startDate) :
                            new Range<Date>(startDate, endDate);
        }

        public void SetDateRangeBackFromToday()
        {
            Duration selectedDuration = view.SelectedFixedRangeDuration;
            DateTime now = Clock.Now;
            var today = new Date(now);
            Date durationAgo = selectedDuration.Before(today);
            dateRange = new Range<Date>(durationAgo, null);
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            dateRange = null;
            view.CloseForm(DialogResult.Cancel);
        }

        public void HandleFixedRangeSelected(object sender, EventArgs e)
        {
            view.FixedRangeDurationEnabled = true;
            view.StartDateEnabled = false;
            view.EndDateEnabled = false;
        }

        public void HandleCustomRangeSelected(object sender, EventArgs e)
        {
            view.FixedRangeDurationEnabled = false;
            view.StartDateEnabled = true;
            view.EndDateEnabled = true;
        }

        public Range<Date> DateRange
        {
            get { return dateRange; }
        }
        
        public List<WorkPermitStatus> SelectedStatuses
        {
            get
            {
                var selectedStatuses = new List<WorkPermitStatus>();
                
                if (view.ApprovedChecked)
                    selectedStatuses.Add(WorkPermitStatus.Approved);

                if (view.ArchiveChecked)
                    selectedStatuses.Add(WorkPermitStatus.Archived);

                if (view.CompletedChecked)
                    selectedStatuses.Add(WorkPermitStatus.Complete);
                
                if (view.IssuedChecked)
                    selectedStatuses.Add(WorkPermitStatus.Issued);

                if (view.PendingChecked)
                    selectedStatuses.Add(WorkPermitStatus.Pending);

                if (view.RejectedCheck)
                    selectedStatuses.Add(WorkPermitStatus.Rejected);

                return selectedStatuses;
            }
        }

        public bool DisplaySelector()
        {
            DialogResult dialogResult = view.ShowDialog();
            return DialogResult.OK == dialogResult;
        }

        private void InitializeStatusCheckBoxes()
        {
            view.ApprovedChecked = previousStatuses.Contains(WorkPermitStatus.Approved);
            view.ArchiveChecked = previousStatuses.Contains(WorkPermitStatus.Archived);
            view.CompletedChecked = previousStatuses.Contains(WorkPermitStatus.Complete);
            view.IssuedChecked = previousStatuses.Contains(WorkPermitStatus.Issued);
            view.PendingChecked = previousStatuses.Contains(WorkPermitStatus.Pending);
            view.RejectedCheck = previousStatuses.Contains(WorkPermitStatus.Rejected);
        }

        private bool DateRangeIsWiderThanThirtyOneDays()
        {
            Date upperBound = dateRange.UpperBound ?? Clock.DateNow;
            TimeSpan timeSpan = upperBound - dateRange.LowerBound;
            if (timeSpan.TotalDays > 31)
            {
                return true;
            }

            return false;
        }

    }
}
