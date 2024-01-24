using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CokerCardConfigurationSelectionPresenter
    {
        private readonly ICokerCardConfigurationSelectionView view;
        private List<CokerCardConfiguration> configurationList;
        private readonly ICokerCardService service;

        public CokerCardConfigurationSelectionPresenter(ICokerCardConfigurationSelectionView cokerCardConfigurationSelectionView)
        {
            view = cokerCardConfigurationSelectionView;
            service = ClientServiceRegistry.Instance.GetService<ICokerCardService>();
        }

        public void InitializeView(object sender, EventArgs e)
        {
            configurationList =
                service.QueryCokerCardConfigurationsByExactFlocMatch(
                    new ExactFlocSet(ClientSession.GetUserContext().DivisionsAndSectionsForSelectedFunctionalLocations));

            view.CokerCardConfigurationsToAddToListView = configurationList;
        }

        public void HandleAccept(object sender, EventArgs e)
        {
            CokerCardConfiguration selectedCokerCardConfiguration = view.SelectedCokerCardConfiguration;
            if (selectedCokerCardConfiguration == null)
            {
                view.LaunchUnSelectedSiteMessage();
            }
            else
            {
                view.CloseForm(DialogResult.OK);
            }
        }

        public void HandleCancel(object sender, EventArgs e)
        {
            view.CloseForm(DialogResult.Cancel);
        }
    }
}