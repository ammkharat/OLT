using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AssignmentConfigurationPresenter
    {
        private readonly IAssignmentConfigurationView view;
        private readonly IWorkAssignmentService service;

        private List<WorkAssignment> lastLoadedAssignments;

        public AssignmentConfigurationPresenter(IAssignmentConfigurationView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>())
        {
        }

        public AssignmentConfigurationPresenter(
            IAssignmentConfigurationView view,
            IWorkAssignmentService service)
        {
            this.view = view;
            this.service = service;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            LoadAssignments();
            view.SiteName = ClientSession.GetUserContext().Site.Name;
        }
        
        private void LoadAssignments()
        {
            List<WorkAssignment> assignments = service.QueryBySite(ClientSession.GetUserContext().Site);
            view.Assignments = assignments;
            lastLoadedAssignments = assignments;
        }

        public void HandleEditAssignment(object sender, EventArgs e)
        {
            PerformEditAssignment(view.SelectedAssignment);
        }

        private void PerformEditAssignment(WorkAssignment selectedAssignment)
        {
            if (selectedAssignment == null) return;

            DialogResult result = view.ShowEditAssignmentForm(selectedAssignment, lastLoadedAssignments);
            if (DialogResult.OK == result)
            {
                LoadAssignments();
                view.SelectedAssignment = selectedAssignment;
            }
        }

        public void HandleRemoveAssignment(object sender, EventArgs e)
        {
            WorkAssignment selectedAssignment = view.SelectedAssignment;
            if (selectedAssignment == null) return;

            service.Remove(selectedAssignment);
            LoadAssignments();
        }


        public void HandleCreateAssignment(object sender, EventArgs e)
        {
            DialogResult result = view.ShowCreateAssignmentForm(lastLoadedAssignments);
            if (DialogResult.OK == result)
            {
                LoadAssignments();
                SelectLastCreatedAssignment();
            }
        }

        private void SelectLastCreatedAssignment()
        {
            List<WorkAssignment> assignments =
                view.Assignments;
            if (assignments.Count != 0)
            {
                assignments.Sort(SortById);
                view.SelectedAssignment = assignments.Last();
            }
        }

        private static int SortById(WorkAssignment x, WorkAssignment y)
        {
            return x.Id.Value.CompareTo(y.Id.Value);
        }
        
        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Assignments - Site: {0}", site.Id);
        }

        public void HandleCloseForm(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        public void HandleDoubleClickAssignment(object sender, DomainEventArgs<WorkAssignment> e)
        {
            if (e == null) return;
            PerformEditAssignment(e.SelectedItem);
        }
    }
}