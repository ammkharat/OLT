using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
   public  interface IGenericTemplateEmailConfigurationview:IBaseForm
    {

        event EventHandler ContractorInformationChanged;
        event EventHandler Add;
       event EventHandler UpdateEmail; 
        event EventHandler Delete;
        event EventHandler Clear;
        event EventHandler ContractorSelected;
        event EventHandler EFormTypeChanged;
        event EventHandler Save;
        event FormClosingEventHandler ViewClosing;
       event EventHandler EFormRoleChanged;

        Site ContractorSite { set; }
        IList<GenericTemplateEmailApprovalConfiguration> Contractors { get; set; }
        List<GenericTemplateEmailApprovalConfiguration> AllEFormType { set; get; }
        GenericTemplateEmailApprovalConfiguration eFormType { get; set; }
        string eRoleType { get; }

        // Actions:
        bool AddEnabled { set; }
        bool UpdateEnabled { set; }
    
        
        bool ClearEnabled { set; }


        bool cmbApproverEnabled { set; }

        string AddText { get; }
        string UpdateText { get; }

        string ContractorName { get;  }

        string ContractorID { get; set; }

        string EmailList { get; set; }

       GenericTemplateEmailApprovalConfiguration SelectedContractor { get; set; }
        void ClearSelectedContractor();

        void ShowWarningMessage(string message, string title);

       
        bool ShowneverEnd { set; get; }

        bool groupBoxenabled { set; }

        bool lblApprovertextvisibe { get; set; }

        string lblApproveText { get; set; }
        string lblApprovelongtext { get; set; }
    }
}
