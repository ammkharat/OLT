using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Priority : SortableSimpleDomainObject
    {
        public static readonly Priority Normal = new Priority(1, 4);
        public static readonly Priority Elevated = new Priority(2, 3);
        public static readonly Priority High = new Priority(3, 2);
        public static readonly Priority CriticalPath = new Priority(4, 1);

        private static readonly Priority[] All = {Normal, Elevated, High, CriticalPath};

        public Priority(long id, int displayPriority) : base(id, displayPriority)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.Priority_Normal;
            }
            if (IdValue == 2)
            {
                return StringResources.Priority_Elevated;
            }
            if (IdValue == 3)
            {
                return StringResources.Priority_High;
            }
            if (IdValue == 4)
            {
                return StringResources.Priority_CriticalPath;
            }
            return null;
        }

        public static Priority GetById(long priorityId)
        {
            return GetById(priorityId, All);
        }
    }
}