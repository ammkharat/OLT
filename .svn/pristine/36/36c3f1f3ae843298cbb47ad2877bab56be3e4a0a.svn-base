using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class OnPremisePersonnelSupervisorDTO : DomainObject
    {
        private readonly bool isDayShift;
        private readonly bool isNightShift;

        public OnPremisePersonnelSupervisorDTO(long id,
            string trade,
            string personnelName,
            string primaryLocation,
            bool isDayShift,
            bool isNightShift,
            DateTime startDateTime,
            DateTime endDateTime,
            string phoneNumber,
            string radio,
            string company,
            string description,
            CardEntryStatus cardEntryStatus) : base(id)
        {
            this.id = id;
            Trade = trade;
            PersonnelName = personnelName;
            PrimaryLocation = primaryLocation;
            this.isDayShift = isDayShift;
            this.isNightShift = isNightShift;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PhoneNumber = phoneNumber;
            Radio = radio;
            Company = company;
            Description = description;
            CardEntryStatus = cardEntryStatus;
        }

        [IncludeInSearch]
        public string Trade { get; private set; }

        [IncludeInSearch]
        public string PersonnelName { get; private set; }

        [IncludeInSearch]
        public string PrimaryLocation { get; private set; }

        [IncludeInSearch]
        public string PhoneNumber { get; private set; }

        [IncludeInSearch]
        public string Radio { get; private set; }

        [IncludeInSearch]
        public string Company { get; private set; }

        [IncludeInSearch]
        public string Description { get; private set; }

        [IncludeInSearch]
        public DateTime StartDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime EndDateTime { get; private set; }

        [IncludeInSearch]
        public CardEntryStatus CardEntryStatus { get; set; }

        [IncludeInSearch]
        public string Shifts
        {
            get
            {
                if (isDayShift && isNightShift)
                    return "Day/Night";
                return isDayShift ? "Day" : "Night";
            }
        }
    }
}