using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class CauseDeterminationWhyType : SimpleDomainObject
    {
        public static readonly CauseDeterminationWhyType DocumentIncorrect = new CauseDeterminationWhyType(1);
        public static readonly CauseDeterminationWhyType EquipmentMalfunction = new CauseDeterminationWhyType(2);
        public static readonly CauseDeterminationWhyType UnexpectedConditions = new CauseDeterminationWhyType(3);
        public static readonly CauseDeterminationWhyType Other = new CauseDeterminationWhyType(4);

        private static readonly CauseDeterminationWhyType[] All =
        {
            DocumentIncorrect, EquipmentMalfunction, UnexpectedConditions, Other
        };

        private CauseDeterminationWhyType(long id)
            : base(id)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.DocumentIncorrectCauseDeterminationWhyType;
            }
            if (IdValue == 2)
            {
                return StringResources.EquipmentMalfunctionCauseDeterminationWhyType;
            }
            if (IdValue == 3)
            {
                return StringResources.UnexpectedConditionsCauseDeterminationWhyType;
            }
            if (IdValue == 4)
            {
                return StringResources.OtherCauseDeterminationWhyType;
            }

            return null;
        }

        public string GetCategoryName()
        {
            if (IdValue == 1)
            {
                return StringResources.DocumentIncorrectCauseDeterminationWhyTypeCategory;
            }
            if (IdValue == 2)
            {
                return StringResources.EquipmentMalfunctionCauseDeterminationWhyTypeCategory;
            }
            if (IdValue == 3)
            {
                return StringResources.UnexpectedConditionsCauseDeterminationWhyTypeCategory;
            }
            if (IdValue == 4)
            {
                return StringResources.OtherCauseDeterminationWhyTypeCategory;
            }

            return null;
        }

        public static CauseDeterminationWhyType GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((CauseDeterminationWhyType) obj).id == id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(CauseDeterminationWhyType x, CauseDeterminationWhyType y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(CauseDeterminationWhyType x, CauseDeterminationWhyType y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}