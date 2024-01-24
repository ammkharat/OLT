using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ShiftHandoverEmailConfigurationPresenter : BaseFormPresenter<IShiftHandoverEmailConfigurationFormView>
    {
        private readonly IShiftHandoverService handoverService;

        public ShiftHandoverEmailConfigurationPresenter() : base(new ShiftHandoverEmailConfigurationForm())
        {
            view.AddButtonClicked += HandleAddButtonClicked;
            view.EditButtonClicked += HandleEditButtonClicked;
            view.DeleteButtonClicked += HandleDeleteButtonClicked;
            view.CloseButtonClicked += HandleCloseButtonClicked;
            view.Load += HandleLoad;

            handoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            ReloadConfigurations();
            view.SelectFirstItem();
        }

        private void ReloadConfigurations()
        {
            List<ShiftHandoverEmailConfiguration> configurations = handoverService.QueryShiftHandoverEmailConfigurationsBySiteId(ClientSession.GetUserContext().SiteId);
            view.ShiftHandoverEmailConfigurations = configurations;            
        }

        private void HandleAddButtonClicked()
        {
            ShiftHandoverEmailConfigurationAddEditPresenter presenter = new ShiftHandoverEmailConfigurationAddEditPresenter();
            presenter.Run(view);
            ReloadConfigurations();
            view.SelectFirstItem();
        }

        private void HandleEditButtonClicked()
        {
            ShiftHandoverEmailConfiguration configuration = view.SelectedConfiguration;

            if (configuration != null)
            {
                ShiftHandoverEmailConfigurationAddEditPresenter presenter = new ShiftHandoverEmailConfigurationAddEditPresenter(configuration);
                presenter.Run(view);
                ReloadConfigurations();
                view.SelectedConfiguration = configuration;
            }
        }

        private void HandleDeleteButtonClicked()
        {
            ShiftHandoverEmailConfiguration configuration = view.SelectedConfiguration;

            if (configuration != null)
            {
                DialogResult dialogResult = view.ConfirmDeleteDialog();

                if (DialogResult.OK == dialogResult)
                {
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(handoverService.DeleteShiftHandoverEmailConfiguration, configuration);
                    ReloadConfigurations();
                    view.SelectFirstItem();
                }
            }
        }

        private void HandleCloseButtonClicked()
        {
            view.Close();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Shift Handover Email Configuration, Site Id: " + site.IdValue;
        }
    }
}
