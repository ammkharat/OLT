using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverQuestionnaireDao : AbstractManagedDao, IShiftHandoverQuestionnaireDao
    {
        private const string QUERY_BY_ID = "QueryShiftHandoverQuestionnaireById";
        private const string QUERY_BY_USER_WORK_ASSIGNMENT_AND_SHIFT = "QueryShiftHandoverQuestionnaireByUserWorkAssignmentAndShift";        
        private const string QUERY_BY_WORK_ASSIGNMENT_AND_SHIFT = "QueryShiftHandoverQuestionnaireByWorkAssignmentAndShift";        
        private const string INSERT = "InsertShiftHandoverQuestionnaire";
        private const string UPDATE = "UpdateShiftHandoverQuestionnaire";
        private const string REMOVE = "RemoveShiftHandoverQuestionnaire";
        private const string QUERY_BY_FLOCS_AND_DATES_AND_ASSIGNMENT = "QueryShiftHandoverQuestionnaireByFunctionalLocationsAndDateRangeAndAssignment";

        private const string QUERY_BY_FLOCS_AND_DATES_AND_ASSIGNMENT_FOR_FLEXI_SHIFT_HANDOVER_DATA_ONLY =
            "QueryShiftHandoverQuestionnaireByFunctionalLocationsAndDateRangeAndAssignmentforFlexiShiftDataOnly";
        private const string INSERT_SHIFT_HANDOVER_QUESTIONNAIRE_FUNCTIONAL_LOCATION = "InsertShiftHandoverQuestionnaireFunctionalLocation";
        private const string INSERT_OR_UPDATE_FUNCTIONAL_LOCATION_LIST = "InsertOrUpdateShiftHandoverQuestionnaireFunctionalLocationList";

        private readonly IFunctionalLocationDao flocDao;
        private readonly IShiftHandoverAnswerDao answerDao;
        private readonly IUserDao userDao;
        private readonly IShiftPatternDao shiftPatternDao;
        private readonly IWorkAssignmentDao assignmentDao;
        private readonly IShiftHandoverQuestionnaireCokerCardConfigurationDao questionnaireCokerCardConfigurationDao;

        public ShiftHandoverQuestionnaireDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            answerDao = DaoRegistry.GetDao<IShiftHandoverAnswerDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            assignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            questionnaireCokerCardConfigurationDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireCokerCardConfigurationDao>();
        }

        public ShiftHandoverQuestionnaire QueryById(long id)
        {
            return ManagedCommand.QueryById<ShiftHandoverQuestionnaire>(id, PopulateInstance, QUERY_BY_ID);   
        }

        public List<ShiftHandoverQuestionnaire> QueryByUserWorkAssignmentAndShift(long userId, long workAssignmentId, UserShift userShift)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@WorkAssignmentId", workAssignmentId);
            command.AddParameter("@ShiftId", userShift.ShiftPattern.IdValue);
            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTimeWithPadding);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTimeWithPadding);

            return command.QueryForListResult<ShiftHandoverQuestionnaire>(PopulateInstance, QUERY_BY_USER_WORK_ASSIGNMENT_AND_SHIFT);
        }

        public List<ShiftHandoverQuestionnaire> QueryByWorkAssignmentAndShift(long workAssignmentId, UserShift userShift)
        {
            SqlCommand command = ManagedCommand;
                                    
            command.AddParameter("@WorkAssignmentId", workAssignmentId);            
            command.AddParameter("@ShiftId", userShift.ShiftPattern.IdValue);
            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTimeWithPadding);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTimeWithPadding);

            return command.QueryForListResult<ShiftHandoverQuestionnaire>(PopulateInstance, QUERY_BY_WORK_ASSIGNMENT_AND_SHIFT);

        }

        public List<ShiftHandoverQuestionnaire> QueryByFunctionalLocationAndDateRangeAndAssignment(
            IFlocSet flocSet, 
            DateTime fromDate,
            DateTime toDate,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvAssignmentIds", workAssignments.BuildIdStringFromList());
            command.AddParameter("@IncludeNullAssignment", includeNullWorkAssignment);
            command.AddParameter("@StartOfDateRange", fromDate);
            command.AddParameter("@EndOfDateRange", toDate);

            return GetUniqueQuestionnaires(command, QUERY_BY_FLOCS_AND_DATES_AND_ASSIGNMENT);
        }

        /*oner load data flexi shift handover RITM0185797 amit shukla*/
        public List<ShiftHandoverQuestionnaire> QueryByFunctionalLocationAndDateRangeAndAssignment(
           IFlocSet flocSet,
           DateTime fromDate,
           DateTime toDate,
           List<WorkAssignment> workAssignments,
           bool includeNullWorkAssignment, bool showFlexibleShiftHandoverData)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvAssignmentIds", workAssignments.BuildIdStringFromList());
            command.AddParameter("@IncludeNullAssignment", includeNullWorkAssignment);
            command.AddParameter("@StartOfDateRange", fromDate);
            command.AddParameter("@EndOfDateRange", toDate);
            command.AddParameter("@ShowFlexibleShiftHandoverData", showFlexibleShiftHandoverData);

            return GetUniqueQuestionnaires(command, QUERY_BY_FLOCS_AND_DATES_AND_ASSIGNMENT_FOR_FLEXI_SHIFT_HANDOVER_DATA_ONLY);
        }
        /**/

        private List<ShiftHandoverQuestionnaire> GetUniqueQuestionnaires(SqlCommand command, string query)
        {
            Dictionary<long, ShiftHandoverQuestionnaire> result = new Dictionary<long, ShiftHandoverQuestionnaire>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");
                    if (!result.ContainsKey(id))
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<ShiftHandoverQuestionnaire>(result.Values);
        }

        public void Insert(ShiftHandoverQuestionnaire shiftHandoverQuestionnaire)
        {
            SqlCommand command = ManagedCommand;
           
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(shiftHandoverQuestionnaire, AddInsertParameters, INSERT);
            shiftHandoverQuestionnaire.Id = idParameter.GetValue<long?>();

            InsertFunctionalLocations(command, shiftHandoverQuestionnaire);
            InsertAnswers(shiftHandoverQuestionnaire);
            foreach (long cokerCardConfigurationId in shiftHandoverQuestionnaire.RelevantCokerCardConfigurations)
            {
                questionnaireCokerCardConfigurationDao.Insert(shiftHandoverQuestionnaire.IdValue, cokerCardConfigurationId);
            }
        }

        private void InsertFunctionalLocations(SqlCommand command, ShiftHandoverQuestionnaire questionnaire)
        {
            if (!questionnaire.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_SHIFT_HANDOVER_QUESTIONNAIRE_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in questionnaire.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ShiftHandoverQuestionnaireId", questionnaire.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }

                InsertOrUpdateFunctionalLocationList(command, questionnaire);
            }
        }

        private void InsertOrUpdateFunctionalLocationList(SqlCommand command, ShiftHandoverQuestionnaire questionnaire)
        {
            command.Parameters.Clear();
            command.CommandText = INSERT_OR_UPDATE_FUNCTIONAL_LOCATION_LIST;
            command.AddParameter("@QuestionnaireId", questionnaire.IdValue);
            command.ExecuteNonQuery();
        }

        private void InsertAnswers(ShiftHandoverQuestionnaire questionnaire)
        {
            foreach (ShiftHandoverAnswer answer in questionnaire.Answers)
            {
                answerDao.Insert(answer, questionnaire.IdValue);
            }
        }

        private static void AddInsertParameters(ShiftHandoverQuestionnaire questionnaire, SqlCommand command)
        {
            command.AddParameter("@ShiftHandoverConfigurationName", questionnaire.ShiftHandoverConfigurationName);
            command.AddParameter("@ShiftId", questionnaire.Shift.Id);
            if (questionnaire.Assignment != null)
            {
                command.AddParameter("@AssignmentId", questionnaire.Assignment.Id);
            }
            command.AddParameter("@CreatedByUserId", questionnaire.CreateUser.Id);
            command.AddParameter("@CreatedDateTime", questionnaire.CreateDateTime);

            /* RITM0185797 Flexible shift handover*/
            /* amit shukla */
            command.AddParameter("@FlexiShiftStartDate", questionnaire.FlexiShiftStartDate);
            command.AddParameter("@FlexiShiftEndDate", questionnaire.FlexiShiftEndDate);
            command.AddParameter("@IsFlexible", questionnaire.IsFlexible);
            /**/
            SetCommonAttributes(questionnaire, command);
        }

        public void Update(ShiftHandoverQuestionnaire questionnaire)
        {
            SqlCommand command = ManagedCommand;

            command.Update(questionnaire, AddUpdateParameters, UPDATE);

            UpdateAnswers(questionnaire);
        }

        private void UpdateAnswers(ShiftHandoverQuestionnaire questionnaire)
        {
            foreach (ShiftHandoverAnswer answer in questionnaire.Answers)
            {
                answerDao.Update(answer);
            }
        }

        private static void AddUpdateParameters(ShiftHandoverQuestionnaire questionnaire, SqlCommand command)
        {
            command.AddParameter("@Id", questionnaire.Id);
            SetCommonAttributes(questionnaire, command);
        }

        private static void SetCommonAttributes(ShiftHandoverQuestionnaire questionnaire, SqlCommand command)
        {
            command.AddParameter("@LastModifiedDateTime", questionnaire.LastModifiedDate);
            command.AddParameter("@HasYesAnswer", questionnaire.HasYesAnswer);
            command.AddParameter("@LogId", questionnaire.LogId);
            command.AddParameter("@SummaryLogId", questionnaire.SummaryLogId);
        }

        public void Delete(ShiftHandoverQuestionnaire questionnaire)
        {
            ManagedCommand.Update(questionnaire, AddRemoveParameters, REMOVE);
        }

        private static void AddRemoveParameters(ShiftHandoverQuestionnaire questionnaire, SqlCommand command)
        {
            command.AddParameter("@Id", questionnaire.Id);
        }

        private ShiftHandoverQuestionnaire PopulateInstance(SqlDataReader reader)
        {
            long id  = reader.Get<long>("Id");

            long? assignmentId  = reader.Get<long?>("WorkAssignmentId");
            WorkAssignment assignment = !assignmentId.HasValue
                                                          ? null
                                                          : assignmentDao.QueryById(assignmentId.Value);

            string configurationName  = reader.Get<string>("ShiftHandoverConfigurationName");
            ShiftPattern shift = shiftPatternDao.QueryById(reader.Get<long>("ShiftId"));
            User createUser = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            DateTime createDate  = reader.Get<DateTime>("CreatedDateTime");
            DateTime lastModifiedDate  = reader.Get<DateTime>("LastModifiedDateTime");

            List<FunctionalLocation> flocs = flocDao.QueryByShiftHandoverQuestionnaireId(id);
            List<ShiftHandoverAnswer> answers = answerDao.QueryByQuestionnaireId(id);
            List<long> relevantCokerCardConfigurations = questionnaireCokerCardConfigurationDao.QueryByShiftHandoverQuestionnaireId(id);
            long? logId = reader.Get<long?>("LogId");
            long? summaryLogId = reader.Get<long?>("SummaryLogId");
            bool isFlexible = reader.Get<bool>("IsFlexible");
            DateTime flexiShiftStartDate = reader.Get<DateTime>("FlexiShiftStartDate");
            DateTime flexiShiftEndDate = reader.Get<DateTime>("FlexiShiftEndDate");
            
            ShiftHandoverQuestionnaire shiftHandoverQuestionnaire = new ShiftHandoverQuestionnaire(
                id,
                configurationName,
                shift,
                assignment,
                createUser,
                createDate,
                flocs,
                answers,
                relevantCokerCardConfigurations,flexiShiftStartDate, flexiShiftEndDate,isFlexible) { LastModifiedDate = lastModifiedDate, LogId = logId, SummaryLogId = summaryLogId };

            return shiftHandoverQuestionnaire;
        }
    }
}