using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class LubesAlarmDisableFormDTO : FormEdmontonDTO
    {
        public LubesAlarmDisableFormDTO(long id, string functionalLocationName, string alarm,
            long createdByUserId, string createdByFullNameWithUserName, DateTime createdDateTime,
            long lastModifiedByUserId, DateTime validFrom, DateTime validTo, FormStatus formStatus,
            DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals, bool hasBeenApproved,
            string lastModifiedBy, string criticality, string sapNotification)
            : base(
                id, new List<string> {functionalLocationName}, EdmontonFormType.LubesAlarmDisable, createdByUserId,
                createdByFullNameWithUserName,
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            HasBeenApproved = hasBeenApproved;
            LastModifiedBy = lastModifiedBy;
            Alarm = alarm;
            Criticality = criticality;
            SapNotification = sapNotification;
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
        public string Alarm { get; private set; }

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
        public string Criticality { get; set; }

        [IncludeInSearch]
        public string SapNotification { get; set; }

        public bool CanBeClosed
        {
            get { return Status != FormStatus.Closed; }
        }

        private static List<string> GetApprovers(LubesAlarmDisableForm lubesAlarmDisableForm)
        {
            return lubesAlarmDisableForm.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    lubesAlarmDisableForm.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }
    }
}