using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ProcedureDeviationCauseDeterminationDao : AbstractManagedDao, IProcedureDeviationCauseDeterminationDao
    {
        private const string QUERY_BY_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE =
            "QueryProcedureDeviationCauseDeterminationByProcedureDeviationId";

        private readonly IUserDao userDao;

        public ProcedureDeviationCauseDeterminationDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<CauseDeterminationWhyType> QueryByProcedureDeviationId(long procedureDeviationId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ProcedureDeviationId", procedureDeviationId);
            var comments =
                command.QueryForListResult(PopulateInstance, QUERY_BY_PROCEDURE_DEVIATION_ID_STORED_PROCEDURE);
            return comments;
        }

        private CauseDeterminationWhyType PopulateInstance(SqlDataReader reader)
        {
            var causeDeterminationTypeId = reader.Get<int>("CauseDeterminationTypeId");

            return CauseDeterminationWhyType.GetById(causeDeterminationTypeId);
        }
    }
}