using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitAutoAssignmentConfigurationPresenter : BaseFormPresenter<IWorkPermitAssignmentConfigurationFormView>
    {        
        private readonly IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfigurationService;
        private AssignmentFlocConfiguration currentlySelectedConfiguration;
        private readonly List<AssignmentFlocConfiguration> modifiedWorkAssignments;

        public WorkPermitAutoAssignmentConfigurationPresenter(IWorkPermitAssignmentConfigurationFormView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IWorkPermitAutoAssignmentConfigurationService>())
        {
        }

        public WorkPermitAutoAssignmentConfigurationPresenter(
            IWorkPermitAssignmentConfigurationFormView view,            
            IWorkPermitAutoAssignmentConfigurationService workPermitAutoAssignmentConfigurationService) : base(view)
        {
            this.workPermitAutoAssignmentConfigurationService = workPermitAutoAssignmentConfigurationService;
            modifiedWorkAssignments = new List<AssignmentFlocConfiguration>();

            view.FormLoad += HandleFormLoad;
            view.WorkAssignmentAreaSelected += HandleWorkAssignmentAreaSelected;
            view.SaveClicked += HandleSaveButtonClicked;
            view.CancelClicked += HandleCancelButtonClicked;
            view.ClearClicked += HandleClearButtonClicked;

            view.Title = StringResources.WorkAssignmentConfigurationForPermitAutoAssignmentTitle;
        }

        public void HandleFormLoad()
        {
            List<AssignmentFlocConfiguration> configurationList = 
                workPermitAutoAssignmentConfigurationService.QueryBySite(ClientSession.GetUserContext().Site);

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
            return string.Format("Work Permit Auto-Assignment Configuration - Site: {0}", site.Id); 
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
            workPermitAutoAssignmentConfigurationService.UpdateFunctionalLocations(modifiedWorkAssignments);
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
