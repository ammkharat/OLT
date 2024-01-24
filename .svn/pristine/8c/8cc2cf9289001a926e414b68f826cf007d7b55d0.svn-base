using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IDateRangeSelectorFormView : IForm
    {
        bool FixedRangeChecked { get; }
        bool CustomRangeChecked { get; set; }
        Date StartDate { get; }
        Date EndDate { get; }
        bool StartDateEnabled { set; }
        bool EndDateEnabled { set; }
        bool FixedRangeDurationEnabled { set; }

        Duration SelectedFixedRangeDuration { get; set; }

        void AddFixedRangeDuration(Duration duration);
        void DisplayErrorDialog(string message);
        DialogResult DisplayWarningDialog(string message);
        void SetErrorForStartDateCannotGreaterThanendDate(); //RITM0232944 - Vibhor
    }
}