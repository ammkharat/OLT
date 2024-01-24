using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitFilterSelectorFormView
    {
        DialogResult ShowDialog();
        void CloseForm(DialogResult result);

        WorkPermitFilterSelectorPresenter Presenter { set; }
        bool FixedRangeChecked { get; set; }
        bool CustomRangeChecked { get; set; }
        Date StartDate { get; }
        Date EndDate { get; }
        bool StartDateEnabled { set; }
        bool EndDateEnabled { set; }
        bool FixedRangeDurationEnabled { set; }

        Duration SelectedFixedRangeDuration { get; set; }

        void AddFixedRangeDuration(Duration[] duration);
        void DisplayErrorDialog(string message);

        Range<Date> SelectedRange { get; }

        bool ArchiveChecked { get; set; }
        bool ApprovedChecked { get; set; }
        bool CompletedChecked { get; set; }
        bool IssuedChecked { get; set; }
        bool PendingChecked { get; set; }
        bool RejectedCheck { get; set; }

        DialogResult DisplayWarningDialog(string message);
    }
}