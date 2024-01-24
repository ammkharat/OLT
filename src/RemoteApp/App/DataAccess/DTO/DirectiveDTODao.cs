using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class DirectiveDTODao : AbstractManagedDao, IDirectiveDTODao
    {
        private readonly IUserDao userDao;

        public DirectiveDTODao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<DirectiveDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet,
            List<long> clientReadableVisibilityGroupIds, long? readByUserId)
        {
            var command = ManagedCommand;
            var queryDateRange = new DateRange(dateRange);
            var csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            command.AddParameter("@StartOfDateRange", queryDateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", queryDateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", csvFlocIds);
            command.AddParameter("@CsvVisibilityGroupIds",
                clientReadableVisibilityGroupIds == null
                    ? null
                    : clientReadableVisibilityGroupIds.ToCommaSeparatedString());
            if (readByUserId != null)
            {
                command.AddParameter("@ReadByUserId", readByUserId);
            }

            return GetDtos(command, "QueryDirectiveDTOByDateRangeAndFlocIds", readByUserId);
        }

       
        public List<MarkedAsReadReportDirectiveDTO> QueryByParentFlocListAndMarkedAsRead(DateTime fromDateTime,
            DateTime toDateTime, IFlocSet flocSet)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", fromDateTime);
            command.AddParameter("@EndOfDateRange", toDateTime);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.CommandText = "QueryDirectiveDTOsByParentFlocListAndMarkedAsRead";

            var result = new Dictionary<long, MarkedAsReadReportDirectiveDTO>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.Get<long>("DirectiveId");
                    if (result.ContainsKey(id))
                    {
                        var dto = result[id];
                        dto.AddReadByUser(GetReadByUser(reader));
                        dto.AddFunctionalLocation(GetFunctionalLocation(reader));

                        var assignment = GetAssignment(reader);
                        if (assignment != null)
                        {
                            dto.AddWorkAssignment(assignment);
                        }
                    }
                    else
                    {
                        result.Add(id, PopulateMarkedAsReadDtoInstance(reader));
                    }
                }
            }

            return new List<MarkedAsReadReportDirectiveDTO>(result.Values);
        }
        //Added by ppanigrahi
        public List<MarkedAsNotReadReportDirectiveDTO> QueryByParentFlocListAndMarkedAsNotRead(DateTime fromDateTime,
            DateTime toDateTime, IFlocSet flocSet)
        {
            var command = ManagedCommand;
            //command.AddParameter("@StartOfDateRange", fromDateTime);
            //command.AddParameter("@EndOfDateRange", toDateTime);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.CommandText = "QueryDirectiveDTOsByParentFlocListAndMarkedAsNotRead";

            var result = new Dictionary<long, MarkedAsNotReadReportDirectiveDTO>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.Get<long>("CreatedByUserID");
                    if (result.ContainsKey(id))
                    {
                        var dto = result[id];
                        dto.AddNotNotReadByUser(GetNotReadByUser(reader));
                        dto.AddFunctionalLocation(GetFunctionalLocation(reader));

                        //var assignment = GetAssignment(reader);
                        //if (assignment != null)
                        //{
                        //    dto.AddWorkAssignment(assignment);
                        //}
                    }
                    else
                    {
                        result.Add(id, PopulateMarkedAsNotReadDtoInstance(reader));
                    }
                }
            }

            return new List<MarkedAsNotReadReportDirectiveDTO>(result.Values);
        }

        private static List<DirectiveDTO> GetDtosForMergedSetions(SqlCommand command, string query, long? readByUserId)
        {
            var result = new Dictionary<long, DirectiveDTO>();

            command.CommandText = query;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.Get<long>("Id");
                    if (result.ContainsKey(id))
                    {
                        var dto = result[id];

                        var floc = GetFunctionalLocation(reader);
                        dto.AddFunctionalLocation(floc);

                        var assignment = GetAssignment(reader);
                        dto.AddWorkAssignment(assignment);
                    }
                    else
                    {
                        result.Add(id, PopulateInstanceForMergedSections(reader, readByUserId));
                    }
                }
            }

            return new List<DirectiveDTO>(result.Values);
        }

        private static List<DirectiveDTO> GetDtos(SqlCommand command, string query, long? readByUserId)
        {
            
            var result = new Dictionary<long, DirectiveDTO>();

            command.CommandText = query;
            using (var reader = command.ExecuteReader())
            {
                    while (reader.Read())
                    {
                        var id = reader.Get<long>("Id");
                        if (result.ContainsKey(id))
                        {
                            var dto = result[id];

                            var floc = GetFunctionalLocation(reader);
                            dto.AddFunctionalLocation(floc);

                            var assignment = GetAssignment(reader);
                            dto.AddWorkAssignment(assignment);
                        }
                        else
                        {
                            result.Add(id, PopulateInstance(reader, readByUserId));
                        }
                    }
                
            }

            return new List<DirectiveDTO>(result.Values);
        }

        private static string GetFunctionalLocation(SqlDataReader reader)
        {
            return reader.Get<string>("FunctionalLocation");
        }

        private static string GetAssignment(SqlDataReader reader)
        {
            return reader.Get<string>("WorkAssignment");
        }

        private static MarkedAsReadReportDirectiveDTO PopulateMarkedAsReadDtoInstance(SqlDataReader reader)
        {
            var activeFromDateTime = reader.Get<DateTime>("ActiveFromDateTime");
            var activeToDateTime = reader.Get<DateTime>("ActiveToDateTime");
            var lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName",
                "LastModifiedByUserName");

            var content = reader.Get<string>("PlainTextContent");
            var floc = GetFunctionalLocation(reader);
            var workAssignment = GetAssignment(reader);

            var assignments = new List<string>();
            if (workAssignment != null)
            {
                assignments.Add(workAssignment);
            }

            return new MarkedAsReadReportDirectiveDTO(
                activeFromDateTime,
                activeToDateTime,
                new List<string> {floc},
                assignments,
                lastModifiedByFullNameWithUserName,
                content,
                new List<ItemReadBy> {GetReadByUser(reader)});
        }
        //Added by ppanigrahi
        private MarkedAsNotReadReportDirectiveDTO PopulateMarkedAsNotReadDtoInstance(SqlDataReader reader)
        {
           

            MarkedAsNotReadReportDirectiveDTO dto = new MarkedAsNotReadReportDirectiveDTO(

                new List<ItemNotReadBy> { GetNotReadByUser(reader) });

            // MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto= new MarkedAsNotReadReportShiftHandoverQuestionnaireDTO(new List<ItemNotReadBy> { GetNotReadByUser(reader)} );
            return dto;
        }

        private static ItemReadBy GetReadByUser(SqlDataReader reader)
        {
            var first = reader.Get<string>("ReadByFirstName");
            var last = reader.Get<string>("ReadByLastName");
            var userName = reader.Get<string>("ReadByUserName");
            var fullName = User.ToFullNameWithUserName(last, first, userName);

            var dateTime = reader.Get<DateTime>("ReadByDateTime");

            return new ItemReadBy(fullName, dateTime);
        }
       //Added by ppanigrahi
        //Added by ppanigrahi
        private ItemNotReadBy GetNotReadByUser(SqlDataReader reader)
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

            return new ItemNotReadBy(fullName, Id);
        }
        private static DirectiveDTO PopulateInstance(SqlDataReader reader, long? readByUserId)
        {
           
                var id = reader.Get<long>("Id");

                var floc = GetFunctionalLocation(reader);
                var assignment = reader.Get<string>("WorkAssignment");
                var assignments = new List<string>();
                if (assignment != null)
                {
                    assignments.Add(assignment);
                }

                var activeFromDateTime = reader.Get<DateTime>("ActiveFromDateTime");
                var activeToDateTime = reader.Get<DateTime>("ActiveToDateTime");
                var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

                var createdByUserId = reader.Get<long>("CreatedByUserId");
                var createdByRoleId = reader.Get<long>("CreatedByRoleId");
                var lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

                var content = reader.Get<string>("PlainTextContent");
                var createdByWorkAssignmentName = reader.Get<string>("CreatedByWorkAssignmentName");

                var createdByFullNameWithUserName = User.ToFullNameWithUserName(reader.Get<string>("CreatedByLastName"),
                    reader.Get<string>("CreatedByFirstName"), reader.Get<string>("CreatedByUsername"));
                var lastModifiedByFullNameWithUserName =
                    User.ToFullNameWithUserName(reader.Get<string>("LastModifiedByLastName"),
                        reader.Get<string>("LastModifiedByFirstName"), reader.Get<string>("LastModifiedByUsername"));
                var lastModifiedByFullName = User.ToFullName(reader.Get<string>("LastModifiedByFirstName"),
                    reader.Get<string>("LastModifiedByLastName"));

                bool? hasBeenReadByQueryUser = null;
                if (readByUserId != null)
                {
                    hasBeenReadByQueryUser = reader.Get<long?>("ReadByUserId") != null;
                }

                var dto = new DirectiveDTO(id, assignments, new List<string> {floc}, activeFromDateTime, activeToDateTime, 
                    createdByUserId, createdByRoleId, createdDateTime, lastModifiedByUserId, content,
                    createdByFullNameWithUserName,
                    lastModifiedByFullName, lastModifiedByFullNameWithUserName, createdByWorkAssignmentName);

                dto.IsReadByCurrentUser = hasBeenReadByQueryUser;
                return dto;
           
        }

        private static DirectiveDTO PopulateInstanceForMergedSections(SqlDataReader reader, long? readByUserId)
        {
         
            var id = reader.Get<long>("Id");

            var floc = GetFunctionalLocation(reader);
            var assignment = reader.Get<string>("WorkAssignment");
            var assignments = new List<string>();
            if (assignment != null)
            {
                assignments.Add(assignment);
            }

            var activeFromDateTime = reader.Get<DateTime>("ActiveFromDateTime");
            var activeToDateTime = reader.Get<DateTime>("ActiveToDateTime");
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var createdByUserId = reader.Get<long>("CreatedByUserId");
            var createdByRoleId = reader.Get<long>("CreatedByRoleId");
            var lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            var content = reader.Get<string>("PlainTextContent");
            var createdByWorkAssignmentName = reader.Get<string>("CreatedByWorkAssignmentName");

            var createdByFullNameWithUserName = User.ToFullNameWithUserName(reader.Get<string>("CreatedByLastName"),
                reader.Get<string>("CreatedByFirstName"), reader.Get<string>("CreatedByUsername"));
            var lastModifiedByFullNameWithUserName =
                User.ToFullNameWithUserName(reader.Get<string>("LastModifiedByLastName"),
                    reader.Get<string>("LastModifiedByFirstName"), reader.Get<string>("LastModifiedByUsername"));
            var lastModifiedByFullName = User.ToFullName(reader.Get<string>("LastModifiedByFirstName"),
                reader.Get<string>("LastModifiedByLastName"));

            bool? hasBeenReadByQueryUser = null;
            if (readByUserId != null)
            {
                hasBeenReadByQueryUser = reader.Get<long?>("ReadByUserId") != null;
            }

            var dto = new DirectiveDTO(id, assignments, new List<string> { floc }, activeFromDateTime, activeToDateTime,              
                createdByUserId, createdByRoleId, createdDateTime, lastModifiedByUserId, content, createdByFullNameWithUserName,
                lastModifiedByFullName, lastModifiedByFullNameWithUserName, createdByWorkAssignmentName);

            dto.IsReadByCurrentUser = hasBeenReadByQueryUser;
            return dto;
        }

    }
}