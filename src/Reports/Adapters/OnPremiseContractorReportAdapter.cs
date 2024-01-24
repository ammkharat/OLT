using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class OnPremiseContractorReportAdapter
    {
        private readonly OnPremiseContractor item;
        private readonly long parentId;

        public OnPremiseContractorReportAdapter(long parentId, OnPremiseContractor item)
        {
            this.parentId = parentId;
            this.item = item;
        }

        public long ParentId
        {
            get { return parentId; }
        }

        public string PersonnelName
        {
            get { return item.PersonnelName; }
        }

        public string PrimaryLocation
        {
            get { return item.PrimaryLocation; }
        }

        public string StartDateTime
        {
            get { return item.StartDateTime.ToLongDateAndTimeString(); }
        }

        public string EndDateTime
        {
            get { return item.EndDateTime.ToLongDateAndTimeString(); }
        }

        public string Shifts
        {
            get { return item.Shifts; }
        }

        public string PhoneNumber
        {
            get
            {
                return item.Radio.IsNullOrEmptyOrWhitespace()
                    ? item.PhoneNumber
                    : item.PhoneNumber + " /" + Environment.NewLine + item.Radio;
            }
        }

        public string Description
        {
            get { return item.Description; }
        }

        public string Contractor
        {
            get { return item.Company; }
        }

        public string WorkOrderNumber
        {
            get { return item.WorkOrderNumber; }
        }

        public string OvertimeHours
        {
            get { return item.ExpectedHours.Format(); }
        }
    }
}