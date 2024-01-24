using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertDefinitionStatus : SortableSimpleDomainObject
    {
        public static LabAlertDefinitionStatus Valid = new LabAlertDefinitionStatus(1, 1);
        public static LabAlertDefinitionStatus InvalidTag = new LabAlertDefinitionStatus(2, 2);

        private static readonly LabAlertDefinitionStatus[] all = {Valid, InvalidTag};

        private LabAlertDefinitionStatus(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.LabAlertDefinitionStatusValid;
            }
            if (IdValue == 2)
            {
                return StringResources.LabAlertDefinitionStatusInvalid;
            }
            return null;
        }

        public static LabAlertDefinitionStatus Get(long index)
        {
            return GetById(index, all);
        }
    }
}