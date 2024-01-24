using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ViewLinkRootsFormPresenter
    {
        private readonly ISelectLinkRootsView view;
        private readonly IDocumentLinkService service;

        public ViewLinkRootsFormPresenter(ISelectLinkRootsView view)
        {
            this.view = view;
            service = ClientServiceRegistry.Instance.GetService<IDocumentLinkService>();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            view.SiteName = ClientSession.GetUserContext().Site.Name;
            view.Items =
                service.QueryRootsBySecondLevelFunctionalLocation(
                    new SectionOnlyFlocSet(ClientSession.GetUserContext().SectionsForSelectedFunctionalLocations));
        }

    }
}