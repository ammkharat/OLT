using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitAssignmentConfigurationPresenter : BaseFormPresenter<IWorkPermitAssignmentConfigurationFormView>
    {
        private readonly IWorkPermitAssignmentConfigurationService workPermitAssignmentConfigurationService;
        private readonly IWorkAssignmentService workAssignmentService;
        private AssignmentFlocConfiguration currentlySelectedConfiguration;
        private readonly List<AssignmentFlocConfiguration> modifiedWorkAssignments;

        public WorkPermitAssignmentConfigurationPresenter(IWorkPermitAssignmentConfigurationFormView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IWorkPermitAssignmentConfigurationService>(), ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>())
        {
        }

        public WorkPermitAssignmentConfigurationPresenter(
            IWorkPermitAssignmentConfigurationFormView view,            
            IWorkPermitAssignmentConfigurationService workPermitAssignmentConfigurationService,
            IWorkAssignmentService workAssignmentService) : base(view)
        {
            this.workPermitAssignmentConfigurationService = workPermitAssignmentConfigurationService;
            this.workAssignmentService = workAssignmentService;
            modifiedWorkAssignments = new List<AssignmentFlocConfiguration>();

            view.FormLoad += HandleFormLoad;
            view.WorkAssignmentAreaSelected += HandleWorkAssignmentAreaSelected;
            view.SaveClicked += HandleSaveButtonClicked;
            view.CancelClicked += HandleCancelButtonClicked;
            view.ClearClicked += HandleClearButtonClicked;
            view.CopyLoginFlocsClicked += HandleCopyLoginFlocsClicked;
            view.Title = StringResources.WorkAssignmentConfigurationForPermitsAndFormsTitle;
        }

        private void HandleCopyLoginFlocsClicked()
        {
            WorkAssignment assignment = workAssignmentService.QueryByIdWithoutCache(currentlySelectedConfiguration.WorkAssignmentId);

            if (assignment.FunctionalLocations == null || assignment.FunctionalLocations.Count == 0)
            {
                view.ShowInfoMessageBox(StringResources.NoLoginFlocsForSelectedAssignment_Title, StringResources.NoLoginFlocsForSelectedAssignment_Message);
                return;
            }

            if (view.SelectedAssignmentDefaultFunctionalLocations.Count != 0)
            {
                DialogResult result = view.ShowYesNoWarningBox(StringResources.OverwriteWithLoginFlocs_Title, StringResources.OverwriteWithLoginFlocs_Message);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            view.SelectedAssignmentDefaultFunctionalLocations = assignment.FunctionalLocations;
        }

        public void HandleFormLoad()
        {
            view.CopyLoginFlocsButtonVisible = true;

            List<AssignmentFlocConfiguration> configurationList = 
                workPermitAssignmentConfigurationService.QueryBySite(ClientSession.GetUserContext().Site);

            if (configurationList.IsEmpty())
            {
                view.FunctionalLocationSelectionEnabled = false;
            }
            else
            {
                view.ConfigurationList = configurationList;                
                view.FunctionalLocationSelectionEnabled = true;
                view.SelectFirstWorkAssignment();                
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Work Permit Assignment Configuration - Site: {0}", site.Id); 
        }

        public void HandleWorkAssignmentAreaSelected(AssignmentFlocConfiguration selectedConfiguration)
        {
            SaveCurrentSelection();

            currentlySelectedConfiguration = selectedConfiguration;
            view.SelectedAssignmentDefaultFunctionalLocations = currentlySelectedConfiguration.FunctionalLocations;
        }

        private void SaveCurrentSelection()
        {
            if (currentlySelectedConfiguration != null)
            {
                IList<FunctionalLocation> locations = new List<FunctionalLocation>();
                locations.AddRange(view.SelectedAssignmentDefaultFunctionalLocations);

                currentlySelectedConfiguration.FunctionalLocations.Clear();
                currentlySelectedConfiguration.FunctionalLocations.AddRange(locations);

                modifiedWorkAssignments.AddIfNotExist(currentlySelectedConfiguration);
            }
        }

        public void HandleSaveButtonClicked()
        {
            SaveCurrentSelection();
            workPermitAssignmentConfigurationService.UpdateFunctionalLocations(modifiedWorkAssignments);
            view.SaveSucceededMessage();
            view.Close();
        }

        public void HandleCancelButtonClicked()
        {
            if (view.ConfirmCancelDialog())
            {
                view.Close();
            }
        }

        public void HandleClearButtonClicked()
        {
            view.ClearFunctionalLocations();
        }

    }
}
