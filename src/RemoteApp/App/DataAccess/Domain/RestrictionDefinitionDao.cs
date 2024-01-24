using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RestrictionDefinitionDao : AbstractManagedDao, IRestrictionDefinitionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryRestrictionDefinitionByID";
        private const string QUERY_BY_NAME_STORED_PROCEDURE = "QueryRestrictionDefinitionsByName";
        private const string QUERY_WITH_INVALID_TAG_STORED_PROCEDURE = "QueryRestrictionDefinitionsWithInvalidTag";
        private const string QUERY_WITH_VALID_TAG_STORED_PROCEDURE = "QueryRestrictionDefinitionsWithValidTag";
        private const string QUERY_FOR_SCHEDULING = "QueryRestrictionDefinitionsForScheduling";

        private const string INSERT_STORED_PROCEDURE = "InsertRestrictionDefinition";
        private const string UPDATE_STORED_PROCEDURE = "UpdateRestrictionDefinition";
        private const string UPDATE_LAST_INVOKED_DATE_TIME_STORED_PROCEDURE = "UpdateRestrictionDefinitionLastInvokedDateTime";                
        private const string REMOVE_STORED_PROCEDURE = "RemoveRestrictionDefinition";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ITagDao tagDao;
        private readonly IUserDao userDao;

        public RestrictionDefinitionDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public RestrictionDefinition QueryById(long id)
        {
            return ManagedCommand.QueryById<RestrictionDefinition>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<RestrictionDefinition> QueryByName(long siteId, string name)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            command.AddParameter("@Name", name);
            return command.QueryForListResult<RestrictionDefinition>(PopulateInstance, QUERY_BY_NAME_STORED_PROCEDURE);                        
        }

        public List<RestrictionDefinition> QueryRestrictionDefinitionsWithInvalidTag(TagInfo tag)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TagId",  tag.Id.Value);
            return command.QueryForListResult<RestrictionDefinition>(PopulateInstance, QUERY_WITH_INVALID_TAG_STORED_PROCEDURE);
        }

        public List<RestrictionDefinition> QueryRestrictionDefinitionsWithValidTag(TagInfo tag)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TagId",  tag.Id.Value);
            return command.QueryForListResult<RestrictionDefinition>(PopulateInstance, QUERY_WITH_VALID_TAG_STORED_PROCEDURE);
        }

        public SchedulingList<RestrictionDefinition, OLTException> QueryAllAvailableForScheduling()
        {
            List<OLTException> exceptions = new List<OLTException>();

            List<RestrictionDefinition> definitions = ManagedCommand.QueryForListResult<RestrictionDefinition>(PopulateInstance , QUERY_FOR_SCHEDULING, exceptions.Add);

            return new SchedulingList<RestrictionDefinition, OLTException>(definitions, exceptions);
        }

        public RestrictionDefinition Insert(RestrictionDefinition definition)
        {
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(definition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            definition.Id = id;
            return definition;
        }

        private static void AddInsertParameters(RestrictionDefinition definition, SqlCommand command)
        {
            command.AddParameter("@CreatedDate", definition.CreatedDate);
            SetInsertUpdateAttributes(definition, command);
        }

        public void Update(RestrictionDefinition definition)
        {
            SqlCommand command = ManagedCommand;
            command.Update(definition, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private static void AddUpdateParameters(RestrictionDefinition definition, SqlCommand command)
        {
            command.AddParameter("@id", definition.Id);
            SetInsertUpdateAttributes(definition, command);
        }

        public void UpdateLastInvokedDateTime(RestrictionDefinition definition)
        {
            SqlCommand command = ManagedCommand;
            command.Update(definition, AddUpdateLastInvokedDateTimeParameters, UPDATE_LAST_INVOKED_DATE_TIME_STORED_PROCEDURE);            
        }
              
        private static void AddUpdateLastInvokedDateTimeParameters(RestrictionDefinition definition, SqlCommand command)
        {
            command.AddParameter("@id", definition.Id);
            command.AddParameter("@LastInvokedDateTime", definition.LastInvokedDateTime);
        }
       
        private static void AddUpdateAfterUnableToAccessTagParameters(RestrictionDefinition definition, SqlCommand command)
        {
            command.AddParameter("@id", definition.Id);
            command.AddParameter("@IsActive", definition.IsActive);
            command.AddParameter("@Description", definition.Description);
            command.AddParameter("@LastModifiedUserId", definition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", definition.LastModifiedDateTime);
        }

        public void Remove(RestrictionDefinition definition)
        {
            ManagedCommand.ExecuteNonQuery(definition, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        private static void AddRemoveParameters(RestrictionDefinition definition, SqlCommand command)
        {
            command.AddParameter("@Id", definition.Id);
            command.AddParameter("@LastModifiedUserId", definition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", definition.LastModifiedDateTime);
        }

        private RestrictionDefinition PopulateInstance(SqlDataReader reader)
        {
            RestrictionDefinition definition = new RestrictionDefinition
            {
                Id = reader.Get<long?>("Id"),
                Name = reader.Get<string>("Name"),
                FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID")),
                Description = reader.Get<string>("Description"),
                MeasurementTagInfo = tagDao.QueryById(reader.Get<long>("MeasurementTagID")),
                ProductionTargetValue = reader.Get<int?>("ProductionTargetValue"),
                Status = RestrictionDefinitionStatus.Get(reader.Get<long>("RestrictionDefinitionStatusID")),
                IsActive = reader.Get<bool>("IsActive"),
                IsOnlyVisibleOnReports = reader.Get<bool>("IsOnlyVisibleOnReports"),
                LastInvokedDateTime = reader.Get<DateTime?>("LastInvokedDateTime"),
                CreatedDate = reader.Get<DateTime>("CreatedDateTime"),
                LastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime"),
                LastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId")),
                Deleted = reader.Get<bool>("Deleted")
            };

            long? productionTargetTagId = reader.Get<long?>("ProductionTargetTagID");
            if (productionTargetTagId.HasValue)
            {
                definition.ProductionTargetTagInfo = tagDao.QueryById(productionTargetTagId.Value);
            }
            //Added by Mukesh for RITM0219490
            definition.ToleranceValue = reader.Get<int?>("ToleranceValue");

            
            definition.HourFrequency = Convert.ToString(reader.Get<long>("HourFrequency")); //DMND0010124 mangesh

            return definition;
        }

        private static void SetInsertUpdateAttributes(RestrictionDefinition definition, SqlCommand command)
        {
            command.AddParameter("@Name", definition.Name);
            command.AddParameter("@FunctionalLocationID", definition.FunctionalLocation.Id);
            command.AddParameter("@Description", definition.Description);

            command.AddParameter("@MeasurementTagID", definition.MeasurementTagInfo.Id);
            command.AddParameter("@ProductionTargetValue", definition.ProductionTargetValue);

            command.AddParameter("@ProductionTargetTagID", definition.ProductionTargetTagInfo != null ? definition.ProductionTargetTagInfo.Id : null);

            command.AddParameter("@RestrictionDefinitionStatusID", definition.Status.Id);
            command.AddParameter("@IsActive", definition.IsActive);
            command.AddParameter("@IsOnlyVisibleOnReports", definition.IsOnlyVisibleOnReports);

            command.AddParameter("@UpdatedUserId", definition.LastModifiedBy.Id);
            command.AddParameter("@UpdatedDate", definition.LastModifiedDateTime);
            //Added by Mukesh for RITM0219490
            command.AddParameter("@ToleranceValue", definition.ToleranceValue);

            command.AddParameter("@HourFrequency", definition.HourFrequency);// DMND0010124 mangesh
        }
    }
}