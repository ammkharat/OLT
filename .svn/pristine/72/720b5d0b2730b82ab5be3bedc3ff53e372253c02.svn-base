
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitDropdownsConfigurationForm : BaseForm, IWorkPermitDropdownsConfigurationView
    {
        private readonly DomainSummaryGrid<WorkPermitDropdown> grid;

        public WorkPermitDropdownsConfigurationForm()
        {
            InitializeComponent();

            string gridHeader = StringResources.WorkPermitMontrealDropdownConfiguration_DropdownsGridHeader;
            grid = new DomainSummaryGrid<WorkPermitDropdown>(new SingleColumnGridRenderer(gridHeader, "Name"), OltGridAppearance.NON_OUTLOOK, string.Empty);
            
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);

            InitializePresenter();
        }

        private void InitializePresenter()
        {
            WorkPermitDropdownsConfigurationFormPresenter presenter = new WorkPermitDropdownsConfigurationFormPresenter(this);
            
            Load += presenter.Load;

            editButton.Click += presenter.EditButton_Click;
            closeButton.Click += presenter.CloseButton_Click;
            FormClosing += presenter.FormClosing;
            grid.DoubleClickSelected += presenter.GridRow_DoubleClick;
        }

        public List<WorkPermitDropdown> Dropdowns
        {
            set { grid.Items = value; }
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }

        public WorkPermitDropdown SelectedItem
        {
            get { return grid.SelectedItem; }
        }

        public void Disable()
        {
            contentsPanel.Enabled = false;
        }

        public void Enable()
        {
            contentsPanel.Enabled = true;
        }

        public void LaunchEditForm(List<DropdownValue> workPermitDropdownValues, string key)
        {
            EditWorkPermitDropdownsConfigurationForm form = new EditWorkPermitDropdownsConfigurationForm(workPermitDropdownValues, key);
            form.ShowDialog(this);
        }
    }
}
