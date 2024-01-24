using System;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface IWorkPermitDefaultTimesPreferenceTabPage : IPreferenceTabPage
    {
        TimeSpan PreShiftPadding { get; set; }
        TimeSpan PostShiftPadding { get; set; }

        void ClearValidationProviders();
        void ShowPreShiftPaddingError(string errorMessage);
        void ShowPostShiftPaddingError(string errorMessage);
    }
}
