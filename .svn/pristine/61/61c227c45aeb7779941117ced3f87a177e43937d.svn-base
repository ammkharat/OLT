using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class OperatingProcedureLevel : SimpleDomainObject
    {
        public static readonly OperatingProcedureLevel Level1 = new OperatingProcedureLevel(1);
        public static readonly OperatingProcedureLevel Level2 = new OperatingProcedureLevel(2);
        public static readonly OperatingProcedureLevel Level3 = new OperatingProcedureLevel(3);
        public static readonly OperatingProcedureLevel Level4 = new OperatingProcedureLevel(4);
        public static readonly OperatingProcedureLevel NotYetDetermined = new OperatingProcedureLevel(5);

        public static readonly OperatingProcedureLevel[] All =
        {
            Level1, Level2, Level3, Level4, NotYetDetermined
        };

        private OperatingProcedureLevel(long id)
            : base(id)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.Level1OperatingProcedureLevel;
            }
            if (IdValue == 2)
            {
                return StringResources.Level2OperatingProcedureLevel;
            }
            if (IdValue == 3)
            {
                return StringResources.Level3OperatingProcedureLevel;
            }
            if (IdValue == 4)
            {
                return StringResources.Level4OperatingProcedureLevel;
            }
            if (IdValue == 5)
            {
                return StringResources.NotYetDeterminedOperatingProcedureLevel;
            }

            return null;
        }

        public static OperatingProcedureLevel GetById(int id)
        {
            return GetById(id, All);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(OperatingProcedureLevel x, OperatingProcedureLevel y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(OperatingProcedureLevel x, OperatingProcedureLevel y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}