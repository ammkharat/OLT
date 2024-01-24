using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureRolePermissionsPresenter : BaseFormPresenter<IConfigureRolePermissionsView>
    {
        private readonly IRoleService roleService;
        private readonly IRoleElementService roleElementService;
        private readonly IRolePermissionService rolePermissionService;

        private List<Role> roles;

        private readonly List<RolePermissionDisplayAdapter> addedAdapters = new List<RolePermissionDisplayAdapter>();
        private readonly List<RolePermissionDisplayAdapter> deletedAdapters = new List<RolePermissionDisplayAdapter>();

        public ConfigureRolePermissionsPresenter(IConfigureRolePermissionsView view) : base(view)
        {
            roleService = ClientServiceRegistry.Instance.GetService<IRoleService>();
            roleElementService = ClientServiceRegistry.Instance.GetService<IRoleElementService>();
            rolePermissionService = ClientServiceRegistry.Instance.GetService<IRolePermissionService>();

            view.Load += HandleViewLoad;
            view.Add += HandleAdd;
            view.Delete += HandleDelete;
            view.Save += HandleSave;
        }

        private void HandleViewLoad(object sender, EventArgs eventArgs)
        {
            Site site = ClientSession.GetUserContext().Site;
            roles = roleService.QueryRolesBySite(site);

            Dictionary<Role, List<RoleElement>> roleElements = new Dictionary<Role, List<RoleElement>>();
            foreach (Role role in roles)
            {
                roleElements.Add(role, roleElementService.QueryTemplateForRole(role));
            }

            List<RolePermission> rolePermissions = new List<RolePermission>();
            foreach (Role role in roles)
            {
                rolePermissions.AddRange(rolePermissionService.QueryByRoleId(role.IdValue));
            }

            List<RolePermissionDisplayAdapter> displayAdapters = new List<RolePermissionDisplayAdapter>();
            foreach (RolePermission rolePermission in rolePermissions)
            {
                Role role = roles.Find(r => r.Id == rolePermission.RoleId);

                List<RoleElement> roleElementList = roleElements[role];
                RoleElement roleElement = roleElementList.Find(re => re.Id == rolePermission.RoleElementId);

                Role createdByRole = roles.Find(r => r.Id == rolePermission.CreatedByRoleId);

                RolePermissionDisplayAdapter displayAdapter = new RolePermissionDisplayAdapter(role, roleElement, createdByRole);
                displayAdapters.Add(displayAdapter);
            }

            view.RolePermissions = displayAdapters;
        }

        private void HandleAdd()
        {
            AddRolePermissionForm addRolePermissionForm = new AddRolePermissionForm(roles, RoleElement.APPLICABLE_TO_ROLE_PERMISSIONS);
            DialogResult dialogResult = addRolePermissionForm.ShowDialog(view);

            if (dialogResult == DialogResult.OK)
            {
                RolePermissionDisplayAdapter displayAdapter = addRolePermissionForm.DisplayAdapter;

                List<RolePermissionDisplayAdapter> displayedAdapters = view.RolePermissions;
                if (displayedAdapters.Contains(displayAdapter))
                {
                    view.ShowPermissionAlreadyExistsMessage();
                }
                else
                {
                    displayedAdapters.Add(displayAdapter);
                    addedAdapters.Add(displayAdapter);
                    view.RolePermissions = displayedAdapters;
                    view.SelectedPermission = displayAdapter;
                }
            }

            addRolePermissionForm.Dispose();
        }

        private void HandleDelete()
        {
            RolePermissionDisplayAdapter selectedPermission = view.SelectedPermission;
            if (addedAdapters.Contains(selectedPermission))
            {
                addedAdapters.Remove(selectedPermission);
            }
            else
            {
                deletedAdapters.Add(selectedPermission);
            }

            List<RolePermissionDisplayAdapter> displayedAdapters = view.RolePermissions;
            displayedAdapters.Remove(selectedPermission);
            view.RolePermissions = displayedAdapters;
        }

        private void HandleSave()
        {
            if (addedAdapters.IsEmpty() && deletedAdapters.IsEmpty())
            {
                view.ShowNothingToSaveMessage();
            }
            else
            {
                foreach (RolePermissionDisplayAdapter addedAdapter in addedAdapters)
                {
                    rolePermissionService.Insert(addedAdapter.CreateRolePermission());
                }

                foreach (RolePermissionDisplayAdapter deletedAdapter in deletedAdapters)
                {
                    rolePermissionService.Delete(deletedAdapter.CreateRolePermission());
                }

                view.ShowSaveSuccessfulMessageAndCloseForm();
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Role Permissions " + site.IdValue;
        }
    }
}
