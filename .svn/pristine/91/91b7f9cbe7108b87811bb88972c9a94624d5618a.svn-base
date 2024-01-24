using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AssignmentMultiSelectForm : BaseForm, IAssignmentMultiSelectFormView
    {
        private SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid;
        private readonly AssignmentMultiSelectFormPresenter presenter;        
        
        public AssignmentMultiSelectForm(bool hideSelectAllAndClearAlButtons)
        {
            InitializeComponent();
            InitializeAssignmentGrid();           

            presenter = new AssignmentMultiSelectFormPresenter(this);
            HookUpEventHandlers();

            selectAllButton.Visible = !hideSelectAllAndClearAlButtons;
            clearAllButton.Visible = !hideSelectAllAndClearAlButtons;                            
        }

        public AssignmentMultiSelectForm() : this(false)
        {            
        }

        private void HookUpEventHandlers()
        {
            Load += presenter.InitializeView;              
            okButton.Click += presenter.OKButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;
            selectAllButton.Click += SelectAllButton_Click;
            clearAllButton.Click += ClearAllButton_Click;
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            SetCheckBox(true);
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            SetCheckBox(false);            
        }

        private void SetCheckBox(bool selected)
        {
            foreach (WorkAssignmentMultiSelectGridRenderer.DisplayAdapter adapter in assignmentGrid.FilteredInItems)
            {
                adapter.Selected = selected;
            }
            assignmentGrid.RefreshBinding();
        }

        public List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> Assignments
        {
            set { assignmentGrid.Items = value; }
            get { return new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(assignmentGrid.Items); }
        }

        public List<WorkAssignment> SelectedAssignments
        {
            get { return AssignmentMultiSelectFormPresenter.GetSelectedAssignments(Assignments); }
        }

        public string SiteName
        {
            set { siteLabelData.Text = value; }
        }             

        public void ShowMultiSelectDialog(List<WorkAssignment> selectedWorkAssignments)
        {
            presenter.SetSelectedAssignments(selectedWorkAssignments);
            ShowDialog();                       
        }
        
        public void CloseForm()
        {
            Close();
        }

        private void InitializeAssignmentGrid()
        {
            assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ConfigurationLayout, true), OltGridAppearance.EDIT_ROW_SELECT_WITH_FILTER);
            assignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            assignmentGrid.TabIndex = 0;
            assignmentGrid.MaximumBands = 1;            
            assignmentAreaGroupBox.Controls.Add(assignmentGrid);
            assignmentGrid.Dock = DockStyle.Fill;
        }

        public void SetDialogResult(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
        }       
    }
}