using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMudsType : SortableSimpleDomainObject
    {
        //public static WorkPermitMudsType COLD = new WorkPermitMudsType(1, 1); //Permis à froid
        public static WorkPermitMudsType ELEVATED_HOT = new WorkPermitMudsType(1, 1); //Permis à risque élevé
        public static WorkPermitMudsType MODERATE_HOT = new WorkPermitMudsType(2, 2); //Permis à risque modéré

        public static WorkPermitMudsType[] All =
        {
           MODERATE_HOT, ELEVATED_HOT
        };

        public static WorkPermitMudsType[] PERMIT_REQUEST_TYPES =
        {
             MODERATE_HOT, ELEVATED_HOT
        };

        public static WorkPermitMudsType[] DURATION_PERMIT_TYPES = {};

        public static WorkPermitMudsType NULL = new WorkPermitMudsType(0, 0);

        private WorkPermitMudsType(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            //if (IdValue == 1)
            //{
            //    return StringResources.WorkPermitCold;
            //}
            if (IdValue == 1)
            {
                return StringResources.WorkPermitMudsElevatedHot;
            }
            if (IdValue == 2)
            {
                return StringResources.WorkPermitMudsModerdateHot;
            }
            return string.Empty;
        }

        public static WorkPermitMudsType Get(long index)
        {
            return GetById(index, All);
        }
    }
}