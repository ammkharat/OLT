using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class LubesCsdFormDTO : FormEdmontonDTO
    {
        public LubesCsdFormDTO(long id, string functionalLocationName, string criticalSystemDefeated,
            long createdByUserId, string createdByFullNameWithUserName, DateTime createdDateTime,
            long lastModifiedByUserId, DateTime validFrom, DateTime validTo, FormStatus formStatus,
            DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals, bool hasBeenApproved,
            string lastModifiedBy, string systemDefeated)
            : base(
                id, new List<string> {functionalLocationName}, EdmontonFormType.LubesCsd, createdByUserId,
                createdByFullNameWithUserName,
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            HasBeenApproved = hasBeenApproved;
            LastModifiedBy = lastModifiedBy;
            SystemDefeated = systemDefeated;
            CriticalSystemDefeated = criticalSystemDefeated;
            FunctionalLocationName = functionalLocationName;
        }

        public override FormStatus Status
        {
            get
            {
                if ((base.Status == FormStatus.Approved || base.Status == FormStatus.Draft) &&
                    (Clock.Now > base.ValidTo))
                    return FormStatus.Expired;
                return base.Status;
            }
        }

        [IncludeInSearch]
        public string CriticalSystemDefeated { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationName { private set; get; }

        public bool CanBeDeleted
        {
            get { return (!HasBeenApproved) && (Status == FormStatus.Draft || Status == FormStatus.Expired); }
        }

        public bool HasBeenApproved { get; set; }

        [IncludeInSearch]
        public string LastModifiedBy { get; set; }

        [IncludeInSearch]
        public string SystemDefeated { get; set; }

        public bool CanBeClosed
        {
            get { return Status != FormStatus.Closed; }
        }

        private static List<string> GetApprovers(LubesCsdForm lubesCsdForm)
        {
            return lubesCsdForm.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    lubesCsdForm.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }
    }
}