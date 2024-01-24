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
    public partial class FormDropdownsConfigurationForm : BaseForm, IFormDropdownsConfigurationView
    {
        private readonly DomainSummaryGrid<FormDropdown> grid;

        public FormDropdownsConfigurationForm()
        {
            InitializeComponent();

            var gridHeader = StringResources.FormEdmontonDropdownConfiguration_DropdownsGridHeader;
            grid = new DomainSummaryGrid<FormDropdown>(new SingleColumnGridRenderer(gridHeader, "Name"),
                OltGridAppearance.NON_OUTLOOK, string.Empty) {Dock = DockStyle.Fill};

            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);

            InitializePresenter();
        }

        public List<FormDropdown> Dropdowns
        {
            set { grid.Items = value; }
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }

        public FormDropdown SelectedItem
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

        public void LaunchEditForm(List<DropdownValue> formDropdownValues, string key, string nameAlreadyExistsErrorMessage = null)
        {
            var form = new EditFormDropdownsConfigurationForm(formDropdownValues, key, nameAlreadyExistsErrorMessage);
            form.ShowDialog(this);
        }

        private void InitializePresenter()
        {
            var presenter = new FormDropdownsConfigurationFormPresenter(this);

            Load += presenter.Load;

            editButton.Click += presenter.EditButton_Click;
            closeButton.Click += presenter.CloseButton_Click;
            FormClosing += presenter.FormClosing;
            grid.DoubleClickSelected += presenter.GridRow_DoubleClick;
        }
    }
}