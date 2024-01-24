using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LabAlertDefinitionDao : AbstractManagedDao, ILabAlertDefinitionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryLabAlertDefinitionByID";
        private const string QUERY_BY_SCHEDULE_ID_STORED_PROCEDURE = "QueryLabAlertDefinitionByScheduleID";
        private const string QUERY_BY_NAME_STORED_PROCEDURE = "QueryLabAlertDefinitionsByName";
        private const string QUERY_WITH_INVALID_TAG_STORED_PROCEDURE = "QueryLabAlertDefinitionsWithInvalidTag";
        private const string QUERY_WITH_VALID_TAG_STORED_PROCEDURE = "QueryLabAlertDefinitionsWithValidTag";
        private const string QUERY_FOR_SCHEDULING_STORED_PROCEDURE = "QueryLabAlertDefinitionsForScheduling";

        private const string INSERT_STORED_PROCEDURE = "InsertLabAlertDefinition";
        private const string UPDATE_STORED_PROCEDURE = "UpdateLabAlertDefinition";        
        private const string REMOVE_STORED_PROCEDURE = "RemoveLabAlertDefinition";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ITagDao tagDao;
        private readonly IUserDao userDao;
        private readonly IScheduleDao scheduleDao;

        public LabAlertDefinitionDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
        }

        public LabAlertDefinition QueryById(long id)
        {
            return ManagedCommand.QueryById<LabAlertDefinition>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public LabAlertDefinition QueryByScheduleId(long scheduleId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@scheduleId", scheduleId);
            return command.QueryForSingleResult<LabAlertDefinition>(PopulateInstance, QUERY_BY_SCHEDULE_ID_STORED_PROCEDURE);
        }

        public List<LabAlertDefinition> QueryByName(long siteId, string name)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            command.AddParameter("@Name", name);
            return command.QueryForListResult<LabAlertDefinition>(PopulateInstance, QUERY_BY_NAME_STORED_PROCEDURE);                        
        }

        public List<LabAlertDefinition> QueryLabAlertDefinitionsWithInvalidTag(TagInfo tag)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TagId",  tag.IdValue);
            return command.QueryForListResult<LabAlertDefinition>(PopulateInstance, QUERY_WITH_INVALID_TAG_STORED_PROCEDURE);
        }

        public List<LabAlertDefinition> QueryLabAlertDefinitionsWithValidTag(TagInfo tag)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TagId",  tag.IdValue);
            return command.QueryForListResult<LabAlertDefinition>(PopulateInstance, QUERY_WITH_VALID_TAG_STORED_PROCEDURE);
        }

        public SchedulingList<LabAlertDefinition, OLTException> QueryAllAvailableForScheduling()
        {
            List<OLTException> exceptions = new List<OLTException>();

            List<LabAlertDefinition> definitions = ManagedCommand.QueryForListResult<LabAlertDefinition>(PopulateInstance, QUERY_FOR_SCHEDULING_STORED_PROCEDURE, exceptions.Add);

            return new SchedulingList<LabAlertDefinition, OLTException>(definitions, exceptions);
        }

        public LabAlertDefinition Insert(LabAlertDefinition definition)
        {
            SqlCommand command = ManagedCommand;

            scheduleDao.Insert(definition.Schedule);

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(definition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            definition.Id = (long?) idParameter.Value;
            return definition;
        }

        private static void AddInsertParameters(LabAlertDefinition definition, SqlCommand command)
        {
            command.AddParameter("@CreatedDateTime", definition.CreatedDateTime);
            command.AddParameter("@CreatedByUserId", definition.CreatedBy.Id);
            command.AddParameter("@ScheduleId", definition.Schedule.Id);
            SetInsertUpdateAttributes(definition, command);
        }

        public void Update(LabAlertDefinition definition)
        {
            SqlCommand command = ManagedCommand;
            command.Update(definition, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            // do this after updating the definition to decrease chance of deadlocks
            if (definition.Schedule.Id.HasValue)
            {
                scheduleDao.Update(definition.Schedule);
            }
            else
            {
                throw new AttemptedToUpdateObjectWithoutIdException(definition, typeof(ISchedule));
            }
        }
            
        private static void AddUpdateParameters(LabAlertDefinition definition, SqlCommand command)
        {
            command.AddParameter("@id", definition.Id);
            SetInsertUpdateAttributes(definition, command);
        }
 
        public void Remove(LabAlertDefinition definition)
        {
            ManagedCommand.ExecuteNonQuery(definition, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        private static void AddRemoveParameters(LabAlertDefinition definition, SqlCommand command)
        {
            command.AddParameter("@Id", definition.Id);
            command.AddParameter("@LastModifiedByUserId", definition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", definition.LastModifiedDate);
        }

        private LabAlertDefinition PopulateInstance(SqlDataReader reader)
        {
            LabAlertTagQueryRange labAlertTagQueryRange;
            
            LabAlertTagQueryRangeType labAlertTagQueryRangeType = (reader.Get<byte>("LabAlertTagQueryRangeType")).ToEnum<LabAlertTagQueryRangeType>();
            Time labAlertTagQueryRangeFromTime = new Time(reader.Get<DateTime>("LabAlertTagQueryRangeFromTime"));
            Time labAlertTagQueryRangeToTime = new Time(reader.Get<DateTime>("LabAlertTagQueryRangeToTime"));
            DayOfWeek labAlertTagQueryRangeFromDayOfWeek = reader.GetDayOfWeek("LabAlertTagQueryRangeFromDayOfWeek");
            DayOfWeek labAlertTagQueryRangeToDayOfWeek = reader.GetDayOfWeek("LabAlertTagQueryRangeToDayOfWeek");
            WeekOfMonth labAlertTagQueryRangeFromWeekOfMonth = reader.GetWeekOfMonth("LabAlertTagQueryRangeFromWeekOfMonth");
            WeekOfMonth labAlertTagQueryRangeToWeekOfMonth = reader.GetWeekOfMonth("LabAlertTagQueryRangeToWeekOfMonth");
            DayOfMonth labAlertTagQueryRangeFromDayOfMonth = reader.GetDayOfMonth("LabAlertTagQueryRangeFromDayOfMonth");
            DayOfMonth labAlertTagQueryRangeToDayOfMonth = reader.GetDayOfMonth("LabAlertTagQueryRangeToDayOfMonth");

            if (labAlertTagQueryRangeType == LabAlertTagQueryRangeType.Daily)
            {
                labAlertTagQueryRange = new LabAlertTagQueryDailyRange(
                    labAlertTagQueryRangeFromTime, labAlertTagQueryRangeToTime);
            }
            else if (labAlertTagQueryRangeType == LabAlertTagQueryRangeType.Weekly)
            {
                labAlertTagQueryRange = new LabAlertTagQueryWeeklyRange(
                    labAlertTagQueryRangeFromTime, labAlertTagQueryRangeToTime,
                    labAlertTagQueryRangeFromDayOfWeek, labAlertTagQueryRangeToDayOfWeek);
            }
            else if (labAlertTagQueryRangeType == LabAlertTagQueryRangeType.MonthlyDayOfWeek)
            {
                labAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfWeekRange(
                    labAlertTagQueryRangeFromTime, labAlertTagQueryRangeToTime,
                    labAlertTagQueryRangeFromWeekOfMonth, labAlertTagQueryRangeToWeekOfMonth,
                    labAlertTagQueryRangeFromDayOfWeek, labAlertTagQueryRangeToDayOfWeek);
            }
            else if (labAlertTagQueryRangeType == LabAlertTagQueryRangeType.MonthlyDayOfMonth)
            {
                labAlertTagQueryRange = new LabAlertTagQueryMonthlyDayOfMonthRange(
                    labAlertTagQueryRangeFromTime, labAlertTagQueryRangeToTime,
                    labAlertTagQueryRangeFromDayOfMonth, labAlertTagQueryRangeToDayOfMonth);
            }
            else
            {
                throw new Exception("Unknown lab sample range type: " + labAlertTagQueryRangeType);
            }

            LabAlertDefinition definition = new LabAlertDefinition(
                reader.Get<long?>("Id"),
                reader.Get<string>("Name"),
                reader.Get<string>("Description"),
                functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID")),
                tagDao.QueryById(reader.Get<long>("TagID")),
                reader.Get<int>("MinimumNumberOfSamples"),
                labAlertTagQueryRange,
                scheduleDao.QueryById(reader.Get<long>("ScheduleId")),
                reader.Get<bool>("IsActive"),
                userDao.QueryById(reader.Get<long>("LastModifiedByUserId")),
                reader.Get<DateTime>("LastModifiedDateTime"),
                userDao.QueryById(reader.Get<long>("CreatedByUserId")),
                reader.Get<DateTime>("CreatedDateTime"),
                LabAlertDefinitionStatus.Get(reader.Get<long>("LabAlertDefinitionStatusID")),                
                reader.Get<bool>("Deleted"));

            return definition;
        }

        private static void SetInsertUpdateAttributes(LabAlertDefinition definition, SqlCommand command)
        {
            command.AddParameter("@Name", definition.Name);
            command.AddParameter("@FunctionalLocationID", definition.FunctionalLocation.Id);
            command.AddParameter("@Description", definition.Description);
            command.AddParameter("@TagID", definition.TagInfo.Id);
            command.AddParameter("@MinimumNumberOfSamples", definition.MinimumNumberOfSamples);

            command.AddParameter("@LabAlertTagQueryRangeType", definition.LabAlertTagQueryRange.LabAlertTagQueryRangeType);
            command.AddParameter("@LabAlertTagQueryRangeFromTime", definition.LabAlertTagQueryRange.FromTime.ToDateTime());
            command.AddParameter("@LabAlertTagQueryRangeToTime", definition.LabAlertTagQueryRange.ToTime.ToDateTime());
            if (definition.LabAlertTagQueryRange is LabAlertTagQueryWeeklyRange)
            {
                LabAlertTagQueryWeeklyRange range = (LabAlertTagQueryWeeklyRange) definition.LabAlertTagQueryRange;
                command.AddParameter("@LabAlertTagQueryRangeFromDayOfWeek", range.FromDayOfWeek.Value);
                command.AddParameter("@LabAlertTagQueryRangeToDayOfWeek", range.ToDayOfWeek.Value);
            }
            else if (definition.LabAlertTagQueryRange is LabAlertTagQueryMonthlyDayOfWeekRange)
            {
                LabAlertTagQueryMonthlyDayOfWeekRange range = (LabAlertTagQueryMonthlyDayOfWeekRange)definition.LabAlertTagQueryRange;
                command.AddParameter("@LabAlertTagQueryRangeFromDayOfWeek", range.FromDayOfWeek.Value);
                command.AddParameter("@LabAlertTagQueryRangeToDayOfWeek", range.ToDayOfWeek.Value);
                command.AddParameter("@LabAlertTagQueryRangeFromWeekOfMonth", range.FromWeekOfMonth.Value);
                command.AddParameter("@LabAlertTagQueryRangeToWeekOfMonth", range.ToWeekOfMonth.Value);
            }
            else if (definition.LabAlertTagQueryRange is LabAlertTagQueryMonthlyDayOfMonthRange)
            {
                LabAlertTagQueryMonthlyDayOfMonthRange range = (LabAlertTagQueryMonthlyDayOfMonthRange)definition.LabAlertTagQueryRange;
                command.AddParameter("@LabAlertTagQueryRangeFromDayOfMonth", range.FromDayOfMonth.Value);
                command.AddParameter("@LabAlertTagQueryRangeToDayOfMonth", range.ToDayOfMonth.Value);
            }

            command.AddParameter("@LabAlertDefinitionStatusID", definition.Status.Id);
            command.AddParameter("@IsActive", definition.IsActive);

            command.AddParameter("@LastModifiedByUserId", definition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", definition.LastModifiedDate);
        }
    }
}