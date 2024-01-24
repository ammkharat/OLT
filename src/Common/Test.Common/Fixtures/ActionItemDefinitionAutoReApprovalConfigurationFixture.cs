using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class ActionItemDefinitionAutoReApprovalConfigurationFixture
    {
        public enum ActionItemDefinitionField
        {
            Name,
            Category,
            OperationalMode,
            Priority,
            Description,
            DocumentLinks,
            FunctionalLocations,
            TargetDependencies,
            Schedule,
            RequiresResponse,
            Assignment,
            ActionItemGenerationMode
        }

        public static ActionItemDefinitionAutoReApprovalConfiguration CreateConfiguration(long siteId, params ActionItemDefinitionField[] requiresReApprovalFields)
        {
            List<ActionItemDefinitionField> requireReApprovalFieldList = new List<ActionItemDefinitionField>(requiresReApprovalFields);
            bool name = requireReApprovalFieldList.Contains(ActionItemDefinitionField.Name);
            bool category = requireReApprovalFieldList.Contains(ActionItemDefinitionField.Category);
            bool operationalMode = requireReApprovalFieldList.Contains(ActionItemDefinitionField.OperationalMode);
            bool priority = requireReApprovalFieldList.Contains(ActionItemDefinitionField.Priority);
            bool description = requireReApprovalFieldList.Contains(ActionItemDefinitionField.Description);
            bool documentLinks = requireReApprovalFieldList.Contains(ActionItemDefinitionField.DocumentLinks);
            bool functionalLocations = requireReApprovalFieldList.Contains(ActionItemDefinitionField.FunctionalLocations);
            bool targetDependencies = requireReApprovalFieldList.Contains(ActionItemDefinitionField.TargetDependencies);
            bool schedule = requireReApprovalFieldList.Contains(ActionItemDefinitionField.Schedule);
            bool requiresResponseWhenTriggered = requireReApprovalFieldList.Contains(ActionItemDefinitionField.RequiresResponse);
            bool assignment = requireReApprovalFieldList.Contains(ActionItemDefinitionField.Assignment);
            bool actionItemGenerationModeChange = requireReApprovalFieldList.Contains(ActionItemDefinitionField.ActionItemGenerationMode);

            ActionItemDefinitionAutoReApprovalConfiguration ret = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                      name,
                                                                                                                      category,
                                                                                                                      operationalMode,
                                                                                                                      priority,
                                                                                                                      description,
                                                                                                                      documentLinks,
                                                                                                                      functionalLocations,
                                                                                                                      targetDependencies,
                                                                                                                      schedule,
                                                                                                                      requiresResponseWhenTriggered,
                                                                                                                      assignment,
                                                                                                                      actionItemGenerationModeChange);
            return ret;
        }

        public static ActionItemDefinitionAutoReApprovalConfiguration CreateDefaultAIDAutoReApprovalConfig(long siteId)
        {
            return CreateAllSelectedAIDAutoReApprovalConfiguration(siteId);
        }

        public static ActionItemDefinitionAutoReApprovalConfiguration CreateAllSelectedAIDAutoReApprovalConfiguration(long siteId)
        {
            bool name = true;
            bool category = true;
            bool operationalMode = true;
            bool priority = true;
            bool description = true;
            bool documentLinks = true;
            bool functionalLocations = true;
            bool targetDependencies = true;
            bool schedule = true;
            bool requiresResponseWhenTriggered = true;
            bool assignment = true;
            bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration ret = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                      name,
                                                                                                                      category,
                                                                                                                      operationalMode,
                                                                                                                      priority,
                                                                                                                      description,
                                                                                                                      documentLinks,
                                                                                                                      functionalLocations,
                                                                                                                      targetDependencies,
                                                                                                                      schedule,
                                                                                                                      requiresResponseWhenTriggered,
                                                                                                                      assignment,
                                                                                                                      actionItemGenerationModeChange);
            return ret;
        }

        public static ActionItemDefinitionAutoReApprovalConfiguration CreateSelectedNoneAIDAutoReApprovalConfiguration(long siteId)
        {
            bool name = false;
            bool category = false;
            bool operationalMode = false;
            bool priority = false;
            bool description = false;
            bool documentLinks = false;
            bool functionalLocations = false;
            bool targetDependencies = false;
            bool schedule = false;
            bool requiresResponseWhenTriggered = false;
            bool assignment = false;
            bool actionItemGenerationModeChange = false;

            ActionItemDefinitionAutoReApprovalConfiguration ret = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                      name,
                                                                                                                      category,
                                                                                                                      operationalMode,
                                                                                                                      priority,
                                                                                                                      description,
                                                                                                                      documentLinks,
                                                                                                                      functionalLocations,
                                                                                                                      targetDependencies,
                                                                                                                      schedule,
                                                                                                                      requiresResponseWhenTriggered,
                                                                                                                      assignment,
                                                                                                                      actionItemGenerationModeChange);
            return ret;
        }

        public static ActionItemDefinitionAutoReApprovalConfiguration CreateSampleActionItemDefAutoReApprovalConfig(long siteId)
        {
            bool name = true;
            bool category = true;
            bool operationalMode = false;
            bool priority = false;
            bool description = false;
            bool documentLinks = true;
            bool functionalLocations = true;
            bool targetDependencies = false;
            bool schedule = false;
            bool requiresResponseWhenTriggered = true;
            bool assignment = true;
            bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration ret = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                      name,
                                                                                                                      category,
                                                                                                                      operationalMode,
                                                                                                                      priority,
                                                                                                                      description,
                                                                                                                      documentLinks,
                                                                                                                      functionalLocations,
                                                                                                                      targetDependencies,
                                                                                                                      schedule,
                                                                                                                      requiresResponseWhenTriggered,
                                                                                                                      assignment,
                                                                                                                      actionItemGenerationModeChange);
            return ret;
        }
    }
}
