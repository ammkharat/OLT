using System.Collections.Generic;
using System.Data.SqlClient;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverQuestionnaireCokerCardConfigurationDao : AbstractManagedDao, IShiftHandoverQuestionnaireCokerCardConfigurationDao
    {
        private const string QUERY_BY_QUESTIONNAIRE_ID = "QueryShiftHandoverQuestionnaireCokerCardConfigurationByQuestionnaireId";
        private const string INSERT = "InsertShiftHandoverQuestionnaireCokerCardConfiguration";

        public List<long> QueryByShiftHandoverQuestionnaireId(long shiftHandoverQuestionnaireId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverQuestionnaireId",  shiftHandoverQuestionnaireId);
            return command.QueryForListResult<long>(PopulateInstance , QUERY_BY_QUESTIONNAIRE_ID);      
            
        }

        private static long PopulateInstance(SqlDataReader reader)
        {
            return reader.Get<long>("CokerCardConfigurationId");
        }

        public void Insert(long shiftHandoverQuestionnaireId, long cokerCardConfigurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverQuestionnaireId", shiftHandoverQuestionnaireId);
            command.AddParameter("@CokerCardConfigurationId", cokerCardConfigurationId);
            command.ExecuteNonQuery(INSERT);
        }
    }
}
