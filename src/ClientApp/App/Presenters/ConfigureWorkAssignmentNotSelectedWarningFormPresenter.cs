using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureWorkAssignmentNotSelectedWarningFormPresenter
    {
        private readonly IConfigureWorkAssignmentNotSelectedWarningFormView view;
        private readonly IRoleService roleService;

        public ConfigureWorkAssignmentNotSelectedWarningFormPresenter(IConfigureWorkAssignmentNotSelectedWarningFormView view)
        {
            this.view = view;
            roleService = ClientServiceRegistry.Instance.GetService<IRoleService>();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            Site site = ClientSession.GetUserContext().Site;
            view.SiteName = site.Name;
            view.Roles = roleService.QueryRolesBySite(site);
        }

        public void HandleSaveButtonClick(object sender, EventArgs e)
        {
            roleService.UpdateWorkAssignmentNotSelectedWarning(view.Roles);
            view.Close();
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.Close();
        }
    }
}
