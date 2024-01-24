using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class DeviationAlertStatus : SortableSimpleDomainObject
    {
        public static readonly DeviationAlertStatus RequiresResponseIsLate = new DeviationAlertStatus(0, 0);
        public static readonly DeviationAlertStatus RequiresResponse = new DeviationAlertStatus(1, 1);
        public static readonly DeviationAlertStatus Responded = new DeviationAlertStatus(2, 2);

        public static readonly DeviationAlertStatus AutomaticallyRespondedForPositiveDeviation =
            new DeviationAlertStatus(3, 3);

        public static readonly DeviationAlertStatus[] All =
        {
            RequiresResponseIsLate, RequiresResponse, Responded,
            AutomaticallyRespondedForPositiveDeviation
        };

        private DeviationAlertStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.DeviationAlertStatus_RequiresResponseIsLate;
            }
            if (IdValue == 1)
            {
                return StringResources.DeviationAlertStatus_RequiresResponse;
            }
            if (IdValue == 2)
            {
                return StringResources.DeviationAlertStatus_Responded;
            }
            if (IdValue == 3)
            {
                return StringResources.DeviationAlertStatus_AutomaticallyRespondedForPositiveDeviation;
            }
            return null;
        }
    }
}