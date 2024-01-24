using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ConfinedSpaceMudsDTO : DomainObject, IHasStatus<ConfinedSpaceStatusMuds>
    {
        public ConfinedSpaceMudsDTO(long id, long confinedSpaceNumber, string functionalLocationName, DateTime startDateTime,
            long createdByUserId,
            string lastModifiedByFullnameWithUserName, long confinedSpaceStatusId)

        {
            Id = id;
            ConfinedSpaceNumber = confinedSpaceNumber;
            FunctionalLocationName = functionalLocationName;
            StartDateTime = startDateTime;
            CreatedByUserId = createdByUserId;
            LastModifiedByFullnameWithUserName = lastModifiedByFullnameWithUserName;
            ConfinedSpaceStatusId = confinedSpaceStatusId;
        }

        public ConfinedSpaceMudsDTO(ConfinedSpaceMuds confinedSpace)
            : this(
            confinedSpace.IdValue,
            confinedSpace.ConfinedSpaceNumber.Value,
            confinedSpace.FunctionalLocation.FullHierarchy,
            confinedSpace.StartDateTime,
            confinedSpace.CreatedBy.IdValue,
            confinedSpace.LastModifiedBy.FullNameWithUserName,
            confinedSpace.ConfinedSpaceStatus.IdValue)
        {
        }

        public long ConfinedSpaceNumber { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationName { get; private set; }

        [IncludeInSearch]
        public DateTime StartDateTime { get; private set; }

        public long CreatedByUserId { get; private set; }

        [IncludeInSearch]
        public string LastModifiedByFullnameWithUserName { get; private set; }

        public long ConfinedSpaceStatusId { get; private set; }

        // Used by grid renderer
        [IncludeInSearch]
        public string ConfinedSpaceNumberDisplayValue
        {
            get { return "EC " + ConfinedSpaceNumber; }
        }

        [IncludeInSearch]
        public ConfinedSpaceStatusMuds Status
        {
            get { return ConfinedSpaceStatusMuds.Get(ConfinedSpaceStatusId); }
        }
    }
}