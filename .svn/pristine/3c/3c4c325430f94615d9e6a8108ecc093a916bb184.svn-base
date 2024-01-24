using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormOP14View : IFormView
    {
        event Action PressureSafetyValveAnswerChanged;
        /*RITM0446491EN50 : CSD Approval Buttonsbug details -Aarti*/
        event Action DepartmentOperationsAnswerChanged; 
        event Action CriticalSystemDefeatedTextBoxChanged;
        event Action ContentRichTextEditorChanged;
        event Action FunctionalLocationListBoxChanged;//RITM0446491:-End
        FormOP14Department Department { get; set; }
        bool IsTheCSDForAPressureSafetyValve { get; set; }
        string CriticalSystemDefeated { get; set; }
        void SetErrorForEmptyOP14CriticalSystemDefeated();
        DialogResult ShowFormHasAdditionalApproversRequired();
        void SetErrorForValidToIsInThePast();
        event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
        /*RITM0265746 - Sarnia CSD marked as read start*/
        bool ShowLogMarkedAsReadWarning();
        /*RITM0265746 - Sarnia CSD marked as read end*/

        //DMND0010261-SELC CSD EdmontonPipeline
        bool IsSCADASupport { get; set; }

        string SetFormTitleName { set; } //INC0458108 : Added By Vibhor {Sarnia : Remove references to "OP-14" within form labels and menu items}


        
    }
}
