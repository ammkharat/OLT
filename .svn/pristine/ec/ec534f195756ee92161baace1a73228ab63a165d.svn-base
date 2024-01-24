using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureAdministratorListFormPresenter
    {
        private readonly IConfigureAdministratorListView view;
        private readonly IAdministratorListService service;

        public ConfigureAdministratorListFormPresenter(IConfigureAdministratorListView view)
        {
            this.view = view;
            service = ClientServiceRegistry.Instance.GetService<IAdministratorListService>();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            view.SiteName = ClientSession.GetUserContext().Site.Name;
            LoadItems();
        }

        public void HandleNew(object sender, EventArgs e)
        {
            bool itemCreated = view.CreateNewAdministrator();
            if (itemCreated)
                LoadItems();
        }

        public void HandleEdit(object sender, EventArgs e)
        {
            AdministratorList administrator = view.SelectedItem;
            if (administrator == null)
                return;

            bool itemEdited = view.EditAdministrator(administrator);
            if (itemEdited)
                LoadItems();
        }

        public void HandleDelete(object sender, EventArgs e)
        {
            AdministratorList administrator = view.SelectedItem;
            if (administrator == null)
                return;

            long id = administrator.IdValue;
            service.Remove(id);
            LoadItems();
        }

        private void LoadItems()
        {
            view.Items = service.QueryAdminMember();
        }

    }
}
