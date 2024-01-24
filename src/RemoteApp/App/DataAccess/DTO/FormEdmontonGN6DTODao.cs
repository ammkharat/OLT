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
    public class FormEdmontonGN6DTODao : AbstractManagedDao, IFormEdmontonGN6DTODao
    {
        private const string QUERY_DTOS = "QueryFormEdmontonGN6DTO";

        public List<FormEdmontonGN6DTO> QueryDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftForms)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());            
            command.AddParameter("@IncludeAllDraft", includeAllDraftForms);          

            return GetDtos(command, QUERY_DTOS);
        }
       
        private static List<FormEdmontonGN6DTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormEdmontonGN6DTO> result = new Dictionary<long, FormEdmontonGN6DTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);                    

                    if (result.ContainsKey(id))
                    {
                        FormEdmontonDTO dto = result[id];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));

                        if (ApprovalStillNeeded(reader))
                        {
                            dto.AddRemainingApproval(reader.Get<string>("Approver"));
                        }
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<FormEdmontonGN6DTO>(result.Values);
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

        private static FormEdmontonGN6DTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            EdmontonFormType formType = EdmontonFormType.GN6;

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            string jobDescription = reader.Get<string>("JobDescription");

            DateTime validFrom = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validTo = reader.Get<DateTime>("ValidToDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            List<string> remainingApprovals = new List<string>();
            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }

            bool section1NotApplicableToJob = reader.Get<bool>("Section1NotApplicableToJob");
            bool section2NotApplicableToJob = reader.Get<bool>("Section2NotApplicableToJob");
            bool section3NotApplicableToJob = reader.Get<bool>("Section3NotApplicableToJob");
            bool section4NotApplicableToJob = reader.Get<bool>("Section4NotApplicableToJob");
            bool section5NotApplicableToJob = reader.Get<bool>("Section5NotApplicableToJob");
            bool section6NotApplicableToJob = reader.Get<bool>("Section6NotApplicableToJob");

            string applicableSections = FormEdmontonGN6DTO.GetApplicableSections(section1NotApplicableToJob, section2NotApplicableToJob, section3NotApplicableToJob, section4NotApplicableToJob, section5NotApplicableToJob, section6NotApplicableToJob);

            FormStatus formStatus = ((DateTime.Now > validTo) && (FormStatus.GetById(reader.Get<int>("FormStatusId"))) != FormStatus.Closed) ? FormStatus.Expired : FormStatus.GetById(reader.Get<int>("FormStatusId"));      //ayman expired when old

            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- start -- 4-apr-2017 
            if (formStatus == FormStatus.Expired)
                formStatus = FormStatus.Closed;
            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- End -- 4-apr-2017 

            FormEdmontonGN6DTO result = new FormEdmontonGN6DTO(
                id, new List<string> { floc }, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals, applicableSections, jobDescription, lastModifiedDateTime);

            return result;
        }
    }
}
