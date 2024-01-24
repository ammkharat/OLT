using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverConfigurationDao : AbstractManagedDao, IShiftHandoverConfigurationDao
    {
        private const string QUERY_BY_WORK_ASSIGNMENT = "QueryShiftHandoverConfigurationByWorkAssignment";
        private const string QUERY_BY_ID = "QueryShiftHandoverConfigurationById";        
        private const string INSERT = "InsertShiftHandoverConfiguration";
        private const string UPDATE = "UpdateShiftHandoverConfiguration";
        private const string DELETE = "RemoveShiftHandoverConfiguration";

        private readonly IShiftHandoverConfigurationWorkAssignmentDao configurationWorkAssignmentDao;
        private readonly IShiftHandoverQuestionDao questionDao;

        public ShiftHandoverConfigurationDao()
        {
            configurationWorkAssignmentDao = DaoRegistry.GetDao<IShiftHandoverConfigurationWorkAssignmentDao>();
            questionDao = DaoRegistry.GetDao<IShiftHandoverQuestionDao>();
        }

        public ShiftHandoverConfiguration QueryById(long id)
        {
            SqlCommand command = ManagedCommand;         
            return command.QueryById(id, (PopulateInstance<ShiftHandoverConfiguration>) PopulateInstance, QUERY_BY_ID);
        } 

        public List<ShiftHandoverConfiguration> QueryByWorkAssignment(long workAssignmentId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId",  workAssignmentId);
            return command.QueryForListResult<ShiftHandoverConfiguration>(PopulateInstance , QUERY_BY_WORK_ASSIGNMENT);
        }

        public ShiftHandoverConfiguration Insert(ShiftHandoverConfiguration configuration)
        {
            SqlCommand command = ManagedCommand;
           
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(configuration, AddInsertParameters, INSERT);
            configuration.Id = (long?)idParameter.Value;

            InsertQuestions(configuration.Id.Value, configuration.Questions);
            InsertWorkAssignments(configuration);

            return configuration;
        }

        public void Update(ShiftHandoverConfiguration shiftHandoverConfiguration, List<ShiftHandoverQuestion> deletedQuestions)
        {
            SqlCommand command = ManagedCommand;

            UpdateQuestions(shiftHandoverConfiguration, deletedQuestions);

            configurationWorkAssignmentDao.DeleteByShiftHandoverConfigurationId(shiftHandoverConfiguration.IdValue);
            InsertWorkAssignments(shiftHandoverConfiguration);

            command.Update(shiftHandoverConfiguration, AddUpdateParameters, UPDATE);
        }

        private void UpdateQuestions(ShiftHandoverConfiguration shiftHandoverConfiguration, IEnumerable<ShiftHandoverQuestion> deletedQuestions)
        {
            foreach (ShiftHandoverQuestion question in deletedQuestions)
            {
                questionDao.Delete(question);
            }

            List<ShiftHandoverQuestion> newQuestions = 
                shiftHandoverConfiguration.Questions.FindAll(obj => !obj.IsInDatabase());

            List<ShiftHandoverQuestion> possiblyChangedQuestions =
                shiftHandoverConfiguration.Questions.FindAll(obj => obj.IsInDatabase());

            foreach (ShiftHandoverQuestion question in possiblyChangedQuestions)
            {
                if (HasChangedFromDBVersion(question))
                {
                    // Set existing one as not the current version
                    UpdateQuestionAsOlderVersion(question);
                    // Add new version as a new question, and as the current one.
                    newQuestions.Add(question);
                }
            }

            InsertQuestions(shiftHandoverConfiguration.IdValue, newQuestions);            
        }

        private void UpdateQuestionAsOlderVersion(ShiftHandoverQuestion question)
        {
            questionDao.UpdateAsOlderVersion(question);            
        }

        private bool HasChangedFromDBVersion(ShiftHandoverQuestion question)
        {
            ShiftHandoverQuestion dbVersionOfQuestion = questionDao.QueryById(question.IdValue);
            return question.DoesNotEqual(dbVersionOfQuestion);
        }

        public void Delete(long configurationId)
        {
            SqlCommand command = ManagedCommand;

            command.Parameters.Clear();
            AddDeleteParameters(configurationId, command);
            command.ExecuteNonQuery(DELETE);            
        }      

        private void InsertWorkAssignments(ShiftHandoverConfiguration configuration)
        {
            foreach (WorkAssignment assignment in configuration.WorkAssignments)
            {
                ShiftHandoverConfigurationWorkAssignment configurationWorkAssignment =
                    new ShiftHandoverConfigurationWorkAssignment(configuration.Id.Value, assignment);
                configurationWorkAssignmentDao.Insert(configurationWorkAssignment);
            }
        }

        private void InsertQuestions(long configurationId, List<ShiftHandoverQuestion> questions)
        {
            foreach (ShiftHandoverQuestion question in questions)
            {
                question.ConfigurationId = configurationId;
                questionDao.Insert(question);
            }
        }

        private static void AddInsertParameters(ShiftHandoverConfiguration configuration, SqlCommand command)
        {
            SetCommonAttributes(configuration, command);
        }

        private static void AddDeleteParameters(long id, SqlCommand command)
        {
            command.AddParameter("@Id", id);
        }

        private static void AddUpdateParameters(ShiftHandoverConfiguration configuration, SqlCommand command)
        {
            command.AddParameter("@Id", configuration.Id);
            SetCommonAttributes(configuration, command);
        }

        private static void SetCommonAttributes(ShiftHandoverConfiguration configuration, SqlCommand command)
        {           
            command.AddParameter("@Name", configuration.Name);
        }

        private ShiftHandoverConfiguration PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            List<ShiftHandoverConfigurationWorkAssignment> configurationWorkAssignments = 
                    configurationWorkAssignmentDao.QueryByShiftHandoverConfigurationId(id);

            string name = reader.Get<string>("Name");
            List<ShiftHandoverQuestion> questions = questionDao.QueryByConfigurationId(id);

            List<WorkAssignment> assignments = configurationWorkAssignments.ConvertAll(obj => obj.WorkAssignment);

            ShiftHandoverConfiguration configuration = new ShiftHandoverConfiguration(id, assignments, name, questions);
            return configuration;
        }
    }
}

