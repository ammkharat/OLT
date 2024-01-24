using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverAnswerDao : AbstractManagedDao, IShiftHandoverAnswerDao
    {
        private readonly IShiftHandoverQuestionDao questionDao;

        private const string QUERY_BY_QUESTIONNAIRE_ID = "QueryShiftHandoverAnswersByQuestionnaireId";        
        private const string INSERT = "InsertShiftHandoverAnswer";
        private const string UPDATE = "UpdateShiftHandoverAnswer";
        private const string QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ = "QueryShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead";
        private const string QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ_FOR_ISFLEXIBLE_DATA =
            "QueryFlexibleShiftHandoverAnswerDTOByParentFlocListAndMarkedAsRead";

        public ShiftHandoverAnswerDao()
        {
            questionDao = DaoRegistry.GetDao<IShiftHandoverQuestionDao>();
        }

        public List<ShiftHandoverAnswer> QueryByQuestionnaireId(long questionnaireId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@QuestionnaireId", questionnaireId);
            return command.QueryForListResult<ShiftHandoverAnswer>(PopulateInstance, QUERY_BY_QUESTIONNAIRE_ID);      
        }

        public ShiftHandoverAnswer Insert(ShiftHandoverAnswer shiftHandoverAnswer, long questionnaireId)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@ShiftHandoverQuestionnaireId", questionnaireId);
            command.Insert(shiftHandoverAnswer, AddInsertParameters, INSERT);
            shiftHandoverAnswer.Id = (long?)idParameter.Value;
            return shiftHandoverAnswer;
        }

        private static void AddInsertParameters(ShiftHandoverAnswer answer, SqlCommand command)
        {
            command.AddParameter("@QuestionDisplayOrder", answer.QuestionDisplayOrder);
            command.AddParameter("@ShiftHandoverQuestionId", answer.ShiftHandoverQuestionId);
            SetCommonAttributes(answer, command);
        }

        public void Update(ShiftHandoverAnswer answer)
        {
            SqlCommand command = ManagedCommand;
            command.Update(answer, AddUpdateParameters, UPDATE);
        }

        private static void AddUpdateParameters(ShiftHandoverAnswer answer, SqlCommand command)
        {
            command.AddParameter("@Id", answer.Id);
            SetCommonAttributes(answer, command);
        }

        private static void SetCommonAttributes(ShiftHandoverAnswer answer, SqlCommand command)
        {
            command.AddParameter("@Answer", answer.Answer);
            command.AddParameter("@Comments", answer.Comments);
        }

        private ShiftHandoverAnswer PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            bool answer  = reader.Get<bool>("Answer");            
            string comments  = reader.Get<string>("Comments");            
            int questionDisplayOrder  = reader.Get<int>("QuestionDisplayOrder");
            long shiftHandoverQuestionId  = reader.Get<long>("shiftHandoverQuestionId");

            ShiftHandoverQuestion shiftHandoverQuestion = questionDao.QueryById(shiftHandoverQuestionId);

            ShiftHandoverAnswer shiftHandoverAnswer =
                new ShiftHandoverAnswer(id, answer, comments, shiftHandoverQuestion.Text,shiftHandoverQuestion.YesNoValue,shiftHandoverQuestion.EmailList, questionDisplayOrder, shiftHandoverQuestionId);//YesNoValue is added by ppanigrahi.
            return shiftHandoverAnswer;
        }

        //public List<ShiftHandoverAnswerDTO> QueryByParentFlocListAndMarkedAsRead(DateTime from, DateTime to, IFlocSet flocSet)
        //{
        //    SqlCommand command = ManagedCommand;
        //    command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
        //    command.AddParameter("@StartOfDateRange", from);
        //    command.AddParameter("@EndOfDateRange", to);

        //    return command.QueryForListResult<ShiftHandoverAnswerDTO>(PopulateMarkedAsReadInstance, QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ);  
        //}

        /* Flexi Shift CokerCardInfoForShiftHandoverDTO RITM0185797*/
        public List<ShiftHandoverAnswerDTO> QueryByParentFlocListAndMarkedAsRead(DateTime from, DateTime to, IFlocSet flocSet, bool isflexibledata)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@StartOfDateRange", from);
            command.AddParameter("@EndOfDateRange", to);

            string procedureName = isflexibledata
               ? QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ_FOR_ISFLEXIBLE_DATA
               : QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ;

            return command.QueryForListResult<ShiftHandoverAnswerDTO>(PopulateMarkedAsReadInstance, procedureName);
        }

        private ShiftHandoverAnswerDTO PopulateMarkedAsReadInstance(SqlDataReader reader)
        {
            long questionnaireId  = reader.Get<long>("ShiftHandoverQuestionnaireId");
            bool answer  = reader.Get<bool>("Answer");
            string comments  = reader.Get<string>("Comments");
            int questionDisplayOrder  = reader.Get<int>("QuestionDisplayOrder");
            string questionText  = reader.Get<string>("QuestionText");
            string yesNo = reader.Get<String>("YesNo");//Added by ppanigrahi
            string emailList = reader.Get<String>("EmailList");//Added by ppanigrahi
            ShiftHandoverAnswerDTO dto = new ShiftHandoverAnswerDTO(
                questionnaireId, 
                answer,
                comments,
                questionText,
                yesNo,
                emailList,
                questionDisplayOrder);

            return dto;
        }
    }
}

