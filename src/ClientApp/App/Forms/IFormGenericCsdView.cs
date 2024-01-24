using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGenericCsdView : IFormView
    {
        event Action PressureSafetyValveAnswerChanged;
        event Action HistoryClicked;
        bool? HasBeenCommunicated{ get; set; }
        bool? HasAttachments{ get; set; }
        string CsdReason{ get; set; }
        bool? IsTheCSDForAPressureSafetyValve { get; set; }
        string CriticalSystemDefeated { get; set; }
        void SetErrorForEmptyCriticalSystemDefeated();
        DialogResult ShowFormHasAdditionalApproversRequired();
        void SetErrorForValidToIsInThePast();
        void SetErrorForNoPressureSafetyValveResponse();
        void SetErrorForNoHasAttachmentsResponse();
        void SetErrorForNoHasBeenCommunicatedResponse();
        void SetErrorForNoCsdReasonGiven();
    }
}
