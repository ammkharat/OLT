using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureGenericTemplateApprovalView : IBaseForm
    {
        event EventHandler ContractorInformationChanged;
        event EventHandler AddOrUpdate;
        event EventHandler Delete;
        event EventHandler Clear;
        event EventHandler ContractorSelected;
        event EventHandler EFormTypeChanged;
        event EventHandler Save;
        event FormClosingEventHandler ViewClosing;
        
        Site ContractorSite { set; }
        IList<GenericTemplateApproval> Contractors { get; set; }
        List<GenericTemplateApproval> AllEFormType { set; get; }
        GenericTemplateApproval eFormType { get; set; }
    
        // Actions:
        bool AddOrUpdateEnabled { set; }
        bool DeleteEnabled { set; }
        bool ClearEnabled { set; }

        string AddUpdateText { set; }
        
        string ContractorName { get; set; }

        GenericTemplateApproval SelectedContractor { get; }
        void ClearSelectedContractor();

        void ShowWarningMessage(string message, string title);

        //DMND0009363-#950321920-Mukesh
        bool ShowneverEnd { set; get; }
    }
}
