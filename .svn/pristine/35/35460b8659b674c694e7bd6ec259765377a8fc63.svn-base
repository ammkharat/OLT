using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraRichEdit.Import.Html;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class TargetDefinitionDTODao : AbstractManagedDao, ITargetDefinitionDTODao
    {
        private const string QUERY_DTOS_BY_FLOC_ID_STORED_PROCEDURE = "QueryTargetDefinitionDTOsByFLOCIDs";
        private const string QUERY_ASSOCIATED_TARGET_BY_PARENT_ID = "QueryAssociatedTargetDefinitionDTOsByParentId";
        private const string QUERY_BY_ACTION_ITEM_DEFINITION_ID = "QueryTargetDefinitionDTOsByActionItemDefinitionId";
        private static readonly ILog logger = GenericLogManager.GetLogger<TargetDefinitionDTODao>();

        private readonly IPlantHistorianGateway gateway;

        private IScheduleDao scheduleDao;

        public TargetDefinitionDTODao()
            : this(PlantHistorianGateway.Instance)
        {
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
        }

        private TargetDefinitionDTODao(IPlantHistorianGateway gateway)
        {
            this.gateway = gateway;
        }

        public List<TargetDefinitionDTO> QueryByActionItemDefinitionId(long actionItemDefinitionId)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", actionItemDefinitionId);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_ACTION_ITEM_DEFINITION_ID);
        }

        public List<TargetDefinitionDTO> QueryByFunctionalLocations(
            IFlocSet flocSet, DateRange dateRange)
        {
            var commaIDs = flocSet.FunctionalLocations.BuildIdStringFromList();
            var command = ManagedCommand;
            command.AddParameter("@IDs", commaIDs);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);
            return command.QueryForListResult(PopulateInstance, QUERY_DTOS_BY_FLOC_ID_STORED_PROCEDURE);
        }

        public List<TargetDefinitionDTO> QueryAssociatedTargets(long parentTargetId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ParentId", parentTargetId);
            return command.QueryForListResult(PopulateInstance, QUERY_ASSOCIATED_TARGET_BY_PARENT_ID);
        }

        private TargetDefinitionDTO PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("TargetDefinitionId");
            var name = reader.Get<string>("Name");
            var categoryId = reader.Get<long>("TargetCategoryId");
            var description = reader.Get<string>("Description");
            var functionLocationfullHierarchy = reader.Get<string>("FullHierarchy");

            var startDate = reader.Get<DateTime>("StartDateTime").ToDate();
            var startTime = reader.Get<DateTime>("FromTime").ToTime();

            var endDateTime = reader.Get<DateTime?>("EndDateTime");
            var endDate = endDateTime.HasValue ? endDateTime.ToDate() : null;

            var endTime = reader.Get<DateTime?>("ToTime").ToTime();

            var scheduleId = reader.Get<long>("ScheduleId");
            var schedule = scheduleDao.QueryById(scheduleId);
            bool hasEndTime = (schedule != null) ? schedule.HasEndTime : endTime != null;
            string scheduleInformation = schedule.Type.Name;

            var gapUnitValueTagConfiguration = CreateTagConfiguration(reader, "GapUnitValue");
            var targetValueTagConfiguration = CreateTagConfiguration(reader, "Target");

            // TODO: (Troy) The following two methods call out to the PHD to get the Tag Value in a Read situation. This is a performance hit, but required for the grid.
            var gapUnitValue = GetValueBasedOnConfiguration(gapUnitValueTagConfiguration,
                reader.Get<decimal?>("GapUnitValue"));
            var targetValue = ReadTargetValue(targetValueTagConfiguration, reader);

            var statusId = reader.Get<long>("TargetDefinitionStatusID");
            var statusName = TargetDefinitionStatus.Get(statusId).Name;
            var operationalModeId = reader.Get<int>("OperationalModeId");
            var operationalModeName = OperationalMode.GetById(operationalModeId).Name;
            var priority = Priority.GetById(reader.Get<long>("PriorityId"));
            var tagName = reader.Get<string>("TagName");
            var requiresApproval = reader.Get<bool>("RequiresApproval");
            var lastModifiedUserId = reader.Get<long?>("LastModifiedUserId");
            var lastModifiedLastName = reader.Get<string>("LastModifiedLastName");
            var lastModifiedFirstName = reader.Get<string>("LastModifiedFirstName");
            var lastModifiedUserName = reader.Get<string>("LastModifiedUserName");
            var lastModifiedByFullNameWithUserName = User.ToFullNameWithUserName(lastModifiedLastName,
                lastModifiedFirstName, lastModifiedUserName);
            var isActive = reader.Get<bool>("IsActive");

            var neverToExceedMin = reader.Get<decimal?>("NeverToExceedMin");
            var minValue = reader.Get<decimal?>("MinValue");
            var maxValue = reader.Get<decimal?>("MaxValue");
            var neverToExceedMax = reader.Get<decimal?>("NeverToExceedMax");

            var workAssignmentName = reader.Get<string>("WorkAssignmentName");

            var result = new TargetDefinitionDTO(id,
                name,
                categoryId,
                description,
                scheduleInformation,
                functionLocationfullHierarchy,
                startDate,
                endDate,
                startTime,
                endTime,
                hasEndTime,
                statusId,
                statusName,
                priority,
                operationalModeName,
                tagName,
                requiresApproval,
                lastModifiedUserId,
                lastModifiedByFullNameWithUserName,
                isActive,
                targetValue,
                gapUnitValue,
                neverToExceedMin,
                minValue,
                maxValue,
                neverToExceedMax,
                workAssignmentName);
            return result;
        }

        private static ReadWriteTagConfiguration CreateTagConfiguration(SqlDataReader reader, string columnPrefix)
        {
            var tagId = reader.Get<long?>(columnPrefix + "TagId");

            if (tagId.HasNoValue())
                return ReadWriteTagConfiguration.CreateEmpty();

            var tagDirection = TagDirection.Get(reader.Get<long>(columnPrefix + "TagDirection"));
            var tagName = reader.Get<string>(columnPrefix + "TagName");
            var tagDescription = reader.Get<string>(columnPrefix + "TagDescription");
            var tagUnits = reader.Get<string>(columnPrefix + "TagUnits");
            var tagSiteId = reader.Get<long>(columnPrefix + "TagSiteId");
            var tagScadaConnectionInfoId = reader.Get<long>(columnPrefix + "TagScadaConnectionInfoId");
            var deleted = reader.Get<bool>(columnPrefix + "TagDeleted");
            var tagInfo = new TagInfo(tagId, tagSiteId, tagName, tagDescription,tagUnits, deleted,tagScadaConnectionInfoId);
            return new ReadWriteTagConfiguration(tagDirection, tagInfo);
        }

        private decimal? GetValueBasedOnConfiguration(ReadWriteTagConfiguration configuration, decimal? dbValue)
        {
            if (configuration.IsReadDirection())
            {
                try
                {
                    return gateway.ReadTagValue(PlantHistorianOrigin.TargetDefinitionDTODao_GetTagValue,
                        configuration.Tag);
                }
                catch (InvalidPlantHistorianReadException ex)
                {
                    logger.InfoFormat("Exception trying to read tag. Inner Exception: {0}. Returning null for value.",
                        ex);
                    return null;
                }
            }
            return dbValue;
        }

        private TargetValue ReadTargetValue(ReadWriteTagConfiguration targetValueConfiguration, SqlDataReader reader)
        {
            if (targetValueConfiguration.IsReadDirection())
            {
                return GetTargetValueFromReadWriteConfiguration(targetValueConfiguration);
            }
            var targetValueTypeId = reader.Get<long>("TargetValueTypeId");
            var target = reader.Get<decimal?>("TargetDefinitionValue");
            return TargetValueType.ToTargetValue(targetValueTypeId, target);
        }

        private TargetValue GetTargetValueFromReadWriteConfiguration(ReadWriteTagConfiguration targetValueConfiguration)
        {
            decimal? targetValue;
            try
            {
                targetValue = gateway.ReadTagValue(PlantHistorianOrigin.TargetDefinitionDTODao_GetTagValue,
                    targetValueConfiguration.Tag);
            }
            catch (InvalidPlantHistorianReadException ex)
            {
                logger.InfoFormat("Exception trying to read tag. Inner Exception: {0}. Returning null for value.", ex);
                targetValue = null;
            }

            return (targetValue.HasValue)
                ? TargetValue.CreateSpecifiedTarget(targetValue.Value)
                : TargetValue.CreateEmptyTarget();
        }
    }
}