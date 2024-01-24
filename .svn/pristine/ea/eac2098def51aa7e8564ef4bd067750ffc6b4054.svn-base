using System;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitDefaultTimesPreferenceTabPagePresenter
    {
        readonly IWorkPermitDefaultTimesPreferenceTabPage page;

        public WorkPermitDefaultTimesPreferenceTabPagePresenter(IWorkPermitDefaultTimesPreferenceTabPage page)
        {
            this.page = page;
        }

        public void Load(object sender, EventArgs e)
        {
            UserWorkPermitDefaultTimePreferences preferences = ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences;
            page.PreShiftPadding = preferences.PreShiftPadding;
            page.PostShiftPadding = preferences.PostShiftPadding;
        }

        public bool Validate()
        {
            page.ClearValidationProviders();

            bool allValid = true;


            var preferences = new UserWorkPermitDefaultTimePreferences(ClientSession.GetUserContext().User.IdValue,
                                                                       page.PreShiftPadding,
                                                                       page.PostShiftPadding);
            
            if (preferences.ValidatePreShiftPadding() == false)
            {
                page.ShowPreShiftPaddingError(ShiftPaddingExceedLimitError());
                allValid = false;
            }
            
            if (preferences.ValidatePostShiftPadding() == false)
            {
                page.ShowPostShiftPaddingError(ShiftPaddingExceedLimitError());
                allValid = false;
            }

            return allValid;
        }

        public void Update()
        {
            UserWorkPermitDefaultTimePreferences preferences = 
                ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences;
            
            preferences.PreShiftPadding = page.PreShiftPadding;
            preferences.PostShiftPadding = page.PostShiftPadding;
        }

        private string ShiftPaddingExceedLimitError()
        {
            TimeSpan limit = Common.Utility.Constants.WorkPermitTimePreferenceOffsetLimit;
            return string.Format(StringResources.WorkPermitTimePreferenceOffsetError,
                                 new Time(limit).ToDateTime());
        }
    }
}
