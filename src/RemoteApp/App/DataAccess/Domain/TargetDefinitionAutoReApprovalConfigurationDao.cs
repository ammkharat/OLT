using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetDefinitionAutoReApprovalConfigurationDao : AbstractManagedDao, ITargetDefinitionAutoReApprovalConfigurationDao
    {
        private const string QUERY_BY_SITE = "QueryTargetDefinitionAutoReApprovalConfigurationBySiteId";
        private const string UPDATE_STORED_PROCEDURE = "UpdateTargetDefinitionAutoReApprovalConfiguration";

        public TargetDefinitionAutoReApprovalConfiguration QueryById(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("SiteId",  siteId);
            return command.QueryForSingleResult<TargetDefinitionAutoReApprovalConfiguration>(PopulateInstance , QUERY_BY_SITE);
        }

        public void Update(TargetDefinitionAutoReApprovalConfiguration configToBeUpdated)
        {
            SqlCommand command = ManagedCommand;
            command.Update(configToBeUpdated, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private void AddUpdateParameters(TargetDefinitionAutoReApprovalConfiguration config, SqlCommand command)
        {
            command.AddParameter("SiteId",  config.SiteId);
            command.AddParameter("@NameChange",  config.NameChange);
            command.AddParameter("@CategoryChange",  config.CategoryChange);
            command.AddParameter("@OperationalModeChange",  config.OperationalModeChange);
            command.AddParameter("@PriorityChange",  config.PriorityChange);
            command.AddParameter("@DescriptionChange",  config.DescriptionChange);
            command.AddParameter("@DocumentLinksChange",  config.DocumentLinksChange);
            command.AddParameter("@FunctionalLocationChange",  config.FunctionalLocationChange);
            command.AddParameter("@PHTagChange",  config.PHTagChange);
            command.AddParameter("@TargetDependenciesChange",  config.TargetDependenciesChange);
            command.AddParameter("@ScheduleChange",  config.ScheduleChange);
            command.AddParameter("@GenerateActionItemChange",  config.GenerateActionItemChange);
            command.AddParameter("@RequiresResponseWhenAlertedChange",  config.RequiresResponseWhenAlertedChange);
            command.AddParameter("@SuppressAlertChange",  config.SuppressAlertChange);
        }

        private TargetDefinitionAutoReApprovalConfiguration PopulateInstance(SqlDataReader reader)
        {
            long queriedSiteId = reader.Get<long>("SiteId");
            bool nameChange = reader.Get<bool>("NameChange");
            bool categoryChange = reader.Get<bool>("CategoryChange");
            bool operationalModeChange = reader.Get<bool>("OperationalModeChange");
            bool priorityChange = reader.Get<bool>("PriorityChange");
            bool descriptionChange = reader.Get<bool>("DescriptionChange");
            bool documentLinksChange = reader.Get<bool>("DocumentLinksChange");
            bool functionalLocationChange = reader.Get<bool>("FunctionalLocationChange");
            bool pHTagChange = reader.Get<bool>("PHTagChange");
            bool targetDependenciesChange = reader.Get<bool>("TargetDependenciesChange");
            bool scheduleChange = reader.Get<bool>("ScheduleChange");
            bool generateActionItemChange = reader.Get<bool>("GenerateActionItemChange");
            bool requiesResponseWhenAlteredChange = reader.Get<bool>("RequiresResponseWhenAlertedChange");
            bool suppressAlertChange = reader.Get<bool>("SuppressAlertChange");

            return new TargetDefinitionAutoReApprovalConfiguration(queriedSiteId,
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
        }
    }
}