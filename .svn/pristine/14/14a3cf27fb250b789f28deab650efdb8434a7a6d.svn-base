using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LabAlertDefinitionHistoryDao : AbstractManagedDao, ILabAlertDefinitionHistoryDao
    {
        private const string QUERY_BY_ID = "QueryLabAlertDefinitionHistoriesById";
        private const string INSERT = "InsertLabAlertDefinitionHistory";

        private readonly IUserDao userDao;
        private readonly ITagDao tagDao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        public LabAlertDefinitionHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<LabAlertDefinitionHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<LabAlertDefinitionHistory>(PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(LabAlertDefinitionHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private LabAlertDefinitionHistory PopulateInstance(SqlDataReader reader)
        {
            LabAlertDefinitionHistory definition = new LabAlertDefinitionHistory(
                reader.Get<long>("Id"),
                reader.Get<string>("Name"),
                reader.Get<string>("Description"),
                functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID")),
                tagDao.QueryById(reader.Get<long>("TagID")),
                reader.Get<int>("MinimumNumberOfSamples"),
                reader.Get<string>("LabAlertTagQueryRange"),
                reader.Get<string>("Schedule"),
                reader.Get<bool>("IsActive"),
                LabAlertDefinitionStatus.Get(reader.Get<long>("LabAlertDefinitionStatusID")),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"));

            return definition;
        }

        private static void AddInsertParameters(LabAlertDefinitionHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.IdValue);
            command.AddParameter("@Name", history.Name);
            command.AddParameter("@FunctionalLocationID", history.FunctionalLocation.Id);
            command.AddParameter("@Description", history.Description);
            command.AddParameter("@TagID", history.TagInfo.Id);
            command.AddParameter("@MinimumNumberOfSamples", history.MinimumNumberOfSamples);
            command.AddParameter("@LabAlertTagQueryRange", history.LabAlertTagQueryRange);
            command.AddParameter("@Schedule", history.Schedule);

            command.AddParameter("@IsActive", history.IsActive);
            command.AddParameter("@LabAlertDefinitionStatusID", history.Status.Id);

            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
        }
    }
}