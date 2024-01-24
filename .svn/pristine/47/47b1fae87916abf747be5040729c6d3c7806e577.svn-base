using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RoleSelectionForm : BaseForm, IRoleSelectionView
    {
        public RoleSelectionForm()
        {
            InitializeComponent();
            InitializePresenter();
        }

        public Role SelectedRole
        {
            get { return (Role) roleComboBox.SelectedItem; }
            set { roleComboBox.SelectedItem = value; }
        }

        public List<Role> Roles
        {
            set { roleComboBox.DataSource = value; }
        }

        private void InitializePresenter()
        {
            RoleSelectionFormPresenter presenter = new RoleSelectionFormPresenter(this);
            Load += presenter.Load;
            okButton.Click += presenter.okButton_Clicked;
            cancelButton.Click += presenter.cancelButton_Clicked;
        }
    }
}
