﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class WorkPermitMontrealDTODao : AbstractManagedDao, IWorkPermitMontrealDTODao
    {
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE = "QueryWorkPermitMontrealDTOsByDateRangeAndFlocIds";
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_FOR_TEMPLATE_STORED_PROCEDURE = "QueryWorkPermitTemplateDTOs";

        public List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocs(Range<Date> dateRangeToQuery, IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            DateRange dateRange = new DateRange(dateRangeToQuery);
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", csvFlocIds);

            return GetDtos(command, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE);
        }

        private static List<WorkPermitMontrealDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, WorkPermitMontrealDTO> result = new Dictionary<long, WorkPermitMontrealDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");
                    if (result.ContainsKey(id))
                    {
                        WorkPermitMontrealDTO dto = result[id];
                        string functionalLocationFullHierarchy = reader.Get<string>("FullHierarchy");
                        dto.AddFunctionalLocation(functionalLocationFullHierarchy);
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<WorkPermitMontrealDTO>(result.Values);
        }

        private static WorkPermitMontrealDTO PopulateInstance(SqlDataReader reader)
        {
            long id  = reader.Get<long>("Id");
            DataSource dataSource = DataSource.GetById(reader.Get<int>("SourceId"));
            int workPermitStatusId  = reader.Get<int>("WorkPermitStatusId");
            int workPermitTypeId  = reader.Get<int>("WorkPermitTypeId");
            DateTime startDateTime  = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime  = reader.Get<DateTime>("EndDateTime");
            long? permitNumber  = reader.Get<long?>("PermitNumber");
            string workOrderNumber  = reader.Get<string>("WorkOrderNumber");
            string functionalLocationFullHierarchy  = reader.Get<string>("FullHierarchy");
            string trade = reader.Get<string>("Trade") ?? string.Empty;
            string requestedByGroup = reader.Get<string>("RequestedByGroup") ?? string.Empty;
            string description = reader.Get<string>("Description") ?? string.Empty;
            DateTime createdDateTime  = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId  = reader.Get<long>("CreatedByUserId");
            DateTime lastModifiedDateTime  = reader.Get<DateTime>("LastModifiedDateTime");
            long lastModifiedByUserId  = reader.Get<long>("LastModifiedByUserId");            
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime? issuedDateTime = reader.Get<DateTime?>("IssuedDateTime");

            WorkPermitMontrealDTO dto = new WorkPermitMontrealDTO(
                id,
                dataSource,                 
                workPermitStatusId,
                workPermitTypeId,
                startDateTime,
                endDateTime,
                permitNumber,
                workOrderNumber,
                new List<string> { functionalLocationFullHierarchy },
                trade,
                requestedByGroup,
                description,
                createdDateTime,
                createdByUserId,
                lastModifiedDateTime,
                lastModifiedByUserId,
                lastModifiedByFullNameWithUserName,
                issuedDateTime
                );

            return dto;
        }

        public List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocsForTemplate(Range<Date> dateRange, IFlocSet flocSet, string username)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);

            return command.QueryForListResult<WorkPermitMontrealDTO>(PopulateInstanceForTemplate, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_FOR_TEMPLATE_STORED_PROCEDURE);
        }

        private static WorkPermitMontrealDTO PopulateInstanceForTemplate(SqlDataReader reader)
        {

            long id = reader.Get<long>("Id");
            var permitNumber = reader.Get<string>("PermitNumber");
            long temlateId = reader.Get<long>("TemplateId");
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            string wpType = reader.Get<string>("WorkPermitType");
            string description = reader.Get<string>("Description");
            bool global = reader.Get<bool>("Global");

            long? pm = long.Parse(permitNumber);

            WorkPermitMontrealDTO result = new WorkPermitMontrealDTO
                (
                id,
                pm,
                templateName,
                categories,
                wpType,
                description,
                global,
                temlateId

                );

            return result;
        }
    }
}
