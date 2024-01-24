using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class WorkPermitEdmontonDTODao : AbstractManagedDao, IWorkPermitEdmontonDTODao
    {
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE = "QueryWorkPermitEdmontonDTOByDateRangeAndFlocIds";
        private const string QUERY_BY_FORM_GN7_ID = "QueryWorkPermitEdmontonDTOByFormGN7Id";
        private const string QUERY_BY_FORM_GN59_ID = "QueryWorkPermitEdmontonDTOByFormGN59Id";
        private const string QUERY_BY_FORM_GN6_ID = "QueryWorkPermitEdmontonDTOByFormGN6Id";
        private const string QUERY_BY_FORM_GN24_ID = "QueryWorkPermitEdmontonDTOByFormGN24Id";
        private const string QUERY_BY_FORM_GN75A_ID = "QueryWorkPermitEdmontonDTOByFormGN75AId";
        private const string QUERY_BY_FORM_GN1_ID = "QueryWorkPermitEdmontonDTOByFormGN1Id";
        private const string QUERY_BY_DATE_RANGE_AND_FLOC_IDS_FOR_TEMPLATE_STORED_PROCEDURE = "QueryWorkPermitTemplateDTOs";
        

        // note: when excluding priority ids, make sure to give all of the priority ids for the group you want to exclude (e.g. to exclude work permits with the Maintenance group,
        // be sure to pass in 0, 1, 2 as opposed to just one of the three
        public List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsAndPriorityIds(Range<Date> dateRange, IFlocSet flocSet, List<long> priorityIds, bool excludeTheGivenPriorityIds)
        {
            SqlCommand command = ManagedCommand;
            DateRange queryDateRange = new DateRange(dateRange);
            string csvFLOCIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            command.AddParameter("@StartOfDateRange", queryDateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", queryDateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", csvFLOCIds);
            if (priorityIds != null)
            {
                command.AddParameter("@CsvPriorityIds", priorityIds.BuildCommaSeparatedList());
            }
            command.AddParameter("@ExcludeTheGivenPriorityIds", excludeTheGivenPriorityIds);

            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_STORED_PROCEDURE);            
        }

        public List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsAndPriorityIdsForTemplate(Range<Date> dateRange, IFlocSet flocSet, 
            List<long> priorityIds, bool excludeTheGivenPriorityIds, bool isTemplate, string username)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);

            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstanceForTemplate, QUERY_BY_DATE_RANGE_AND_FLOC_IDS_FOR_TEMPLATE_STORED_PROCEDURE);
        }

        public List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet)
        {
            return QueryByDateRangeAndFlocsAndPriorityIds(dateRange, flocSet, null, false);
        }
        public List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(Range<Date> dateRange, IFlocSet flocSet, string username)
        {
            return QueryByDateRangeAndFlocsAndPriorityIdsForTemplate(dateRange, flocSet, null, false, false, username);
        }

        public List<WorkPermitEdmontonDTO> QueryByFormGN59Id(long formGN59Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN59Id", formGN59Id);
            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_FORM_GN59_ID);
        }

        public List<WorkPermitEdmontonDTO> QueryByFormGN7Id(long formGN7Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN7Id", formGN7Id);
            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_FORM_GN7_ID);
        }

        public List<WorkPermitEdmontonDTO> QueryByFormGN24Id(long formGN24Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN24Id", formGN24Id);
            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_FORM_GN24_ID);
        }

        public List<WorkPermitEdmontonDTO> QueryByFormGN6Id(long formGN6Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN6Id", formGN6Id);
            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_FORM_GN6_ID);
        }

        public List<WorkPermitEdmontonDTO> QueryByFormGN75AId(long formGN75AId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN75AId", formGN75AId);
            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_FORM_GN75A_ID);        
        }

        public List<WorkPermitEdmontonDTO> QueryByFormGN1Id(long formGN1Id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN1Id", formGN1Id);
            return command.QueryForListResult<WorkPermitEdmontonDTO>(PopulateInstance, QUERY_BY_FORM_GN1_ID);        
        }

        private static WorkPermitEdmontonDTO PopulateInstance(SqlDataReader reader)
        {
            long id  = reader.Get<long>("Id");
            int dataSourceId  = reader.Get<int>("DataSourceId");
            int workPermitStatusId  = reader.Get<int>("WorkPermitStatusId");
            int workPermitTypeId  = reader.Get<int>("WorkPermitTypeId");
            DateTime requestedStartDateTime  = reader.Get<DateTime>("RequestedStartDateTime");
            DateTime? issuedDateTime  = reader.Get<DateTime?>("IssuedDateTime");
            DateTime expiredDateTime  = reader.Get<DateTime>("ExpiredDateTime");
            long? permitNumber  = reader.Get<long?>("PermitNumber");
            string workOrderNumber  = reader.Get<string>("WorkOrderNumber");
            string functionalLocationFullHierarchy  = reader.Get<string>("FullHierarchy");
            string occupation  = reader.Get<string>("Occupation");
            string group  = reader.Get<string>("GroupName");
            string description  = reader.Get<string>("TaskDescription");
            DateTime createdDateTime  = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId  = reader.Get<long>("CreatedByUserId");
            DateTime lastModifiedDateTime  = reader.Get<DateTime>("LastModifiedDateTime");
            long lastModifiedByUserId  = reader.Get<long>("LastModifiedByUserId");
            
            string lastModifiedByFirstName  = reader.Get<string>("LastModifiedByFirstName");
            string lastModifiedByLastName  = reader.Get<string>("LastModifiedByLastName");
            string lastModifiedByUserName  = reader.Get<string>("LastModifiedByUserName");
            
            string permitRequestCreatedByFirstName  = reader.Get<string>("PermitRequestCreatedByFirstName");
            string permitRequestCreatedByLastName  = reader.Get<string>("PermitRequestCreatedByLastName");
            string permitRequestCreatedByUserName  = reader.Get<string>("PermitRequestCreatedByUserName");

            string issuedByFirstName = reader.Get<string>("IssuedByFirstName");
            string issuedByLastName = reader.Get<string>("IssuedByLastName");
            string issuedByUserName = reader.Get<string>("IssuedByUserName");

            string company  = reader.Get<string>("Company");
            string permitAcceptor  = reader.Get<string>("PermitAcceptor");
            Priority priority = Priority.GetById(reader.Get<int>("PriorityId"));
            string areaLabelName = reader.Get<string>("AreaLabelName");

            //bool isTemplate = reader.Get<bool>("IsTemplate");

            string lastModifiedByFullNameWithUserName = null;
            if (lastModifiedByFirstName != null && lastModifiedByLastName != null && lastModifiedByUserName != null)
            {
                lastModifiedByFullNameWithUserName = User.ToFullNameWithUserName(lastModifiedByLastName, lastModifiedByFirstName, lastModifiedByUserName);
            }

            string permitRequestCreatedByFullNameWithUserName = null;
            if (permitRequestCreatedByFirstName != null && permitRequestCreatedByLastName != null && permitRequestCreatedByUserName != null)
            {
                permitRequestCreatedByFullNameWithUserName = User.ToFullNameWithUserName(permitRequestCreatedByLastName, permitRequestCreatedByFirstName, permitRequestCreatedByUserName);
            }

            string issuedByFullnameWithUserName = null;
            if (issuedByFirstName.HasValue() && issuedByLastName.HasValue() && issuedByUserName.HasValue())
            {
                issuedByFullnameWithUserName = User.ToFullNameWithUserName(issuedByLastName, issuedByFirstName, issuedByUserName);
            }

            WorkPermitEdmontonDTO dto = new WorkPermitEdmontonDTO(id, dataSourceId, workPermitStatusId, workPermitTypeId, requestedStartDateTime,
                                                                  issuedDateTime, expiredDateTime, permitNumber, workOrderNumber, occupation, @group, description,
                                                                  functionalLocationFullHierarchy,
                                                                  createdDateTime, createdByUserId, lastModifiedDateTime, lastModifiedByUserId, lastModifiedByFullNameWithUserName,
                                                                  issuedByFullnameWithUserName, permitRequestCreatedByFullNameWithUserName,
                                                                  company, permitAcceptor, priority, areaLabelName);

            return dto;
        }

        private static WorkPermitEdmontonDTO PopulateInstanceForTemplate(SqlDataReader reader)
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

            WorkPermitEdmontonDTO result = new WorkPermitEdmontonDTO
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
