using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class OvertimeFormDTODao : AbstractManagedDao, IOvertimeFormDTODao
    {
        public IList<EdmontonOvertimeFormDTO> QueryDTOs(DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult(PopulateInstance, "QueryOvertimeFormDTO");
        }

        public IList<EdmontonOvertimeFormDTO> QueryWaitingApprovalDTOs(DateRange dateRange)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult(PopulateInstance, "QueryOvertimeFormDTOsWaitingApproval");
        }

        private EdmontonOvertimeFormDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string functionalLocation = reader.Get<string>("FullHierarchy");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName", "CreatedByUserName");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            DateTime validFrom = reader.Get<DateTime>("ValidFromDateTime");
            DateTime validTo = reader.Get<DateTime>("ValidToDateTime");
            FormStatus formStatus = FormStatus.GetById(reader.Get<byte>("FormStatusId"));
            DateTime? approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            DateTime? cancelledDateTime = reader.Get<DateTime?>("CancelledDateTime");

            string trade = reader.Get<string>("Trade");
            decimal totalHours = reader.Get<decimal>("TotalHours");
            
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            
            string approvedByFullNameWithUserName = reader.GetUser("ApprovedByFirstName", "ApprovedByLastName", "ApprovedByUserName");

            EdmontonOvertimeFormDTO dto = new EdmontonOvertimeFormDTO(id, new List<string> {functionalLocation}, EdmontonFormType.Overtime, createdByUserId, createdByFullNameWithUserName, createdDateTime,
                lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, cancelledDateTime, trade, totalHours, lastModifiedByFullNameWithUserName,
                approvedByFullNameWithUserName);

            if (approvedByFullNameWithUserName.IsNullOrEmptyOrWhitespace())
            {
                string remainingApproval = reader.Get<string>("Approver");
                dto.AddRemainingApproval(remainingApproval);
            }
            return dto;

        }
    }
}