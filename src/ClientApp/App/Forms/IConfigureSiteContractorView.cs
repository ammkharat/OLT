using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureSiteContractorView : IBaseForm
    {
        event EventHandler ContractorInformationChanged;
        event EventHandler AddOrUpdate;
        event EventHandler Delete;
        event EventHandler Clear;
        event EventHandler ContractorSelected;
        event EventHandler Save;
        event FormClosingEventHandler ViewClosing;
        
        Site ContractorSite { set; }
        IList<Contractor> Contractors { get; set; }
        
        // Actions:
        bool AddOrUpdateEnabled { set; }
        bool DeleteEnabled { set; }
        bool ClearEnabled { set; }

        string AddUpdateText { set; }
        
        string ContractorName { get; set; }

        Contractor SelectedContractor { get; }
        void ClearSelectedContractor();

        void ShowWarningMessage(string message, string title);
    }
}