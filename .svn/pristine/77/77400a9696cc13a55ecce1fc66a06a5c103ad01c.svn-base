using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class OnPremisePersonnelDtoDao : AbstractManagedDao, IOnPremisePersonnelDtoDao
    {
        public IList<OnPremisePersonnelShiftReportDetailDTO> QueryOnPremisePersonnelShiftReportDetailDtos(Range<DateTime> dateRange)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.LowerBound);
            command.AddParameter("@EndOfDateRange", dateRange.UpperBound);

            return command.QueryForListResult(PopulateShiftReportViewDtoInstance, "QueryOnPremisePersonnelByDateRange");
        }

        public IList<OnPremisePersonnelSupervisorDTO> QuerySupervisorViewDtos(Range<DateTime> dateRange)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.LowerBound);
            command.AddParameter("@EndOfDateRange", dateRange.UpperBound);

            return command.QueryForListResult(PopulateSupervisorViewDtoInstance, "QueryOnPremisePersonnelSupervisorViewDTO");
        }

        public IList<OnPremisePersonnelAuditDTO> QueryAuditViewDtos(Range<Date> dateRange)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.LowerBound.ToDateTimeAtStartOfDay());
            var endOfRange = dateRange.UpperBound != null ? dateRange.UpperBound.ToDateTimeAtEndOfDay() : DateTime.MaxValue;
            command.AddParameter("@EndOfDateRange", endOfRange);

            return command.QueryForListResult(PopulateAuditViewDtoInstance, "QueryOnPremisePersonnelAuditViewDTO");
        }

        private OnPremisePersonnelAuditDTO PopulateAuditViewDtoInstance(SqlDataReader reader)
        {
            var contractorId = reader.Get<long>("ContractorId");
            var formId = reader.Get<long>("OvertimeFormId");
            var company = reader.Get<string>("Company");
            var trade = reader.Get<string>("Trade");
            var person = reader.Get<string>("PersonnelName");
            var startDateTime = reader.Get<DateTime>("StartDateTime");
            var endDateTime = reader.Get<DateTime>("EndDateTime");
            var primaryLocation = reader.Get<string>("PrimaryLocation");
            var expectedHours = reader.Get<decimal>("ExpectedHours");
            var description = reader.Get<string>("Description");
            var workOrderNumber = reader.Get<string>("WorkOrderNumber");
            var formStatus = FormStatus.GetById(reader.Get<byte>("FormStatusId"));
            var approvedBy = reader.GetUserFullName("ApprovedByFirstName", "ApprovedByLastName");

            return new OnPremisePersonnelAuditDTO(contractorId,
                formId,
                company,
                trade,
                person,
                startDateTime,
                endDateTime,
                primaryLocation,
                expectedHours,
                description,
                workOrderNumber,
                formStatus,
                approvedBy);
        }

        private OnPremisePersonnelSupervisorDTO PopulateSupervisorViewDtoInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var occupation = reader.Get<string>("Trade");
            var personnelName = reader.Get<string>("PersonnelName");
            var primaryLocation = reader.Get<string>("PrimaryLocation");
            var isDayShift = reader.Get<bool>("IsDayShift");
            var isNightShift = reader.Get<bool>("IsNightShift");
            var phoneNumber = reader.Get<string>("PhoneNumber");
            var radio = reader.Get<string>("Radio");
            var company = reader.Get<string>("Company");
            var description = reader.Get<string>("Description");
            var startDateTime = reader.Get<DateTime>("StartDateTime");
            var endDateTime = reader.Get<DateTime>("EndDateTime");

            return new OnPremisePersonnelSupervisorDTO(id,
                occupation,
                personnelName,
                primaryLocation,
                isDayShift,
                isNightShift,
                startDateTime,
                endDateTime,
                phoneNumber,
                radio,
                company,
                description,
                CardEntryStatus.UnKnown);
        }

        private OnPremisePersonnelShiftReportDetailDTO PopulateShiftReportViewDtoInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var occupation = reader.Get<string>("Trade");
            var personnelName = reader.Get<string>("PersonnelName");
            var primaryLocation = reader.Get<string>("PrimaryLocation");
            var isDayShift = reader.Get<bool>("IsDayShift");
            var isNightShift = reader.Get<bool>("IsNightShift");
            var phoneNumber = reader.Get<string>("PhoneNumber");
            var radio = reader.Get<string>("Radio");
            var company = reader.Get<string>("Company");
            var description = reader.Get<string>("Description");
            var startDateTime = reader.Get<DateTime>("StartDateTime");
            var endDateTime = reader.Get<DateTime>("EndDateTime");

            return new OnPremisePersonnelShiftReportDetailDTO(id,
                occupation,
                personnelName,
                primaryLocation,
                isDayShift,
                isNightShift,
                startDateTime,
                endDateTime,
                phoneNumber,
                radio,
                company,
                description);
        }
    }
}