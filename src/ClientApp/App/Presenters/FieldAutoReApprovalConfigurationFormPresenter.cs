using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FieldAutoReApprovalConfigurationFormPresenter
    {
        private readonly ISiteConfigurationService siteConfigurationService;
        private readonly IFieldAutoReApprovalConfigurationFormView view;

        public FieldAutoReApprovalConfigurationFormPresenter(IFieldAutoReApprovalConfigurationFormView view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>())
        {
        }

        public FieldAutoReApprovalConfigurationFormPresenter(
            IFieldAutoReApprovalConfigurationFormView view,
            ISiteConfigurationService siteConfigurationService)
        {
            this.view = view;
            this.siteConfigurationService = siteConfigurationService;
        }

        public void HandleLoad(object sender, EventArgs args)
        {
            Site site = ClientSession.GetUserContext().Site;
            SiteConfiguration siteConfiguration = siteConfigurationService.QueryBySiteIdWithNoCaching(site.Id.Value);

            view.SiteName = site.Name;

            TargetDefinitionAutoReApprovalConfiguration targetDefConfig = siteConfiguration.TargetDefinitionAutoReApprovalConfiguration;
            SetTargetDefinitionConfiguration(targetDefConfig);

            ActionItemDefinitionAutoReApprovalConfiguration aidConfig = siteConfiguration.ActionItemDefinitionAutoReApprovalConfiguration;
            SetActionItemDefinitionConfiguration(aidConfig);
        }

        public void HandleTargetDefinitionConfigSelectAll(object sender, EventArgs args)
        {
            long siteId = ClientSession.GetUserContext().SiteId;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationChange = true;
            const bool pHTagChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool generateActionItemChange = true;
            const bool requiesResponseWhenAlteredChange = true;
            const bool suppressAlertChange = true;

            TargetDefinitionAutoReApprovalConfiguration allSelected = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                      nameChange,
                                                                                                                      categoryChange,
                                                                                                                      operationalModeChange,
                                                                                                                      priorityChange,
                                                                                                                      descriptionChange,
                                                                                                                      documentLinksChange,
                                                                                                                      functionalLocationChange,
                                                                                                                      pHTagChange,
                                                                                                                      targetDependenciesChange,
                                                                                                                      scheduleChange,
                                                                                                                      generateActionItemChange,
                                                                                                                      requiesResponseWhenAlteredChange,
                                                                                                                      suppressAlertChange);
            SetTargetDefinitionConfiguration(allSelected);
        }

        public void HandleTargetDefinitionConfigClearAll(object sender, EventArgs args)
        {
            long siteId = ClientSession.GetUserContext().SiteId;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;

            TargetDefinitionAutoReApprovalConfiguration noneSelected = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                       nameChange,
                                                                                                                       categoryChange,
                                                                                                                       operationalModeChange,
                                                                                                                       priorityChange,
                                                                                                                       descriptionChange,
                                                                                                                       documentLinksChange,
                                                                                                                       functionalLocationChange,
                                                                                                                       pHTagChange,
                                                                                                                       targetDependenciesChange,
                                                                                                                       scheduleChange,
                                                                                                                       generateActionItemChange,
                                                                                                                       requiesResponseWhenAlteredChange,
                                                                                                                       suppressAlertChange);
            SetTargetDefinitionConfiguration(noneSelected);
        }

        public void HandleActionItemDefinitionConfigSelectAll(object sender, EventArgs args)
        {
            long siteId = ClientSession.GetUserContext().SiteId;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration allSelected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                      nameChange,
                                                                                                                      categoryChange,
                                                                                                                      operationalModeChange,
                                                                                                                      priorityChange,
                                                                                                                      descriptionChange,
                                                                                                                      documentLinksChange,
                                                                                                                      functionalLocationsChange,
                                                                                                                      targetDependenciesChange,
                                                                                                                      scheduleChange,
                                                                                                                      requiresResponseWhenTriggeredChange,
                                                                                                                      assignmentChange,
                                                                                                                      actionItemGenerationModeChange);
            SetActionItemDefinitionConfiguration(allSelected);
        }

        public void HandleActionItemDefinitionConfigClearAll(object sender, EventArgs args)
        {
            long siteId = ClientSession.GetUserContext().SiteId;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationsChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool requiresResponseWhenTriggeredChange = false;
            const bool assignmentChange = false;
            const bool actionItemGenerationModeChange = false;

            ActionItemDefinitionAutoReApprovalConfiguration noneSelected 
                = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                      nameChange,
                                                                      categoryChange,
                                                                      operationalModeChange,
                                                                      priorityChange,
                                                                      descriptionChange,
                                                                      documentLinksChange,
                                                                      functionalLocationsChange,
                                                                      targetDependenciesChange,
                                                                      scheduleChange,
                                                                      requiresResponseWhenTriggeredChange,
                                                                      assignmentChange,
                                                                      actionItemGenerationModeChange);
            SetActionItemDefinitionConfiguration(noneSelected);
        }


        public void HandleSave(object sender, EventArgs args)
        {
            ActionItemDefinitionAutoReApprovalConfiguration newAIDConfig = GetActionItemDefinitionConfigurationFromView();
            TargetDefinitionAutoReApprovalConfiguration newTargetDefConfig = GetTargetDefinitionConfigurationFromView();

            siteConfigurationService.UpdateActionItemDefinitionAutoReApprovalConfiguration(newAIDConfig);
            siteConfigurationService.UpdateTargetDefinitionAutoReApprovalConfiguration(newTargetDefConfig);
            view.SaveSucceededMessage();
            view.Close();
        }

        public void HandleCancel(object sender, EventArgs args)
        {
            view.Close();
        }

        private void SetActionItemDefinitionConfiguration(ActionItemDefinitionAutoReApprovalConfiguration aidConfig)
        {
            IActionItemDefinitionAutoReApprovalConfigurationView aidConfigView = view.AIDAutoReApprovalConfigView;
            aidConfigView.NameChange = aidConfig.NameChange;
            aidConfigView.CategoryChange = aidConfig.CategoryChange;
            aidConfigView.OperationalModeChange = aidConfig.OperationalModeChange;
            aidConfigView.PriorityChange = aidConfig.PriorityChange;
            aidConfigView.DescriptionChange = aidConfig.DescriptionChange;
            aidConfigView.DocumentLinksChange = aidConfig.DocumentLinksChange;
            aidConfigView.FunctionalLocationsChange = aidConfig.FunctionalLocationsChange;
            aidConfigView.TargetDependenciesChange = aidConfig.TargetDependenciesChange;
            aidConfigView.ScheduleChange = aidConfig.ScheduleChange;
            aidConfigView.RequiresResponseWhenTriggeredChange = aidConfig.RequiresResponseWhenTriggeredChange;
            aidConfigView.AssignmentChange = aidConfig.AssignmentChange;
            aidConfigView.ActionItemGenerationModeChange = aidConfig.ActionItemGenerationModeChange;
        }

        private ActionItemDefinitionAutoReApprovalConfiguration GetActionItemDefinitionConfigurationFromView()
        {
            IActionItemDefinitionAutoReApprovalConfigurationView aidConfigView = view.AIDAutoReApprovalConfigView;

            long siteId = ClientSession.GetUserContext().SiteId;

            ActionItemDefinitionAutoReApprovalConfiguration ret = 
                new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                  aidConfigView.NameChange,
                                                                  aidConfigView.CategoryChange,
                                                                  aidConfigView.OperationalModeChange,
                                                                  aidConfigView.PriorityChange,
                                                                  aidConfigView.DescriptionChange,
                                                                  aidConfigView.DocumentLinksChange,
                                                                  aidConfigView.FunctionalLocationsChange,
                                                                  aidConfigView.TargetDependenciesChange,
                                                                  aidConfigView.ScheduleChange,
                                                                  aidConfigView.RequiresResponseWhenTriggeredChange,
                                                                  aidConfigView.AssignmentChange,
                                                                  aidConfigView.ActionItemGenerationModeChange);
            return ret;
        }

        private void SetTargetDefinitionConfiguration(TargetDefinitionAutoReApprovalConfiguration targetDefConfig)
        {
            ITargetDefinitionAutoReApprovalConfigurationView targetDefConfigView = view.TargetDefAutoReApprovalConfigView;
            targetDefConfigView.NameChange = targetDefConfig.NameChange;
            targetDefConfigView.CategoryChange = targetDefConfig.CategoryChange;
            targetDefConfigView.OperationalModeChange = targetDefConfig.OperationalModeChange;
            targetDefConfigView.PriorityChange = targetDefConfig.PriorityChange;
            targetDefConfigView.DescriptionChange = targetDefConfig.DescriptionChange;
            targetDefConfigView.DocumentLinksChange = targetDefConfig.DocumentLinksChange;
            targetDefConfigView.FunctionalLocationChange = targetDefConfig.FunctionalLocationChange;
            targetDefConfigView.PHTagChange = targetDefConfig.PHTagChange;
            targetDefConfigView.TargetDependenciesChange = targetDefConfig.TargetDependenciesChange;
            targetDefConfigView.ScheduleChange = targetDefConfig.ScheduleChange;
            targetDefConfigView.GenerateActionItemChange = targetDefConfig.GenerateActionItemChange;
            targetDefConfigView.RequiresResponseWhenAlertedChange = targetDefConfig.RequiresResponseWhenAlertedChange;
            targetDefConfigView.SuppressAlertChange = targetDefConfig.SuppressAlertChange;
        }

        private TargetDefinitionAutoReApprovalConfiguration GetTargetDefinitionConfigurationFromView()
        {
            ITargetDefinitionAutoReApprovalConfigurationView targetDefConfigView = view.TargetDefAutoReApprovalConfigView;
            long siteId = ClientSession.GetUserContext().SiteId;
            TargetDefinitionAutoReApprovalConfiguration ret = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                              targetDefConfigView.NameChange,
                                                                                                              targetDefConfigView.CategoryChange,
                                                                                                              targetDefConfigView.OperationalModeChange,
                                                                                                              targetDefConfigView.PriorityChange,
                                                                                                              targetDefConfigView.DescriptionChange,
                                                                                                              targetDefConfigView.DocumentLinksChange,
                                                                                                              targetDefConfigView.FunctionalLocationChange,
                                                                                                              targetDefConfigView.PHTagChange,
                                                                                                              targetDefConfigView.TargetDependenciesChange,
                                                                                                              targetDefConfigView.ScheduleChange,
                                                                                                              targetDefConfigView.GenerateActionItemChange,
                                                                                                              targetDefConfigView.RequiresResponseWhenAlertedChange,
                                                                                                              targetDefConfigView.SuppressAlertChange);
            return ret;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Auto Re-Approval By Field Site = {0}", site.Id);
        }
    }
}
