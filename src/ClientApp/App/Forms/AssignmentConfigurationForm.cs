using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AssignmentConfigurationForm : BaseForm, IAssignmentConfigurationView
    {
        private DomainSummaryGrid<WorkAssignment> assignmentGrid;
        private readonly AssignmentConfigurationPresenter presenter;
        
        public AssignmentConfigurationForm()
        {
            InitializeComponent();
            InitializeAssignmentGrid();           

            presenter = new AssignmentConfigurationPresenter(this);
            HookUpEventHandlers();
        }
       
        private void HookUpEventHandlers()
        {
            Load += presenter.HandleFormLoad;
            deleteButton.Click += presenter.HandleRemoveAssignment;
            editButton.Click += presenter.HandleEditAssignment;
            newButton.Click += presenter.HandleCreateAssignment;
            closeButton.Click += presenter.HandleCloseForm;
            assignmentGrid.DoubleClickSelected += presenter.HandleDoubleClickAssignment;
        }
        
        public List<WorkAssignment> Assignments
        {
            set { assignmentGrid.Items = value; }
            get { return new List<WorkAssignment>(assignmentGrid.Items); }
        }

        public string SiteName
        {
            set { siteLabelData.Text = value; }
        }
        
        public WorkAssignment SelectedAssignment
        {
            get { return assignmentGrid.SelectedItem; }
            set { assignmentGrid.SelectItem(value); }
        }

        public DialogResult ShowEditAssignmentForm(WorkAssignment assignmentToEdit, List<WorkAssignment> assignments)
        {
            CreateOrEditAssignmentForm createOrEditForm = new CreateOrEditAssignmentForm(assignmentToEdit, assignments);
            return createOrEditForm.ShowDialog(this);
        }

        public DialogResult ShowCreateAssignmentForm(List<WorkAssignment> assignments)
        {
            CreateOrEditAssignmentForm createOrEditForm = new CreateOrEditAssignmentForm(assignments);
            return createOrEditForm.ShowDialog(this);            
        }

        public void CloseForm()
        {
            Close();
        }

        private void InitializeAssignmentGrid()
        {
            WorkAssignmentGridRenderer renderer = new WorkAssignmentGridRenderer(true, true);
            renderer.NameColumnWidth = 250;
            renderer.RoleColumnWidth = 175;
            renderer.DescriptionColumnWidth = 275;
            renderer.CategoryColumnWidth = 80;

            assignmentGrid = new DomainSummaryGrid<WorkAssignment>(renderer, OltGridAppearance.SINGLE_SELECT, string.Empty);
            assignmentGrid.HideGroupByArea = true;
            assignmentGrid.TabIndex = 0;
            assignmentGrid.MaximumBands = 1;            
            assignmentAreaGroupBox.Controls.Add(assignmentGrid);
            assignmentGrid.Dock = DockStyle.Fill;
        }  
    }
}