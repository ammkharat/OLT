﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class PermitRequestMontrealDTODao : AbstractManagedDao, IPermitRequestMontrealDTODao
    {
        private const string QUERY_BY_FLOC_STORED_PROCEDURE = "QueryPermitRequestMontrealDTOsByFlocUnitAndBelow";
        private const string QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE = "QueryPermitRequestTemplateDto";

        public List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelow(
                   IFlocSet flocSet, DateRange dateRange)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@FlocIds", flocids);
            command.AddParameter("@FromDate", dateRange.SqlFriendlyStart);
            command.AddParameter("@ToDate", dateRange.SqlFriendlyEnd);

            return GetDtos(command, QUERY_BY_FLOC_STORED_PROCEDURE);
        }

        private static List<PermitRequestMontrealDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, PermitRequestMontrealDTO> result = new Dictionary<long, PermitRequestMontrealDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");
                    if (result.ContainsKey(id))
                    {
                        PermitRequestMontrealDTO dto = result[id];
                        string functionalLocationFullHierarchy = reader.Get<string>("FunctionalLocationName");
                        dto.AddFunctionalLocation(functionalLocationFullHierarchy);
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<PermitRequestMontrealDTO>(result.Values);
        }

        public List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelowForTemplate(
                 IFlocSet flocSet, DateRange dateRange, string username)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;

            //command.AddParameter("@FlocIds", flocids);
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);

            return command.QueryForListResult<PermitRequestMontrealDTO>(PopulateInstanceForTemplate, QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE);
        }

        private PermitRequestMontrealDTO PopulateInstanceForTemplate(SqlDataReader reader)
        {

            PermitRequestMontrealDTO permitRequest = new PermitRequestMontrealDTO(
                reader.Get<long>("Id"),
                reader.Get<string>("TemplateName"),
                reader.Get<string>("Categories"),
                reader.Get<string>("WorkPermitType"),
                reader.Get<string>("Description"),
                reader.Get<bool>("Global"),
                reader.Get<long>("TemplateId")
                //new List<string>
                //{
                //    reader.Get<string>("FunctionalLocationName")
                
                //}
                );
            return permitRequest;
        }

        private static PermitRequestMontrealDTO PopulateInstance(SqlDataReader reader)
        {
            PermitRequestMontrealDTO permitRequest = new PermitRequestMontrealDTO(
                reader.Get<long>("Id"),
                WorkPermitMontrealType.Get(reader.Get<int>("WorkPermitTypeId")),
                new List<string> { reader.Get<string>("FunctionalLocationName") },
                new Date(reader.Get<DateTime>("StartDate")),
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("WorkOrderNumber"),
                reader.Get<string>("OperationNumber"),
                reader.Get<string>("Trade"),
                reader.Get<string>("RequestedByGroup"),
                reader.Get<string>("Description"),
                DataSource.GetById(reader.Get<int>("SourceId")),
                reader.GetUser("LastImportedByFirstName", "LastImportedByLastName", "LastImportedByUserName"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                 reader.GetUser("LastSubmittedByFirstName", "LastSubmittedByLastName", "LastSubmittedByUserName"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                reader.Get<long>("CreatedByUserId"),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName"),
                PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId")));

            return permitRequest;
        }
    }
}
