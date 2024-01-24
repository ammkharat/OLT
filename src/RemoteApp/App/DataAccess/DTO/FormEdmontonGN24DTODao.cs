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
    public class FormEdmontonGN24DTODao : AbstractManagedDao, IFormEdmontonGN24DTODao
    {
        private const string QUERY_DTOS = "QueryFormEdmontonGN24DTO";

        public List<FormEdmontonGN24DTO> QueryDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftForms)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());            
            command.AddParameter("@IncludeAllDraft", includeAllDraftForms);          

            return GetDtos(command, QUERY_DTOS);
        }
       
        private static List<FormEdmontonGN24DTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormEdmontonGN24DTO> result = new Dictionary<long, FormEdmontonGN24DTO>();

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

            return new List<FormEdmontonGN24DTO>(result.Values);
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

        private static FormEdmontonGN24DTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            string floc = GetFunctionalLocationName(reader);

            EdmontonFormType formType = EdmontonFormType.GN24;

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime validFrom = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validTo = reader.Get<DateTime>("ValidToDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            bool psv = reader.Get<bool>("IsTheSafeWorkPlanForPSVRemovalOrInstallation");

            List<string> remainingApprovals = new List<string>();
            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }

            FormStatus formStatus = (DateTime.Now > validTo) ? FormStatus.Expired : FormStatus.GetById(reader.Get<int>("FormStatusId"));      //ayman expired when old
            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- start -- 4-apr-2017 
            if (formStatus == FormStatus.Expired)
                formStatus = FormStatus.Closed;
            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- End -- 4-apr-2017 

            FormEdmontonGN24DTO result = new FormEdmontonGN24DTO(
                id, new List<string> { floc }, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId, lastModifiedDateTime, validFrom, validTo, psv, formStatus, approvedDateTime, closedDateTime, remainingApprovals);

            return result;
        }
    }
}