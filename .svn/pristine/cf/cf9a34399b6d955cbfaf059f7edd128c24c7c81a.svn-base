using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PreferencesPresenter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (PreferencesPresenter));
        protected bool shouldSkipConfirm;
        private readonly IPreferencesView view;
        private readonly IUserService userService;
        private readonly User user;

        public PreferencesPresenter(IPreferencesView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IUserService>())
        {                                   
        }

        public PreferencesPresenter(IPreferencesView view, IUserService userService)
        {
            this.view = view;
            this.userService = userService;
            user = ClientSession.GetUserContext().User;
        }

        public void Load(object sender, EventArgs e)
        {
            view.Title = string.Format(StringResources.PreferencesFormTitle, ClientSession.GetUserContext().User.FullNameWithUserName);
        }

        public void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirm && !view.ConfirmCancelDialog())
            {
                e.Cancel = true;
            }
        }

        public void Save(object sender, EventArgs eventArgs)
        {
            try
            {
                List<IPreferenceTabPage> tabs = view.Tabs;
                if (tabs.TrueForAll(tab => tab.IsTabValid))
                {
                    tabs.ForEach(tab => tab.UpdatePreference());
                    
                    UserPrintPreference saved = userService.UpdatePrintPreferences(user);
                    if (user.WorkPermitPrintPreference.Id == null)
                    {
                        user.WorkPermitPrintPreference.Id = saved.Id;
                    }
                    
                    userService.UpdateWorkPermitDefaultTimesPreferences(user);
                    shouldSkipConfirm = true;
                    view.SaveSucceededMessage();
                    view.Close();
                }
            }
            catch (Exception e)
            {
                view.SaveFailedMessage();
                logger.Error(StringResources.ServerSaveUpdateError, e);
            }
        }

        public void Cancel(object sender, EventArgs e)
        {
        }
    }
}
