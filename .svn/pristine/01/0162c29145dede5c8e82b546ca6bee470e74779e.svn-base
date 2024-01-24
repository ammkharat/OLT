using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureDefaultTabsForm : BaseForm, IConfigureDefaultTabsFormView
    {
        private readonly Dictionary<SectionKey, ValueList> pageValueListMap = new Dictionary<SectionKey, ValueList>();
        private readonly SummaryGrid<RoleDisplayConfiguration> grid;
        private ConfigureDefaultTabsFormPresenter presenter;

        public ConfigureDefaultTabsForm()
        {
            InitializeComponent();

            grid = new SummaryGrid<RoleDisplayConfiguration>(new RoleDisplayConfigurationGridRenderer(), OltGridAppearance.EDIT_CELL_SELECT);
            grid.Dock = DockStyle.Fill;
            gridPanel.Controls.Add(grid);

            grid.BeforeCellActivate += Grid_BeforeCellActivate;

            InitializePresenter();
        }

        private void Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell.Column.Key == RoleDisplayConfigurationGridRenderer.PRIMARY_PAGE_KEY_COLUMN ||
                e.Cell.Column.Key == RoleDisplayConfigurationGridRenderer.SECONDARY_PAGE_KEY_COLUMN)
            {
                RoleDisplayConfiguration configuration = (RoleDisplayConfiguration)e.Cell.Row.ListObject;
                if (pageValueListMap.ContainsKey(configuration.SectionKey))
                {
                    e.Cell.Column.ValueList = pageValueListMap[configuration.SectionKey];
                }
                else
                {
                    e.Cell.Column.ValueList = null;
                }
            } 
        }

        private void InitializePresenter()
        {
            presenter = new ConfigureDefaultTabsFormPresenter(this);
            Load += presenter.LoadForm;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
        }

        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public Dictionary<SectionKey, List<PageKey>> SectionToPageMap
        {
            set
            {
                Dictionary<SectionKey, List<PageKey>> sectionToPageMap = value;
                foreach (SectionKey sectionKey in SectionKey.All)
                {
                    pageValueListMap.Add(sectionKey, new ValueList());
                    pageValueListMap[sectionKey].ValueListItems.Add(null, "");

                    if (sectionToPageMap.ContainsKey(sectionKey))
                    {
                        List<PageKey>  pageList = sectionToPageMap[sectionKey];
                        foreach (PageKey pageKey in pageList)
                        {
                            pageValueListMap[sectionKey].ValueListItems.Add(pageKey, pageKey.TabText);
                        }
                    }
                }
            }
        }

        public IList<RoleDisplayConfiguration> Configurations
        {
            get { return grid.Items; }
            set { grid.Items = value; }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Default Tabs Form, Site Id: " + site.IdValue);
        }
    }
}