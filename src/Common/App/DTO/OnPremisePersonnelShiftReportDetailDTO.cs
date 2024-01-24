using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class OnPremisePersonnelShiftReportDetailDTO : DomainObject
    {
        public OnPremisePersonnelShiftReportDetailDTO(long id, string trade, string personnelName,
            string primaryLocation, bool isDayShift, bool isNightShift, DateTime startDateTime,
            DateTime endDateTime, string phoneNumber, string radio, string company, string description) : base(id)
        {
            this.id = id;
            Trade = trade;
            PersonnelName = personnelName;
            PrimaryLocation = primaryLocation;
            IsDayShift = isDayShift;
            IsNightShift = isNightShift;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PhoneNumber = phoneNumber;
            Radio = radio;
            Company = company;
            Description = description;
        }

        public string Trade { get; private set; }
        public string PersonnelName { get; private set; }
        public string PrimaryLocation { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Radio { get; private set; }
        public string Company { get; private set; }
        public string Description { get; private set; }
        public bool IsNightShift { get; private set; }
        public bool IsDayShift { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
    }
}