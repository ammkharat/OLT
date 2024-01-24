
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using System.Text.RegularExpressions;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureRolePresenter
    {
        private readonly IConfigureRoleView view;
        private readonly IRoleService contractorService;
        private bool viewCloseNeedsConfirmation;
        private readonly Site site;

        public ConfigureRolePresenter(IConfigureRoleView view) : 
            this(view, ClientServiceRegistry.Instance.GetService<IRoleService>())
        {
        }

        public ConfigureRolePresenter(IConfigureRoleView view, IRoleService contractorService)
        {
            this.view = view;
            this.contractorService = contractorService;
            viewCloseNeedsConfirmation = false;
            site = ClientSession.GetUserContext().Site;
        }
        
        public void LoadView()
        {
           
            view.roleSite = site;
            view.roles = contractorService.QueryRolesBySite(site);
            DisableActions();
        }

        public void ContractorInformationChanged()
        {
            string RoleName = view.RoleName;
           
            if (RoleName.HasValue() || view.alias.HasValue() || view.activedirectorykey.HasValue())
            {
                view.AddOrUpdateEnabled = true;
                view.ClearEnabled = true;
            }
            else
            {
                view.AddOrUpdateEnabled = false;
                view.ClearEnabled = false;
                
            }

            view.DeleteEnabled = false;
        }

        public void AddOrUpdate()
        {
            Role selectedRole = view.SelectedRole;
            if (selectedRole == null)
            {
               
                HandleAdd();
            }
            else
            {
                
                HandleUpdate();
            }
        }

        public void Clear()
        {
            view.RoleName = string.Empty;
            view.alias = string.Empty;
            view.activedirectorykey = string.Empty;
            view.ClearSelectedContractor();
            view.ClearErrorProviders();
            DisableActions();
        }

        public void ContractorSelected()
        {
            Role SelectedRole = view.SelectedRole;
            if (SelectedRole != null)
            {
                view.RoleName = SelectedRole.Name;
                view.alias = SelectedRole.Alias;
                view.activedirectorykey = SelectedRole.ActiveDirectoryKey;
                view.AddOrUpdateEnabled = true;
                view.DeleteEnabled = true;
                view.ClearEnabled = true;
                view.AddUpdateText = StringResources.UpdateButtonLabel;
                view.ClearErrorProviders();
            }
        }

        public void Delete()
        {
            if (view.SelectedRole != null)
            {
                contractorService.RemoveRole(site, view.SelectedRole);
                LoadView();
            }
            viewCloseNeedsConfirmation = false;
            Clear();
         
        }

       

        public void Save(Role role)
        {
            contractorService.UpdateRole(site, role);
            viewCloseNeedsConfirmation = false;
            view.Close();
        }


        public void ViewClosing(FormClosingEventArgs e)
        {
            if (ViewShouldBeClosed() == false)
            {
                e.Cancel = true;
            }
        }

        private bool ViewShouldBeClosed()
        {
            return !viewCloseNeedsConfirmation ||
                   view.ConfirmCancelDialog();
        }

        public void HandleAdd()
        {

                     
            var newRole = new Role(0, view.RoleName, view.activedirectorykey, view.isadministratorrole, view.isreadonlyrole, view.isdefaultreadonlyroleforsite, view.isworkpermitnonoperationsrole, view.warnifworkassignmentnotselected, view.alias, site.IdValue);
            IList<Role> contractors = view.roles;
            if (Validate(newRole))
            {
                AddContractorWithDuplicateCheck(contractors, newRole);

            }
        }

        private void AddContractorWithDuplicateCheck(IList<Role> contractors, Role newContractor)
        {
            if (contractors.Exists(
                existingContractor => existingContractor.Name.TrimAndEqual(newContractor.Name)))
            {
                view.ShowWarningMessage(StringResources.DuplicateRoleMessage, StringResources.DuplicateRoleTitle);
            }
            else
            {
                contractorService.InsertRole(site, newContractor);
                LoadView();
                Clear();
            }
        }

        private void HandleUpdate()
        {
            var Role = new Role(view.SelectedRole.Id, view.RoleName, view.activedirectorykey, view.isadministratorrole, view.isreadonlyrole, view.isdefaultreadonlyroleforsite, view.isworkpermitnonoperationsrole, view.warnifworkassignmentnotselected, view.alias, site.IdValue);
           
            //validation
            if (Validate(Role)==false)
            {
                return;
            }

            //Duplicate name update check
            if (view.roles.Exists(
                existingContractor => existingContractor.Name.TrimAndEqual(Role.Name) && existingContractor.Id != Role.Id))
            {
                view.ShowWarningMessage(StringResources.DuplicateRoleMessage, StringResources.DuplicateRoleTitle);
            }
            
            else
            {
                contractorService.UpdateRole(site, Role);
                Clear();
                LoadView();
            }
          
            viewCloseNeedsConfirmation = false;
        }

        private void DisableActions()
        {
            view.AddOrUpdateEnabled = false;
            view.DeleteEnabled = false;
            view.ClearEnabled = false;

            view.AddUpdateText = StringResources.AddButtonLabel;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Role: " + site.Id;
        }

        public void RegisterToViewEvents()
        {
            view.Load += HandleLoad;
            view.ContractorInformationChanged += HandleContractorInformationChanged;
            view.AddOrUpdate += HandleAddOrUpdate;
            view.Delete += HandleDelete;
            view.Clear += HandleClear;
            view.ContractorSelected += HandleContractorSelected;
            view.ViewClosing += HandleViewClosing;
        }

        public void HandleLoad(object sender, EventArgs e)
        {
            LoadView();
        }

        public void HandleContractorInformationChanged(object sender, EventArgs e)
        {
            ContractorInformationChanged();
        }

        public void HandleAddOrUpdate(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        public void HandleDelete(object sender, EventArgs e)
        {
            Delete();
        }

        public void HandleClear(object sender, EventArgs e)
        {
            Clear();
        }

        public void HandleContractorSelected(object sender, EventArgs e)
        {
            ContractorSelected();
        }

       
        public void HandleViewClosing(object sender, FormClosingEventArgs e)
        {
            ViewClosing(e);
        }

        public bool Validate(Role R)
        {
            bool isValidate = true;
             view.ClearErrorProviders();
            if (R.Name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
               isValidate= false;
            }
            if (R.Alias.IsNullOrEmptyOrWhitespace())
            {
                view.ShowAliasIsEmptyError();
                isValidate= false;
            }
            if (R.ActiveDirectoryKey.IsNullOrEmptyOrWhitespace())
            {
                view.ShowActiveDirectoryKeyIsEmptyError();
                isValidate= false;
            }
            Regex rgx = new Regex("[^a-zA-Z0-9]");


            if (rgx.IsMatch(R.ActiveDirectoryKey))
            {
                view.ShowWarningMessage(StringResources.RoleDirectoryKeyMessage, StringResources.RoleDirectoryKeyTitle);
                isValidate = false;
            }
            return isValidate;
        }
    }
}
