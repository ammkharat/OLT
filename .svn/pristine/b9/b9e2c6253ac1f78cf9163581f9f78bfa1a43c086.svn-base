using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class FormEdmontonGN1DTODao : AbstractManagedDao, IFormEdmontonGN1DTODao
    {
        private const string QUERY_DTOS = "QueryFormEdmontonGN1DTO";

        public List<FormEdmontonGN1DTO> QueryDTOs(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftForms)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftForms);

            return GetDtos(command, QUERY_DTOS);        
        }

        private static List<FormEdmontonGN1DTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, FormEdmontonGN1DTO> result = new Dictionary<long, FormEdmontonGN1DTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>("Id");

                    if (result.ContainsKey(id))
                    {
                        FormEdmontonGN1DTO dto = result[id];
                        AddApprovalIfStillNeeded(reader, dto);                        
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }
            return new List<FormEdmontonGN1DTO>(result.Values);
        }

        private static void AddApprovalIfStillNeeded(SqlDataReader reader, FormEdmontonGN1DTO dto)
        {
            string cseLevel = reader.Get<string>("CSELevel");

            if (WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(cseLevel))
                return;

            string rescuePlanApprovalApprover = reader.Get<string>("RescuePlanApprovalApprover");
            string planningWorksheetApprovalApprover = reader.Get<string>("PlanningWorksheetApprovalApprover");

            long? planningWorksheetApprovedByUserId = reader.Get<long?>("PlanningWorksheetApprovalApprovedByUserId");
            long? rescuePlanApprovedByUserId = reader.Get<long?>("RescuePlanApprovalApprovedByUserId");

            if (rescuePlanApprovalApprover != null && rescuePlanApprovedByUserId == null)
            {
                dto.AddRemainingApproval(reader.Get<string>("RescuePlanApprovalApprover"));
            }

            if (planningWorksheetApprovalApprover != null && planningWorksheetApprovedByUserId == null)
            {
                dto.AddRemainingApproval(reader.Get<string>("PlanningWorksheetApprovalApprover"));
            }

            bool hasTradeChecklistConstFieldMaintCoordApproval = reader.Get<bool>("TradeChecklistConstFieldMaintCoordApproval");
            bool hasTradeChecklistOpsCoordApproval = reader.Get<bool>("TradeChecklistOpsCoordApproval");
            bool hasTradeChecklistAreaManagerApproval = reader.Get<bool>("TradeChecklistAreaManagerApproval");

            if (!hasTradeChecklistConstFieldMaintCoordApproval)
            {
                dto.AddRemainingApproval(FormGN1.ConstFieldMaintCoordApprovalName);
            }

            if (!hasTradeChecklistOpsCoordApproval)
            {
                dto.AddRemainingApproval(FormGN1.OpsCoordApprovalName);
            }

            if (!hasTradeChecklistAreaManagerApproval)
            {
                dto.AddRemainingApproval(FormGN1.AreaManagerApprovalName);
            }
        }

        private static FormEdmontonGN1DTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string floc = reader.Get<string>("FullHierarchy");

            EdmontonFormType formType = EdmontonFormType.GN1;

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");
            string tradeChecklistNames = reader.Get<string>("TradeChecklistNames");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            DateTime validFrom = reader.Get<DateTime>("FromDateTime");
            DateTime validTo = reader.Get<DateTime>("ToDateTime");
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
                        
            List<string> remainingApprovals = new List<string>();

            FormStatus formStatus = ((DateTime.Now > validTo) && (FormStatus.GetById(reader.Get<int>("FormStatusId"))) != FormStatus.Closed) ? FormStatus.Expired : FormStatus.GetById(reader.Get<int>("FormStatusId"));      //ayman expired when old    
            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- start -- 4-apr-2017 
            if (formStatus == FormStatus.Expired)
                formStatus = FormStatus.Closed;
            //Dharmesh --DMND0005326 -- Edmonton OLT Enhancements–II --- task 9 -- End -- 4-apr-2017 

            FormEdmontonGN1DTO result = new FormEdmontonGN1DTO(
                id, floc, tradeChecklistNames, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId, lastModifiedDateTime, validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals);

            AddApprovalIfStillNeeded(reader, result);

            return result;
        }
    }
}