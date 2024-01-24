using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetDefinitionHistoryDao : AbstractManagedDao, ITargetDefinitionHistoryDao
    {
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ITagDao tagDao;
        private readonly IUserDao userDao;

        public TargetDefinitionHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<TargetDefinitionHistory> GetById(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult(PopulateInstance, "QueryTargetDefinitionHistoriesById");
        }

        public void Insert(TargetDefinitionHistory targetDefinitionHistory)
        {
            var command = ManagedCommand;
            command.Insert(targetDefinitionHistory, AddInsertParameters, "InsertTargetDefinitionHistory");
        }

        private TargetDefinitionHistory PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var name = reader.Get<string>("Name");

            var neverToExceedMinimum = reader.Get<decimal?>("NeverToExceedMin");
            var neverToExceedMaximum = reader.Get<decimal?>("NeverToExceedMax");
            var minValue = reader.Get<decimal?>("MinValue");
            var maxValue = reader.Get<decimal?>("MaxValue");

            var preApprovedNeverToExceedMinimum = reader.Get<decimal?>("PreApprovedNeverToExceedMin");
            var preApprovedNeverToExceedMaximum = reader.Get<decimal?>("PreApprovedNeverToExceedMax");
            var preApprovedMinValue = reader.Get<decimal?>("PreApprovedMin");
            var preApprovedMaxValue = reader.Get<decimal?>("PreApprovedMax");

            var neverToExceedMinFrequency = reader.Get<int?>("NeverToExceedMinFrequency");
            var neverToExceedMaxFrequency = reader.Get<int?>("NeverToExceedMaxFrequency");
            var minValueFrequency = reader.Get<int?>("MinValueFrequency");
            var maxValueFrequency = reader.Get<int?>("MaxValueFrequency");

            var targetValue = reader.Get<string>("TargetDefinitionValue");
            var gapUnitValue = reader.Get<decimal?>("GapUnitValue");
            var generateActionItem = reader.Get<bool>("GenerateActionItem");
            var description = reader.Get<string>("Description");
            var isAlertRequired = reader.Get<bool>("AlertRequired");
            var category = TargetCategory.GetTargetCategory(reader.Get<long>("TargetCategoryID"));
            var status = TargetDefinitionStatus.Get(reader.Get<long>("TargetDefinitionStatusID"));
            var functionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID"));
            var tagInfo = tagDao.QueryById(reader.Get<long>("TagID"));
            var associatedTargets = reader.Get<string>("AssociatedTargets");
            var schedule = reader.Get<string>("Schedule");
            var lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            var requiresApproval = reader.Get<bool>("RequiresApproval");
            var requiresResponseWhenAlerted = reader.Get<bool>("RequiresResponseWhenAlerted");
            var isActive = reader.Get<bool>("IsActive");
            var operationalModeId = reader.Get<int>("OperationalModeId");
            var opMode = OperationalMode.GetById(operationalModeId);

            var priorityId = reader.Get<long>("PriorityId");
            var priority = Priority.GetById(priorityId);

            var documentLinks = reader.Get<string>("DocumentLinks");

            var readWriteConfiguration = reader.Get<string>("ReadWriteConfiguration");

            var assignmentName = reader.Get<string>("WorkAssignmentName");

            return new TargetDefinitionHistory(
                id,
                name,
                neverToExceedMinimum,
                neverToExceedMaximum,
                preApprovedNeverToExceedMinimum,
                preApprovedNeverToExceedMaximum,
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
                description,
                category,
                tagInfo,
                generateActionItem,
                isAlertRequired,
                requiresResponseWhenAlerted,
                isActive,
                requiresApproval,
                functionalLocation,
                status,
                lastModifiedBy,
                lastModifiedDate,
                opMode,
                priority,
                schedule,
                associatedTargets, 
                documentLinks, 
                readWriteConfiguration,
                assignmentName);
        }

        private static void AddInsertParameters(TargetDefinitionHistory targetDefinitionHistory, SqlCommand command)
        {
            command.AddParameter("@Id", targetDefinitionHistory.Id);
            command.AddParameter("@Name", targetDefinitionHistory.Name);
            command.AddParameter("@UpdatedUserId", targetDefinitionHistory.LastModifiedBy.Id);
            command.AddParameter("@UpdatedDate", targetDefinitionHistory.LastModifiedDate);

            command.AddParameter("@NeverToExceedMin", targetDefinitionHistory.NeverToExceedMinimum);
            command.AddParameter("@NeverToExceedMax", targetDefinitionHistory.NeverToExceedMaximum);
            command.AddParameter("@MinValue", targetDefinitionHistory.MinValue);
            command.AddParameter("@MaxValue", targetDefinitionHistory.MaxValue);

            command.AddParameter("@PreApprovedNeverToExceedMin", targetDefinitionHistory.PreApprovedNeverToExceedMinimum);
            command.AddParameter("@PreApprovedNeverToExceedMax", targetDefinitionHistory.PreApprovedNeverToExceedMaximum);
            command.AddParameter("@PreApprovedMin", targetDefinitionHistory.PreApprovedMinValue);
            command.AddParameter("@PreApprovedMax", targetDefinitionHistory.PreApprovedMaxValue);

            command.AddParameter("@NeverToExceedMinFrequency", targetDefinitionHistory.NeverToExceedMinimumFrequency);
            command.AddParameter("@NeverToExceedMaxFrequency", targetDefinitionHistory.NeverToExceedMaximumFrequency);
            command.AddParameter("@MinValueFrequency", targetDefinitionHistory.MinValueFrequency);
            command.AddParameter("@MaxValueFrequency", targetDefinitionHistory.MaxValueFrequency);

            command.AddParameter("@TargetDefinitionValue", targetDefinitionHistory.TargetValue);
            command.AddParameter("@GapUnitValue", targetDefinitionHistory.GapUnitValue);
            command.AddParameter("@GenerateActionItem", targetDefinitionHistory.GenerateActionItem);
            command.AddParameter("@TargetDefinitionStatusID", targetDefinitionHistory.Status.Id);
            command.AddParameter("@TargetCategoryID", targetDefinitionHistory.Category.Id);
            command.AddParameter("@TagID", targetDefinitionHistory.TagInfo.Id);
            command.AddParameter("@FunctionalLocationId", targetDefinitionHistory.FunctionalLocation.Id);
            command.AddParameter("@Schedule", targetDefinitionHistory.Schedule);
            command.AddParameter("@Description", targetDefinitionHistory.Description);
            command.AddParameter("@AlertRequired", targetDefinitionHistory.IsAlertRequired);
            command.AddParameter("@RequiresApproval", targetDefinitionHistory.RequiresApproval);
            command.AddParameter("@RequiresResponseWhenAlerted", targetDefinitionHistory.RequiresResponseWhenAlerted);
            command.AddParameter("@IsActive", targetDefinitionHistory.IsActive);
            command.AddParameter("@OperationalModeId", targetDefinitionHistory.OperationalMode.Id);
            command.AddParameter("@PriorityId", targetDefinitionHistory.Priority.Id);
            command.AddParameter("@DocumentLinks", targetDefinitionHistory.DocumentLinks);

            command.AddParameter("@AssociatedTargets", targetDefinitionHistory.AssociatedTargets);

            command.AddParameter("@ReadWriteConfiguration", targetDefinitionHistory.ReadWriteConfiguration);
            command.AddParameter("@WorkAssignmentName", targetDefinitionHistory.WorkAssignmentName);
        }
    }
}