using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormSarniaOP14DTO : FormSarniaDTO
    {
        public FormSarniaOP14DTO(long id, List<string> functionalLocations, string criticalSystemDefeated,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals)
            : base(
                id, functionalLocations, EdmontonFormType.OP14, createdByUserId, createdByFullNameWithUserName,
                createdDateTime, lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            CriticalSystemDefeated = criticalSystemDefeated;
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

        public string CriticalSystemDefeated { get; private set; }

        private static List<string> GetApprovers(FormOP14 formOp14)
        {
            return formOp14.IsApproved()
                ? new List<string>()
                : new List<string>
                {
                    formOp14.AllApprovals.ConvertAll(input => input.Approver).First()
                };
        }
    }
}