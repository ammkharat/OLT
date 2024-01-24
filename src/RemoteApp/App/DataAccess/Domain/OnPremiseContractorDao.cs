using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class OnPremiseContractorDao : AbstractManagedDao, IOnPremiseContractorDao
    {
        public List<OnPremiseContractor> QueryByOvertimeForm(long formId)
        {
            SqlCommand managedCommand = ManagedCommand;
            managedCommand.AddParameter("OvertimeFormId", formId);
            return managedCommand.QueryForListResult(PopulateInstance, "QueryOnPremiseContractorByOvertimeFormId");
        }

        public void Insert(OnPremiseContractor contractor)
        {
            ManagedCommand.InsertAndSetId(contractor, AddInsertParameters, "InsertOvertimeFormContractor");
        }

        public void RemoveAllThatAreNotInThisList(long overtimeFormId, List<OnPremiseContractor> items)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@OverTimeFormId", overtimeFormId);
            command.AddParameter("@CsvItemIds", items.BuildIdStringFromList());
            command.ExecuteNonQuery("RemoveOvertimeOnPremiseContractorsNotInTheList");
        }

        public void Update(OnPremiseContractor item)
        {
            SqlCommand command = ManagedCommand;
            command.Update(item, AddUpdateParameters, "UpdateOvertimeFormContractor");
        }

        private void AddUpdateParameters(OnPremiseContractor onPremiseContractor, SqlCommand command)
        {
            command.AddParameter("@Id", onPremiseContractor.Id);
            AddCommonInsertOrUpdateParameters(onPremiseContractor, command);
        }

        private void AddInsertParameters(OnPremiseContractor onPremiseContractor, SqlCommand command)
        {
            command.AddParameter("OvertimeFormId", onPremiseContractor.OvertimeFormId);
            AddCommonInsertOrUpdateParameters(onPremiseContractor, command);
        }

        private void AddCommonInsertOrUpdateParameters(OnPremiseContractor onPremiseContractor, SqlCommand command)
        {
            command.AddParameter("PersonnelName", onPremiseContractor.PersonnelName);
            command.AddParameter("PrimaryLocation", onPremiseContractor.PrimaryLocation);
            command.AddParameter("StartDateTime", onPremiseContractor.StartDateTime);
            command.AddParameter("EndDateTime", onPremiseContractor.EndDateTime);
            command.AddParameter("IsDayShift", onPremiseContractor.IsDayShift);
            command.AddParameter("IsNightShift", onPremiseContractor.IsNightShift);
            command.AddParameter("PhoneNumber", onPremiseContractor.PhoneNumber);
            command.AddParameter("Radio", onPremiseContractor.Radio);
            command.AddParameter("Description", onPremiseContractor.Description);
            command.AddParameter("Company", onPremiseContractor.Company);
            command.AddParameter("WorkOrderNumber", onPremiseContractor.WorkOrderNumber);
            command.AddParameter("ExpectedHours", onPremiseContractor.ExpectedHours);
        }

        private OnPremiseContractor PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");
            long? overtimeFormId = reader.Get<long?>("OvertimeFormId");

            string person = reader.Get<string>("PersonnelName");
            string primaryLocation = reader.Get<string>("PrimaryLocation");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");
            bool isDayShift = reader.Get<bool>("IsDayShift");
            bool isNightShift = reader.Get<bool>("IsNightShift");
            string phoneNumber = reader.Get<string>("PhoneNumber");
            string radio = reader.Get<string>("Radio");
            string description = reader.Get<string>("Description");
            string company = reader.Get<string>("Company");
            string workOrderNumber = reader.Get<string>("WorkOrderNumber");
            decimal expectedHours = reader.Get<decimal>("ExpectedHours");

            return new OnPremiseContractor(id, overtimeFormId, person, primaryLocation, startDateTime, endDateTime, isDayShift, isNightShift, phoneNumber, radio, description, company,
                workOrderNumber, expectedHours);
        }
    }
}