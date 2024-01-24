using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{    
    public class LogTemplateWorkAssignmentDao : AbstractManagedDao, ILogTemplateWorkAssignmentDao
    {
        private readonly IWorkAssignmentDao workAssignmentDao;

        private const string DELETE_BY_LOG_TEMPLATE_ID_STORED_PROCEDURE = "DeleteLogTemplateWorkAssignmentByLogTemplateId";
        private const string INSERT_STORED_PROCEDURE = "InsertLogTemplateWorkAssignment";
        private const string QUERY_BY_LOG_TEMPLATE_ID = "QueryLogTemplateWorkAssignmentByLogTemplateId";

        public LogTemplateWorkAssignmentDao()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public LogTemplateWorkAssignment Insert(LogTemplateWorkAssignment logTemplateWorkAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(logTemplateWorkAssignment, AddInsertParameters, INSERT_STORED_PROCEDURE);
            return logTemplateWorkAssignment;
        }

        private void AddInsertParameters(LogTemplateWorkAssignment logTemplate, SqlCommand command)
        {
            command.AddParameter("@LogTemplateId",  logTemplate.LogTemplateId);
            command.AddParameter("@WorkAssignmentId",  logTemplate.WorkAssignment.IdValue);
        }

        public List<LogTemplateWorkAssignment> QueryByLogTemplateId(long logTemplateId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogTemplateId",  logTemplateId);
            return command.QueryForListResult<LogTemplateWorkAssignment>(PopulateInstance, QUERY_BY_LOG_TEMPLATE_ID);
        }

        public void DeleteByLogTemplateId(long? logTemplateId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogTemplateId",  logTemplateId);
            command.ExecuteNonQuery(DELETE_BY_LOG_TEMPLATE_ID_STORED_PROCEDURE);
        }

        private LogTemplateWorkAssignment PopulateInstance(SqlDataReader reader)
        {
            long workAssignmentId = reader.Get<long>("WorkAssignmentId");
            WorkAssignment workAssignment = workAssignmentDao.QueryByIdWithoutCache(workAssignmentId);

            long logTemplateId = reader.Get<long>("LogTemplateId");

            return new LogTemplateWorkAssignment(logTemplateId, workAssignment);
        }
    }
}