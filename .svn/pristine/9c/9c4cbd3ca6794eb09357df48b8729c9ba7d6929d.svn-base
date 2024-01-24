using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetAlertStatus : SortableSimpleDomainObject
    {
        public static readonly TargetAlertStatus NeverToExceedAlert = new TargetAlertStatus(3, 1);
        public static readonly TargetAlertStatus StandardAlert = new TargetAlertStatus(0, 2);
        public static readonly TargetAlertStatus Acknowledged = new TargetAlertStatus(1, 3);
        public static readonly TargetAlertStatus Closed = new TargetAlertStatus(2, 4);
        public static readonly TargetAlertStatus Cleared = new TargetAlertStatus(4, 5);

        public static readonly TargetAlertStatus Unknown = new TargetAlertStatus(5, 6);

        private static readonly TargetAlertStatus[] all =
        {
            NeverToExceedAlert,
            StandardAlert,
            Acknowledged,
            Closed,
            Cleared,
            Unknown
        };

        private static readonly TargetAlertStatus[] allNeedingAttention =
        {
            NeverToExceedAlert,
            StandardAlert,
            Acknowledged
        };

        private static readonly TargetAlertStatus[] allForDisplayPriority =
        {
            NeverToExceedAlert,
            StandardAlert
        };

        private TargetAlertStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public static List<TargetAlertStatus> AllNeedingAttention
        {
            get { return new List<TargetAlertStatus>(allNeedingAttention); }
        }

        public static List<TargetAlertStatus> AllForPriorityDisplay
        {
            get { return new List<TargetAlertStatus>(allForDisplayPriority); }
        }

        public static List<TargetAlertStatus> All
        {
            get { return new List<TargetAlertStatus>(all); }
        }

        public override string GetName()
        {
            if (IdValue == 3)
            {
                return StringResources.TargetAlertStatus_NeverToExceedAlert;
            }
            if (IdValue == 0)
            {
                return StringResources.TargetAlertStatus_StandardAlert;
            }
            if (IdValue == 1)
            {
                return StringResources.TargetAlertStatus_Acknowledged;
            }
            if (IdValue == 2)
            {
                return StringResources.TargetAlertStatus_Closed;
            }
            if (IdValue == 4)
            {
                return StringResources.TargetAlertStatus_Cleared;
            }
            if (IdValue == 5)
            {
                return StringResources.TargetAlertStatus_Unknown;
            }
            return null;
        }

        public static TargetAlertStatus Get(long id)
        {
            return GetById(id, all);
        }
    }
}