using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IWorkPermitFortHillsPrintable
    {
        void ShowUnableToPrintWithExpiryDateInPastMessage();
        void UpdateWorkPermit(WorkPermitFortHills permit);
        void ShowPrintingFailedMessage();
        bool? AskIfTheyWantToPrintTheForms();
        bool IsOnlyPrintingOnePermit { get; set; }
        bool ShouldNotPrintForms { get; set; }
    }
}