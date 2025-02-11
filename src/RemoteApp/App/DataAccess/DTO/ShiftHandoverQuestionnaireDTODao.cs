using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class ShiftHandoverQuestionnaireDTODao : AbstractManagedDao, IShiftHandoverQuestionnaireDTODao
    {
        private const string QUERY_BY_FLOC_AND_ASSIGNMENT = "QueryShiftHandoverQuestionnaireDTOsByFunctionalLocationAndAssignment";
        private const string QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ = "QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsRead";
        private const string QUERY_BY_FLOC_AND_SHIFT_YES_ANSWERS_ONLY = "QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFunctionalLocationAndShift";
        private const string QUERY_BY_FLOC_AND_DATE_RANGE_YES_ANSWERS_ONLY = "QueryShiftHandoverQuestionnaireDTOsWithYesAnswersByFunctionalLocationAndDateRange";
        private const string QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ_FOR_ISFLEXIBLE_DATA = "QueryFlexiShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsRead";

        private const string QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_NOTREAD = "QueryShiftHandoverQuestionnaireDTOsByParentFlocListAndMarkedAsNotRead";//Added by ppanigrahi

        

        private readonly IShiftHandoverAnswerDao answerDao;
        private readonly  IUserDao userDao ;
        

        public ShiftHandoverQuestionnaireDTODao()
        {
            answerDao = DaoRegistry.GetDao<IShiftHandoverAnswerDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocation(IFlocSet flocSet, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@IncludeAssignmentInCondition", false);
            command.AddParameter("@WorkAssignmentId", null);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());
            if (readByUserId.HasValue)
            {
                command.AddParameter("@ReadByUserId", readByUserId);
            }            
            return GetDtos(command, flocSet.Site, QUERY_BY_FLOC_AND_ASSIGNMENT, readByUserId);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocationAndAssignment(IFlocSet flocSet, long? workAssignmentId, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@IncludeAssignmentInCondition", true);
            command.AddParameter("@WorkAssignmentId", workAssignmentId.HasValue ? workAssignmentId : null);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());
            if (readByUserId.HasValue)
            {
                command.AddParameter("@ReadByUserId", readByUserId.Value);
            }
            return GetDtos(command, flocSet.Site, QUERY_BY_FLOC_AND_ASSIGNMENT, readByUserId);
        }


        //Added for View shifthandover based on rolepermission
        public List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocation(IFlocSet flocSet, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds, long? RoleId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@IncludeAssignmentInCondition", false);
            command.AddParameter("@WorkAssignmentId", null);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            command.AddParameter("@RoleId", RoleId);

            if (readByUserId.HasValue)
            {
                command.AddParameter("@ReadByUserId", readByUserId);
            }
            return GetDtos(command, flocSet.Site, QUERY_BY_FLOC_AND_ASSIGNMENT, readByUserId);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryByFunctionalLocationAndAssignment(IFlocSet flocSet, long? workAssignmentId, DateRange dateRange, long? readByUserId, List<long> readableVisibilityGroupIds, long? RoleId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@IncludeAssignmentInCondition", true);
            command.AddParameter("@WorkAssignmentId", workAssignmentId.HasValue ? workAssignmentId : null);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());
            command.AddParameter("@RoleId", RoleId);
            if (readByUserId.HasValue)
            {
                command.AddParameter("@ReadByUserId", readByUserId.Value);
            }
            return GetDtos(command, flocSet.Site, QUERY_BY_FLOC_AND_ASSIGNMENT, readByUserId);
        }
        //end

        public List<ShiftHandoverQuestionnaireDTO> QueryOnesWithYesAnswersByFunctionalLocationAndShift(RootFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@ShiftPatternId", userShift.ShiftPatternId);

            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTimeWithPadding);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTimeWithPadding);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return GetDtos(command, flocSet.Site, QUERY_BY_FLOC_AND_SHIFT_YES_ANSWERS_ONLY, null);
        }

        public List<ShiftHandoverQuestionnaireDTO> QueryOnesWithYesAnswersByFunctionalLocationAndDateRange(RootFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());

            command.AddParameter("@StartDateTime", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndDateTime", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return GetDtos(command, flocSet.Site, QUERY_BY_FLOC_AND_DATE_RANGE_YES_ANSWERS_ONLY, null);
        }

        private static List<ShiftHandoverQuestionnaireDTO> GetDtos(SqlCommand command, Site site, string query, long? readByUserId)
        {
            Dictionary<long, ShiftHandoverQuestionnaireDTO> result = new Dictionary<long, ShiftHandoverQuestionnaireDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        ShiftHandoverQuestionnaireDTO dto = result[id];
                        dto.AddVisibilityGroup(GetVisibilityGroupName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader, site, readByUserId));
                    }
                }
            }

            return new List<ShiftHandoverQuestionnaireDTO>(result.Values);
        }

        private static ShiftHandoverQuestionnaireDTO PopulateInstance(SqlDataReader reader, Site site, long? readByUserId)
        {
            long id = GetId(reader);

            UserShift userShift = GetUserShift(reader, site);
            
            Date createdShiftStartDate = userShift.StartDate;
            Date createdShiftEndDate = userShift.EndDate;

            bool? hasBeenReadByQueryUser = null;
            long? readByUserIdInDb = reader.Get<long?>("ReadByUserId");
            if (readByUserId != null)
            {
                hasBeenReadByQueryUser = readByUserIdInDb.HasValue;
            }

            ShiftPattern shiftPattern = userShift.ShiftPattern;

            ShiftHandoverQuestionnaireDTO definition = new ShiftHandoverQuestionnaireDTO(
                id,
                GetShiftHandoverConfigurationName(reader),
                GetFunctionalLocationName(reader),
                shiftPattern.IdValue,
                shiftPattern.Name,
                reader.Get<long?>("AssignmentId"),
                GetAssignmentName(reader),
                GetCreateUserFirstName(reader),
                GetCreateUserLastName(reader),
                GetCreateUserUserName(reader),
                GetCreateDateTime(reader),
                createdShiftStartDate,
                createdShiftEndDate,
                reader.Get<long>("CreatedByUserId"),
                hasBeenReadByQueryUser,
                reader.Get<bool>("HasYesAnswer"),
                new List<string> { GetVisibilityGroupName(reader) }, GetIsFlexibleShiftHandovervalue(reader)
                , GetIsFlexibleShiftStartDate(reader)
                , GetIsFlexibleShiftEnddate(reader));

            return definition;
        }

        private static string GetAssignmentDescription(SqlDataReader reader)
        {
            return reader.Get<string>("AssignmentDescription");
        }

        private static string GetAssignmentName(SqlDataReader reader)
        {
            return reader.Get<string>("AssignmentName");
        }

        private static string GetCreateUserFullNameWithUserName(SqlDataReader reader)
        {
            string lastModifiedLastName = GetCreateUserLastName(reader);
            string lastModifiedFirstName = GetCreateUserFirstName(reader);
            string lastModifiedUserName = GetCreateUserUserName(reader);
            return User.ToFullNameWithUserName(lastModifiedLastName, lastModifiedFirstName, lastModifiedUserName);
        }

        private static string GetCreateUserUserName(SqlDataReader reader)
        {
            return reader.Get<string>("CreatedByUserName");
        }

        private static string GetCreateUserFirstName(SqlDataReader reader)
        {
            return reader.Get<string>("CreatedByFirstName");
        }

        private static string GetCreateUserLastName(SqlDataReader reader)
        {
            return reader.Get<string>("CreatedByLastName");
        }

        private static UserShift GetUserShift(SqlDataReader reader, Site site)
        {
            long shiftId = reader.Get<long>("ShiftId");
            string shiftName = reader.Get<string>("ShiftName");
            Time shiftStartTime = new Time(reader.Get<TimeSpan>("ShiftStartTime"));
            Time shiftEndTime = new Time(reader.Get<TimeSpan>("ShiftEndTime"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            TimeSpan preShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PreShiftPaddingInMinutes"), 0);
            TimeSpan postShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PostShiftPaddingInMinutes"), 0);

            ShiftPattern logShiftPattern = new ShiftPattern
                (shiftId,
                 shiftName,
                 shiftStartTime, shiftEndTime,
                 LogDTODao.DONT_CARE_SHIFT_CREATION_DATE,
                 site,
                 preShiftPaddingInMinutes, postShiftPaddingInMinutes
                );

            return new UserShift(logShiftPattern, createdDateTime);
        }

        private static DateTime GetCreateDateTime(SqlDataReader reader)
        {
            return reader.Get<DateTime>("CreatedDateTime");
        }

        private static string GetShiftHandoverConfigurationName(SqlDataReader reader)
        {
            return reader.Get<string>("ShiftHandoverConfigurationName");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static string GetVisibilityGroupName(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupName");
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }
        //Added by Ppanigrahi
        private static long GetUserId(SqlDataReader reader)
        {
            return reader.Get<long>("CreatedByUserID");
        }
        private static bool GetIsFlexibleShiftHandovervalue(SqlDataReader reader)
        {
            return reader.Get<bool>("IsFlexible");
        }
        private static DateTime GetIsFlexibleShiftStartDate(SqlDataReader reader)
        {
            return reader.Get<DateTime>("FlexiShiftStartDate");
        }
        private static DateTime GetIsFlexibleShiftEnddate(SqlDataReader reader)
        {
            return reader.Get<DateTime>("FlexiShiftEndDate");
        }

        /*flexi shift handover added ana extra param (showFlexiShiftDataonly) to get flexi shift data only or shift handover data only RITM0185797*/
        public List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> QueryByParentFlocListAndMarkedAsRead(
            Site site, DateTime from, DateTime to, IFlocSet flocSet, bool showFlexiShiftDataonly)
        {
            Dictionary<long, MarkedAsReadReportShiftHandoverQuestionnaireDTO> result = GetMarkedAsReadQuestionnaires(site, from, to, flocSet, showFlexiShiftDataonly);

            List<ShiftHandoverAnswerDTO> answers = answerDao.QueryByParentFlocListAndMarkedAsRead(from, to, flocSet, showFlexiShiftDataonly);
            foreach (ShiftHandoverAnswerDTO answer in answers)
            {
                long key = answer.QuestionnaireId;
                if (result.ContainsKey(key))
                {
                    result[key].Answers.Add(answer);
                }
            }

            return new List<MarkedAsReadReportShiftHandoverQuestionnaireDTO>(result.Values);
        }
        //Added by ppanigrahi
        public List<MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> QueryByParentFlocListAndMarkedAsNotRead(
           Site site, DateTime from, DateTime to, IFlocSet flocSet)
        {
            Dictionary<long, MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> result = GetMarkedAsNotReadQuestionnaires(site, from, to, flocSet);

            //List<ShiftHandoverAnswerDTO> answers = answerDao.QueryByParentFlocListAndMarkedAsRead(from, to, flocSet, showFlexiShiftDataonly);
            //foreach (ShiftHandoverAnswerDTO answer in answers)
            //{
            //    long key = answer.QuestionnaireId;
            //    if (result.ContainsKey(key))
            //    {
            //        result[key].Answers.Add(answer);
            //    }
            //}

            return new List<MarkedAsNotReadReportShiftHandoverQuestionnaireDTO>(result.Values);
        }


        /*flexi shift handover added ana extra param (showFlexiShiftDataonly) to get flexi shift data only or shift handover data only RITM0185797*/
        private Dictionary<long, MarkedAsReadReportShiftHandoverQuestionnaireDTO> GetMarkedAsReadQuestionnaires(Site site, DateTime from, DateTime to, IFlocSet flocSet, bool showFlexiShiftDataonly)
        {
            Dictionary<long, MarkedAsReadReportShiftHandoverQuestionnaireDTO> result = new Dictionary<long, MarkedAsReadReportShiftHandoverQuestionnaireDTO>();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@StartOfDateRange", from);
            command.AddParameter("@EndOfDateRange", to);
            if (showFlexiShiftDataonly)
            {command.CommandText = QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ_FOR_ISFLEXIBLE_DATA;}
            else
            {command.CommandText = QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ;}

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = result[id];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));
                        dto.AddReadByUser(GetReadByUser(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateMarkedAsReadDtoInstance(reader, site));
                    }
                }
            }
            return result;
        }
        //Added by ppanigrahi
        private Dictionary<long, MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> GetMarkedAsNotReadQuestionnaires(Site site, DateTime from, DateTime to, IFlocSet flocSet)
        {
            Dictionary<long, MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> result = new Dictionary<long, MarkedAsNotReadReportShiftHandoverQuestionnaireDTO>();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
           // command.AddParameter("@StartOfDateRange", from);
           // command.AddParameter("@EndOfDateRange", to);
            command.CommandText = QUERY_BY_PARENT_FLOC_LIST_AND_MARKED_AS_NOTREAD; 

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetUserId(reader);
                    if (result.ContainsKey(id))
                    {
                        MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto = result[id];
                       // dto.AddFunctionalLocation(GetFunctionalLocationName(reader));
                        dto.AddReadByUser(GetNotReadByUser(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateMarkedAsNotReadDtoInstance(reader, site));
                    }
                }
            }
            return result;
        }

        private static MarkedAsReadReportShiftHandoverQuestionnaireDTO PopulateMarkedAsReadDtoInstance(SqlDataReader reader, Site site)
        {
            string createUserFullNameWithUserName = GetCreateUserFullNameWithUserName(reader);

            UserShift userShift = GetUserShift(reader, site);
            Date createdShiftStartDate = userShift.StartDate;
            string shiftDisplayName =  String.Format("{0} - {1}", createdShiftStartDate, userShift.ShiftPattern.Name);

            if (GetIsFlexibleShiftHandovervalue(reader))
            {
                shiftDisplayName = String.Format("{0} - {1} - F", GetIsFlexibleShiftStartDate(reader).ToDate(), GetIsFlexibleShiftEnddate(reader).ToDate());
            }
            else
            {
                shiftDisplayName = String.Format("{0} - {1}", createdShiftStartDate, userShift.ShiftPattern.Name);
            }
            
            
            MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = new MarkedAsReadReportShiftHandoverQuestionnaireDTO(
                GetShiftHandoverConfigurationName(reader),
                GetCreateDateTime(reader),
                shiftDisplayName,
                createUserFullNameWithUserName,
                WorkAssignment.GetDisplayName(GetAssignmentName(reader), GetAssignmentDescription(reader)),
                GetFunctionalLocationName(reader),
                new List<ItemReadBy> { GetReadByUser(reader) });

            return dto;
        }
        //Added by ppanigrahi
        private  MarkedAsNotReadReportShiftHandoverQuestionnaireDTO PopulateMarkedAsNotReadDtoInstance(SqlDataReader reader, Site site)
        {
         //  string createUserFullNameWithUserName = GetCreateUserFullNameWithUserName(reader);

         // UserShift userShift = GetUserShift(reader, site);
         // Date createdShiftStartDate = userShift.StartDate;
         //string shiftDisplayName = String.Format("{0} - {1}", createdShiftStartDate, userShift.ShiftPattern.Name);

         //if (GetIsFlexibleShiftHandovervalue(reader))
         //{
         //    shiftDisplayName = String.Format("{0} - {1} - F", GetIsFlexibleShiftStartDate(reader).ToDate(), GetIsFlexibleShiftEnddate(reader).ToDate());
         //}
         //else
         //{
         //    shiftDisplayName = String.Format("{0} - {1}", createdShiftStartDate, userShift.ShiftPattern.Name);
         //}


         MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto = new MarkedAsNotReadReportShiftHandoverQuestionnaireDTO(
            
             new List<ItemNotReadBy> { GetNotReadByUser(reader) });

           // MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto= new MarkedAsNotReadReportShiftHandoverQuestionnaireDTO(new List<ItemNotReadBy> { GetNotReadByUser(reader)} );
            return dto;
        }

        private static ItemReadBy GetReadByUser(SqlDataReader reader)
        {
            string first = reader.Get<string>("ReadByFirstName");
            string last = reader.Get<string>("ReadByLastName");
            string userName = reader.Get<string>("ReadByUserName");
            string fullName = User.ToFullNameWithUserName(last, first, userName);

            DateTime dateTime = reader.Get<DateTime>("ReadByDateTime");

            return new ItemReadBy(fullName, dateTime);
        }
        //Added by ppanigrahi
        private  ItemNotReadBy GetNotReadByUser(SqlDataReader reader)
        {
            string Id = reader.Get<Int64>("CreatedByUserId").ToString();
           // string last = reader.Get<string>("CreatedByLastName");
            //string userName = reader.Get<string>("CreatedByUserName");
          //  string first = reader.Get<string>("CreatedByFirstName");
             User user = userDao.QueryById(long.Parse(Id));
            string last = user.LastName;
            string first = user.FirstName;
           string userName = user.Username;
            string fullName = User.ToFullNameWithUserName(last, first, userName);
           // string userid = null;

           // DateTime dateTime = reader.Get<DateTime>("ReadByDateTime");

            return new ItemNotReadBy(fullName,Id);
        }
    }
}