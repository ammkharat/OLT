using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class LogDefinitionDTODao : AbstractManagedDao, ILogDefinitionDTODao
    {
        private const string QUERY_BY_FLOCS_AND_LOGTYPE = "QueryLogDefinitionDTOsByFLOCIDsAndLogType";
        private const string QUERY_BY_USER_ROOT_FLOC_DIRECT_ANCESTORS_AND_DESCENDANTS = "QueryLogDefinitionDTOByUserRootFlocDirectAncestorsAndDescendants";

        public List<LogDefinitionDTO> QueryByFunctionalLocationsAndLogType(IFlocSet flocSet, LogType logType, List<long> readableVisibilityGroupIds)
        {
            string csvFunctionalLocationIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvIds", csvFunctionalLocationIds);
            command.AddParameter("@LogType", logType);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return GetDtos(command, QUERY_BY_FLOCS_AND_LOGTYPE);
        }

        public List<LogDefinitionDTO> QueryByUserRootFlocsAndLogType(IFlocSet flocSet, LogType logType, List<long> readableVisibilityGroupIds)
        {
            string csvFunctionalLocationIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFLOCIds", csvFunctionalLocationIds);
            command.AddParameter("@LogType", logType);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return GetDtos(command, QUERY_BY_USER_ROOT_FLOC_DIRECT_ANCESTORS_AND_DESCENDANTS);
        }

        private static List<LogDefinitionDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, LogDefinitionDTO> result = new Dictionary<long, LogDefinitionDTO>();
            command.CommandText = query;

            command.QueryForListResult(ex => { return; }, reader =>
                {
                    long id = reader.Get<long>("LogId");
                    if (result.ContainsKey(id))
                    {
                        LogDefinitionDTO dto = result[id];
                        dto.AddFunctionalLocation(reader.Get<string>("FunctionalLocationName"));
                        dto.AddVisibilityGroup(GetVisibilityGroupName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                });

            return new List<LogDefinitionDTO>(result.Values);
        }

        private static string GetVisibilityGroupName(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupName");
        }

        private static LogDefinitionDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("LogId");
            string functionalLocationName = reader.Get<string>("FunctionalLocationName");
            long? lastModifiedByUserId = reader.Get<long?>("LastModifiedUserId");
            string lastModifiedByFirstName = reader.Get<string>("LastModifiedByFirstName");
            string lastModifiedByLastName = reader.Get<string>("LastModifiedByLastName");
            string lastModifiedByUserName = reader.Get<string>("LastModifiedByUserName");
            string lastModifiedByFullNameWithUserName = User.ToFullNameWithUserName(lastModifiedByLastName, lastModifiedByFirstName, lastModifiedByUserName);
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            ISchedule schedule = ScheduleDao.PopulateScheduleInstanceForDTO(reader);
            bool isOperatingEngineerLog = reader.Get<bool>("IsOperatingEngineerLog");
            long createdByUserId = reader.Get<long>("CreatedBy");
            long createdByRoleId = reader.Get<long>("CreatedByRoleId");
            string allComments = reader.Get<string>("PlainTextComments");
            byte type = reader.Get<byte>("LogType");
            bool isActive = reader.Get<bool>("Active");

            LogType logType = type.ToEnum<LogType>();

            LogDefinitionDTO result = new LogDefinitionDTO
                (
                id,
                allComments,
                lastModifiedByUserId,
                lastModifiedByFullNameWithUserName,
                schedule,
                new List<string> { functionalLocationName },
                createdDateTime,
                isOperatingEngineerLog,
                createdByRoleId,
                createdByUserId,
                logType,
                isActive,
                new List<string> { GetVisibilityGroupName(reader) });

            return result;
        }
    }
}