using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGenericTemplateView : IFormView
    {
        event Action PressureSafetyValveAnswerChanged;
        
        DialogResult ShowFormHasAdditionalApproversRequired();
        void SetErrorForValidToIsInThePast();
        event Action WaitingApprovalButtonClicked;
        bool ApprovalsEnabled { set; }

        //DMND0009363-#950321920-Mukesh
        event Action NeverEndCheckChanged;
        bool neverEndvisible { set; get; }
        bool neverEndchecked { set; get; }
    }
}
