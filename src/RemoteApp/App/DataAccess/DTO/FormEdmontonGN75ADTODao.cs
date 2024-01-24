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
    public class FormEdmontonGN75ADTODao : AbstractManagedDao, IFormEdmontonGN75ADTODao
    {
        private const string QUERY_DTOS = "QueryFormEdmontonGN75ADTO";

        public List<FormEdmontonGN75ADTO> QueryDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftForms)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftForms);

            return GetDtos(command, QUERY_DTOS);
        }

        private static List<FormEdmontonGN75ADTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormEdmontonGN75ADTO> result = new Dictionary<long, FormEdmontonGN75ADTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");

                    if (result.ContainsKey(id))
                    {
                        FormEdmontonGN75ADTO dto = result[id];
                        
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

            return new List<FormEdmontonGN75ADTO>(result.Values);
        }

        private static bool ApprovalStillNeeded(SqlDataReader reader)
        {
            long? approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            return approvedByUserId == null;
        }

        private static FormEdmontonGN75ADTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string floc = reader.Get<string>("FullHierarchy");

            EdmontonFormType formType = EdmontonFormType.GN75A;

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime validFrom = reader.Get<DateTime>("FromDateTime");
            DateTime validTo = reader.Get<DateTime>("ToDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");

            long? associatedGN75BNumber = reader.Get<long?>("AssociatedFormGN75BId");
            
            List<string> remainingApprovals = new List<string>();
            
            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }

            FormStatus formStatus = ((DateTime.Now > validTo) && (FormStatus.GetById(reader.Get<int>("FormStatusId"))) != FormStatus.Closed) ? FormStatus.Expired : FormStatus.GetById(reader.Get<int>("FormStatusId"));   //ayman expired when old

            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- start -- 4-apr-2017 
            if (formStatus == FormStatus.Expired)
                formStatus = FormStatus.Closed;
            //Dharmesh Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- End -- 4-apr-2017 

            FormEdmontonGN75ADTO result = new FormEdmontonGN75ADTO(
                id, floc, formType, associatedGN75BNumber, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId, lastModifiedDateTime, validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals);

            return result;
        }
    }
}