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
    public class FormEdmontonDTODao : AbstractManagedDao, IFormEdmontonDTODao
    {
        private const string QUERY_GN7_BY_FLOCS_AND_OTHER_THINGS = "QueryFormGN7DTOsByFunctionalLocationsAndOtherThings";
        private const string QUERY_GN59_BY_FLOCS_AND_OTHER_THINGS = "QueryFormGN59DTOsByFunctionalLocationsAndOtherThings";
        private const string QueryTemplateByIDToShowApprovedByHowManyeipforms = "QueryTemplateByIDToShowApprovedByHowManyeipforms";     //ayman Sarnia eip DMND0008992

        public List<FormEdmontonDTO> QueryFormGN7(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftFormsRegardlessOfDateRange);          

            return GetDtos(command, QUERY_GN7_BY_FLOCS_AND_OTHER_THINGS);
        }

        //ayman Sarnia eip DMND0008992
        public List<FormEdmontonDTO> QueryApprovedTemplateDTOs(long id, long siteid)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@id", id);
            command.AddParameter("@siteid", siteid);
            return GetDtos(command, QueryTemplateByIDToShowApprovedByHowManyeipforms);
        }

        public List<FormEdmontonDTO> QueryFormGN59(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftFormsRegardlessOfDateRange);          

            return GetDtos(command, QUERY_GN59_BY_FLOCS_AND_OTHER_THINGS);
        }

        private static List<FormEdmontonDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<string, FormEdmontonDTO> result = new Dictionary<string, FormEdmontonDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    EdmontonFormType formType = GetFormType(reader);
                    string key = GetKey(id, formType);

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

            return new List<FormEdmontonDTO>(result.Values);
        }

        private static string GetKey(long id, EdmontonFormType formType)
        {
            return String.Format("{0}_{1}", id, formType);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static EdmontonFormType GetFormType(SqlDataReader reader)
        {
            return EdmontonFormType.GetById(reader.Get<int>("FormTypeId"));
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

        private static FormEdmontonDTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            EdmontonFormType formType = GetFormType(reader);

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

            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- start -- 4-apr-2017 
            //FormStatus formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));     //ayman expired when old  (DateTime.Now > validTo) ? FormStatus.Expired : 
            FormStatus formStatus = ((DateTime.Now > validTo) && (FormStatus.GetById(reader.Get<int>("FormStatusId"))) != FormStatus.Closed) ? FormStatus.Expired : FormStatus.GetById(reader.Get<int>("FormStatusId"));      //ayman expired when old    
            if (formStatus == FormStatus.Expired)
                formStatus = FormStatus.Closed;
            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- End -- 4-apr-2017 
            
            FormEdmontonDTO result = new FormEdmontonDTO(id, new List<string> { floc }, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals);

            return result;
        }
    }
}