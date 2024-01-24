using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CreateOrEditAssignmentForm : BaseForm, ICreateOrEditAssignmentView
    {
        private DomainSummaryGrid<WorkAssignmentVisibilityGroupGridDisplayAdapter> visibilityGroupGrid;
        
        public CreateOrEditAssignmentForm(List<WorkAssignment> assignments)
        {
            InitializeComponent();

            InitializeGrid();
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(this, assignments);
            RegisterEventHandlersOnPresenter(presenter);
        }

        public CreateOrEditAssignmentForm(WorkAssignment workAssignment, List<WorkAssignment> assignments)
        {
            InitializeComponent();

            InitializeGrid();
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(this, workAssignment, assignments);
            RegisterEventHandlersOnPresenter(presenter);
        }
        
        private void InitializeGrid()
        {
            visibilityGroupGrid = new DomainSummaryGrid<WorkAssignmentVisibilityGroupGridDisplayAdapter>(new EditWorkAssignmentVisibilityGroupsGridRenderer(),
                                                                                                         OltGridAppearance.EDIT_ROW_SELECT, "visibilityGroups");
            visibilityGroupGrid.InitializeRow += HandleInitializeRow;
            visibilityGroupGrid.Padding = new Padding(3);
            visibilityGroupGrid.HideGroupByArea = true;
            visibilityGroupGrid.Dock = DockStyle.Fill;
            visibilityGroupsPanel.Controls.Add(visibilityGroupGrid);
        }

        private static void HandleInitializeRow(object sender, InitializeRowEventArgs e)
        {
            foreach (UltraGridCell cell in e.Row.Cells)
            {
                if (cell.Column.Key != EditWorkAssignmentVisibilityGroupsGridRenderer.GROUP_NAME_COLUMN)
                {
                    cell.ActiveAppearance.BackColor = SystemColors.Window;
                    cell.ActiveAppearance.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void RegisterEventHandlersOnPresenter(CreateOrEditAssignmentFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            advancedButton.Click += presenter.HandleAdvancedButtonClick;
        }

        public string AssignmentName
        {
            get { return nameTextBox.Text.TrimOrNull(); } 
            set { nameTextBox.Text = value; }
        }
        
        public string AssignmentDescription
        {
            get { return descriptionTextBox.Text.TrimOrNull(); }
            set { descriptionTextBox.Text = value; }
        }

        public string Category
        {
            get { return categoryComboBox.Text.TrimOrNull(); }
            set { categoryComboBox.Text = value; }
        }

        public string ViewTitle
        {
            set { Text = value; }
        }

        public string AssignmentSite
        {
            set { siteLabelData.Text = value; }
        }
        
        public List<Role> Roles
        {
            get { return (List<Role>) roleComboBox.DataSource; }
            set { roleComboBox.DataSource = value; }
        }

        public Role SelectedRole
        {
            get { return (Role) roleComboBox.SelectedItem; }
            set { roleComboBox.SelectedItem = value; }
        }

        public List<WorkAssignmentVisibilityGroupGridDisplayAdapter> VisibilityGroupAdapters
        {
            set { visibilityGroupGrid.Items = value; }
            get { return new List<WorkAssignmentVisibilityGroupGridDisplayAdapter>(visibilityGroupGrid.Items); }
        }

        public List<string> Categories
        {
            set
            {                
                categoryComboBox.Items.Clear();
                categoryComboBox.Items.AddRange(value.ToArray());
            }           
        }

        public void ClearErrorProviders()
        {            
            errorProvider.Clear();
        }

        public void ShowNameIsEmptyError()
        {
            errorProvider.SetError(nameTextBox, StringResources.FieldEmptyError);
        }

        public void ShowDescriptionIsEmptyError()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.FieldEmptyError);
        }

        public void ShowNameAlreadyExistsError()
        {
            errorProvider.SetError(nameTextBox, StringResources.DuplicateAssignmentForSite);
        }

        public void ShowRoleIsNullError()
        {
            errorProvider.SetError(roleComboBox, StringResources.FieldEmptyError);
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public void ShowNoGroupWithBothReadAndWriteError()
        {
            errorProvider.SetError(visibilityGroupsGroupBox, StringResources.VisibilityGroupWithoutReadAndWriteError);
        }

        public override void SaveSucceededMessage()
        {
            // Do not display confirmation.
        }
    }
}