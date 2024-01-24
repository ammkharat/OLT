using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class OperationalMode : SortableSimpleDomainObject
    {
        public static readonly OperationalMode Normal = new OperationalMode(0, 0);
        public static readonly OperationalMode Constrained = new OperationalMode(1, 1);
        public static readonly OperationalMode ShutDown = new OperationalMode(2, 2);

        public static readonly OperationalMode[] All = {Normal, Constrained, ShutDown};

        private OperationalMode(long id, int displayPriority) : base(id, displayPriority)
        {
        }

        public static IList<OperationalMode> AllList
        {
            get { return All; }
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.OperationalMode_Normal;
            }
            if (IdValue == 1)
            {
                return StringResources.OperationalMode_Constrained;
            }
            if (IdValue == 2)
            {
                return StringResources.OperationalMode_ShutDown;
            }
            return null;
        }

        public static OperationalMode GetById(long id)
        {
            var result = GetById(id, All);

            if (result != null)
                return result;

            throw new ApplicationException("Functional Location Operational Mode ID does not exist in application");
        }
    }
}