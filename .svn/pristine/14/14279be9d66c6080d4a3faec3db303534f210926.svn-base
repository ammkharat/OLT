using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ManageOpModeForUnitLevelFLOCFormPresenter
    {
        private readonly IManageOpModeForUnitLevelFLOCView view;
        private readonly IFunctionalLocationOperationalModeService service;

        private readonly List<FunctionalLocationOperationalModeDTO> modifiedOpModeList = new List<FunctionalLocationOperationalModeDTO>();

        public ManageOpModeForUnitLevelFLOCFormPresenter(IManageOpModeForUnitLevelFLOCView view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>())
        {
        }

        public ManageOpModeForUnitLevelFLOCFormPresenter(
            IManageOpModeForUnitLevelFLOCView view,
            IFunctionalLocationOperationalModeService service)
        {
            this.view = view;
            this.service = service;
        }

        public void LoadPage(object sender, EventArgs eventArgs)
        {
            UserContext clientSession = ClientSession.GetUserContext();
            view.Site = clientSession.Site.Name;
            view.Items = service.GetBySiteId(clientSession.Site.IdValue);
        }

        public void HandleEditButtonClicked(object sender, EventArgs eventArgs)
        {
            FunctionalLocationOperationalModeDTO selectedItem = view.SelectedItem;

            if (selectedItem != null)
            {                                
                FunctionalLocationOperationalModeDTO modifiedOpModeDto = view.OpenEditOperationalModeDialog(selectedItem);
                
                if (modifiedOpModeDto != null)
                {
                    modifiedOpModeList.Add(modifiedOpModeDto);
                }
            }
            else
            {
                view.DisplayOKDialog(StringResources.ManageOperationalModeNoFlocSelectedMessageBoxText);
            }
        }

        public void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            User lastModifiedUser = ClientSession.GetUserContext().User;
            service.Update(modifiedOpModeList, lastModifiedUser);
            view.CloseForm();
        }

        public void HandleCancelButtonClicked(object sender, EventArgs eventArgs)
        {
            view.CloseForm();
        }

        public List<FunctionalLocationOperationalModeDTO> ModifiedOperationalModeList
        {
            get
            {
                List<FunctionalLocationOperationalModeDTO> modeArray = new List<FunctionalLocationOperationalModeDTO>(modifiedOpModeList);
                return modeArray;
            }
        }
    }
}