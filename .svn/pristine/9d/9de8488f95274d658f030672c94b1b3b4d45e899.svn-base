using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardConfigurationCycleStepDao : AbstractManagedDao, ICokerCardConfigurationCycleStepDao
    {
        private const string INSERT = "InsertCokerCardConfigurationCycleStep";
        private const string UPDATE = "UpdateCokerCardConfigurationCycleStep";
        private const string QUERY_COKER_CARD_CONFIGURATION_CYCLE_STEPS = "QueryCokerCardConfigurationCycleSteps";

        public void Insert(CokerCardConfigurationCycleStep step, long configurationId)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@CokerCardConfigurationId", configurationId);
            command.Insert(step, AddInsertParameters, INSERT);
            step.Id = (long?)idParameter.Value;             
        }

        public void Update(CokerCardConfigurationCycleStep step)
        {
            ManagedCommand.Update(step, AddUpdateParameters, UPDATE);           
        }

        public List<CokerCardConfigurationCycleStep> QueryByCokerCardConfigurationId(long cokerCardConfigurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardConfigurationId", cokerCardConfigurationId);
            return command.QueryForListResult<CokerCardConfigurationCycleStep>(PopulateCycleStep, QUERY_COKER_CARD_CONFIGURATION_CYCLE_STEPS);
        }

        private static void AddUpdateParameters(CokerCardConfigurationCycleStep step, SqlCommand command)
        {
            command.AddParameter("@Id", step.IdValue);
            AddCommonParameters(step, command);
        }

        private static void AddInsertParameters(CokerCardConfigurationCycleStep step, SqlCommand command)
        {
            AddCommonParameters(step, command);
        }

        private static void AddCommonParameters(CokerCardConfigurationCycleStep step, SqlCommand command)
        {
            command.AddParameter("@Name", step.Name);
            command.AddParameter("@DisplayOrder", step.DisplayOrder);
        }


        private static CokerCardConfigurationCycleStep PopulateCycleStep(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            int displayOrder = reader.Get<int>("DisplayOrder");

            return new CokerCardConfigurationCycleStep(id, name, displayOrder);
        }
    }
}