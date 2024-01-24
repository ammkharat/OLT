using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardConfigurationDrumDao : AbstractManagedDao, ICokerCardConfigurationDrumDao
    {
        private const string INSERT = "InsertCokerCardConfigurationDrum";
        private const string UPDATE = "UpdateCokerCardConfigurationDrum";
        private const string QUERY_COKER_CARD_CONFIGURATION_DRUMS = "QueryCokerCardConfigurationDrums";        

        public List<CokerCardConfigurationDrum> QueryByCokerCardConfigurationId(long cokerCardConfigurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardConfigurationId", cokerCardConfigurationId);
            return command.QueryForListResult<CokerCardConfigurationDrum>(PopulateDrum, QUERY_COKER_CARD_CONFIGURATION_DRUMS);
        }

        public void Insert(CokerCardConfigurationDrum drum, long configurationId)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@CokerCardConfigurationId", configurationId);
            command.Insert(drum, AddInsertParameters, INSERT);
            drum.Id = (long?)idParameter.Value;             
        }

        public void Update(CokerCardConfigurationDrum drum)
        {            
            ManagedCommand.Update(drum, AddUpdateParameters, UPDATE);           
        }

        private static void AddUpdateParameters(CokerCardConfigurationDrum drum, SqlCommand command)
        {
            command.AddParameter("@Id", drum.IdValue);
            AddCommonParameters(drum, command);
        }

        private static void AddInsertParameters(CokerCardConfigurationDrum drum, SqlCommand command)
        {
            AddCommonParameters(drum, command);
        }

        private static void AddCommonParameters(CokerCardConfigurationDrum drum, SqlCommand command)
        {
            command.AddParameter("@Name", drum.Name);
            command.AddParameter("@DisplayOrder", drum.DisplayOrder);
        }

        private static CokerCardConfigurationDrum PopulateDrum(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            int displayOrder = reader.Get<int>("DisplayOrder");

            return new CokerCardConfigurationDrum(id, name, displayOrder);
        }
    }
}