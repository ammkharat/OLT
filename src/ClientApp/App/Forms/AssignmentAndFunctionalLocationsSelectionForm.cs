using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AssignmentAndFunctionalLocationsSelectionForm : BaseForm, IAssignmentAndFunctionalLocationsSelectionForm
    {
        public event Action AcceptClicked;
        public event Action CancelClicked;
        public event Action LoadPreviousFlocsClicked;
        public event Action NoAssignmentCheckedChanged;
        public event Action ClearFlocsClicked;
        public event Action SelectedAssignmentCategoryChanged;
        public event Action SelectedAssignmentChanged;
        public event Action GroupGridUpdated;

        private DomainSummaryGrid<WorkAssignment> assignmentGrid;
        private float initialHeightOfVisibilityGroupRow;
        private const int visibilityGroupRowIndex = 1;

        public AssignmentAndFunctionalLocationsSelectionForm()
        {
            InitializeComponent();
            InitializeAssignmentGrid();

            functionalLocationControl.Mode = ClientSession.GetInstance().SiteConfiguredFunctionalLocationMode;
            functionalLocationControl.CheckParentIfAllSiblingsAreChecked = true;

            acceptButton.Click += HandleAcceptButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            loadPreviousFlocsButton.Click += HandleLoadPreviousFlocsButtonClick;
            noAssignmentRadioButton.CheckedChanged += HandleNoAssignmentCheckedChanged;
            clearFlocsButton.Click += HandleClearFlocsButtonClick;
            assignmentGrid.SelectedItemChanged += HandleSelectedAssignmentChanged;
            assignmentCategoryComboBox.SelectedIndexChanged += HandleSelectedAssignmentCategoryChanged;
            groupGrid.AfterCellUpdate += HandleGroupGridAfterCellUpdate;
            visibilityGroupsToggleButton.Click += HandleExpandCollapseClick;

            groupGrid.InitializeLayout += HandleGroupGridInitializeLayout;
        }

        private void HandleGroupGridInitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn column in e.Layout.Bands[0].Columns)
            {
                if (column.Key == VisibilityGroupLoginDisplayAdapter.NAME_PROPERTY)
                {
                    column.Header.Caption = RendererStringResources.Group;
                }
                else if (column.Key == VisibilityGroupLoginDisplayAdapter.READ_PROPERTY)
                {
                    column.Header.Caption = RendererStringResources.View;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            initialHeightOfVisibilityGroupRow = flocAndVisibilityTableLayoutPanel.RowStyles[visibilityGroupRowIndex].Height;
        }

        private void InitializeAssignmentGrid()
        {
            WorkAssignmentGridRenderer renderer = new WorkAssignmentGridRenderer(true, false);
            renderer.NameColumnWidth = 250;
            renderer.RoleColumnWidth = 175;
            renderer.DescriptionColumnWidth = 275;

            assignmentGrid = new DomainSummaryGrid<WorkAssignment>(renderer, OltGridAppearance.SINGLE_SELECT, string.Empty);
            assignmentGrid.Dock = DockStyle.Fill;
            assignmentGrid.HideGroupByArea = true;

            assignmentGridPanel.Controls.Add(assignmentGrid);
        }

        private void HandleAcceptButtonClick(object sender, EventArgs eventArgs)
        {
            if (AcceptClicked != null)
            {
                AcceptClicked();
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs eventArgs)
        {
            if (CancelClicked != null)
            {
                CancelClicked();
            }
        }

        private void HandleSelectedAssignmentCategoryChanged(object sender, EventArgs e)
        {
            if (SelectedAssignmentCategoryChanged != null)
            {
                SelectedAssignmentCategoryChanged();
            }

        }

        private void HandleSelectedAssignmentChanged(object sender, DomainEventArgs<WorkAssignment> e)
        {
            if (SelectedAssignmentChanged != null)
            {
                SelectedAssignmentChanged();
            }
        }

        private void HandleClearFlocsButtonClick(object sender, EventArgs e)
        {
            if (ClearFlocsClicked != null)
            {
                ClearFlocsClicked();
            }
        }

        private void HandleNoAssignmentCheckedChanged(object sender, EventArgs e)
        {
            if (NoAssignmentCheckedChanged != null)
            {
                NoAssignmentCheckedChanged();
            }
        }

        private void HandleLoadPreviousFlocsButtonClick(object sender, EventArgs e)
        {
            if (LoadPreviousFlocsClicked != null)
            {
                LoadPreviousFlocsClicked();
            }
        }

        public WorkAssignment SelectedAssignment
        {
            get { return assignmentGrid.SelectedItem; }
            set
            {
                assignmentGrid.SelectItem(value);
                if (value == null)
                {
                    noAssignmentRadioButton.Checked = true;
                }
                else
                {
                    assignmentGrid.ScrollToItemById(value.IdValue);
                }
            }
        }

        public string SelectedAssignmentCategory
        {
            get
            {
                string selectedAssignmentCategory = (string) assignmentCategoryComboBox.SelectedItem;
                if (Equals(selectedAssignmentCategory, StringResources.All))
                {
                    return null;
                }
                else
                {
                    return selectedAssignmentCategory;                    
                }
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    assignmentCategoryComboBox.SelectedItem = StringResources.All;
                }
                else
                {
                    assignmentCategoryComboBox.SelectedItem = value;
                }
            }
        }

        public void ClearSelectedAssignment()
        {
            assignmentGrid.ClearSelections();
        }

        public void SelectFirstAssignment()
        {
            assignmentGrid.SelectFirstRow();
        }

        public void LaunchFunctionalLocationSelectionRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.FlocEmptyError, StringResources.FunctionalLocationsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LaunchAtLeastOneReadableVisibilityGroupRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.NoGroupSelectedError, StringResources.GroupTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowNoAssignmentSelectedWarning()
        {
            return OltMessageBox.Show(this,
                StringResources.NoAssignmentSelectedWarningDialog_Text,
                StringResources.NoAssignmentSelectedWarningDialog_Title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
        }

        public IList<WorkAssignment> Assignments
        {
            set
            {
                WorkAssignment originallySelectedItem = assignmentGrid.SelectedItem;
                assignmentGrid.Items = value;
                if (value.Contains(originallySelectedItem))
                {
                    assignmentGrid.SelectItem(originallySelectedItem);
                }
                else
                {
                    assignmentGrid.SelectFirstRow();   
                }
            }
        }

        public List<string> AssignmentCategories
        {
            set 
            {
                value.Sort();
                value.Insert(0, StringResources.All);
                assignmentCategoryComboBox.Items.Clear();
                assignmentCategoryComboBox.Items.AddRange(value.ToArray());
                assignmentCategoryComboBox.SelectedIndex = 0;
            }
        }

        public IList<FunctionalLocation> UserCheckedFunctionalLocations
        {
            get { return functionalLocationControl.UserCheckedFunctionalLocations; }
            set { functionalLocationControl.UserCheckedFunctionalLocations = value; }
        }

        public List<FunctionalLocation> AllCheckedFunctionalLocations
        {
            get { return functionalLocationControl.AllCheckedFunctionalLocations;  }
        }

        public bool NoAssignmentSelected
        {
            get { return noAssignmentRadioButton.Checked; }
        }

        public List<long> SelectedReadableVisibilityGroupIds { get; set; }

        public void CloseForm(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
            Close();
        }

        public void DisableAssignmentSelection()
        {
            assignmentGridPanel.Enabled = false;
            assignmentCategoryComboBox.Enabled = false;
        }

        public void EnableAssignmentSelection()
        {
            assignmentGridPanel.Enabled = true;
            assignmentCategoryComboBox.Enabled = true;
        }

        public void DisableSelectAssignmentOption()
        {
            noAssignmentRadioButton.Checked = true;
            assignmentRadioButton.Enabled = false;
        }

        public List<VisibilityGroupLoginDisplayAdapter> VisibilityGroupList
        {
            get
            {
                List<VisibilityGroupLoginDisplayAdapter> adapters = visibilityGroupBindingSource.DataSource as List<VisibilityGroupLoginDisplayAdapter>;

                if (adapters == null)
                {
                    return new List<VisibilityGroupLoginDisplayAdapter>();
                }

                return adapters;
            }
            set { visibilityGroupBindingSource.DataSource = value; }
        }

        public void SetAtLeastOneMatchingReadAndWriteGroupRequiredError()
        {
            errorProvider.SetError(writeGroupTextBox, StringResources.AtLeastOneMatchingReadWriteGroupNeededError);
        }

        public void SetAtLeastOneReadableVisibilityGroupRequiredMessage()
        {
            errorProvider.SetError(groupGrid, StringResources.AtLeastOneReadVisibilityGroupRequiredError);
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public string WriteGroupList
        {
            set { writeGroupTextBox.Text = value; }
        }

        public bool FormContentVisible
        {
            set 
            { 
                flocAndVisibilityTableLayoutPanel.Visible = value;
                assignmentGroupBox.Visible = value;
            }
        }

        public void HideVisibilityGroupArea()
        {
            flocAndVisibilityTableLayoutPanel.RowStyles[visibilityGroupRowIndex].Height = 0;
        }

        private void HandleGroupGridAfterCellUpdate(object sender, CellEventArgs cellEventArgs)
        {
            if (GroupGridUpdated != null)
            {
                GroupGridUpdated();
            }
        }

        private void HandleExpandCollapseClick(object sender, EventArgs e)
        {
            if (visibilityGroupsContentPanel.Visible)
            {
                visibilityGroupsContentPanel.Hide();
                flocAndVisibilityTableLayoutPanel.RowStyles[visibilityGroupRowIndex].Height = visibilityGroupsToggleButton.Height + 15;
            }
            else
            {
                visibilityGroupsContentPanel.Show();
                flocAndVisibilityTableLayoutPanel.RowStyles[visibilityGroupRowIndex].Height = initialHeightOfVisibilityGroupRow;
            }

        }


    }
}