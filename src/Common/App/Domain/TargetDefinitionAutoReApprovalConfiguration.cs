using System;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class TargetDefinitionAutoReApprovalConfiguration : DomainObject
    {
        private readonly bool categoryChange;
        private readonly bool descriptionChange;
        private readonly bool documentLinksChange;
        private readonly bool functionalLocationChange;
        private readonly bool generateActionItemChange;
        private readonly bool nameChange;
        private readonly bool operationalModeChange;
        private readonly bool pHTagChange;
        private readonly bool priorityChange;
        private readonly bool requiresResponseWhenAlertedChange;
        private readonly bool scheduleChange;
        private readonly bool suppressAlertChange;
        private readonly bool targetDependenciesChange;

        public TargetDefinitionAutoReApprovalConfiguration(long siteId,
            bool nameChange,
            bool categoryChange,
            bool operationalModeChange,
            bool priorityChange,
            bool descriptionChange,
            bool documentLinksChange,
            bool functionalLocationChange,
            bool pHTagChange,
            bool targetDependenciesChange,
            bool scheduleChange,
            bool generateActionItemChange,
            bool requiesResponseWhenAlteredChange,
            bool suppressAlertChange)
        {
            id = siteId;
            this.nameChange = nameChange;
            this.categoryChange = categoryChange;
            this.operationalModeChange = operationalModeChange;
            this.priorityChange = priorityChange;
            this.descriptionChange = descriptionChange;
            this.documentLinksChange = documentLinksChange;
            this.functionalLocationChange = functionalLocationChange;
            this.pHTagChange = pHTagChange;
            this.targetDependenciesChange = targetDependenciesChange;
            this.scheduleChange = scheduleChange;
            this.generateActionItemChange = generateActionItemChange;
            requiresResponseWhenAlertedChange = requiesResponseWhenAlteredChange;
            this.suppressAlertChange = suppressAlertChange;
        }

        public long SiteId
        {
            get { return id.Value; }
        }

        public bool NameChange
        {
            get { return nameChange; }
        }

        public bool CategoryChange
        {
            get { return categoryChange; }
        }

        public bool OperationalModeChange
        {
            get { return operationalModeChange; }
        }

        public bool PriorityChange
        {
            get { return priorityChange; }
        }

        public bool DescriptionChange
        {
            get { return descriptionChange; }
        }

        public bool DocumentLinksChange
        {
            get { return documentLinksChange; }
        }

        public bool FunctionalLocationChange
        {
            get { return functionalLocationChange; }
        }

        public bool PHTagChange
        {
            get { return pHTagChange; }
        }

        public bool TargetDependenciesChange
        {
            get { return targetDependenciesChange; }
        }

        public bool ScheduleChange
        {
            get { return scheduleChange; }
        }

        public bool GenerateActionItemChange
        {
            get { return generateActionItemChange; }
        }

        public bool RequiresResponseWhenAlertedChange
        {
            get { return requiresResponseWhenAlertedChange; }
        }

        public bool SuppressAlertChange
        {
            get { return suppressAlertChange; }
        }

        public bool RequrieReApproval(TargetDefinition before, TargetDefinition after)
        {
            var requireReApproveNameChange = nameChange && before.Name != after.Name;
            var requireReApproveCategoryChange = categoryChange && before.Category.Id != after.Category.Id;
            var requireReApproveOperationalModeChange = operationalModeChange &&
                                                        before.OperationalMode.Id != after.OperationalMode.Id;
            var requireReApprovePriorityChange = priorityChange && before.Priority.Id != after.Priority.Id;
            var requireReApproveDescriptionChange = descriptionChange && before.Description != after.Description;
            var requireReApproveDocumentLinksChange = documentLinksChange &&
                                                      before.DocumentLinks.EqualsById(after.DocumentLinks) == false;
            var requireReApproveFunctionalLocationChange = functionalLocationChange &&
                                                           before.FunctionalLocation.Id != after.FunctionalLocation.Id;
            var requireReApprovePHTagChange = pHTagChange && before.TagInfo.Id != after.TagInfo.Id;
            var requireReApproveTargetDependenciesChange = targetDependenciesChange &&
                                                           before.AssociatedTargetDTOs.EqualsById(
                                                               after.AssociatedTargetDTOs) == false;
            var requireReApproveScheduleChange = scheduleChange && before.Schedule.Equals(after.Schedule) == false;
            var requireReApproveGenerateActionItemChange = generateActionItemChange &&
                                                           before.GenerateActionItem != after.GenerateActionItem;
            var requireReApproveRequiresResponseWhenAlertedChange = requiresResponseWhenAlertedChange &&
                                                                    before.RequiresResponseWhenAlerted !=
                                                                    after.RequiresResponseWhenAlerted;
            var requireReApproveSuppressAlertChange = suppressAlertChange &&
                                                      before.IsAlertRequired != after.IsAlertRequired;

            return requireReApproveNameChange ||
                   requireReApproveCategoryChange ||
                   requireReApproveOperationalModeChange ||
                   requireReApprovePriorityChange ||
                   requireReApproveDescriptionChange ||
                   requireReApproveDocumentLinksChange ||
                   requireReApproveFunctionalLocationChange ||
                   requireReApprovePHTagChange ||
                   requireReApproveTargetDependenciesChange ||
                   requireReApproveScheduleChange ||
                   requireReApproveGenerateActionItemChange ||
                   requireReApproveRequiresResponseWhenAlertedChange ||
                   requireReApproveSuppressAlertChange;
        }
    }
}