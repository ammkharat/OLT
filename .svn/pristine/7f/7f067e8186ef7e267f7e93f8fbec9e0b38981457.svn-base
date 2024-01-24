using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CokerCardConfigurationSelectionForm : BaseForm, ICokerCardConfigurationSelectionView
    {
        private readonly DomainSummaryGrid<CokerCardConfiguration> grid;
        private CokerCardConfigurationSelectionPresenter presenter;
        
        public CokerCardConfigurationSelectionForm()
        {
            InitializeComponent();
            InitializePresenter();
            grid = new DomainSummaryGrid<CokerCardConfiguration>(new CokerCardConfigurationGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            grid.DisplayLayout.GroupByBox.Hidden = true;
            grid.TabIndex = 0;
            grid.MaximumBands = 1;
            grid.Dock = DockStyle.Fill;
            listPanel.Controls.Add(grid);
            grid.Focus();
        }

        private void InitializePresenter()
        {
            presenter = new CokerCardConfigurationSelectionPresenter(this);
            Load += presenter.InitializeView;
            okButton.Click += presenter.HandleAccept;
            cancelButton.Click += presenter.HandleCancel;
        }

        public List<CokerCardConfiguration> CokerCardConfigurationsToAddToListView
        {
            set { grid.Items = value; }
        }

        public void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }

        public void LaunchUnSelectedSiteMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.UnselectedCokerCardError, StringResources.CokerCardTitle,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
        }

        public CokerCardConfiguration SelectedCokerCardConfiguration
        {
            get { return grid.SelectedItem; } 
        }
    }
}
