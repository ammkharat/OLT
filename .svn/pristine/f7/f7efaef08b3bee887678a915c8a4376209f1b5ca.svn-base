using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class DateRangeSelectorPresenter
    {        
        private readonly IDateRangeSelectorFormView view;
        private Range<Date> dateRange;

        public DateRangeSelectorPresenter(IDateRangeSelectorFormView view)
        {
            this.view = view;
        }
       
        public void HandleSelectButtonClicked(object sender, EventArgs e  )
        {
            if (view.CustomRangeChecked)
            {
                //RITM0232944 - Vibhor
                if (!SetCustomDateRange()) return;
            } 
            else
            {
                SetDateRangeBackFromToday();
            }

            if (DateRangeIsWiderThanOneYear())
            {
                view.DisplayErrorDialog(StringResources.DateRangeSelectorDateOutOfRangeMessageBoxText);
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

                view.DialogResult = DialogResult.OK;
                view.Close();
            }
        }

        private bool DateRangeIsWiderThanOneYear()
        {
            return new DateRange(dateRange.LowerBound, dateRange.UpperBound).DateRangeIsWiderThanOneYear;
        }

        private bool DateRangeIsWiderThanThirtyOneDays()
        {
            TimeSpan timeSpan = dateRange.UpperBound - dateRange.LowerBound;
            if (timeSpan.TotalDays > 31)
            {
                return true;
            }

            return false;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            view.AddFixedRangeDuration(Duration.OneWeek);
            view.AddFixedRangeDuration(Duration.OneMonth);
            view.AddFixedRangeDuration(Duration.ThreeMonths);
            view.AddFixedRangeDuration(Duration.SixMonths);
            view.AddFixedRangeDuration(Duration.OneYear);
            view.SelectedFixedRangeDuration = Duration.ThreeMonths;
            view.CustomRangeChecked = true;
        }


        //Vibhor
        //private void SetCustomDateRange()
        //{   
        //    Date startDate = view.StartDate;
        //    Date endDate = view.EndDate;

        //        dateRange = startDate > endDate ?
        //                    new Range<Date>(endDate, startDate) :
        //                    new Range<Date>(startDate, endDate);
        //}
        //RITM0232944 - Vibhor
        private bool SetCustomDateRange()
        {
            Date startDate = view.StartDate;
            Date endDate = view.EndDate;
            if (startDate > endDate)
            {
                view.SetErrorForStartDateCannotGreaterThanendDate();
                return false;
            }
            dateRange = new Range<Date>(startDate, endDate);
            return true;
        }

        private void SetDateRangeBackFromToday()
        {
            Duration selectedDuration = view.SelectedFixedRangeDuration;
            DateTime now = Clock.Now;
            Date today = new Date(now);
            Date durationAgo = selectedDuration.Before(today);
            dateRange = new Range<Date>(durationAgo, today);
        }

        public void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            dateRange = null;
            view.Close();
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
        
    }
}
