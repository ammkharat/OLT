using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormTemporaryInstallationsView : IFormView
    {
        event Action PressureSafetyValveAnswerChanged;
        event Action HistoryClicked;
        string CsdReason{ get; set; }
        DialogResult ShowFormHasAdditionalApproversRequired();
        void SetErrorForValidToIsInThePast();
        void SetErrorForNoCsdReasonGiven();
        bool ApprovalsEnabled { set; }
        string ApprovalsGroupBoxLabel { set; }
    
        //bool? HasBeenCommunicated{ get; set; }
        //bool? HasAttachments{ get; set; }
        //bool? IsTheCSDForAPressureSafetyValve { get; set; }
        //string CriticalSystemDefeated { get; set; }
        //void SetErrorForEmptyCriticalSystemDefeated();
        //void SetErrorForNoPressureSafetyValveResponse();
        //void SetErrorForNoHasAttachmentsResponse();
        //void SetErrorForNoHasBeenCommunicatedResponse();
    }
}
