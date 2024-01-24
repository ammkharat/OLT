using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItemDefinitionAutoReApprovalConfiguration : DomainObject
    {
        public ActionItemDefinitionAutoReApprovalConfiguration(long siteId,
            bool nameChange,
            bool categoryChange,
            bool operationalModeChange,
            bool priorityChange,
            bool descriptionChange,
            bool documentLinksChange,
            bool functionalLocationsChange,
            bool targetDependenciesChange,
            bool scheduleChange,
            bool requiresResponseWhenTriggeredChange,
            bool assignmentChange,
            bool actionItemGenerationModeChange)
        {
            SiteId = siteId;
            NameChange = nameChange;
            CategoryChange = categoryChange;
            OperationalModeChange = operationalModeChange;
            PriorityChange = priorityChange;
            DescriptionChange = descriptionChange;
            DocumentLinksChange = documentLinksChange;
            FunctionalLocationsChange = functionalLocationsChange;
            TargetDependenciesChange = targetDependenciesChange;
            ScheduleChange = scheduleChange;
            RequiresResponseWhenTriggeredChange = requiresResponseWhenTriggeredChange;
            AssignmentChange = assignmentChange;
            ActionItemGenerationModeChange = actionItemGenerationModeChange;
        }

        public long SiteId { get; private set; }

        public bool NameChange { get; private set; }

        public bool CategoryChange { get; private set; }

        public bool OperationalModeChange { get; private set; }

        public bool PriorityChange { get; private set; }

        public bool DescriptionChange { get; private set; }

        public bool DocumentLinksChange { get; private set; }

        public bool FunctionalLocationsChange { get; private set; }

        public bool TargetDependenciesChange { get; private set; }

        public bool ScheduleChange { get; private set; }

        public bool RequiresResponseWhenTriggeredChange { get; private set; }

        public bool AssignmentChange { get; private set; }

        public bool ActionItemGenerationModeChange { get; private set; }

        public bool RequireReApproval(ActionItemDefinition before, ActionItemDefinition after)
        {
            var requireReApprovalNameChange = NameChange && before.Name != after.Name;
            var requireReApprovalCategoryChange = CategoryChange && before.Category.Id != after.Category.Id;
            var requireReApprovalOperationalModeChange = OperationalModeChange &&
                                                         before.OperationalMode.Id != after.OperationalMode.Id;
            var requireReApprovalPriorityChange = PriorityChange && before.Priority.Id != after.Priority.Id;
            var requireReApprovalDescriptionChange = DescriptionChange && before.Description != after.Description;
            var requireReApprovalDocumentLinksChange = DocumentLinksChange &&
                                                       before.DocumentLinks.EqualsById(after.DocumentLinks) == false;
            var requireReApprovalFunctionalLocationsChange = FunctionalLocationsChange &&
                                                             before.FunctionalLocations.EqualsById(
                                                                 after.FunctionalLocations) == false;
            var requireReApprovalTargetDependenciesChange = TargetDependenciesChange &&
                                                            before.TargetDefinitionDTOs.EqualsById(
                                                                after.TargetDefinitionDTOs) == false;
            var requireReApprovalScheduleChange = ScheduleChange && before.Schedule.Equals(after.Schedule) == false;
            var requireReApprovalRequiresResponseWhenTriggeredChange = RequiresResponseWhenTriggeredChange &&
                                                                       before.ResponseRequired != after.ResponseRequired;
            var requiresReApprovalAssignmentChange = false;
            if (AssignmentChange)
            {
                if (before.Assignment == null || after.Assignment == null)
                {
                    requiresReApprovalAssignmentChange = (before.Assignment == null && after.Assignment != null) ||
                                                         (before.Assignment != null && after.Assignment == null);
                }
                else
                {
                    requiresReApprovalAssignmentChange = before.Assignment.Id != after.Assignment.Id;
                }
            }
            var requireReApprovalActionItemGenerationModeChange =
                ActionItemGenerationModeChange &&
                before.CreateAnActionItemForEachFunctionalLocation != after.CreateAnActionItemForEachFunctionalLocation;

            return requireReApprovalNameChange ||
                   requireReApprovalCategoryChange ||
                   requireReApprovalOperationalModeChange ||
                   requireReApprovalPriorityChange ||
                   requireReApprovalDescriptionChange ||
                   requireReApprovalDocumentLinksChange ||
                   requireReApprovalFunctionalLocationsChange ||
                   requireReApprovalTargetDependenciesChange ||
                   requireReApprovalScheduleChange ||
                   requireReApprovalRequiresResponseWhenTriggeredChange ||
                   requiresReApprovalAssignmentChange ||
                   requireReApprovalActionItemGenerationModeChange;
        }
    }
}