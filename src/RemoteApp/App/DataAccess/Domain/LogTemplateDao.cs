using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogTemplateDao : AbstractManagedDao, ILogTemplateDao
    {
        private const string INSERT_STORED_PROCEDURE = "InsertLogTemplate";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryLogTemplateById";
        private const string UPDATE_STORED_PROCEDURE = "UpdateLogTemplate";        
        private const string QUERY_BY_SITE_ID_STORED_PROCEDURE = "QueryLogTemplateBySiteId";
        private const string DELETE_STORED_PROCEDURE = "DeleteLogTemplate";
        private const string QUERY_ONES_SET_AS_AUTOINSERT_FOR_GIVEN_ASSIGNMENTS_STORED_PROCEDURE = "QueryLogTemplatesSetAsAutoInsertForGivenAssignments";

        private readonly ILogTemplateWorkAssignmentDao logTemplateWorkAssignmentDao;
        private readonly IUserDao userDao;

        public LogTemplateDao()
        {
            logTemplateWorkAssignmentDao = DaoRegistry.GetDao<ILogTemplateWorkAssignmentDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public LogTemplate Insert(LogTemplate logTemplate)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(logTemplate, AddInsertParameters, INSERT_STORED_PROCEDURE);
            logTemplate.Id = long.Parse(idParameter.Value.ToString());
            InsertWorkAssignments(logTemplate);
            return logTemplate;
        }

        private void InsertWorkAssignments(LogTemplate logTemplate)
        {
            foreach (WorkAssignment workAssignment in logTemplate.WorkAssignments)
            {
                logTemplateWorkAssignmentDao.Insert(new LogTemplateWorkAssignment(logTemplate.Id.Value, workAssignment));
            }
        }

        public LogTemplate QueryById(long id)
        {
            return ManagedCommand.QueryById<LogTemplate>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);                                                             
        }

        public List<LogTemplate> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            return command.QueryForListResult<LogTemplate>(PopulateInstance, QUERY_BY_SITE_ID_STORED_PROCEDURE);
        }

        public void Update(LogTemplate logTemplate)
        {
            SqlCommand command = ManagedCommand;
            command.Update(logTemplate, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            logTemplateWorkAssignmentDao.DeleteByLogTemplateId(logTemplate.Id);
            InsertWorkAssignments(logTemplate);
            RemoveLogTemplateAsAutoInsertChoiceFromAssignmentsNotConnectedtoTheTemplate(command, logTemplate);
        }

        private void RemoveLogTemplateAsAutoInsertChoiceFromAssignmentsNotConnectedtoTheTemplate(SqlCommand command, LogTemplate logTemplate)
        {
            command.ClearParameters();
            command.AddParameter("@LogTemplateId", logTemplate.IdValue);
            command.ExecuteNonQuery("RemoveLogTemplateAsAutoInsertChoiceFromWorkAssignmentsThatAreNotConnectedToTheTemplate");
        }

        public void Delete(LogTemplate logTemplate)
        {
            SqlCommand command = ManagedCommand;
            logTemplateWorkAssignmentDao.DeleteByLogTemplateId(logTemplate.Id);
            command.AddParameter("@Id",  logTemplate.Id);
            command.ExecuteNonQuery(DELETE_STORED_PROCEDURE);
        }

        public List<LogTemplate> QueryLogTemplatesSetAsAutoInsertForTheseAssignments(List<WorkAssignment> workAssignments)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvWorkAssignmentIds", workAssignments.BuildIdStringFromList());
            return command.QueryForListResult<LogTemplate>(PopulateInstance, QUERY_ONES_SET_AS_AUTOINSERT_FOR_GIVEN_ASSIGNMENTS_STORED_PROCEDURE);

        }

        private static void AddInsertParameters(LogTemplate logTemplate, SqlCommand command)
        {
            command.AddParameter("@CreatedUserId", logTemplate.CreatedBy.Id);
            command.AddParameter("@CreatedDateTime", logTemplate.CreatedDateTime);

            SetCommonParameters(command, logTemplate);
        }

        private static void AddUpdateParameters(LogTemplate logTemplate, SqlCommand command)
        {
            command.AddParameter("@Id", logTemplate.Id);
            SetCommonParameters(command, logTemplate);
        }

        private static void SetCommonParameters(SqlCommand command, LogTemplate logTemplate)
        {
            command.AddParameter("@Name", logTemplate.Name);
            command.AddParameter("@Text", logTemplate.Text);

            command.AddParameter("@AppliesToLogs", logTemplate.AppliesToLogs);
            command.AddParameter("@AppliesToSummaryLogs", logTemplate.AppliesToSummaryLogs);
            command.AddParameter("@AppliesToDirectives", logTemplate.AppliesToDirectives);

            command.AddParameter("@LastModifiedUserId", logTemplate.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", logTemplate.LastModifiedDateTime);
        }

        private LogTemplate PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            string text = reader.Get<string>("Text");

            bool appliesToLogs = reader.Get<bool>("AppliesToLogs");
            bool appliesToSummaryLogs = reader.Get<bool>("AppliesToSummaryLogs");
            bool appliesToDirectives = reader.Get<bool>("AppliesToDirectives");

            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            User createUser = userDao.QueryById(reader.Get<long>("CreatedUserId"));
            DateTime createDateTime = reader.Get<DateTime>("CreatedDateTime");

            List<LogTemplateWorkAssignment> logTemplateWorkAssignments = logTemplateWorkAssignmentDao.QueryByLogTemplateId(id);
            List<WorkAssignment> workAssignments = logTemplateWorkAssignments.ConvertAll(i => i.WorkAssignment);

            return new LogTemplate(name, text, workAssignments, appliesToLogs, appliesToSummaryLogs, appliesToDirectives, lastModifiedUser, 
                lastModifiedDateTime, createUser, createDateTime) { Id = id };
        }
    }
}