using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertStatus : SortableSimpleDomainObject
    {
        public static readonly LabAlertStatus DataUnavailableLate = new LabAlertStatus(10, 0);
        public static readonly LabAlertStatus NotRespondedLate = new LabAlertStatus(11, 1);
        public static readonly LabAlertStatus DataUnavailable = new LabAlertStatus(0, 2);
        public static readonly LabAlertStatus NotResponded = new LabAlertStatus(1, 3);
        public static readonly LabAlertStatus Responded = new LabAlertStatus(2, 4);

        public static LabAlertStatus[] All =
        {
            DataUnavailableLate, NotRespondedLate, DataUnavailable, NotResponded,
            Responded
        };

        public static LabAlertStatus[] AllForResponding = {NotResponded, Responded};

        public static LabAlertStatus[] AllForPriorityDisplay =
        {
            DataUnavailableLate, NotRespondedLate, DataUnavailable,
            NotResponded
        };

        private LabAlertStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 10)
            {
                return StringResources.LabAlertStatus_DataUnavailableLate;
            }
            if (IdValue == 11)
            {
                return StringResources.LabAlertStatus_NotRespondedLate;
            }
            if (IdValue == 0)
            {
                return StringResources.LabAlertStatus_DataUnavailable;
            }
            if (IdValue == 1)
            {
                return StringResources.LabAlertStatus_NotResponded;
            }
            if (IdValue == 2)
            {
                return StringResources.LabAlertStatus_Responded;
            }
            return null;
        }

        public static LabAlertStatus Get(long id)
        {
            return Array.Find(All, obj => obj.id == id);
        }
    }
}