using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

//RITM-RITM0164850   Mukesh  Jan 12, 2018
namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureRoleView : IBaseForm
    {
        event EventHandler ContractorInformationChanged;
        event EventHandler AddOrUpdate;
        event EventHandler Delete;
        event EventHandler Clear;
        event EventHandler ContractorSelected;
        event FormClosingEventHandler ViewClosing;

        Site roleSite { set; }
        IList<Role> roles { get; set; }

        // Actions:
        bool AddOrUpdateEnabled { set; }
        bool DeleteEnabled { set; }
        bool ClearEnabled { set; }

        string AddUpdateText { set; }

        string RoleName { get; set; }

         string activedirectorykey { get; set; }

         bool isadministratorrole { get; set; }

         bool isreadonlyrole { get;  set; }

         bool isdefaultreadonlyroleforsite { get; set; }

         bool isworkpermitnonoperationsrole { get; set; }

         bool warnifworkassignmentnotselected { get; set; }

         string alias { get;  set; }

        Role SelectedRole { get;  }

        void ClearSelectedContractor();

        void ShowWarningMessage(string message, string title);
        void ShowNameIsEmptyError();
         void ClearErrorProviders();
         void ShowAliasIsEmptyError();
         void ShowActiveDirectoryKeyIsEmptyError();

    }
}
