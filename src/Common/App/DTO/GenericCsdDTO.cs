using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class GenericCsdDTO : FormEdmontonDTO
    {
        public GenericCsdDTO(long id, List<string> functionalLocations, string criticalSystemDefeated,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals,
            string lastModifiedBy, bool hasBeenApproved)
            : base(
                id, functionalLocations, EdmontonFormType.MontrealCsd, createdByUserId, createdByFullNameWithUserName,
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            CriticalSystemDefeated = criticalSystemDefeated;
            HasBeenApproved = hasBeenApproved;

            LastModifiedBy = lastModifiedBy;
        }

        public bool HasBeenApproved { get; set; }

        public bool CanBeClosed
        {
            get { return Status != FormStatus.Closed; }
        }

        public string ClosedBy
        {
            get
            {
                return
                    ClosedDateTime != null ? LastModifiedBy : string.Empty;
            }
        }

        public override FormStatus Status
        {
            get
            {
                // MS: 3664 - Ayman
                if (base.RemainingApprovalsString.ToLower().StartsWith("directeur") && base.ValidFrom <= Clock.Now && base.ValidFrom.AddDays(5) <= Clock.Now && base.Status != FormStatus.Closed && base.ValidTo >= Clock.Now)
                    return FormStatus.Draft;
                else if (base.RemainingApprovalsString.ToLower().StartsWith("directeur") && base.ValidFrom <= Clock.Now && base.ValidFrom.AddDays(5) <= Clock.Now && base.ValidTo < Clock.Now && base.Status != FormStatus.Closed)
                    return FormStatus.Expired;
                else if (base.RemainingApprovalsString.ToLower().StartsWith("directeur") && base.ValidFrom <= Clock.Now && base.ValidFrom.AddDays(5) >= Clock.Now && base.ValidTo > Clock.Now && base.Status != FormStatus.Closed)
                    return FormStatus.Approved;
                else if (base.RemainingApprovalsString.ToLower().StartsWith("directeur") && base.Status == FormStatus.Closed)
                    return FormStatus.Closed;

                if (base.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && base.ValidFrom <= Clock.Now && base.ValidFrom.AddDays(3) <= Clock.Now && base.Status != FormStatus.Closed && base.ValidTo >= Clock.Now)
                    return FormStatus.Draft;
                else if (base.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && base.ValidFrom <= Clock.Now && base.ValidFrom.AddDays(3) <= Clock.Now && base.ValidTo < Clock.Now && base.Status != FormStatus.Closed)
                    return FormStatus.Expired;
                else if (base.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && base.ValidFrom <= Clock.Now && base.ValidFrom.AddDays(3) >= Clock.Now && base.ValidTo > Clock.Now && base.Status != FormStatus.Closed)
                    return FormStatus.Approved;
                else if (base.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && base.Status == FormStatus.Closed)
                    return FormStatus.Closed;
                else if ((base.Status == FormStatus.Closed) && (!base.RemainingApprovalsString.ToLower().StartsWith("directeur") && !base.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && base.ValidTo < Clock.Now))
                    return FormStatus.Closed;
                else if ((base.Status == FormStatus.Approved || base.Status == FormStatus.Draft) && (Clock.Now > base.ValidTo))
                    return FormStatus.Expired;
                return base.Status;
            }
        }

        public bool CanBeDeleted
        {
            get { return (!HasBeenApproved) && (Status == FormStatus.Draft || Status == FormStatus.Expired); }
        }


        [IncludeInSearch]
        public string CriticalSystemDefeated { get; private set; }

        [IncludeInSearch]
        public string LastModifiedBy { get; set; }

        private static List<string> GetApprovers(GenericCsd montrealCsd)
        {
            return montrealCsd.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    montrealCsd.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }
    }
}