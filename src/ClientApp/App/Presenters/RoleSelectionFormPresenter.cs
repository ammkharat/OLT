using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class RoleSelectionFormPresenter
    {
        private readonly IRoleSelectionView view;

        public RoleSelectionFormPresenter(IRoleSelectionView view)
        {
            this.view = view;
        }

        public void Load(object sender, EventArgs e)
        {
            UserContext userContext = ClientSession.GetUserContext();

            List<Role> roles = userContext.User.GetRoles(userContext.Site);
            roles.Sort(Role.CompareByName);
            view.Roles = roles;

            if (roles.Count > 0)
            {
                view.SelectedRole = roles[0];
            }
        }

        public void okButton_Clicked(object sender, EventArgs e)
        {
            view.DialogResult = DialogResult.OK;          
        }

        public void cancelButton_Clicked(object sender, EventArgs e)
        {
            view.DialogResult = DialogResult.Cancel;
        }
    }
}