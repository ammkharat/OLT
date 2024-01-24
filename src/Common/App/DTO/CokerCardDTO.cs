using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class CokerCardDTO : DomainObject
    {
        private readonly string createdByFullnameWithUserName;
        private readonly long createdByUserId;
        private readonly DateTime createdDateTime;
        private readonly string functionalLocationName;
        private readonly string name;
        private readonly Date shiftDate;

        private readonly long shiftId;
        private readonly string shiftName;
        private readonly string workAssignmentName;

        public CokerCardDTO(CokerCard card) : this(
            card.IdValue,
            card.ConfigurationName,
            card.FunctionalLocation.FullHierarchy,
            card.WorkAssignment != null ? card.WorkAssignment.Name : null,
            card.Shift.IdValue,
            card.Shift.Name,
            GetCreateUserShift(card).StartDate,
            card.CreatedBy.IdValue,
            card.CreatedBy.FullNameWithUserName,
            card.CreatedDateTime)
        {
        }

        public CokerCardDTO(
            long id,
            string name,
            string functionalLocationName,
            string workAssignmentName,
            long shiftId,
            string shiftName,
            Date shiftDate,
            long createdByUserId,
            string createdByFullnameWithUserName,
            DateTime createdDateTime)
        {
            this.id = id;
            this.name = name;
            this.functionalLocationName = functionalLocationName;
            this.workAssignmentName = workAssignmentName;

            this.shiftId = shiftId;
            this.shiftName = shiftName;
            this.shiftDate = shiftDate;

            this.createdByUserId = createdByUserId;
            this.createdByFullnameWithUserName = createdByFullnameWithUserName;
            this.createdDateTime = createdDateTime;
        }

        [IncludeInSearch]
        public string Name
        {
            get { return name; }
        }

        [IncludeInSearch]
        public string FunctionalLocationName
        {
            get { return functionalLocationName; }
        }

        [IncludeInSearch]
        public string WorkAssignmentName
        {
            get { return workAssignmentName; }
        }

        public long ShiftId
        {
            get { return shiftId; }
        }

        public Date ShiftDate
        {
            get { return shiftDate; }
        }

        [IncludeInSearch]
        public string Shift
        {
            get { return String.Format("{0} - {1}", shiftDate, shiftName); }
        }

        public long CreatedByUserId
        {
            get { return createdByUserId; }
        }

        [IncludeInSearch]
        public string CreatedByFullnameWithUserName
        {
            get { return createdByFullnameWithUserName; }
        }

        [IncludeInSearch]
        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        private static UserShift GetCreateUserShift(CokerCard card)
        {
            return new UserShift(card.Shift, card.CreatedDateTime);
        }
    }
}