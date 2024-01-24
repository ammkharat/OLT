using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class WorkPermitLubesDTODao : AbstractManagedDao, IWorkPermitLubesDTODao
    {
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE = "QueryWorkPermitLubesDTOByDateRangeAndFlocIds";

        public List<WorkPermitLubesDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            DateRange queryDateRange = new DateRange(dateRange);
            string csvFLOCIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            command.AddParameter("@StartOfDateRange", queryDateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", queryDateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", csvFLOCIds);

            return command.QueryForListResult<WorkPermitLubesDTO>(PopulateInstance, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE);            
        }
              
        private static WorkPermitLubesDTO PopulateInstance(SqlDataReader reader)
        {
            WorkPermitLubesDTO dto = new WorkPermitLubesDTO();

            long id = reader.Get<long>("Id");
            int dataSourceId = reader.Get<int>("DataSourceId");
            int statusId = reader.Get<int>("WorkPermitStatus");
            bool followupRequired = reader.Get<bool>("AdditionalFollowupRequired");
            long? permitNumber = reader.Get<long?>("PermitNumber");
            string floc = reader.Get<string>("FunctionalLocationFullHierarchy");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime expireDateTime = reader.Get<DateTime>("ExpireDateTime");
            DateTime? issuedDateTime = reader.Get<DateTime?>("IssuedDateTime");
            string company = reader.Get<string>("Company");
            var version = new Version(reader.Get<string>("Version"));
            string lastModifiedByLastName = reader.Get<string>("LastModifiedByLastName");
            string lastModifiedByFirstName = reader.Get<string>("LastModifiedByFirstName");
            string lastModifiedByUserName = reader.Get<string>("LastModifiedByUserName");

            string submittedByLastName = reader.Get<string>("PermitRequestSubmittedByLastName");
            string submittedByFirstName = reader.Get<string>("PermitRequestSubmittedByFirstName");
            string submittedByUserName = reader.Get<string>("PermitRequestSubmittedByUserName");

            string lastModified = User.ToFullNameWithUserName(lastModifiedByLastName, lastModifiedByFirstName, lastModifiedByUserName);

            string submittedBy = null;
            if (submittedByLastName != null && submittedByFirstName != null && submittedByUserName != null)
            {
                submittedBy = User.ToFullNameWithUserName(submittedByLastName, submittedByFirstName, submittedByUserName);
            }

            string permitRequestCreatedByLastName = reader.Get<string>("PermitRequestCreatedByLastName");
            string permitRequestCreatedByFirstName = reader.Get<string>("PermitRequestCreatedByFirstName");
            string permitRequestCreatedByUserName = reader.Get<string>("PermitRequestCreatedByUserName");

            string requestedBy = null;
            if (permitRequestCreatedByLastName != null && permitRequestCreatedByFirstName != null && permitRequestCreatedByUserName != null)
            {
                requestedBy = User.ToFullNameWithUserName(permitRequestCreatedByLastName, permitRequestCreatedByFirstName, permitRequestCreatedByUserName);
            }

            string issuedByLastName = reader.Get<string>("IssuedByLastName");
            string issuedByFirstName = reader.Get<string>("IssuedByFirstName");
            string issuedByUserName = reader.Get<string>("IssuedByUserName");

            string issuedBy = null;
            if (issuedByLastName != null && issuedByFirstName != null && issuedByUserName != null)
            {
                issuedBy = User.ToFullNameWithUserName(issuedByLastName, issuedByFirstName, issuedByUserName);
            }
                
            dto.Id = id;
            dto.DataSource = DataSource.GetById(dataSourceId);
            dto.Status = PermitRequestBasedWorkPermitStatus.Get(statusId);
            dto.AdditionalFollowupRequired = followupRequired;
            dto.PermitNumber = WorkPermitLubes.GetPermitNumberDisplayValue(permitNumber);
            dto.FunctionalLocation = floc;
            dto.StartDateTime = startDateTime;
            dto.ExpireDateTime = expireDateTime;
            dto.Version = version;
            dto.IssuedDateTime = issuedDateTime;
            dto.Trade = reader.Get<string>("Trade");
            dto.RequestedByGroup = reader.Get<string>("RequestedByGroupName");
            dto.Description = reader.Get<string>("TaskDescription");
            dto.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            dto.LastEditorFullNameWithUserName = lastModified;
            dto.RequestedByUserFullNameWithUserName = requestedBy;
            dto.SubmittedByUserFullNameWithUserName = submittedBy;
            dto.IssuedByUserFullNameWithUserName = issuedBy;
            dto.Company = company;
            dto.CreatedByUserId = reader.Get<long>("CreatedByUserId");
            dto.LastModifiedUserId = reader.Get<long>("LastModifiedByUserId");

            return dto;
        }
    }
}
