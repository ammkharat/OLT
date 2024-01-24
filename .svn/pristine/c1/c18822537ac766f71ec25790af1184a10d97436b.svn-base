using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureRolePermissionsForm : BaseForm, IConfigureRolePermissionsView
    {
        public event Action Add;
        public event Action Delete;
        public event Action Save;

        public ConfigureRolePermissionsForm()
        {
            InitializeComponent();

            addButton.Click += HandleAddButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            saveButton.Click += HandleSaveButtonClick;
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (Save != null)
            {
                Save();
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete();
            }
        }

        private void HandleAddButtonClick(object sender, EventArgs eventArgs)
        {
            if (Add != null)
            {
                Add();
            }
        }

        public List<RolePermissionDisplayAdapter> RolePermissions
        {
            set
            {
                bindingSource.DataSource = value;
                bindingSource.ResetBindings(false);
            }
            get { return (List<RolePermissionDisplayAdapter>) bindingSource.DataSource; }
        }

        public RolePermissionDisplayAdapter SelectedPermission
        {
            get
            {
                return (rolePermissionsGrid.ActiveRow == null ? null : rolePermissionsGrid.ActiveRow.ListObject) as RolePermissionDisplayAdapter;
            }
            set
            {
                foreach (UltraGridRow row in rolePermissionsGrid.Rows)
                {
                    if (row.ListObject.Equals(value))
                    {
                        rolePermissionsGrid.ActiveRow = row;
                    }
                }
            }
        }

        public void ShowPermissionAlreadyExistsMessage()
        {
            OltMessageBox.Show(this, StringResources.PermissionAlreadyExists, StringResources.PermissionAlreadyExistsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowNothingToSaveMessage()
        {
            OltMessageBox.Show(this, StringResources.NoChanges, StringResources.NoChangesTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowSaveSuccessfulMessageAndCloseForm()
        {
            OltMessageBox.Show(this, StringResources.SaveSuccessMessage, StringResources.SaveSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
