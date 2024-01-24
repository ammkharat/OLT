using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverQuestionDao : AbstractManagedDao, IShiftHandoverQuestionDao
    {
        private const string QUERY_BY_CONFIGURATION_ID = "QueryShiftHandoverQuestionsByConfigurationId";
        private const string QUERY_BY_ID = "QueryShiftHandoverQuestionById";
        private const string DELETE_BY_ID = "RemoveShiftHandoverQuestionById";
        private const string INSERT = "InsertShiftHandoverQuestion";
        private const string UPDATE_AS_OLD_VERSION = "UpdateShiftHandoverQuestionAsOld";

        public ShiftHandoverQuestion QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById(id, (PopulateInstance<ShiftHandoverQuestion>) PopulateInstance, QUERY_BY_ID);
        }

        public List<ShiftHandoverQuestion> QueryByConfigurationId(long id)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@ConfigurationId",  id);
            return command.QueryForListResult<ShiftHandoverQuestion>(PopulateInstance , QUERY_BY_CONFIGURATION_ID);
        }

        public ShiftHandoverQuestion Insert(ShiftHandoverQuestion shiftHandoverQuestion)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(shiftHandoverQuestion, AddInsertParameters, INSERT);
            shiftHandoverQuestion.Id = (long?)idParameter.Value;

            return shiftHandoverQuestion;
        }

        public void Delete(ShiftHandoverQuestion shiftHandoverQuestion)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id",  shiftHandoverQuestion.Id);
            command.ExecuteNonQuery(DELETE_BY_ID);
        }

        public void UpdateAsOlderVersion(ShiftHandoverQuestion shiftHandoverQuestion)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id",  shiftHandoverQuestion.Id);
            command.ExecuteNonQuery(UPDATE_AS_OLD_VERSION);
        }

        private static void AddInsertParameters(ShiftHandoverQuestion question, SqlCommand command)
        {
            command.AddParameter("@ConfigurationId", question.ConfigurationId);
            SetCommonAttributes(question, command);
        }

        private static void SetCommonAttributes(ShiftHandoverQuestion question, SqlCommand command)
        {
            command.AddParameter("@DisplayOrder", question.DisplayOrder);
            command.AddParameter("@Text", question.Text);
            command.AddParameter("@HelpText", question.HelpText);
            //EmailList and YesNo parameter has been added by ppanigrahi
            command.AddParameter("@EmailList",question.EmailList);
            command.AddParameter("@YesNo",question.YesNoValue);
        }

        private static ShiftHandoverQuestion PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long configurationId = reader.Get<long>("ShiftHandoverConfigurationId");
            int displayOrder = reader.Get<int>("DisplayOrder");
            string question = reader.Get<string>("Text");
            string yesNo = reader.Get<string>("YesNo");//Added by ppanigrahi
            string emailList = reader.Get<string>("EmailList");//Added by ppanigrahi
            string helpText = reader.Get<string>("HelpText");

            ShiftHandoverQuestion shiftHandoverQuestion = new ShiftHandoverQuestion(id, configurationId, displayOrder, question,yesNo,emailList, helpText);//Changed by ppanigrahi
            return shiftHandoverQuestion;
        }
    }
}

