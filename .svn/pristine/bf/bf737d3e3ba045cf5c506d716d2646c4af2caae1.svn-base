using System;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using DevExpress.Office.PInvoke;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitCloseFormView : IRespondFormView
    {
        event EventHandler SubmitButtonClick;
        event EventHandler CancelButtonClick;
        event EventHandler CreateLogCheckedChanged;
        
        string Description { set; }
        bool IsLogAnOperatingEngineeringLog { get; set;}
        void EnableMakingAnOperatingEngineerLog();
        void HideOperatingEngineerLogCheckbox();
     
        string OperatingEngineerLogDisplayText { set; }
        bool CreateLogEnabled { set; }
        string FormTitle { set; }
        void HideDescription();

       
    }

    public interface IWorkPermitCloseWithStatusFormView : IBaseForm
    {
        event EventHandler SubmitButtonClick;
        event EventHandler CancelButtonClick;
        event EventHandler ActionItemCheckboxCheck;//Added by ppanigrahi

        DateTime CreateDateTime { set; }
        string Shift { set; }
        User Author { set; }
        List<WorkPermitLoggableStatus> Statuses { set; }
        WorkPermitLoggableStatus SelectedStatus { get; }
        string Comment { get; }
        string CommentsSectionTitle { set; }

        string Description { set; }
        string FormTitle { set; }

        bool StatusHidden { get; }
        void HideCloseStatus();

        void SetErrorForNoStatusSelected();
        void SetErrorForNoComments();
        void ClearErrors();

        //Addded by ppanigrahi
        bool ActionItemCheckBoxVisible { set; }
        bool ActionItemCheckBoxchecked { get; set; }
        bool commentBoxEnable { get; set; }
        bool commentBoxVisible { set; }
        bool dateTimeControlVisible { set; }
        bool dateTimeControlEnable { set; }
        bool ActionItemCheckBoxEnable { get; set; }
        void SetErrorForNoActionItemComments();
      //  bool hotpanelVisible { set; }
        string WorkPermitCloseComment { get; }
        DateTime ClosingDateTime { get; set; }
        Size SetSize { set; }
        Size setFormSize { set; }
        Size mainPanelSize { set; }
    

    }
}
