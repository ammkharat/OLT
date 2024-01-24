using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PreferencesForm : BaseForm, IPreferencesView
    {
        private readonly Control workPermitPrintPreferencePageAsControl;
        private readonly Control defaultPermitTimesTabPageAsControl;        
        private readonly PreferencesPresenter presenter;
        private readonly List<IPreferenceTabPage> preferences;
        private readonly IPreferenceTabPage preferenceTabPage;

        public PreferencesForm()
        {
            InitializeComponent();

            presenter = new PreferencesPresenter(this);
            preferences = new List<IPreferenceTabPage>();
            
            preferenceTabPage = new WorkPermitPrintPreferenceTabPage();
            preferences.Add(preferenceTabPage);

            workPermitPrintPreferencePageAsControl = preferenceTabPage as Control;
            if (workPermitPrintPreferencePageAsControl != null)
            {
                workPermitPrintPreferencePageAsControl.Dock = DockStyle.Fill;
                workPermitPrintPreferencePageAsControl.Padding = new Padding(3);
                workPermitPrintingTabControl.Controls.Add(workPermitPrintPreferencePageAsControl);
            }

            preferenceTabPage = new WorkPermitDefaultTimesPreferenceTabPage();
            preferences.Add(preferenceTabPage);

            defaultPermitTimesTabPageAsControl = preferenceTabPage as Control;
            defaultPermitTimesTabPageAsControl.Dock = DockStyle.Fill;
            defaultPermitTimesTabPageAsControl.Padding = new Padding(3);
            defaultPermitTimesTabControl.Controls.Add(defaultPermitTimesTabPageAsControl);

            UserContext userContext = ClientSession.GetUserContext();

            if (!UserShouldSeePermitPrintingTab(userContext))
            {
                preferencesTabControl.HideTab(workPermitPrintingTabControl);
            }

            if (!UserShouldSeeDefaultPermitTimesTab(userContext))
            {
                preferencesTabControl.HideTab(defaultPermitTimesTabControl);
            }

            InitializeEvents();
        }

        public static bool UserShouldSeePreferencesAtAll(UserContext userContext)
        {
            return UserShouldSeePermitPrintingTab(userContext) || UserShouldSeeDefaultPermitTimesTab(userContext);
        }

        private static bool UserShouldSeePermitPrintingTab(UserContext userContext)
        {            
            return userContext.SiteConfiguration.ShowWorkPermitPrintingTabInPreferences && new Authorized().ToPrintWorkPermitsInGeneral(userContext.UserRoleElements);
        }

        private static bool UserShouldSeeDefaultPermitTimesTab(UserContext userContext)
        {
            return userContext.SiteConfiguration.ShowDefaultPermitTimesTabInPreferences;
        }

        private void InitializeEvents()
        {
            Load += presenter.Load;
            FormClosing += presenter.FormClosing;
            saveButton.Click += presenter.Save;
            cancelButton.Click += presenter.Cancel;
        }

        public string Title
        {
            set { Text = value; }
        }

        public List<IPreferenceTabPage> Tabs
        {
            get { return preferences; }
        }
    }
}