using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.PlantHistorian;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetDefinitionDao : AbstractManagedDao, ITargetDefinitionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryTargetDefinitionById";
        private const string INSERT_STORED_PROCEDURE = "InsertTargetDefinition";
        private const string REMOVE_STORED_PROCEDURE = "RemoveTargetDefinition";
        private const string UPDATE_STORED_PROCEDURE = "UpdateTargetDefinition";

        private const string UPDATE_AFTER_UNABLE_TO_ACCESS_TAGS = "UpdateTargetDefinitionAfterUnableToAccessTag";

        private const string INSERT_ASSOCIATED_TARGET_RELATIONSHIP = "InsertTargetDefinitionChildAssociation";
        private const string DELETE_ASSOCIATED_TARGET_RELATIONSHIP = "RemoveTargetDefinitionChildAssociation";
        private const string QUERY_ASSOCIATED_TARGETS = "QueryAssociatedTargetDefinitions";
        private const string QUERY_TARGET_BY_SCHEDULE_ID = "QueryTargetDefinitionByScheduleId";
        private const string QUERY_TARGETS_BY_SCHEDULE_IDS = "QueryTargetDefinitionsByScheduleIds";
        private const string QUERY_FOR_SCHEDULING = "QueryTargetDefinitionsForScheduling";
        private const string QUERY_ACTIVE_TARGETS = "QueryActiveTargetDefinitions";
        private const string QUERY_BY_NAME = "QueryTargetDefinitionsByName";
        private const string QUERY_LINKED_ACTION_ITEM_DEFINITION_COUNT = "QueryLinkedActionItemDefinitionCount";
        private const string COUNT_TARGET_DEFINITIONS_BY_NAME = "CountTargetDefinitionsByName";
        private const string QUERY_PARENT_TARGETS = "QueryParentTargetDefinitionsByChildTargetDefinitionId";

        private const string QUERY_TARGET_DEFINITIONS_ALREADY_WRITING_TO_TAG =
            "QueryTargetDefinitionsAlreadyWritingToTag";

        private const string QUERY_TARGET_DEFINITIONS_WITH_INVALID_TAG = "QueryTargetDefinitionsWithInvalidTag";
        private const string QUERY_TARGET_DEFINITIONS_WITH_VALID_TAG = "QueryTargetDefinitionsWithValidTag";
        private const string UPDATE_TARGET_DEFINITION_STATUS = "UpdateTargetDefinitionStatus";
        private readonly IWorkAssignmentDao assignmentDao;

        private readonly ICommentDao commentDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IPlantHistorianGateway gateway;
        private readonly IScheduleDao scheduleDao;
        private readonly ITagDao tagDao;
        private readonly ITargetDefinitionReadWriteTagConfigurationDao targetDefinitionReadWriteTagConfigurationDao;
        private readonly ITargetDefinitionDTODao targetDtoDao;
        private readonly IUserDao userDao;

        public TargetDefinitionDao() :
            this(PlantHistorianGateway.Instance)
        {
        }

        public TargetDefinitionDao(IPlantHistorianGateway gateway)
        {
            this.gateway = gateway;
            targetDtoDao = DaoRegistry.GetDao<ITargetDefinitionDTODao>();
            targetDefinitionReadWriteTagConfigurationDao =
                DaoRegistry.GetDao<ITargetDefinitionReadWriteTagConfigurationDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            commentDao = DaoRegistry.GetDao<ICommentDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            assignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public int GetCount(string name, long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@Name", name);
            command.AddParameter("@SiteId", siteId);
            return command.GetCount(COUNT_TARGET_DEFINITIONS_BY_NAME);
        }

        public List<TargetDefinition> QueryByName(long siteId, string name)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@Name", name);
            return command.QueryForListResult(PopulateInstance, QUERY_BY_NAME);
        }

        public List<TargetDefinition> QueryActiveByName(long siteId, string name)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@Name", name);
            return command.QueryForListResult(PopulateInstance, QUERY_ACTIVE_TARGETS);
        }

        public SchedulingList<TargetDefinition, OLTException> QueryAllAvailableForScheduling(List<long> siteIds)
        {
            var exceptions = new List<OLTException>();

            Action<OLTException> exceptionAction = exceptions.Add;

            var command = ManagedCommand;
            var csvSiteIdList = siteIds.BuildCommaSeparatedList(Convert.ToString);
            command.AddParameter("@CsvSiteIds", csvSiteIdList);

            var targetDefinitions =
                command.QueryForListResult(PopulateWithoutEvaluatingTagsForAvailableForScheduling, QUERY_FOR_SCHEDULING,
                    exceptionAction);

            return new SchedulingList<TargetDefinition, OLTException>(targetDefinitions, exceptions);
        }

        public TargetDefinition QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Remove(TargetDefinition targetDefinition)
        {
            if (targetDefinition.AssociatedTargetDTOs.Count > 0)
            {
                DeleteDependentTargetDefinitions(ManagedCommand, targetDefinition);
            }
            ManagedCommand.ExecuteNonQuery(targetDefinition, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public TargetDefinition Insert(TargetDefinition targetDefinition)
        {
            var command = ManagedCommand;
            InsertSchedule(targetDefinition);
            var idParameter = command.AddIdOutputParameter();
            command.Insert(targetDefinition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            targetDefinition.Id = (long?) idParameter.Value;
            InsertReadWriteTagConfiguration(targetDefinition);
            InsertDependentTargetDefinitions(command, targetDefinition);
            InsertNewComments(targetDefinition);
            CheckTagValueConfigurations(targetDefinition,
                PlantHistorianOrigin.TargetDefinitionDao_PopulateInstance_CheckTagValue_Insert);
            InsertNewDocumentLinks(targetDefinition);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(targetDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return targetDefinition;
        }

        public void Update(TargetDefinition targetDefinition)
        {
            var command = ManagedCommand;
            command.Update(targetDefinition, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            // Queries normally query TargetDefinition first, before joining.  We want to modify data in the
            // same order and do all these updates below after the update to target definition above.  This
            // reduces the chance of deadlocks.
            UpdateSchedule(targetDefinition);
            UpdateReadWriteTagConfiguration(targetDefinition);
            UpdateTargetAssociations(command, targetDefinition);
            InsertNewComments(targetDefinition);
            CheckTagValueConfigurations(targetDefinition,
                PlantHistorianOrigin.TargetDefinitionDao_PopulateInstance_CheckTagValue_Update);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(targetDefinition);
            InsertNewDocumentLinks(targetDefinition);
            RemoveDeletedDocumentLinks(targetDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        public void UpdateAfterUnableToAccessTags(TargetDefinition definition)
        {
            var command = ManagedCommand;
            command.Update(definition, AddUpdateParametersForUnableToAccessTag, UPDATE_AFTER_UNABLE_TO_ACCESS_TAGS);
            InsertNewComments(definition);
        }

        public IEnumerable<long> QueryAssociatedTargets(long parentTargetId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ParentTargetDefinitionID", parentTargetId);
            return command.QueryForListResult(PopulateAssociatedTargetInstance, QUERY_ASSOCIATED_TARGETS);
        }

        public List<string> QueryParentTargets(long childTargetId)
        {
            var command = ManagedCommand;
            command.Parameters.Clear();
            command.AddParameter("@ChildTargetDefinitionId", childTargetId);
            return command.QueryForListResult(PopulateParentTargetInstance, QUERY_PARENT_TARGETS);
        }

        public TargetDefinition QueryByScheduleId(long? scheduleId)
        {
            var command = ManagedCommand;
            command.AddParameter("@ScheduleId", scheduleId);
            return command.QueryForSingleResult(PopulateInstance, QUERY_TARGET_BY_SCHEDULE_ID);
        }

        public List<TargetDefinition> QueryByScheduleIds(IList<long> schedules)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvScheduleIds", schedules.ToCommaSeparatedString());
            return command.QueryForListResult(PopulateWithoutEvaluatingTagsForAvailableForScheduling,
                QUERY_TARGETS_BY_SCHEDULE_IDS);
        }

        public List<TargetDefinition> QueryTargetDefinitionAlreadyUsingTag(long? targetDefinitionId,
            TagDirection direction, long tagId)
        {
            var command = ManagedCommand;
            command.CommandText = QUERY_TARGET_DEFINITIONS_ALREADY_WRITING_TO_TAG;

            command.AddParameter("@TargetDefinitionId", targetDefinitionId);
            command.AddParameter("@TagDirectionId", direction.IdValue);
            command.AddParameter("@TagId", tagId);

            return command.QueryForListResult(PopulateInstance, QUERY_TARGET_DEFINITIONS_ALREADY_WRITING_TO_TAG);
        }

        public List<TargetDefinition> QueryTargetDefinitionsWithInvalidTag(TagInfo tag)
        {
            var command = ManagedCommand;
            command.AddParameter("@TagId", tag.IdValue);
            return command.QueryForListResult(PopulateInstance, QUERY_TARGET_DEFINITIONS_WITH_INVALID_TAG);
        }

        public List<TargetDefinition> QueryTargetDefinitionsWithValidTag(TagInfo tag)
        {
            var command = ManagedCommand;
            command.AddParameter("@TagId", tag.IdValue);
            return command.QueryForListResult(PopulateInstance, QUERY_TARGET_DEFINITIONS_WITH_VALID_TAG);
        }

        public void UpdateStatus(TargetDefinition targetDefinition)
        {
            var command = ManagedCommand;
            command.AddParameter("@TargetDefinitionId", targetDefinition.IdValue);
            command.AddParameter("@StatusId", targetDefinition.Status.IdValue);
            command.AddParameter("@LastModifiedDateTime", targetDefinition.LastModifiedDate);
            command.AddParameter("@LastModifiedUserId", targetDefinition.LastModifiedBy.IdValue);
            command.AddParameter("@IsActive", targetDefinition.IsActive);
            command.ExecuteNonQuery(UPDATE_TARGET_DEFINITION_STATUS);
        }

        public int QueryLinkedActionItemDefinitionCount(long? id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.GetCount(QUERY_LINKED_ACTION_ITEM_DEFINITION_COUNT);
        }

        public void WriteTagValues(TargetDefinition targetDefinition)
        {
            if (targetDefinition.Is(TargetDefinitionStatus.Approved))
            {
                WriteConfiguredTagValues(targetDefinition.ReadWriteTagsConfiguration.MaxValue, targetDefinition.MaxValue);
                WriteConfiguredTagValues(targetDefinition.ReadWriteTagsConfiguration.MinValue, targetDefinition.MinValue);
                WriteConfiguredTagValues(targetDefinition.ReadWriteTagsConfiguration.GapUnitValue,
                    targetDefinition.GapUnitValue);
                if (targetDefinition.ReadWriteTagsConfiguration.TargetValue.IsWriteDirection())
                {
                    targetDefinition.TargetValue.Do(
                        new WriteTargetValueParameters(
                            targetDefinition.ReadWriteTagsConfiguration.TargetValue.Tag,
                            gateway));
                }
            }
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject targetDefinition)
        {
            documentLinkDao.InsertNewDocumentLinks(targetDefinition, documentLinkDao.InsertForAssociatedTargetDefinition);
        }

        private static void AddUpdateParametersForUnableToAccessTag(TargetDefinition definition, SqlCommand command)
        {
            command.AddParameter("@Id", definition.Id);
            command.AddParameter("@IsActive", definition.IsActive);
            command.AddParameter("@LastModifiedUserId", definition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", definition.LastModifiedDate);
        }

        private void UpdateSchedule(TargetDefinition targetDefinition)
        {
            if (targetDefinition.Schedule.Id.HasValue)
            {
                scheduleDao.Update(targetDefinition.Schedule);
            }
            else
            {
                throw new AttemptedToUpdateObjectWithoutIdException(targetDefinition, typeof (ISchedule));
            }
        }

        private void UpdateReadWriteTagConfiguration(TargetDefinition targetDefinition)
        {
            targetDefinitionReadWriteTagConfigurationDao.Update(targetDefinition.ReadWriteTagsConfiguration);
        }

        private static void UpdateTargetAssociations(SqlCommand command, TargetDefinition target)
        {
            var targetDefinitionDao =
                DaoRegistry.GetDao<ITargetDefinitionDao>();
            var currentAssociations =
                new List<long>(targetDefinitionDao.QueryAssociatedTargets(target.IdValue));
            var newAssociations = new List<long>();
            foreach (var associatedDTO in target.AssociatedTargetDTOs)
            {
                newAssociations.Add(associatedDTO.IdValue);
            }
            if (!newAssociations.Equals(currentAssociations))
            {
                DeleteDependentTargetDefinitions(command, target);
                InsertDependentTargetDefinitions(command, target);
            }
        }

        private static void InsertDependentTargetDefinitions(SqlCommand command, TargetDefinition targetDefinition)
        {
            if (!targetDefinition.AssociatedTargetDTOs.IsEmpty())
            {
                command.CommandText = INSERT_ASSOCIATED_TARGET_RELATIONSHIP;
                foreach (var associatedTargetDTO in targetDefinition.AssociatedTargetDTOs)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@ParentTargetDefinitionID", targetDefinition.Id);
                    command.AddParameter("@ChildTargetDefinitionId", associatedTargetDTO.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void DeleteDependentTargetDefinitions(SqlCommand command, TargetDefinition target)
        {
            command.CommandText = DELETE_ASSOCIATED_TARGET_RELATIONSHIP;
            command.Parameters.Clear();
            command.AddParameter("@ParentTargetDefinitionID", target.Id);
            command.ExecuteNonQuery();
        }

        private void InsertNewComments(TargetDefinition targetDefinition)
        {
            foreach (var comment in targetDefinition.Comments)
            {
                if (comment.Id == null)
                {
                    commentDao.InsertTargetDefinitionComment(targetDefinition.IdValue, comment);
                }
            }
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject targetDefinition)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(targetDefinition,
                documentLinkDao.QueryByTargetDefinitionId);
        }

        private static void AddUpdateParameters(TargetDefinition targetDefinition, SqlCommand command)
        {
            command.AddParameter("@id", targetDefinition.Id);
            SetCommonAttributes(targetDefinition, command);
        }

        private static void AddInsertParameters(TargetDefinition targetDefinition, SqlCommand command)
        {
            SetCommonAttributes(targetDefinition, command);
        }

        private static void AddRemoveParameters(TargetDefinition targetDefinition, SqlCommand command)
        {
            command.AddParameter("@Id", targetDefinition.Id);
            command.AddParameter("@LastModifiedUserId", targetDefinition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", targetDefinition.LastModifiedDate);
        }

        private TargetDefinition PopulateWithoutEvaluatingTagsForAvailableForScheduling(SqlDataReader reader)
        {
            return PopulateInstance(reader, false);
        }

        private TargetDefinition PopulateInstance(SqlDataReader reader, bool shouldReadTagValues)
        {
            var functionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID"));
            var id = reader.Get<long?>("Id");
            var name = reader.Get<string>("Name");
            var neverToExceedMaximum = reader.Get<decimal?>("NeverToExceedMax");
            var neverToExceedMinimum = reader.Get<decimal?>("NeverToExceedMin");

            var preApprovedNeverToExceedMin = reader.Get<decimal?>("PreApprovedNeverToExceedMin");
            var preApprovedNeverToExceedMax = reader.Get<decimal?>("PreApprovedNeverToExceedMax");
            var preApprovedMinValue = reader.Get<decimal?>("PreApprovedMin");
            var preApprovedMaxValue = reader.Get<decimal?>("PreApprovedMax");
            var neverToExceedMaxFrequency = reader.Get<int?>("NeverToExceedMaxFrequency");
            var neverToExceedMinFrequency = reader.Get<int?>("NeverToExceedMinFrequency");
            var maxValueFrequency = reader.Get<int?>("MaxValueFrequency");
            var minValueFrequency = reader.Get<int?>("MinValueFrequency");
            var generateActionItem = reader.Get<bool>("GenerateActionItem");
            var description = reader.Get<string>("Description");
            var isAlertRequired = reader.Get<bool>("AlertRequired");
            var category = TargetCategory.GetTargetCategory(reader.Get<long>("TargetCategoryID"));
            var status = TargetDefinitionStatus.Get(reader.Get<long>("TargetDefinitionStatusID"));
            var priority = Priority.GetById(reader.Get<long>("PriorityId"));
            var tagInfo = tagDao.QueryById(reader.Get<long>("TagID"));
            var dependentTargets = targetDtoDao.QueryAssociatedTargets(id.Value);
            var schedule = scheduleDao.QueryById(reader.Get<long>("ScheduleId"));
            var lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            var comments = commentDao.QueryByTargetDefinitionId(id.Value);
            var requiresApproval = reader.Get<bool>("RequiresApproval");
            var requiresResponseWhenAlerted = reader.Get<bool>("RequiresResponseWhenAlerted");
            var isActive = reader.Get<bool>("IsActive");
            var deleted = reader.Get<bool>("Deleted");
            var operationalModeId = reader.Get<int>("OperationalModeId");
            var opMode = OperationalMode.GetById(operationalModeId);
            var documentLinks = documentLinkDao.QueryByTargetDefinitionId(id.Value);

            var readWriteTagConfiguration = GetReadWriteTagConfiguration(id.Value);

            WorkAssignment assignment = null;
            var assignmentId = reader.Get<long?>("WorkAssignmentId");
            if (assignmentId != null)
            {
                assignment = assignmentDao.QueryById(assignmentId.Value);
            }

            decimal? maxValue = null;
            decimal? minValue = null;
            decimal? gapUnitValue = null;
            var targetValue = TargetValue.CreateEmptyTarget();

            if (shouldReadTagValues)
            {
                var waitHandles = new List<WaitHandle>();

                PhdReadObject maxTagRead = null;
                if (readWriteTagConfiguration.MaxValue.IsReadDirection())
                {
                    var autoResetEvent = new AutoResetEvent(false);
                    waitHandles.Add(autoResetEvent);
                    maxTagRead = new PhdReadObject(readWriteTagConfiguration.MaxValue.Tag,
                        PlantHistorianOrigin.TargetDefinitionDao_PopulateInstance_GetConfigValue_Max, autoResetEvent);
                    ThreadPool.QueueUserWorkItem(GetValueBasedOnConfiguration, maxTagRead);
                }
                else
                {
                    maxValue = reader.Get<decimal?>("MaxValue");
                }

                PhdReadObject minTagRead = null;
                if (readWriteTagConfiguration.MinValue.IsReadDirection())
                {
                    var autoResetEvent = new AutoResetEvent(false);
                    waitHandles.Add(autoResetEvent);
                    minTagRead = new PhdReadObject(readWriteTagConfiguration.MinValue.Tag,
                        PlantHistorianOrigin.TargetDefinitionDao_PopulateInstance_GetConfigValue_Min, autoResetEvent);
                    ThreadPool.QueueUserWorkItem(GetValueBasedOnConfiguration, minTagRead);
                }
                else
                {
                    minValue = reader.Get<decimal?>("MinValue");
                }

                PhdReadObject gapUnitValueTagRead = null;
                if (readWriteTagConfiguration.GapUnitValue.IsReadDirection())
                {
                    var autoResetEvent = new AutoResetEvent(false);
                    waitHandles.Add(autoResetEvent);
                    gapUnitValueTagRead = new PhdReadObject(readWriteTagConfiguration.GapUnitValue.Tag,
                        PlantHistorianOrigin.TargetDefinitionDao_PopulateInstance_GetConfigValue_Gap,
                        autoResetEvent);
                    ThreadPool.QueueUserWorkItem(GetValueBasedOnConfiguration, gapUnitValueTagRead);
                }
                else
                {
                    gapUnitValue = reader.Get<decimal?>("GapUnitValue");
                }

                PhdReadObject targetValueTagRead = null;
                if (readWriteTagConfiguration.TargetValue.IsReadDirection())
                {
                    var autoResetEvent = new AutoResetEvent(false);
                    waitHandles.Add(autoResetEvent);
                    targetValueTagRead = new PhdReadObject(readWriteTagConfiguration.TargetValue.Tag,
                        PlantHistorianOrigin.TargetDefinitionDao_PopulateInstance_ReadTargetValue,
                        autoResetEvent);
                    ThreadPool.QueueUserWorkItem(GetValueBasedOnConfiguration, targetValueTagRead);
                }
                else
                {
                    targetValue = GetTargetValueFromDatabase(reader);
                }

                if (waitHandles.Count > 0)
                {
                    WaitHandle.WaitAll(waitHandles.ToArray(), 5000);
                    if (maxTagRead != null)
                    {
                        maxValue = maxTagRead.Result;
                    }
                    if (minTagRead != null)
                    {
                        minValue = minTagRead.Result;
                    }
                    if (gapUnitValueTagRead != null)
                    {
                        gapUnitValue = gapUnitValueTagRead.Result;
                    }
                    if (targetValueTagRead != null)
                    {
                        var result = targetValueTagRead.Result;
                        if (result.HasValue)
                        {
                            targetValue = TargetValue.CreateSpecifiedTarget(result.Value);
                        }
                    }
                }
            }

            else
            {
                maxValue = reader.Get<decimal?>("MaxValue");
                minValue = reader.Get<decimal?>("MinValue");
                gapUnitValue = reader.Get<decimal?>("GapUnitValue");
                if (!readWriteTagConfiguration.TargetValue.IsReadDirection())
                {
                    targetValue = GetTargetValueFromDatabase(reader);
                }
            }

            var targetDefinition
                = new TargetDefinition(name,
                    description,
                    category,
                    status,
                    tagInfo,
                    schedule,
                    neverToExceedMinimum,
                    neverToExceedMaximum,
                    preApprovedNeverToExceedMin,
                    preApprovedNeverToExceedMax,
                    neverToExceedMinFrequency,
                    neverToExceedMaxFrequency,
                    maxValue,
                    minValue,
                    preApprovedMinValue,
                    preApprovedMaxValue,
                    maxValueFrequency,
                    minValueFrequency,
                    targetValue,
                    gapUnitValue,
                    functionalLocation,
                    generateActionItem,
                    isAlertRequired,
                    requiresApproval,
                    requiresResponseWhenAlerted,
                    dependentTargets,
                    lastModifiedBy,
                    lastModifiedDate,
                    isActive,
                    opMode,
                    readWriteTagConfiguration,
                    documentLinks,
                    assignment)
                {
                    Comments = comments,
                    Id = id,
                    Deleted = deleted,
                    Priority = priority,
                };

            return targetDefinition;
        }

        private TargetDefinition PopulateInstance(SqlDataReader reader)
        {
            return PopulateInstance(reader, true);
        }

        private TargetValue GetTargetValueFromDatabase(SqlDataReader reader)
        {
            var targetValueTypeId = reader.Get<long>("TargetValueTypeId");
            var target = reader.Get<decimal?>("TargetDefinitionValue");
            return TargetValueType.ToTargetValue(targetValueTypeId, target);
        }

        private TargetDefinitionReadWriteTagConfiguration GetReadWriteTagConfiguration(long targetDefinitionId)
        {
            var targetDefinitionReadWriteTagConfiguration = targetDefinitionReadWriteTagConfigurationDao
                .QueryByTargetDefinitionId(
                    targetDefinitionId) ?? TargetDefinitionReadWriteTagConfiguration.CreateDefault();

            return targetDefinitionReadWriteTagConfiguration;
        }

        private void WriteConfiguredTagValues(ReadWriteTagConfiguration configuration, decimal? tagValue)
        {
            if (!configuration.IsWriteDirection() || !tagValue.HasValue) return;
            gateway.WriteTagValue(configuration.Tag, tagValue.Value);
        }

        private void CheckTagValueConfigurations(TargetDefinition targetDefinition, PlantHistorianOrigin origin)
        {
            targetDefinition.MinValue =
                GetValueBasedOnConfiguration(targetDefinition.ReadWriteTagsConfiguration.MinValue,
                    targetDefinition.MinValue, origin);
            targetDefinition.MaxValue =
                GetValueBasedOnConfiguration(targetDefinition.ReadWriteTagsConfiguration.MaxValue,
                    targetDefinition.MaxValue, origin);
            GetTargetValueForReadWriteConfiguration(targetDefinition, origin);
            targetDefinition.GapUnitValue =
                GetValueBasedOnConfiguration(targetDefinition.ReadWriteTagsConfiguration.GapUnitValue,
                    targetDefinition.GapUnitValue, origin);
        }

        private void GetTargetValueForReadWriteConfiguration(TargetDefinition targetDefinition,
            PlantHistorianOrigin origin)
        {
            if (targetDefinition.ReadWriteTagsConfiguration.TargetValue.IsReadDirection())
            {
                targetDefinition.TargetValue =
                    GetTargetValueFromPlantHistorian(targetDefinition.ReadWriteTagsConfiguration, origin);
            }
        }

        private TargetValue GetTargetValueFromPlantHistorian(TargetDefinitionReadWriteTagConfiguration configuration,
            PlantHistorianOrigin origin)
        {
            var targetValue = GetTagValue(configuration.TargetValue.Tag, origin);
            return (targetValue.HasValue)
                ? TargetValue.CreateSpecifiedTarget(targetValue.Value)
                : TargetValue.CreateEmptyTarget();
        }

        private void GetValueBasedOnConfiguration(object state)
        {
            var readObject = (PhdReadObject) state;

            try
            {
                var result = GetTagValue(readObject.Tag, readObject.Source);
                readObject.Result = result;
            }
            catch (InvalidPlantHistorianReadException e)
            {
                // swallow the exception since we will just set the Result to null.                
            }
            finally
            {
                readObject.WaitHandle.Set();
            }
        }

        private decimal? GetValueBasedOnConfiguration(ReadWriteTagConfiguration configuration, decimal? dbValue,
            PlantHistorianOrigin origin)
        {
            return configuration.IsReadDirection() ? GetTagValue(configuration.Tag, origin) : dbValue;
        }

        private decimal? GetTagValue(TagInfo tagInfo, PlantHistorianOrigin origin)
        {
            var values = gateway.ReadTagValues(origin, tagInfo, new[] {DateTime.Now.GetNetworkPortable()});
            return values != null && values.Length > 0 ? values[0] : new decimal?();
        }

        private void InsertReadWriteTagConfiguration(TargetDefinition targetDefinition)
        {
            targetDefinitionReadWriteTagConfigurationDao.Insert(targetDefinition);
        }

        private void InsertSchedule(TargetDefinition targetDefinition)
        {
            scheduleDao.Insert(targetDefinition.Schedule);
        }

        private static void SetCommonAttributes(TargetDefinition target, SqlCommand command)
        {
            command.AddParameter("@Name", target.Name);
            command.AddParameter("@UpdatedUserId", target.LastModifiedBy.Id); //will eventually be a User.
            command.AddParameter("@UpdatedDate", target.LastModifiedDate);
            command.AddParameter("@NeverToExceedMax", target.NeverToExceedMaximum);
            command.AddParameter("@NeverToExceedMin", target.NeverToExceedMinimum);
            command.AddParameter("@NeverToExceedMaxFrequency", target.NeverToExceedMaxFrequency);
            command.AddParameter("@NeverToExceedMinFrequency", target.NeverToExceedMinFrequency);
            command.AddParameter("@MaxValue", target.MaxValue);
            command.AddParameter("@MinValue", target.MinValue);
            command.AddParameter("@MaxValueFrequency", target.MaxValueFrequency);
            command.AddParameter("@MinValueFrequency", target.MinValueFrequency);
            target.TargetValue.Do(new SetTargetValueParameters(command.Parameters));
            command.AddParameter("@GapUnitValue", target.GapUnitValue);
            command.AddParameter("@GenerateActionItem", target.GenerateActionItem);
            command.AddParameter("@TargetDefinitionStatusID", target.Status.Id);
            command.AddParameter("@PriorityId", target.Priority.Id);
            command.AddParameter("@TargetCategoryID", target.Category.Id);
            command.AddParameter("@TagID", target.TagInfo.Id);
            command.AddParameter("@FunctionalLocationID", target.FunctionalLocation.Id);
            command.AddParameter("@ScheduleId", target.Schedule.Id);
            command.AddParameter("@Description", target.Description);
            command.AddParameter("@AlertRequired", target.IsAlertRequired);
            command.AddParameter("@RequiresApproval", target.RequiresApproval);
            command.AddParameter("@RequiresResponseWhenAlerted", target.RequiresResponseWhenAlerted);
            command.AddParameter("@IsActive", target.IsActive);
            command.AddParameter("@OperationalModeId", target.OperationalMode.Id);
            command.AddParameter("@PreApprovedMin", target.PreApprovedMinValue);
            command.AddParameter("@PreApprovedMax", target.PreApprovedMaxValue);
            command.AddParameter("@PreApprovedNeverToExceedMin", target.PreApprovedNeverToExceedMinimum);
            command.AddParameter("@PreApprovedNeverToExceedMax", target.PreApprovedNeverToExceedMaximum);
            command.AddParameter("@WorkAssignmentId",
                target.Assignment != null
                    ? target.Assignment.Id
                    : null);

       
        }

        private static string PopulateParentTargetInstance(SqlDataReader reader)
        {
            return reader.Get<string>("Name");
        }

        private static long PopulateAssociatedTargetInstance(SqlDataReader reader)
        {
            return reader.Get<long>("ChildTargetDefinitionId");
        }

        private class PhdReadObject
        {
            public PhdReadObject(TagInfo tag, PlantHistorianOrigin source, AutoResetEvent waitHandle)
            {
                Source = source;
                WaitHandle = waitHandle;
                Tag = tag;
            }

            public PlantHistorianOrigin Source { get; private set; }
            public AutoResetEvent WaitHandle { get; private set; }
            public TagInfo Tag { get; private set; }

            public decimal? Result { get; set; }
        }

        private class SetTargetValueParameters : ITargetAction
        {
            private readonly SqlParameterCollection parameters;

            public SetTargetValueParameters(SqlParameterCollection parameters)
            {
                this.parameters = parameters;
            }

            public void DoForMinimize()
            {
                parameters.AddWithValue("@TargetValueTypeId", TargetValueType.MINIMIZE);
            }

            public void DoForMaximize()
            {
                parameters.AddWithValue("@TargetValueTypeId", TargetValueType.MAXIMIZE);
            }

            public void DoForEmpty()
            {
                parameters.AddWithValue("@TargetValueTypeId", TargetValueType.SPECIFIED);
            }

            public void DoWithSpecifiedValue(decimal specifiedValue)
            {
                parameters.AddWithValue("@TargetValueTypeId", TargetValueType.SPECIFIED);
                parameters.AddWithValue("@TargetDefinitionValue", specifiedValue);
            }
        }

        private class WriteTargetValueParameters : ITargetAction
        {
            private readonly IPlantHistorianGateway gateway;
            private readonly TagInfo tag;

            public WriteTargetValueParameters(TagInfo tag, IPlantHistorianGateway gateway)
            {
                this.tag = tag;
                this.gateway = gateway;
            }

            public void DoForMinimize()
            {
                // DO Nothing
            }

            public void DoForMaximize()
            {
                // DO Nothing
            }

            public void DoForEmpty()
            {
                // DO Nothing
            }

            public void DoWithSpecifiedValue(decimal specifiedValue)
            {
                gateway.WriteTagValue(tag, specifiedValue);
            }
        }
    }
}