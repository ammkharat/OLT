using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class LogTemplateDTODao : AbstractManagedDao, ILogTemplateDTODao
    {
        private const string QUERY_BY_WORK_ASSIGNMENT_ID_STORED_PROCEDURE = "QueryLogTemplateByWorkAssignment";

        public List<LogTemplateDTO> QueryByWorkAssignmentId(long workAssignmentId, LogTemplate.LogType logType)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkAssignmentId", workAssignmentId);
            command.AddParameter("@AppliesToLogs", (logType == LogTemplate.LogType.Standard));
            command.AddParameter("@AppliesToSummaryLogs", (logType == LogTemplate.LogType.SummaryLog));
            command.AddParameter("@AppliesToDirectives", (logType == LogTemplate.LogType.DailyDirective));
            return command.QueryForListResult<LogTemplateDTO>(PopulateInstance, QUERY_BY_WORK_ASSIGNMENT_ID_STORED_PROCEDURE);            
        }

        private LogTemplateDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            return new LogTemplateDTO(id, name);
        }
    }
}