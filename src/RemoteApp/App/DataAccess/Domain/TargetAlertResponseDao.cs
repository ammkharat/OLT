using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class TargetAlertResponseDao : AbstractManagedDao, ITargetAlertResponseDao
    {
        private const string INSERT = "InsertTargetAlertResponse";
        private const string QUERY_BY_ALERT = "QueryTargetAlertResponsesByTargetAlertId";
        private const string QUERYGAPREASONS_BY_SHIFT_AND_DATERANGE = "QueryGapReasonsByShiftAndDateRange";
        private readonly ICommentDao commentDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IShiftPatternDao shiftPatternDao;

        public TargetAlertResponseDao()
                : this(DaoRegistry.GetDao<ICommentDao>(),
                       DaoRegistry.GetDao<IFunctionalLocationDao>(),
                       DaoRegistry.GetDao<IShiftPatternDao>()) {}

        private TargetAlertResponseDao(ICommentDao commentDao, IFunctionalLocationDao functionalLocationDao, IShiftPatternDao shiftPatternDao)
        {
            this.commentDao = commentDao;
            this.functionalLocationDao = functionalLocationDao;
            this.shiftPatternDao = shiftPatternDao;
        }
        
        public TargetAlertResponse Insert(TargetAlertResponse response)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(response, SetCommonAttributes, INSERT);
            response.Id = (long?) idParameter.Value;
            return response;
        }

        public List<TargetAlertResponse> QueryByTargetAlert(TargetAlert targetAlert)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TargetAlertId",  targetAlert.IdValue);
            var responsePopulator = new TargetAlertResponsePopulator(this, targetAlert);
            return command.QueryForListResult<TargetAlertResponse>(responsePopulator.PopulateInstance, QUERY_BY_ALERT);
        }

        public List<ShiftGapReasonReportDTO> QueryGapReasonsByShiftAndDateRange(IFlocSet flocSet,
                                                                                          ShiftPattern shiftPattern,
                                                                                          DateTime fromDateTime,
                                                                                          DateTime toDateTime)
        {
            string csvFunctionalLocationIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FlocIds", csvFunctionalLocationIds);
            command.AddParameter("@CreatedShiftPatternId",  shiftPattern.Id);
            command.AddParameter("@FromDateTime",  fromDateTime);
            command.AddParameter("@ToDateTime",  toDateTime);
            List<ShiftGapReasonReportDTO> result
                    = command.QueryForListResult<ShiftGapReasonReportDTO>(PopulateInstanceForShiftGapReasonReport, QUERYGAPREASONS_BY_SHIFT_AND_DATERANGE);
            return result;
        }

        private class TargetAlertResponsePopulator
        {
            private readonly TargetAlertResponseDao outer;
            private readonly TargetAlert targetAlert;

            public TargetAlertResponsePopulator(TargetAlertResponseDao outer, TargetAlert targetAlert)
            {
                this.outer = outer;
                this.targetAlert = targetAlert;
            }

            public TargetAlertResponse PopulateInstance(SqlDataReader reader)
            {
                long id = reader.Get<long>("Id");
                Comment comment = outer.commentDao.QueryById(reader.Get<long>("CommentId"));
                TargetGapReason targetGapReason = TargetGapReason.Get(reader.Get<long?>("TargetGapReasonId"));
                FunctionalLocation functionalLocation = ReadFunctionalLocation(reader);
                ShiftPattern createdShiftPattern = ReadShiftPattern(reader);
                var response = new TargetAlertResponse(targetAlert, comment, targetGapReason, functionalLocation,
                                                                       createdShiftPattern) {Id = id};
                return response;
            }

            private ShiftPattern ReadShiftPattern(SqlDataReader reader)
            {
                long? shiftPatternId = reader.Get<long?>("CreatedShiftPatternId");
                return shiftPatternId.HasValue ? outer.shiftPatternDao.QueryById(shiftPatternId.Value) : null;
            }

            private FunctionalLocation ReadFunctionalLocation(SqlDataReader reader)
            {
                long? functionalLocationId = reader.Get<long?>("ResponsibleFunctionalLocationId");
                return functionalLocationId.HasValue ? outer.functionalLocationDao.QueryById(functionalLocationId.Value) : null;
            }
        }

        private ShiftGapReasonReportDTO PopulateInstanceForShiftGapReasonReport(SqlDataReader reader)
        {
            string targetAlertUnit = reader.Get<string>("TargetAlertUnitName");
            string targetAlertUnitDescription = reader.Get<string>("TargetAlertUnitDescription");
            string targetAlertFloc = reader.Get<string>("TargetAlertFunctionalLocation");
            string targetAlertFlocDescription = reader.Get<string>("TargetAlertFunctionalLocationDescription");
            string targetAlertName = reader.Get<string>("TargetAlertName");

//            COMMENT: trg - this is ignored because these things are all part of the COMMENT and don't really have a
//                           way to get them effectively. Have restructured the report to try and provide better layout
//                           and see if that meets their needs.

//            PLUS THE VALUES CAN'T BE RETRIEVED FROM THE DB. AND RECALCULATING IS BAD
//            THE ACTUALVALUE READWRITE DATETIME DOESN'T CURRENTLY EXIST IN THE SYSTEM.
            string phdtagName = reader.Get<string>("TagName");
            string limitValue = string.Empty; //don't know how to get yet;
            string actualValue = string.Empty; //don't know how to get yet;
            DateTime actualValueReadDateTime = DateTime.Now.GetNetworkPortable(); //don't know how to get yet;
         
            string userName = reader.Get<string>("Username");
            string firstName = reader.Get<string>("Firstname");
            string lastName = reader.Get<string>("Lastname");
            string respondedBy = User.ToFullNameWithUserName(lastName, firstName, userName);
            DateTime respondedDateTime = reader.Get<DateTime>("RespondedDateTime");
            string targetGapReasonComment = reader.Get<string>("TargetGapReasonComment");

            string targetGapReason = null;
            long? targetGapReasonId = reader.Get<long?>("TargetGapReasonId");
            if (targetGapReasonId.HasValue)
            {
                TargetGapReason gapReason = TargetGapReason.Get(targetGapReasonId);
                if (gapReason != null)
                {
                    targetGapReason = gapReason.Name;
                }
            }

            long shiftId = reader.Get<long>("ShiftId");
            ShiftPattern shiftPattern = shiftPatternDao.QueryById(shiftId);
            DateTime startDateTime = respondedDateTime;
            UserShift userShift = new UserShift(shiftPattern, startDateTime);

            string shiftName = shiftPattern.Name;
            DateTime shiftStartDate = userShift.StartDateTime;

            return new ShiftGapReasonReportDTO(shiftName,
                                               shiftStartDate,
                                               targetAlertUnit,
                                               targetAlertUnitDescription,
                                               targetAlertFloc,
                                               targetAlertFlocDescription,
                                               targetAlertName,
                                               phdtagName,
                                               limitValue,
                                               actualValue,
                                               actualValueReadDateTime,
                                               respondedBy,
                                               respondedDateTime,
                                               targetGapReason,
                                               targetGapReasonComment);
        }

        private static void SetCommonAttributes(TargetAlertResponse response, SqlCommand command)
        {
            command.AddParameter("@TargetAlertId", response.Alert.Id);
            command.AddParameter("@CommentId", response.ResponseComment.Id);
            command.AddParameter("@TargetGapReasonId", GapReasonId(response));
            command.AddParameter("@CreatedShiftPatternId", response.CreatedInShiftPattern.Id);
            command.AddParameter("@ResponsibleFunctionalLocationId", ResponsibleFunctionalLocationId(response));
        }

        private static long? GapReasonId(TargetAlertResponse response)
        {
            if(response.GapReason == null)
            {
                return null;
            }
            return response.GapReason.IdValue == TargetGapReason.Null.IdValue ? null : response.GapReason.Id;
        }

        private static long? ResponsibleFunctionalLocationId(TargetAlertResponse response)
        {
            return response.ResponsibleForGap == null ? null : response.ResponsibleForGap.Id;
        }
    }
}