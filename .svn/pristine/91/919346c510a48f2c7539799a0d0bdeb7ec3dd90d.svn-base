using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetAlertDao : AbstractManagedDao, ITargetAlertDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryTargetAlertByID";
        private const string QUERY_BY_TARGET_DEFINITION_AND_STATUSES_STORED_PROCEDURE = "QueryTargetAlertsByDefinitionAndStatuses";
        private const string QUERY_BY_FLOC_AND_USER_SHIFT = "QueryTargetAlertsByFunctionalLocationsAndUserShift";
        private const string QUERY_ALL_TARGET_ALERTS_NEEDING_ATTENTION = "QueryAllTargetAlertsNeedingAttention";
        private const string INSERT_STORED_PROCEDURE = "InsertTargetAlert";
        private const string UPDATE_STORED_PROCEDURE = "UpdateTargetAlert";

        private readonly ITargetDefinitionDao targetDefinitionDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ITagDao tagDao;
        private readonly IUserDao userDao;
        private readonly IDocumentLinkDao documentLinkDao;

        public TargetAlertDao()
        {
            targetDefinitionDao = DaoRegistry.GetDao<ITargetDefinitionDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public TargetAlert QueryById(long id)
        {
            return ManagedCommand.QueryById<TargetAlert>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<TargetAlert> QueryByTargetDefinitionAndStatuses(TargetDefinition definition,
                                                                              List<TargetAlertStatus> statuses)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@TargetDefinitionId", definition.Id);
            command.AddParameter("@StatusIds", statuses.BuildIdStringFromList());

            return command.QueryForListResult<TargetAlert>(PopulateInstance, QUERY_BY_TARGET_DEFINITION_AND_STATUSES_STORED_PROCEDURE);
        }

        public List<TargetAlert> QueryAllTargetAlertsNeedingAttention(List<FunctionalLocation> functionalLocations, List<TargetAlertStatus> statuses)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", functionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvStatusIds", statuses.BuildIdStringFromList());
            return command.QueryForListResult<TargetAlert>(PopulateInstance, QUERY_ALL_TARGET_ALERTS_NEEDING_ATTENTION);
        }

        public List<TargetAlert> QueryByFunctionalLocationsAndUserShift(
            IFlocSet flocSet, UserShift userShift)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTime);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTime);
            return command.QueryForListResult<TargetAlert>(PopulateInstance, QUERY_BY_FLOC_AND_USER_SHIFT);
        }

        public TargetAlert Insert(TargetAlert target)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(target, AddInsertParameters, INSERT_STORED_PROCEDURE);
            target.Id = long.Parse(idParameter.Value.ToString());
            InsertNewDocumentLinks(target);
            return target;
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject target)
        {
            documentLinkDao.InsertNewDocumentLinks(target, documentLinkDao.InsertForAssociatedTargetAlert);
        }

        public void Update(TargetAlert targetAlert)
        {
            ManagedCommand.Update(targetAlert, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
        }

        private static void AddUpdateParameters(TargetAlert alert, SqlCommand command)
        {
            command.AddParameter("@Id", alert.Id);
            command.AddParameter("@AcknowledgedUserId", 
                                            (alert.AcknowledgedUser == null ? null : alert.AcknowledgedUser.Id));
            command.AddParameter("@AcknowledgedDateTime", alert.AcknowledgedDateTime);
            SetCommonAttributes(alert, command);
        }

        private static void AddInsertParameters(TargetAlert alert, SqlCommand command)
        {
            command.AddParameter("@TargetDefinitionId",  alert.TargetDefinition.Id);
            command.AddParameter("@CreatedDateTime",  alert.CreatedDateTime);
            command.AddParameter("@CreatedByScheduleTypeId",  alert.CreatedByScheduleType.Id);

            command.AddParameter("@TargetName", alert.TargetName);
            command.AddParameter("@NeverToExceedMaxFrequency",  alert.NeverToExceedMaxFrequency);
            command.AddParameter("@NeverToExceedMinFrequency",  alert.NeverToExceedMinFrequency);
            command.AddParameter("@MaxValueFrequency",  alert.MaxValueFrequency);
            command.AddParameter("@MinValueFrequency",  alert.MinValueFrequency);

            command.AddParameter("@TagID",  alert.Tag.Id);
            command.AddParameter("@FunctionalLocationID",  alert.FunctionalLocation.Id);

            command.AddParameter("@TargetCategoryID",  alert.Category.Id);
            command.AddParameter("@RequiresResponse",  alert.RequiresResponse);
            command.AddParameter("@PriorityId",  alert.Priority.Id);
            command.AddParameter("@OriginalExceedingValue",  alert.OriginalExceedingValue);

            SetCommonAttributes(alert, command);
        }

        private static void SetCommonAttributes(TargetAlert targetAlert, SqlCommand command)
        {
            command.AddParameter("@TargetAlertStatusID", targetAlert.Status.Id);
            command.AddParameter("@ExceedingBoundaries", targetAlert.ExceedingBoundaries);
            command.AddParameter("@ActualValue", targetAlert.ActualValue);
            command.AddParameter("@LastModifiedDateTime", targetAlert.LastModifiedDateTime);

            command.AddParameter("@MaxValue", targetAlert.MaxValue);
            command.AddParameter("@NeverToExceedMax", targetAlert.NeverToExceedMaximum);
            command.AddParameter("@MinValue", targetAlert.MinValue);
            command.AddParameter("@NeverToExceedMin", targetAlert.NeverToExceedMinimum);
            targetAlert.TargetValue.Do(new SetTargetValueParameters(command.Parameters));
            command.AddParameter("@GapUnitValue", targetAlert.GapUnitValue);
            command.AddParameter("@Description", targetAlert.Description);

            command.AddParameter("@TypeOfViolationStatusId", targetAlert.TypeOfViolationStatus.IdValue);
            command.AddParameter("@LastViolatedDateTime", targetAlert.LastViolatedDateTime);
            command.AddParameter("@MaxAtEvaluation", targetAlert.MaxAtEvaluation);
            command.AddParameter("@MinAtEvaluation", targetAlert.MinAtEvaluation);
            command.AddParameter("@NTEMaxAtEvaluation", targetAlert.NTEMaxAtEvaluation);
            command.AddParameter("@NTEMinAtEvaluation", targetAlert.NTEMinAtEvaluation);
            command.AddParameter("@ActualValueAtEvaluation", targetAlert.ActualValueAtEvaluation);

            if (targetAlert.LastModifiedBy != null)
            {
                command.AddParameter("@LastModifiedUserId", targetAlert.LastModifiedBy.Id);
            }
        }

        private TargetAlert PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            TargetDefinition targetDefinition = targetDefinitionDao.QueryById(reader.Get<long>("TargetDefinitionId"));
            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationID"));
            TagInfo tagInfo = tagDao.QueryById(reader.Get<long>("TagID"));
            string targetName = reader.Get<string>("TargetName");
            decimal? neverToExceedMaximum = reader.Get<decimal?>("NeverToExceedMax");
            decimal? neverToExceedMinimum = reader.Get<decimal?>("NeverToExceedMin");
            decimal? maxValue = reader.Get<decimal?>("MaxValue");
            decimal? minValue = reader.Get<decimal?>("MinValue");
            int? neverToExceedMaxFrequency = reader.Get<int?>("NeverToExceedMaxFrequency");
            int? neverToExceedMinFrequency = reader.Get<int?>("NeverToExceedMinFrequency");
            int? maxValueFrequency = reader.Get<int?>("MaxValueFrequency");
            int? minValueFrequency = reader.Get<int?>("MinValueFrequency");
            TargetValue targetValue = ReadTargetValue(reader);
            decimal? gapUnitValue = reader.Get<decimal?>("GapUnitValue");
            string description = reader.Get<string>("Description");
            decimal? actualValue = reader.Get<decimal?>("ActualValue");
            decimal? originalExceedingValue = reader.Get<decimal?>("OriginalExceedingValue");
            bool requiresResponse = reader.Get<bool>("RequiresResponse");
            TargetCategory targetCategory = TargetCategory.GetTargetCategory(reader.Get<long>("TargetCategoryID"));
            ScheduleType createdByScheduleType = ScheduleType.GetById(reader.Get<int>("CreatedByScheduleTypeId"));
            TargetAlertStatus targetAlertStatus = TargetAlertStatus.Get(reader.Get<long>("TargetAlertStatusID"));
            Priority priority = Priority.GetById(reader.Get<long>("PriorityId"));
            bool exceedingBoundaries = reader.Get<bool>("ExceedingBoundaries");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            User lastModifiedBy = ReadLastModifiedBy(reader, "LastModifiedUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            User acknowledgedUser = AssignUser(reader.Get<long?>("AcknowledgedUserId"));
            DateTime? acknowledgedDateTime = reader.Get<DateTime?>("AcknowledgedDateTime");

            int statusIdAsInt = reader.Get<int>("TypeOfViolationStatusId");
            long statusIdAsLong = statusIdAsInt;
            TargetAlertStatus typeOfViolationStatusId = TargetAlertStatus.Get(statusIdAsLong);
            DateTime lastViolatedDateTime = reader.Get<DateTime>("LastViolatedDateTime");
            decimal? maxAtEvaluation = reader.Get<decimal?>("MaxAtEvaluation");
            decimal? minAtEvaluation = reader.Get<decimal?>("MinAtEvaluation");
            decimal? nteMaxAtEvaluation = reader.Get<decimal?>("NTEMaxAtEvaluation");
            decimal? nteMinAtEvaluation = reader.Get<decimal?>("NTEMinAtEvaluation");
            decimal? actualValueAtEvaluation = reader.Get<decimal?>("ActualValueAtEvaluation");

            List<DocumentLink> documentLinks = documentLinkDao.QueryByTargetAlertId(id.Value);

            TargetAlert result = new TargetAlert(targetDefinition,
                                                 functionalLocation,
                                                 tagInfo,
                                                 targetName,
                                                 description,
                                                 createdDateTime,
                                                 lastModifiedBy,
                                                 lastModifiedDateTime,
                                                 acknowledgedUser,
                                                 acknowledgedDateTime,
                                                 neverToExceedMaximum,
                                                 neverToExceedMinimum,
                                                 maxValue,
                                                 minValue,
                                                 neverToExceedMaxFrequency,
                                                 neverToExceedMinFrequency,
                                                 maxValueFrequency,
                                                 minValueFrequency,
                                                 targetValue,
                                                 gapUnitValue,
                                                 actualValue,
                                                 originalExceedingValue,
                                                 createdByScheduleType,
                                                 targetAlertStatus,
                                                 priority,
                                                 targetCategory,
                                                 exceedingBoundaries,
                                                 requiresResponse,
                                                 typeOfViolationStatusId,
                                                 lastViolatedDateTime,
                                                 maxAtEvaluation,
                                                 minAtEvaluation,
                                                 nteMaxAtEvaluation,
                                                 nteMinAtEvaluation,
                                                 actualValueAtEvaluation,
                                                 documentLinks) {Id = id};
            return result;
        }

        private User AssignUser(long? userId)
        {
            return (userId.HasValue ? userDao.QueryById(userId.Value) : null);
        }

        private static TargetValue ReadTargetValue(SqlDataReader reader)
        {
            long targetValueTypeId = reader.Get<long>("TargetValueTypeId");
            decimal? targetValue = reader.Get<decimal?>("TargetAlertValue");
            return TargetValueType.ToTargetValue(targetValueTypeId, targetValue);
        }

        private User GetUser(SqlDataReader reader, string userIdColumn)
        {
            long? userId = reader.Get<long?>(userIdColumn);
            return userId.HasValue ? userDao.QueryById(userId.Value) : null;
        }

        private User ReadLastModifiedBy(SqlDataReader reader, string columnName)
        {
            return GetUser(reader, columnName);
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
                parameters.AddWithValue("@TargetAlertValue", specifiedValue);
            }
        }
    }
}