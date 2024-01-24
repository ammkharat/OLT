using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AssignmentMultiSelectFormPresenter
    {
        private readonly IAssignmentMultiSelectFormView view;
        private readonly IWorkAssignmentService service;

        private List<WorkAssignment> initialSelectedAssignments;

        public AssignmentMultiSelectFormPresenter(IAssignmentMultiSelectFormView view) : this(view, ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>())
        {
        }

        public AssignmentMultiSelectFormPresenter(
            IAssignmentMultiSelectFormView view,
            IWorkAssignmentService service)
        {
            this.view = view;
            this.service = service;
        }

        public void InitializeView(object sender, EventArgs e)
        {
            LoadAssignments();
            view.SiteName = ClientSession.GetUserContext().Site.Name;
        }
        
        private void LoadAssignments()
        {
            List<WorkAssignment> assignments = service.QueryBySite(ClientSession.GetUserContext().Site);
            
            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> adapters =
                assignments.ConvertAll(a => new WorkAssignmentMultiSelectGridRenderer.DisplayAdapter(a));

            foreach (WorkAssignment selectedAssignment in initialSelectedAssignments)
            {
                WorkAssignmentMultiSelectGridRenderer.DisplayAdapter adapter = 
                    adapters.Find(waa => waa.GetWorkAssignment().IdValue == selectedAssignment.IdValue);

                // This happens if the work assignment has been deleted since being assigned to the parent entity
                if (adapter != null)
                {                    
                    adapter.Selected = true;    
                }                
            }
           
            view.Assignments = adapters;
        }
                                 
        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Assignments - Site: {0}", site.Id);
        }

        public void OKButton_Click(object sender, EventArgs e)
        {       
            view.SetDialogResult(DialogResult.OK);
            view.CloseForm();
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            view.SetDialogResult(DialogResult.Cancel);
            view.CloseForm();
        }

        public void SetSelectedAssignments(List<WorkAssignment> selectedWorkAssignments)
        {
            initialSelectedAssignments = new List<WorkAssignment>(selectedWorkAssignments);
        }

        public static List<WorkAssignment> GetSelectedAssignments(List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> workAssignmentSelectableGridDisplayAdapters)
        {
            List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> selectedAdapters = 
                workAssignmentSelectableGridDisplayAdapters.FindAll(a => a.Selected);
            return selectedAdapters.ConvertAll(a => a.GetWorkAssignment());
        }
    }
}