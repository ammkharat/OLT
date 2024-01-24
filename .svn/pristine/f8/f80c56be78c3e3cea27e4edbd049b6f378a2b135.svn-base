using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ActionItemDefinitionAutoReApprovalConfigurationDao : AbstractManagedDao, IActionItemDefinitionAutoReApprovalConfigurationDao
    {
        private const string QUERY_BY_SITE = "QueryActionItemDefinitionAutoReApprovalConfigurationBySiteId";
        private const string UPDATE_STORED_PROCEDURE = "UpdateActionItemDefinitionAutoReApprovalConfiguration";

        public ActionItemDefinitionAutoReApprovalConfiguration QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForSingleResult<ActionItemDefinitionAutoReApprovalConfiguration>(PopulateInstance, QUERY_BY_SITE);
        }

        public void Update(ActionItemDefinitionAutoReApprovalConfiguration configToBeUpdated)
        {
            SqlCommand command = ManagedCommand;
            command.Update(configToBeUpdated, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private void AddUpdateParameters(ActionItemDefinitionAutoReApprovalConfiguration configuration, SqlCommand command)
        {
            command.AddParameter("@SiteId", configuration.SiteId);
            command.AddParameter("@NameChange", configuration.NameChange);
            command.AddParameter("@CategoryChange", configuration.CategoryChange);
            command.AddParameter("@OperationalModeChange", configuration.OperationalModeChange);
            command.AddParameter("@PriorityChange", configuration.PriorityChange);
            command.AddParameter("@DescriptionChange", configuration.DescriptionChange);
            command.AddParameter("@DocumentLinksChange", configuration.DocumentLinksChange);
            command.AddParameter("@FunctionalLocationsChange", configuration.FunctionalLocationsChange);
            command.AddParameter("@TargetDependenciesChange", configuration.TargetDependenciesChange);
            command.AddParameter("@ScheduleChange", configuration.ScheduleChange);
            command.AddParameter("@RequiresResponseWhenTriggeredChange", configuration.RequiresResponseWhenTriggeredChange);
            command.AddParameter("@AssignmentChange", configuration.AssignmentChange);
            command.AddParameter("@ActionItemGenerationModeChange", configuration.ActionItemGenerationModeChange);
        }

        private static ActionItemDefinitionAutoReApprovalConfiguration PopulateInstance(SqlDataReader reader)
        {
            long siteId = reader.Get<long>("SiteId");
            bool nameChange = reader.Get<bool>("NameChange");
            bool categoryChange = reader.Get<bool>("CategoryChange");
            bool operationalModeChange = reader.Get<bool>("OperationalModeChange");
            bool priorityChange = reader.Get<bool>("PriorityChange");
            bool descriptionChange = reader.Get<bool>("DescriptionChange");
            bool documentLinksChange = reader.Get<bool>("DocumentLinksChange");
            bool functionalLocationsChange = reader.Get<bool>("FunctionalLocationsChange");
            bool targetDependenciesChange = reader.Get<bool>("TargetDependenciesChange");
            bool scheduleChange = reader.Get<bool>("ScheduleChange");
            bool requiresResponseWhenTriggeredChange = reader.Get<bool>("RequiresResponseWhenTriggeredChange");
            bool assignmentChange = reader.Get<bool>("AssignmentChange");
            bool actionItemGenerationModeChange = reader.Get<bool>("ActionItemGenerationModeChange");


            ActionItemDefinitionAutoReApprovalConfiguration ret = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
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
            return ret;
        }
    }
}