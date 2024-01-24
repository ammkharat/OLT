using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DeviationAlertResponseHistoryDao : AbstractManagedDao, IDeviationAlertResponseHistoryDao
    {
        private const string QUERY_BY_ID = "QueryDeviationAlertResponseHistoriesById";
        private const string INSERT = "InsertDeviationAlertResponseHistory";

        private readonly IUserDao userDao;

        public DeviationAlertResponseHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<DeviationAlertResponseHistory> GetById(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(DeviationAlertResponseHistory targetDefinitionHistory)
        {
            var command = ManagedCommand;
            command.Insert(targetDefinitionHistory, AddInsertParameters, INSERT);
        }

        private DeviationAlertResponseHistory PopulateInstance(SqlDataReader reader)
        {
            var definition = new DeviationAlertResponseHistory(
                reader.Get<long>("Id"),
                reader.Get<string>("ReasonCodes"),
                reader.Get<string>("Comments"),
                userDao.QueryById(reader.Get<long>("LastModifiedUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"));

            return definition;
        }

        private static void AddInsertParameters(DeviationAlertResponseHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@ReasonCodes", history.ReasonCodes);
            command.AddParameter("@UpdatedUserId", history.LastModifiedBy.Id);
            command.AddParameter("@UpdatedDate", history.LastModifiedDate);
            command.AddParameter("@Comments", history.Comments);
        }
    }
}