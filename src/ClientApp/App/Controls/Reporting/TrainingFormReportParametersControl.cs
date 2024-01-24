using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public partial class TrainingFormReportParametersControl : UserControl, ITrainingFormReportParametersControl
    {
        private readonly SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid;
        private readonly SummaryGrid<UserMultiSelectGridRenderer.DisplayAdapter> userGrid;

        private List<WorkAssignment> allAvailableWorkAssignments = new List<WorkAssignment>();

        private string errorMessage = null;

        public TrainingFormReportParametersControl()
        {
            InitializeComponent();

            assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(
                    new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ReportParameterLayout), OltGridAppearance.EDIT_CELL_SELECT_WITH_FILTER);
            assignmentGrid.Dock = DockStyle.Fill;
            gridPanel.Controls.Add(assignmentGrid);
            assignmentGrid.Items = new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>();
            assignmentGrid.DisplayLayout.Override.TipStyleScroll = TipStyle.Hide;

            userGrid = new SummaryGrid<UserMultiSelectGridRenderer.DisplayAdapter>(new UserMultiSelectGridRenderer(), OltGridAppearance.EDIT_CELL_SELECT_WITH_FILTER);
            userGrid.Dock = DockStyle.Fill;
            userPanel.Controls.Add(userGrid);
            userGrid.Items = new List<UserMultiSelectGridRenderer.DisplayAdapter>();
            userGrid.DisplayLayout.Override.TipStyleScroll = TipStyle.Hide;
        }

        public bool IsValid 
        {
            get
            {
                if (StartDate > EndDate)
                {
                    errorMessage = StringResources.StartDateBeforeEndDate;
                    return false;
                }

                if (SelectedUsers.Count == 0)
                {
                    errorMessage = StringResources.AtLeastOneUserMustBeSelected;
                    return false;      
                }

                if (SelectedWorkAssignments.Count == 0)
                {
                    errorMessage = StringResources.AtLeastOneWorkAssignmentMustBeSelected;
                    return false;
                }

                return true;
            }
        }

        public string ErrorMessage { get { return errorMessage; } }

        public Date StartDate
        {
            get { return startDatePicker.Value; }
            set { startDatePicker.Value = value; }
        }

        public Date EndDate
        {
            get { return endDatePicker.Value; }
            set { endDatePicker.Value = value; }
        }

        public List<WorkAssignment> SelectedWorkAssignments
        {
            get
            {
                List<WorkAssignment> selectedWorkAssignments = new List<WorkAssignment>();
                foreach (WorkAssignmentMultiSelectGridRenderer.DisplayAdapter wrapper in assignmentGrid.FilteredInItems)
                {
                    if (wrapper.Selected)
                    {
                        selectedWorkAssignments.Add(wrapper.GetWorkAssignment());
                    }
                }

                return selectedWorkAssignments;
            }
        }

        public List<UserDTO> SelectedUsers
        {
            get
            {
                List<UserDTO> selectedUsers = new List<UserDTO>();
                foreach (UserMultiSelectGridRenderer.DisplayAdapter wrapper in userGrid.FilteredInItems)
                {
                    if (wrapper.Selected)
                    {
                        selectedUsers.Add(wrapper.GetUser());
                    }
                }

                return selectedUsers;
            }
        }

        public void SetAvailableWorkAssignments(List<WorkAssignment> assignments)
        {
            allAvailableWorkAssignments = new List<WorkAssignment>(assignments);            
                                 
            List<WorkAssignment> originallySelectedWorkAssignments = SelectedWorkAssignments;
            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> wrappers = new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>();
            
            foreach (WorkAssignment assignment in allAvailableWorkAssignments)
            {
                WorkAssignmentMultiSelectGridRenderer.DisplayAdapter wrapper = new WorkAssignmentMultiSelectGridRenderer.DisplayAdapter(
                        assignment, originallySelectedWorkAssignments.Count == 0 || originallySelectedWorkAssignments.ExistsById(assignment));

                wrappers.Add(wrapper);
            }

            assignmentGrid.Items = wrappers;
        }

        public void SetAvailableUsers(List<UserDTO> users)
        {
            List<UserDTO> incomingUsers = new List<UserDTO>(users);
            List<UserDTO> alreadySelectedUsers = SelectedUsers;

            List<UserMultiSelectGridRenderer.DisplayAdapter> wrappers = new List<UserMultiSelectGridRenderer.DisplayAdapter>();

            bool noSelectedUsers = alreadySelectedUsers.Count == 0;

            foreach (UserDTO user in incomingUsers)
            {
                UserMultiSelectGridRenderer.DisplayAdapter wrapper = new UserMultiSelectGridRenderer.DisplayAdapter(user, noSelectedUsers || alreadySelectedUsers.ExistsById(user));
                wrappers.Add(wrapper);
            }

            userGrid.Items = wrappers;
        }
    }
}
