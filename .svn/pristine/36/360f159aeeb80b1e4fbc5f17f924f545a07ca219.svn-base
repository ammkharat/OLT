using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class WorkPermitSafetyFormState : SimpleDomainObject
    {
        public static readonly WorkPermitSafetyFormState NotApplicable = new WorkPermitSafetyFormState(1);
        public static readonly WorkPermitSafetyFormState Approved = new WorkPermitSafetyFormState(2);
        public static readonly WorkPermitSafetyFormState Required = new WorkPermitSafetyFormState(3);

        private static readonly WorkPermitSafetyFormState[] All = {NotApplicable, Approved, Required};

        private WorkPermitSafetyFormState(int id) : base(id)
        {
        }

        public static List<WorkPermitSafetyFormState> AllValues
        {
            get { return new List<WorkPermitSafetyFormState>(All); }
        }

        public override string GetName()
        {
            if (IdValue == 1) return StringResources.WorkPermitSafetyFormState_NA;
            if (IdValue == 2) return StringResources.WorkPermitSafetyFormState_Approved;
            if (IdValue == 3) return StringResources.WorkPermitSafetyFormState_Required;

            return null;
        }

        public static WorkPermitSafetyFormState GetById(long id)
        {
            return GetById(id, All);
        }
    }
}