using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SiteSelectionForm : BaseForm, ISiteSelectionView
    {
        private readonly DomainSummaryGrid<Site> grid;
        private SiteSelectionPresenter presenter;
        
        public SiteSelectionForm()
        {
            InitializeComponent();
            InitializePresenter();
            grid = new DomainSummaryGrid<Site>(new SiteGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            grid.DisplayLayout.GroupByBox.Hidden = true;
            grid.TabIndex = 0;
            grid.MaximumBands = 1;
            grid.Dock = DockStyle.Fill;
            listPanel.Controls.Add(grid);
            grid.Focus();
        }

        private void InitializePresenter()
        {
            presenter = new SiteSelectionPresenter(this);
            Load += presenter.InitializeView;
            okButton.Click += presenter.HandleAccept;
            cancelButton.Click += presenter.HandleCancel;
        }

        public List<Site> SiteToAddToListListView
        {
            set { grid.Items = value; }
        }

        public Site SelectedSite
        {
            get { return grid.SelectedItem; }
        }

        public void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }

        public void LaunchUnSelectedSiteMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.UnselectedSiteError, StringResources.SiteTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}