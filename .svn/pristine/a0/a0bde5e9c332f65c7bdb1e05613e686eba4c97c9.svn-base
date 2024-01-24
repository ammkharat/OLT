using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RestrictionDefinitionHistoryDao : AbstractManagedDao, IRestrictionDefinitionHistoryDao
    {
        private const string QUERY_BY_ID = "QueryRestrictionDefinitionHistoriesById";
        private const string INSERT = "InsertRestrictionDefinitionHistory";

        private readonly IUserDao userDao;
        private readonly ITagDao tagDao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        public RestrictionDefinitionHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<RestrictionDefinitionHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<RestrictionDefinitionHistory>(PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(RestrictionDefinitionHistory targetDefinitionHistory)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(targetDefinitionHistory, AddInsertParameters, INSERT);
        }

        private RestrictionDefinitionHistory PopulateInstance(SqlDataReader reader)
        {
            long? productionTargetTagId = reader.Get<long?>("ProductionTargetTagID");
            TagInfo tagInfo = null;
            if (productionTargetTagId.HasValue)
            {
                tagInfo = tagDao.QueryById(productionTargetTagId.Value);
            }

            RestrictionDefinitionHistory definition = new RestrictionDefinitionHistory(
                reader.Get<long>("Id"),
                reader.Get<string>("Name"),
                reader.Get<string>("Description"),
                functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID")),
                tagDao.QueryById(reader.Get<long>("MeasurementTagID")),
                reader.Get<int?>("ProductionTargetValue"),
                tagInfo,
                reader.Get<bool>("IsActive"),
                reader.Get<bool>("IsOnlyVisibleOnReports"),
                RestrictionDefinitionStatus.Get(reader.Get<long>("RestrictionDefinitionStatusID")),
                userDao.QueryById(reader.Get<long>("LastModifiedUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"));

            //Added by Mukesh for RITM0219490
            definition.ToleranceValue = reader.Get<int?>("ToleranceValue");

            definition.HourFrequency = Convert.ToString(reader.Get<long>("HourFrequency")); //DMND0010124 mangesh

            return definition;
        }

        private static void AddInsertParameters(RestrictionDefinitionHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.IdValue);
            command.AddParameter("@Name", history.Name);
            command.AddParameter("@FunctionalLocationID", history.FunctionalLocation.Id);
            command.AddParameter("@Description", history.Description);

            command.AddParameter("@MeasurementTagID", history.MeasurementTagInfo.Id);
            command.AddParameter("@ProductionTargetValue", history.ProductionTargetValue);
            command.AddParameter("@ProductionTargetTagID", history.ProductionTargetTagInfo != null ? history.ProductionTargetTagInfo.Id : null);

            command.AddParameter("@RestrictionDefinitionStatusID", history.Status.Id);
            command.AddParameter("@IsActive", history.IsActive);
            command.AddParameter("@IsOnlyVisibleOnReports", history.IsOnlyVisibleOnReports);

            command.AddParameter("@UpdatedUserId", history.LastModifiedBy.Id);
            command.AddParameter("@UpdatedDate", history.LastModifiedDate);

            command.AddParameter("@ToleranceValue", history.ToleranceValue);

            command.AddParameter("@HourFrequency", history.HourFrequency);// DMND0010124 mangesh
        }
    }
}