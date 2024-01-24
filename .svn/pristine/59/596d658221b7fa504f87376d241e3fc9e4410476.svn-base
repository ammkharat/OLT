
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditWorkPermitDropdownsConfigurationForm : BaseForm, IEditWorkPermitDropdownsConfigurationForm
    {
        private DomainSummaryGrid<DropdownValue> grid;

        public EditWorkPermitDropdownsConfigurationForm(List<DropdownValue> dropdownValues, string key)
        {
            InitializeComponent();
            InitializeGrid();
            InitializePresenter(dropdownValues, key);
        }

        private void InitializeGrid()
        {
            string gridHeader = StringResources.WorkPermitMontrealDropdownConfiguration_ValuesGridHeader;
            grid = new DomainSummaryGrid<DropdownValue>(new SingleColumnGridRenderer(gridHeader, "Name"), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            grid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            gridPanel.Controls.Add(grid);
        }

        private void InitializePresenter(List<DropdownValue> dropdownValues, string key)
        {
            EditWorkPermitDropdownsConfigurationFormPresenter presenter = new EditWorkPermitDropdownsConfigurationFormPresenter(this, dropdownValues, key);

            Load += presenter.Load;
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Clicked;
            moveQuestionUpButton.Click += presenter.MoveValueUpButton_Clicked;
            moveQuestionDownButton.Click += presenter.MoveValueDownButton_Clicked;

            addValueButton.Click += presenter.AddValueButton_Clicked;
            editValueButton.Click += presenter.EditValueButton_Clicked;
            deleteValueButton.Click += presenter.DeleteValueButton_Clicked;

            FormClosing += presenter.FormClosing;
            grid.DoubleClickSelected += presenter.GridRow_DoubleClicked;
        }

        public List<DropdownValue> DropdownValues
        {
            set { grid.Items = value; }
        }

        public string DropdownName
        {
            set { dropdownNameLabel.Text = value; }
        }

        public DropdownValue SelectedValue
        {
            get { return grid.SelectedItem; }
            set { grid.SelectItemByReference(value); }
        }

        public void SelectFirstValue()
        {
            grid.SelectFirstRow();
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetAtLeastOneValueRequiredError()
        {
            errorProvider.SetError(gridPanel, StringResources.ValueRequiredError);
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        public void Disable()
        {
            contentPanel.Enabled = false;
        }

        public void Enable()
        {
            contentPanel.Enabled = true;
        }

        public DropdownValue LaunchAddEditValueForm(WorkPermitDropdown dropdown, DropdownValue editObject)
        {
            AddEditWorkPermitDropdownValueForm form = new AddEditWorkPermitDropdownValueForm(dropdown, editObject);
            return form.ShowDialogAndReturnValue(this);
        }
    }
}
