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
    public class ActionItemDefinitionDTODao : AbstractManagedDao, IActionItemDefinitionDTODao
    {
        private const string QUERY_BY_CSV_FUNCTIONALLOCATION_IDS = "QueryActionItemDefinitionDTOsByFLOCIDs";

        //ayman action item definition
        private const string QUERY_BY_CSV_ActionItemDef_IDS_RelatedToActionItems = "QueryActionItemDefinitionDTOsByActionItemDefIDs";


        private const string QUERY_BY_TARGET_DEFINITION_ID = "QueryActionItemDefinitionDTOsByTargetDefinitionId";
        
        public List<ActionItemDefinitionDTO> QueryByActionItemDefinitions(
           List<long> aidSet, List<long> readableVisibilityGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvDefIds", aidSet.ToCommaSeparatedString());
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return GetDtos(command, QUERY_BY_CSV_ActionItemDef_IDS_RelatedToActionItems);
        }

        //********************** end ***************************************





        public List<ActionItemDefinitionDTO> QueryByFunctionalLocations(
            IFlocSet flocSet, DateTime? fromDate, DateTime? toDate, List<long> readableVisibilityGroupIds)
        {
            if (fromDate.HasNoValue())
            {
                fromDate = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            if (toDate.HasNoValue())
            {
                toDate = DateTimeExtensions.CreateSQLServerFriendlyMaxDate();
            }

            string csvFunctionalLocationIds =
                flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            command.AddParameter("@StartOfDateRange", fromDate);
            command.AddParameter("@EndOfDateRange", toDate);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return GetDtos(command, QUERY_BY_CSV_FUNCTIONALLOCATION_IDS);
        }

        public List<ActionItemDefinitionDTO> QueryByTargetDefinitionId(long? targetId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", targetId);
            return GetDtos(command, QUERY_BY_TARGET_DEFINITION_ID);
        }

        private List<ActionItemDefinitionDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, ActionItemDefinitionDTO> result = new Dictionary<long, ActionItemDefinitionDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        ActionItemDefinitionDTO dto = result[id];
                        dto.AddFunctionalLocationName(GetFunctionalLocationName(reader));
                        dto.AddVisibilityGroupName(GetVisibilityGroupName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<ActionItemDefinitionDTO>(result.Values);
        }

        private long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("ActionItemDefinitionId");
        }

        private string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private string GetVisibilityGroupName(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupName");
        }

        private ActionItemDefinitionDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("ActionItemDefinitionId");
            string name = reader.Get<string>("Name");
            long statusId = reader.Get<long>("ActionItemDefinitionStatusId");            

            long lastModifiedUserId = reader.Get<long>("LastModifiedUserId");
            string lastModifiedByFirstName = reader.Get<string>("LastModifiedFirstName");
            string lastModifiedByLastName = reader.Get<string>("LastModifiedLastName");
            string lastModifiedByUserName = reader.Get<string>("LastModifiedUserName");
            string lastModifiedFullNameWithUserName =
                User.ToFullNameWithUserName(lastModifiedByLastName, lastModifiedByFirstName, lastModifiedByUserName);

            bool isActive = reader.Get<bool>("Active");
            string description = reader.Get<string>("Description");
            long? categoryId = reader.Get<long?>("BusinessCategoryId");
            string categoryName = reader.Get<string>("BusinessCategoryName");
            int operatingModeId = reader.Get<int>("OperationalModeId");          
            string functionalLocationName = reader.Get<string>("FullHierarchy");                      
            int sourceId = reader.Get<int>("SourceId");
            Priority priority = Priority.GetById(reader.Get<long>("PriorityId"));

            var reading = reader.Get<bool>("Reading");          //ayman action item reading

            ISchedule schedule = ScheduleDao.PopulateScheduleInstanceForDTO(reader);
            string scheduleInformation = schedule.Type.Name;

            Date startDate;
            Date endDate = null;
            Time startTime;
            Time endTime;

            if (schedule.Type.Equals(ScheduleType.Single))
            {
                startTime = new Time(schedule.StartDateTime);
                endTime = new Time(schedule.EndDateTime);
                startDate = schedule.StartDateTime.ToDate();
                endDate = schedule.EndDateTime.ToDate();
            }
            else
            {
                startDate = schedule.StartDate;
                startTime = schedule.StartTime;
                endTime = schedule.EndTime;
                if (schedule.HasEndDate)
                {
                    endDate = schedule.EndDate;
                }
            }

            var result =
                new ActionItemDefinitionDTO(id,
                                            name,
                                            startDate,
                                            startTime,
                                            endDate,
                                            endTime,
                                            statusId,                                            
                                            lastModifiedUserId,
                                            lastModifiedFullNameWithUserName,
                                            description,
                                            scheduleInformation,
                                            categoryId,    
                                            categoryName,
                                            sourceId,
                                            isActive,
                                            operatingModeId,                                            
                                            priority,
                                            reading);                      //ayman action item reading

            result.AddFunctionalLocationName(functionalLocationName);
            result.AddVisibilityGroupName(GetVisibilityGroupName(reader));
            return result;
        }


    }
}
