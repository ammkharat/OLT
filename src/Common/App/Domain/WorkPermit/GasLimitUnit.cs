using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class GasLimitUnit : DomainObject
    {
        public static readonly GasLimitUnit UNKNOWN = new GasLimitUnit(null, "Unknown",
            new GasLimitRange(GasLimitRange.DEFAULT_LOWER_BOUND, double.MaxValue));

        public static readonly GasLimitUnit PERCENTAGE = new GasLimitUnit(1, "%", new GasLimitRange(0, 100));

        public static readonly GasLimitUnit PARTS_PER_MILLION = new GasLimitUnit(2, "PPM",
            new GasLimitRange(GasLimitRange.DEFAULT_LOWER_BOUND, double.MaxValue));

        public static readonly GasLimitUnit PARTS_PER_BILLION = new GasLimitUnit(3, "PPB",
            new GasLimitRange(0, double.MaxValue));

        public static GasLimitUnit[] ALL =
        {
            UNKNOWN, PERCENTAGE,
            PARTS_PER_MILLION,
            PARTS_PER_BILLION
        };

        private readonly GasLimitRange legalRange;
        private readonly string unit = string.Empty;

        private GasLimitUnit(long? id, string unit, GasLimitRange legalRange)
        {
            this.id = id;
            this.unit = unit;
            this.legalRange = legalRange;
        }

        public string UnitName
        {
            get { return unit; }
        }

        public static GasLimitUnit QueryById(long? id)
        {
            foreach (var unit in ALL)
            {
                if (unit.id == id)
                    return unit;
            }
            return UNKNOWN;
        }

        public static GasLimitUnit QueryByName(string unitName)
        {
            foreach (var unit in ALL)
            {
                if (unit.UnitName == unitName)
                    return unit;
            }
            throw new ArgumentException();
        }

        public override string ToString()
        {
            return UnitName;
        }

        public bool IsWithinRange(GasLimitRange gasRange, out string errorMessage)
        {
            var message = string.Format(StringResources.GasLimitUnit_OutOfRange, legalRange);

            errorMessage = IsWithinRange(gasRange) ? string.Empty : message;
            return errorMessage.IsNullOrEmptyOrWhitespace();
        }

        private bool IsWithinRange(GasLimitRange gasRange)
        {
            if (gasRange == null || gasRange.Equals(GasLimitRange.EmptyLimitRange))
                return true;

            return legalRange.ContainsInclusive(gasRange);
        }
    }
}