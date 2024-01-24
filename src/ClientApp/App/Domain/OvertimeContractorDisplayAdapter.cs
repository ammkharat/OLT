using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Domain
{
    public class OvertimeContractorDisplayAdapter : IDataErrorInfo
    {
        private readonly OnPremiseContractor onPremiseContractor;
        private readonly List<string> errors = new List<string>();

        public OvertimeContractorDisplayAdapter(OnPremiseContractor onPremiseContractor)
        {
            this.onPremiseContractor = onPremiseContractor;
        }

        public OnPremiseContractor GetOnPremisePerson()
        {
            return onPremiseContractor;
        }

        public string this[string columnName]
        {
            get { return null; }   // we do not have cell-level validation turned on, so this should never be called
        }

        public DateTime StartDate
        {
            get { return onPremiseContractor.StartDateTime; }
            set { onPremiseContractor.StartDateTime = value; }
        }

        public DateTime StartTime
        {
            get { return onPremiseContractor.StartDateTime; }
            set { onPremiseContractor.StartDateTime = value; }
        }

        public DateTime EndDate
        {
            get { return onPremiseContractor.EndDateTime; }
            set { onPremiseContractor.EndDateTime = value; }
        }

        public DateTime EndTime
        {
            get { return onPremiseContractor.EndDateTime; }
            set { onPremiseContractor.EndDateTime = value; }
        }

        public bool DayShift
        {
            get { return onPremiseContractor.IsDayShift; }
            set { onPremiseContractor.IsDayShift = value; }
        }

        public bool NightShift
        {
            get { return onPremiseContractor.IsNightShift; }
            set { onPremiseContractor.IsNightShift = value; }
        }

        public string PhoneNumber
        {
            get { return onPremiseContractor.PhoneNumber; }
            set { onPremiseContractor.PhoneNumber = value; }
        }

        public string Radio
        {
            get { return onPremiseContractor.Radio; }
            set { onPremiseContractor.Radio = value; }
        }

        public string Description
        {
            get { return onPremiseContractor.Description; }
            set { onPremiseContractor.Description = value; }
        }

        public string Contractor
        {
            get { return onPremiseContractor.Company; }
            set { onPremiseContractor.Company = value; }
        }

        public string WorkOrderNumber
        {
            get { return onPremiseContractor.WorkOrderNumber; }
            set { onPremiseContractor.WorkOrderNumber = value; }
        }

        public decimal ExpectedHours
        {
            get { return onPremiseContractor.ExpectedHours; }
            set { onPremiseContractor.ExpectedHours = value; }
        }

        public string PersonnelName
        {
            get { return onPremiseContractor.PersonnelName; }
            set { onPremiseContractor.PersonnelName = value; }
        }

        public string PrimaryLocation
        {
            get { return onPremiseContractor.PrimaryLocation; }
            set { onPremiseContractor.PrimaryLocation = value; }
        }

        [Browsable(false)]   // setting browsable to false ensures that an Error column doesn't appear in the grid
        public string Error
        {
            get { return errors.Join(Environment.NewLine); }
        }

        public void ClearErrors()
        {
            errors.Clear();
        }

        public void AddError(string error)
        {
            errors.AddIfNotExist(error);
        }

        public bool DatesContainsRequestedShifts()
        {
            return onPremiseContractor.DatesContainsRequestedShifts();
        }
    }
}