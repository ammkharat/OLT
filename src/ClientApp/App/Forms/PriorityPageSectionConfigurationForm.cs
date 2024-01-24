using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PriorityPageSectionConfigurationForm : BaseForm, IPriorityPageSectionConfigurationFormView
    {
        public event Action SaveAndCloseClicked;
        public event Action ClearPreferencesClicked;        
        public event Action CancelClicked;

        private readonly SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid;

        private readonly int workAssignmentContainerHeight;

        public PriorityPageSectionConfigurationForm()
        {
            InitializeComponent();
            saveAndCloseButton.Click += HandleSaveAndCloseButtonClicked;
            clearPreferencesButton.Click += HandleClearPreferencesButtonClicked;
            cancelButton.Click += HandleCancelButtonClick;

            assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(
                new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ConfigurationLayout, true), OltGridAppearance.EDIT_CELL_SELECT_WITH_FILTER)
            {
                Dock = DockStyle.Fill
            };

            workAssignmentGroupBox.Controls.Add(assignmentGrid);
            assignmentGrid.Items = new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>();
            workAssignmentContainerHeight = workAssignmentGroupBox.Height;
        }

        public void HideWorkAssignmentSection()
        {
            Height = Height - workAssignmentContainerHeight;
            workAssignmentGroupBox.Hide();
        }

        public void ShowWorkAssignmentSection()
        {
            workAssignmentGroupBox.Show();
            Height = Height + workAssignmentContainerHeight;
        }

        public void SetWorkAssignments(List<WorkAssignment> allWorkAssignmentsForSite, List<WorkAssignment> selectedWorkAssignments)
        {
            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> displayAdapters = allWorkAssignmentsForSite.ConvertAll(wa => new WorkAssignmentMultiSelectGridRenderer.DisplayAdapter(wa));

            foreach (var displayAdapter in displayAdapters)
            {
                displayAdapter.Selected = selectedWorkAssignments.Exists(wa => wa.IdValue == displayAdapter.GetWorkAssignment().IdValue);
            }

            assignmentGrid.Items = displayAdapters;
        }

        public List<WorkAssignment> SelectedWorkAssignments
        {
            get
            {
                List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> displayAdapters = new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(assignmentGrid.Items);
                List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> selectedAdapters = displayAdapters.FindAll(da => da.Selected);
                return selectedAdapters.ConvertAll(a => a.GetWorkAssignment());
            }
        }

        public bool DefaultToExpanded
        {
            get { return defaultToExpandedRadioButton.Checked; }
            set
            {
                defaultToExpandedRadioButton.Checked = value;
                defaultToCollapsedRadioButton.Checked = !value;
            }
        }

        public string FormTitle
        {
            set { Text = value; }
        }

        public bool ClearPreferencesButtonEnabled
        {
            set { clearPreferencesButton.Enabled = value; }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            CancelClicked();
        }

        private void HandleSaveAndCloseButtonClicked(object sender, EventArgs e)
        {
            SaveAndCloseClicked();
        }

        private void HandleClearPreferencesButtonClicked(object sender, EventArgs e)
        {
            ClearPreferencesClicked();
        }
    }
}