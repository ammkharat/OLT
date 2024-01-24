using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureLinkRootsFormPresenter
    {
        private readonly IConfigureLinkRootsView view;
        private readonly IDocumentLinkService service;

        public ConfigureLinkRootsFormPresenter(IConfigureLinkRootsView view)
        {
            this.view = view;
            service = ClientServiceRegistry.Instance.GetService<IDocumentLinkService>();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            view.SiteName = ClientSession.GetUserContext().Site.Name;
            LoadItems();
        }

        public void HandleNew(object sender, EventArgs e)
        {
            bool itemCreated = view.CreateNewUncRoot();
            if (itemCreated)
                LoadItems();
        }

        public void HandleEdit(object sender, EventArgs e)
        {
            DocumentRootUncPath documentRootUncPath = view.SelectedItem;
            if (documentRootUncPath == null)
                return;

            bool itemEdited = view.EditUncRoot(documentRootUncPath);
            if (itemEdited)
                LoadItems();
        }

        public void HandleDelete(object sender, EventArgs e)
        {
            DocumentRootUncPath documentRootUncPath = view.SelectedItem;
            if (documentRootUncPath == null)
                return;

            long id = documentRootUncPath.IdValue;
            service.Remove(id);
            LoadItems();
        }

        private void LoadItems()
        {
            view.Items = service.QueryRootsBySiteId(ClientSession.GetUserContext().SiteId);
        }

    }
}
