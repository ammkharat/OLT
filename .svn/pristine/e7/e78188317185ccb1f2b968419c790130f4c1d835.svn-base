using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogGuidelineDao : AbstractManagedDao, ILogGuidelineDao
    {
        private const string QUERY_BY_DIVISION_ID = "QueryLogGuidelineByDivision";        
        private const string INSERT = "InsertLogGuideline";
        private const string UPDATE = "UpdateLogGuideline";

        private readonly IFunctionalLocationDao functionalLocationDao;

        public LogGuidelineDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public LogGuideline QueryByDivision(FunctionalLocation functionalLocation)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@DivisionId", functionalLocation.IdValue);
            return command.QueryForSingleResult<LogGuideline>(PopulateInstance, QUERY_BY_DIVISION_ID);
        }

        public LogGuideline Insert(LogGuideline logGuideline)
        {
            SqlCommand command = ManagedCommand;

            long id = command.InsertAndReturnId(logGuideline, AddInsertParameters, INSERT);
            logGuideline.Id = id;
            return logGuideline;
        }

        public void Update(LogGuideline guideline)
        {
            SqlCommand command = ManagedCommand;
            command.Update(guideline, AddUpdateParameters, UPDATE);
        }             

        private static void AddInsertParameters(LogGuideline guideline, SqlCommand command)
        {                        
            SetCommonAttributes(guideline, command);
        }
      
        private static void AddUpdateParameters(LogGuideline guideline, SqlCommand command)
        {
            command.AddParameter("@Id", guideline.Id);
            SetCommonAttributes(guideline, command);
        }

        private static void SetCommonAttributes(LogGuideline guideline, SqlCommand command)
        {            
            command.AddParameter("@Text", guideline.Text);
            command.AddParameter("@FunctionalLocationId", guideline.FunctionalLocation.IdValue);
        }

        private LogGuideline PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            string text = reader.Get<string>("Text");

            LogGuideline guideline = new LogGuideline(id, functionalLocation, text);

            return guideline;
        }
    }
}