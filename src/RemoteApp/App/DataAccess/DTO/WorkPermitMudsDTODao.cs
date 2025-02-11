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
    public class WorkPermitMudsDTODao : AbstractManagedDao, IWorkPermitMudsDTODao
    {
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE = "QueryWorkPermitMudsDTOsByDateRangeAndFlocIds";
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_FOR_TEMPLATE_STORED_PROCEDURE = "QueryWorkPermitTemplateDTOs";

        public List<WorkPermitMudsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRangeToQuery, IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            DateRange dateRange = new DateRange(dateRangeToQuery);
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", csvFlocIds);

            return GetDtos(command, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE);
        }

        private static List<WorkPermitMudsDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, WorkPermitMudsDTO> result = new Dictionary<long, WorkPermitMudsDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");
                    if (result.ContainsKey(id))
                    {
                        WorkPermitMudsDTO dto = result[id];
                        string functionalLocationFullHierarchy = reader.Get<string>("FullHierarchy");
                        dto.AddFunctionalLocation(functionalLocationFullHierarchy);
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<WorkPermitMudsDTO>(result.Values);
        }


        public List<WorkPermitMudsTemplateDTO> QueryByDateRangeAndFlocsTemplate(Range<Date> dateRangeToQuery, IFlocSet flocSet, string username)
        {
            
            DateRange dateRange = new DateRange(dateRangeToQuery);
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);
            //command.AddParameter("@CsvFlocIds", csvFlocIds);

            return command.QueryForListResult<WorkPermitMudsTemplateDTO>(PopulateInstanceForTemplate, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_FOR_TEMPLATE_STORED_PROCEDURE);
        }


        private static WorkPermitMudsTemplateDTO PopulateInstanceForTemplate(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long temlateId = reader.Get<long>("TemplateId");
            var permitNumber = reader.Get<string>("PermitNumber");
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            string wpType = reader.Get<string>("WorkPermitType");
            string description = reader.Get<string>("Description");
            bool global = reader.Get<bool>("Global");
            //string functionalLocationFullHierarchy = reader.Get<string>("FullHierarchy");
            

            long? pm = long.Parse(permitNumber);

            WorkPermitMudsTemplateDTO result = new WorkPermitMudsTemplateDTO
                (
                id,
                pm,
                templateName,
                categories,
                wpType,
                description,
                global,
                temlateId
                //new List<string> { functionalLocationFullHierarchy }

                );

            return result;
        }

        private static WorkPermitMudsDTO PopulateInstance(SqlDataReader reader)
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
            string requestedByGroup = reader.Get<string>("RequestedByGroupId") ?? string.Empty;
            string description = reader.Get<string>("Description") ?? string.Empty;
            string interrupteursFCO = reader.Get<string>("InterrupteursEtVannesCadenassesValue") ?? string.Empty; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            bool fco = reader.Get<bool>("InterrupteursEtVannesCadenasses"); //Added By Vibhor : RITM0555766 - OLT improvement on work request

            
            DateTime createdDateTime  = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId  = reader.Get<long>("CreatedByUserId");
            DateTime lastModifiedDateTime  = reader.Get<DateTime>("LastModifiedDateTime");
            long lastModifiedByUserId  = reader.Get<long>("LastModifiedByUserId");            
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime? issuedDateTime = reader.Get<DateTime?>("IssuedDateTime");

            string mudsAnswerTextBox = reader.Get<string>("MudsAnswerTextBox");

            WorkPermitMudsDTO dto = new WorkPermitMudsDTO(
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
                interrupteursFCO, // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
                fco, //Added By Vibhor : RITM0555766 - OLT improvement on work request
                createdDateTime,
                createdByUserId,
                lastModifiedDateTime,
                lastModifiedByUserId,
                lastModifiedByFullNameWithUserName,
                issuedDateTime,
                mudsAnswerTextBox
                );

            return dto;
        }
    }
}
