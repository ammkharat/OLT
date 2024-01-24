using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IWorkPermitEdmontonPrintable
    {
        void ShowUnableToPrintWithExpiryDateInPastMessage();
        void UpdateWorkPermit(WorkPermitEdmonton permit);
        void ShowPrintingFailedMessage();
        bool? AskIfTheyWantToPrintTheForms();
        bool IsOnlyPrintingOnePermit { get; set; }
        bool ShouldNotPrintForms { get; set; }
    }
}