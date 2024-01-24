using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class TemporaryInstallationsMudsDTO : FormEdmontonDTO
    {
        public TemporaryInstallationsMudsDTO(long id, List<string> functionalLocations, string criticalSystemDefeated,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals,
            string lastModifiedBy, bool hasBeenApproved)
            : base(
                id, functionalLocations, EdmontonFormType.TemporaryInstallationsMuds, createdByUserId, createdByFullNameWithUserName,
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
                if ((base.Status == FormStatus.Approved || base.Status == FormStatus.Draft ||
                          base.Status == FormStatus.WaitingForApproval) && 
                         (Clock.Now > base.ValidTo))
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

        private static List<string> GetApprovers(TemporaryInstallationsMUDS tempInstallationsMuds)
        {
            return tempInstallationsMuds.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    tempInstallationsMuds.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }
    }
}