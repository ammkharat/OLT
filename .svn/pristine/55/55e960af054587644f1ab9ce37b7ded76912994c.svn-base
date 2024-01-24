using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogGuidelineConfigurationSelectionFormPresenter : BaseFormPresenter<ILogGuidelineConfigurationSelectionView>
    {
        private readonly IFunctionalLocationInfoService functionalLocationService;
        private readonly List<FunctionalLocation> functionalLocationsForSite;

        public LogGuidelineConfigurationSelectionFormPresenter() : base(new LogGuidelineConfigurationSelectionForm())
        {            
            functionalLocationService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationInfoService>();

            List<FunctionalLocationInfo> flocInfos =
                functionalLocationService.QueryDivisionsBySiteId(ClientSession.GetUserContext().SiteId);
            functionalLocationsForSite = flocInfos.ConvertAll(info => info.Floc);

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            view.Load += view_Load;
            view.EditButtonClicked += HandleEditButtonClicked;
            view.CloseButtonClicked += CloseButton_Clicked;
        }

        private void view_Load(object sender, EventArgs e)
        {
            view.FunctionalLocationList = functionalLocationsForSite;
            view.SelectFirstFunctionalLocation();
        }

        private void HandleEditButtonClicked(object sender, EventArgs e)
        {
            FunctionalLocation selectedFunctionalLocation = view.SelectedFunctionalLocation;

            LogGuidelineConfigurationEditFormPresenter editFormPresenter = 
                new LogGuidelineConfigurationEditFormPresenter(selectedFunctionalLocation);

            editFormPresenter.Run(view);
        }

        public override DialogResult Run(IWin32Window parent)
        {
            if (functionalLocationsForSite.Count == 1)
            {
                LogGuidelineConfigurationEditFormPresenter editFormPresenter = 
                    new LogGuidelineConfigurationEditFormPresenter(functionalLocationsForSite[0]);
                return editFormPresenter.Run(parent);
            }
            else
            {
                return base.Run(parent);
            }            
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Log Guidelines - Site: {0}", site.Id);
        }
    }
}
