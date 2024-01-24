using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class TargetDefinitionAutoReApprovalConfigurationFixture
    {
        public enum TargetDefinitionField
        {
            Name,
            Category,
            OperationalMode,
            Priority,
            Description,
            DocumentLinks,
            FunctionalLocation,
            PHTag,
            TargetDependencies,
            Schedule,
            GenerateActionItem,
            RequiresResponseWhenAlerted,
            SuppressAlert,
        }

        public static TargetDefinitionAutoReApprovalConfiguration CreateConfiguration(long siteId, params TargetDefinitionField[] requireReApprovalFields)
        {
            List<TargetDefinitionField> autoReApprovalFieldList = new List<TargetDefinitionField>(requireReApprovalFields);
            bool nameChange = autoReApprovalFieldList.Contains(TargetDefinitionField.Name);
            bool categoryChange = autoReApprovalFieldList.Contains(TargetDefinitionField.Category);
            bool operationalModeChange = autoReApprovalFieldList.Contains(TargetDefinitionField.OperationalMode);
            bool priorityChange = autoReApprovalFieldList.Contains(TargetDefinitionField.Priority);
            bool descriptionChange = autoReApprovalFieldList.Contains(TargetDefinitionField.Description);
            bool documentLinksChange = autoReApprovalFieldList.Contains(TargetDefinitionField.DocumentLinks);
            bool functionalLocationChange = autoReApprovalFieldList.Contains(TargetDefinitionField.FunctionalLocation);
            bool pHTagChange = autoReApprovalFieldList.Contains(TargetDefinitionField.PHTag);
            bool targetDependenciesChange = autoReApprovalFieldList.Contains(TargetDefinitionField.TargetDependencies);
            bool scheduleChange = autoReApprovalFieldList.Contains(TargetDefinitionField.Schedule);
            bool generateActionItemChange = autoReApprovalFieldList.Contains(TargetDefinitionField.GenerateActionItem);
            bool requiesResponseWhenAlteredChange = autoReApprovalFieldList.Contains(TargetDefinitionField.RequiresResponseWhenAlerted);
            bool suppressAlertChange = autoReApprovalFieldList.Contains(TargetDefinitionField.SuppressAlert);

            TargetDefinitionAutoReApprovalConfiguration ret = new TargetDefinitionAutoReApprovalConfiguration(siteId,
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
            return ret;
        }

        public static TargetDefinitionAutoReApprovalConfiguration CreateDefaultTargetDefAutoReApprovalConfig(long siteId)
        {
            return CreateAllSelectedTargetDefAutoReApprovalConfig(siteId);
        }

        public static TargetDefinitionAutoReApprovalConfiguration CreateAllSelectedTargetDefAutoReApprovalConfig(long siteId)
        {
            bool nameChange = true;
            bool categoryChange = true;
            bool operationalModeChange = true;
            bool priorityChange = true;
            bool descriptionChange = true;
            bool documentLinksChange = true;
            bool functionalLocationChange = true;
            bool pHTagChange = true;
            bool targetDependenciesChange = true;
            bool scheduleChange = true;
            bool generateActionItemChange = true;
            bool requiesResponseWhenAlteredChange = true;
            bool suppressAlertChange = true;

            TargetDefinitionAutoReApprovalConfiguration ret = new TargetDefinitionAutoReApprovalConfiguration(siteId,
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
            return ret;
        }

        public static TargetDefinitionAutoReApprovalConfiguration CreateSelectedNoneTargetDefAutoReApprovalConfig(long siteId)
        {
            bool nameChange = false;
            bool categoryChange = false;
            bool operationalModeChange = false;
            bool priorityChange = false;
            bool descriptionChange = false;
            bool documentLinksChange = false;
            bool functionalLocationChange = false;
            bool pHTagChange = false;
            bool targetDependenciesChange = false;
            bool scheduleChange = false;
            bool generateActionItemChange = false;
            bool requiesResponseWhenAlteredChange = false;
            bool suppressAlertChange = false;

            TargetDefinitionAutoReApprovalConfiguration ret = new TargetDefinitionAutoReApprovalConfiguration(siteId,
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
            return ret;
        }

        public static TargetDefinitionAutoReApprovalConfiguration CreateSampleTargetDefAutoReApprovalConfig(long siteId)
        {
            bool nameChange = false;
            bool categoryChange = true;
            bool operationalModeChange = true;
            bool priorityChange = false;
            bool descriptionChange = false;
            bool documentLinksChange = false;
            bool functionalLocationChange = true;
            bool pHTagChange = false;
            bool targetDependenciesChange = true;
            bool scheduleChange = true;
            bool generateActionItemChange = false;
            bool requiesResponseWhenAlteredChange = false;
            bool suppressAlertChange = true;

            TargetDefinitionAutoReApprovalConfiguration ret = new TargetDefinitionAutoReApprovalConfiguration(siteId,
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
            return ret;
        }
    }
}
