using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddRolePermissionForm : BaseForm
    {
        private readonly List<Role> roles;
        private readonly List<RoleElement> roleElements;

        public AddRolePermissionForm()
        {
            InitializeComponent();
        }

        public AddRolePermissionForm(List<Role> roles, List<RoleElement> roleElements) : this()
        {
            this.roles = roles;
            this.roleElements = roleElements;

            okButton.Click += HandleOkButtonClick;
        }

        private void HandleOkButtonClick(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            roleComboBox.DataSource = new List<Role>(roles);
            roleComboBox.DisplayMember = "Name";

            roleElementComboBox.DataSource = new List<RoleElement>(roleElements);
            roleElementComboBox.DisplayMember = "Name";

            createdByRoleComboBox.DataSource = new List<Role>(roles);
            createdByRoleComboBox.DisplayMember = "Name";
        }

        public RolePermissionDisplayAdapter DisplayAdapter
        {
            get
            {
                return new RolePermissionDisplayAdapter((Role) roleComboBox.SelectedItem, (RoleElement) roleElementComboBox.SelectedItem, (Role) createdByRoleComboBox.SelectedItem);
            }
        }
    }
}
