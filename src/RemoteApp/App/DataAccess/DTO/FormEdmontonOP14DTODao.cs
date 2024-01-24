using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FormEdmontonOP14DTODao : AbstractManagedDao, IFormEdmontonOP14DTODao
    {
        private const string QUERY_OP14_BY_FLOCS_AND_OTHER_THINGS = "QueryFormOP14DTOsByFunctionalLocationsAndOtherThings";
        private const string QUERY_APPROVED_OP14_BY_FLOCS = "QueryFormDTOsThatAreOP14ApprovedDraftExpiredByFunctionalLocations";
     
        public List<FormEdmontonOP14DTO> QueryFormOP14(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftFormsRegardlessOfDateRange);          

            return GetDtos(command, QUERY_OP14_BY_FLOCS_AND_OTHER_THINGS);
        }

        public List<FormEdmontonOP14DTO> QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(IFlocSet flocSet, DateTime now)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@Now", now);
            return GetDtos(command, QUERY_APPROVED_OP14_BY_FLOCS);
        }

        private static List<FormEdmontonOP14DTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormEdmontonOP14DTO> result = new Dictionary<long, FormEdmontonOP14DTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {                   
                    long key = GetId(reader);

                    if (result.ContainsKey(key))
                    {
                        FormEdmontonDTO dto = result[key];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));

                        if (ApprovalStillNeeded(reader))
                        {
                            dto.AddRemainingApproval(reader.Get<string>("Approver"));
                        }
                    }
                    else
                    {
                        result.Add(key, PopulateInstance(reader));
                    }
                }
            }

            return new List<FormEdmontonOP14DTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static bool ApprovalStillNeeded(SqlDataReader reader)
        {
            long? approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            return approvedByUserId == null;
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static FormEdmontonOP14DTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            string criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");
            
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            DateTime validFrom = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validTo = reader.Get<DateTime>("ValidToDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            List<string> remainingApprovals = new List<string>();

            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }
            long siteid = reader.Get<long>("siteid");                 //ayman sarnia
            FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            FormEdmontonOP14DTO result = 
                new FormEdmontonOP14DTO(id, new List<string> { floc }, criticalSystemDefeated, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId, 
                    validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals,siteid);                //ayman sarnia

            return result;
        }

       
    }
}
