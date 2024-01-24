using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureDefaultFlocsForDailyAssignnmentPresenter
    {
        private readonly IWorkAssignmentService workAssignmentService;
        private readonly IConfigureDefaultFlocsForDailyAssignmentView view;
        private WorkAssignment currentlySelectedWorkAssignment;
        private readonly List<WorkAssignment> modifiedWorkAssignments;

        public ConfigureDefaultFlocsForDailyAssignnmentPresenter(IConfigureDefaultFlocsForDailyAssignmentView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>())
        {
        }

        public ConfigureDefaultFlocsForDailyAssignnmentPresenter(
            IConfigureDefaultFlocsForDailyAssignmentView view,
            IWorkAssignmentService workAssignmentService)
        {
            this.view = view;
            this.workAssignmentService = workAssignmentService;
            modifiedWorkAssignments = new List<WorkAssignment>();
        }

        public void HandleLoad(object sender, EventArgs empty)
        {
            List<WorkAssignment> workAssignments = workAssignmentService.QueryBySite(ClientSession.GetUserContext().Site);
            if (workAssignments.IsEmpty())
            {
                view.FunctionalLocationSelectionEnabled = false;
            }
            else
            {
                view.WorkAssignmentList = workAssignments;                
                view.FunctionalLocationSelectionEnabled = true;
                view.SelectFirstWorkAssignment();                
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Default Flocs For Daily Assignment - Site: {0}", site.Id); 
        }

        public void HandleWorkAssignmentAreaSelected(object sender, DomainEventArgs<WorkAssignment> e)
        {
            SaveCurrentSelection();

            currentlySelectedWorkAssignment = e.SelectedItem;
            view.SelectedAssignmentDefaultFunctionalLocations = currentlySelectedWorkAssignment.FunctionalLocations;
        }

        private void SaveCurrentSelection()
        {
            if (currentlySelectedWorkAssignment != null)
            {
                List<FunctionalLocation> locations = new List<FunctionalLocation>();
                locations.AddRange(view.SelectedAssignmentDefaultFunctionalLocations);
                currentlySelectedWorkAssignment.FunctionalLocations = locations;

                modifiedWorkAssignments.AddIfNotExist(currentlySelectedWorkAssignment);
            }
        }

        public void HandleSaveButtonClicked(object sender, EventArgs args)
        {
            SaveCurrentSelection();
            workAssignmentService.UpdateFunctionalLocations(modifiedWorkAssignments);
            view.SaveSucceededMessage();
            view.Close();
        }

        public void HandleCancelButtonClicked(object sender, EventArgs empty)
        {
            if (view.ConfirmCancelDialog())
            {
                view.Close();
            }
        }

        public void HandleClearButtonClicked(object sender, EventArgs args)
        {
            view.ClearFunctionalLocations();
        }

    }
}
